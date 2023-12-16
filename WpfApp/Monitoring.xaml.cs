using Org.BouncyCastle.Utilities;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Timers;
using Timer = System.Timers.Timer;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для Monitoring.xaml
    /// </summary>
    public partial class Monitoring : Window
    {
        private DataBase _data;
        private Timer checkComponentTimer;

        private List<Machine> _machine = new List<Machine>();
        private ObservableCollection<Logs> logs = new ObservableCollection<Logs>();
        private List<double> arrTemperature = new List<double>();
        private List<double> arrTime = new List<double>();


        private double maxTemperature = 40.0;
        private double temperatureCnc;
        private double temperatureMainMotion;
        private double temperatureSpindle;
        private double time = 0;
        private bool flag = false;


        public Monitoring()
        {
            InitializeComponent();

            _data = new DataBase();
            _data.OpenConnection();
            _machine = _data.ReadValue();
            _data.CloseConnection();

            nameMachineBox.SelectedIndex = 0;            
            dateBox.Text = DateTime.Now.ToShortDateString();
            logsGrid.ItemsSource = logs;

            checkComponentTimer = new Timer(10000);  // Интервал в миллисекундах (в данном случае, 10 секунд)
            checkComponentTimer.Elapsed += OnCheckComponentTimerTick;
            checkComponentTimer.AutoReset = true;


            temperatureCnc = 2.0;
            temperatureMainMotion = 5.0;
            temperatureSpindle = 3.0;

            FillComboBox();
            UpdateTextBoxAverage(0);
            UpdateTextBoxReady("Не готов");
            UpdateTextBoxTemperature();



        }


        public void FillComboBox()
        {
            nameMachineBox.ItemsSource = _machine;
        }

        private void nameMachineBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            typeMachine.Text = _machine[nameMachineBox.SelectedIndex].type_cnc;

            UpdateImage(_machine[nameMachineBox.SelectedIndex].name);
            UpdateTextBoxAverage(0);
            UpdateTextBoxReady("Не готов");
            UpdateTextBoxTemperature();
        }

        public void UpdateImage(string imageName)
        {
            Uri src;
            BitmapImage bmp;

            switch (imageName)
            {
                case "ST-10LF":
                    src = new Uri(System.IO.Path.GetFullPath($@"..\..\Image\{imageName}.png"));
                    bmp = new BitmapImage(src);
                    imageMachine.Source = bmp;
                    break;
                case "DMTG CKE":
                    src = new Uri(System.IO.Path.GetFullPath($@"..\..\Image\{imageName}.png"));
                    bmp = new BitmapImage(src);
                    imageMachine.Source = bmp;
                    break;
                case "TL-30LLF":
                    src = new Uri(System.IO.Path.GetFullPath($@"..\..\Image\{imageName}.png"));
                    bmp = new BitmapImage(src);
                    imageMachine.Source = bmp;
                    break;

            }
        }

        private async void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            nameMachineBox.IsEnabled = false;
            btnPlay.IsEnabled = false;
            btnStop.IsEnabled = true;
            flag = true;
            checkComponentTimer.Enabled = true;

            WpfPlot1.Reset();

            UpdateGrid(msg: "Запуск", nameMachine: _machine[nameMachineBox.SelectedIndex].name, typeError: Error.Info.ToString(),date: DateTime.Now.ToUniversalTime().ToString(), template: TemplateLogs.Start);
            
            await Task.Delay(5000);
            await Task.Run(() => Simulation());


        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            nameMachineBox.IsEnabled = true;
            btnStop.IsEnabled = false;
            btnPlay.IsEnabled = true;
            flag = false;
            checkComponentTimer.Enabled = false;

            temperatureCnc = 2.0;
            temperatureMainMotion = 5.0;
            temperatureSpindle = 3.0;

            UpdateGrid(msg: "Остановка", nameMachine: _machine[nameMachineBox.SelectedIndex].name, typeError: Error.Info.ToString(), date: DateTime.Now.ToUniversalTime().ToString(), template: TemplateLogs.Stop);
            UpdateTextBoxAverage(Math.Round(arrTemperature.Average(), 2));

            WpfPlot1.Plot.AddScatter(arrTime.ToArray(), arrTemperature.ToArray());
            WpfPlot1.Refresh();

           
            arrTemperature.Clear();
            arrTime.Clear();
            time = 0;
        }




        public void UpdateGrid(string msg, string typeError,string nameMachine,string date, TemplateLogs template)
        {
            switch (template)
            {
                case TemplateLogs.Start:
                    logs.Add(new Logs() { Date = date,Name = nameMachine, TypeError = typeError, Msg = msg, Id_machine = _machine[nameMachineBox.SelectedIndex].id });
                    break;
                case TemplateLogs.Stop:
                    logs.Add(new Logs() { Date = date, Name = nameMachine, TypeError = typeError, Msg = msg, Id_machine = _machine[nameMachineBox.SelectedIndex].id });
                    break;
                case TemplateLogs.Message:
                    logs.Add(new Logs() { Date = date, Name = nameMachine, TypeError = typeError, Msg = msg, Id_machine = _machine[nameMachineBox.SelectedIndex].id });
                    break;
            }
            
           

            
        }

        public void Simulation()
        {
            Dispatcher.Invoke(() => UpdateTextBoxReady("Готовы"));
            Random rnd = new Random();
            

            while (flag)
            {
                temperatureCnc = SimulateComponentTemperatureChange("СЧПУ", temperatureCnc);
                temperatureMainMotion = SimulateComponentTemperatureChange("Привод главного движения", temperatureMainMotion);
                temperatureSpindle = SimulateComponentTemperatureChange("Шпиндель", temperatureSpindle);

                if(temperatureMainMotion > maxTemperature || temperatureCnc > maxTemperature || temperatureSpindle > maxTemperature)
                {
                    Dispatcher.Invoke(() => UpdateGrid(msg: "Критическая температура. Выключите машину", nameMachine: _machine[nameMachineBox.SelectedIndex].name, typeError: Error.Critical.ToString(), date: DateTime.Now.ToUniversalTime().ToString(), template: TemplateLogs.Message));
                    
                    break;
                }
                Thread.Sleep(5000);
            }      


        }


        public double SimulateComponentTemperatureChange(string componentName, double temperature)
        {
            double smoothingFactor = 0.1;
            double randomChange = new Random().NextDouble() * (15 - 10) * 10;
            temperature = smoothingFactor * randomChange + (1 - smoothingFactor) * temperature;

            // Обработка критической температуры для каждого компонента
            if (temperature > GetCriticalTemperatureThreshold(componentName))
            {
                Dispatcher.Invoke(() => UpdateGrid(msg: "Критическая температура", nameMachine: componentName, typeError: Error.Critical.ToString(), date: DateTime.Now.ToUniversalTime().ToString(), template: TemplateLogs.Message));

            }
            return Math.Round(temperature, 2);
        }

        public double GetCriticalTemperatureThreshold(string componentName)
        {
            Dispatcher.Invoke(() => UpdateGrid(msg: "Температура в норме", nameMachine: componentName, typeError: Error.Info.ToString(), date: DateTime.Now.ToUniversalTime().ToString(), template: TemplateLogs.Message));
            
            switch (componentName)
            {
                case "СЧПУ":
                    return 30.0;
                case "Привод главного движения":
                    return 35.0;
                case "Шпиндель":
                    return 25.0;
                default:
                    throw new ArgumentException("Invalid component name");
            }
        }

        private void OnCheckComponentTimerTick(Object source, ElapsedEventArgs e)
        {
            time += 10;
            
            double criticalTemperatureThreshold = GetCriticalTemperatureThreshold("Привод главного движения");

            if (temperatureMainMotion > criticalTemperatureThreshold)
            {
                Dispatcher.Invoke(() => UpdateGrid(msg: "Критическая температура", nameMachine: "Привод главного движения", typeError: Error.Info.ToString(), date: DateTime.Now.ToUniversalTime().ToString(), template: TemplateLogs.Message));
            }
            arrTime.Add(time);
            arrTemperature.Add(temperatureMainMotion);
            Dispatcher.Invoke(() => UpdateTextBoxTemperature());
        }

        private void UpdateTextBoxTemperature()
        {
            textBoxCNC.Text = $"Температура СЧПУ: {temperatureCnc}";
            textBoxMainMotion.Text = $"Температура привода: {temperatureMainMotion}";
            textBoxSpindle.Text = $"Температура шпинделя: {temperatureSpindle}";
        }

        private void UpdateTextBoxReady(string text)
        {
            textBoxReadyCNC.Text = text;
            textBoxReadySpindle.Text = text;
        }

        private void UpdateTextBoxAverage(double averageTemperature)
        {
            textBoxAverageMainMotion.Text = $"Средняя температура: {averageTemperature}";
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            logsGrid.ItemsSource = logs;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            List<Logs> log = new List<Logs>();
            foreach (Logs l in logs)
            {
                if (l.Name == "СЧПУ")
                {
                    log.Add(l);
                }

            }

            logsGrid.ItemsSource = log;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            List<Logs> log = new List<Logs>();
            foreach (Logs l in logs)
            {
                if (l.Name == "Шпиндель")
                {
                    log.Add(l);
                }

            }

            logsGrid.ItemsSource = log;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            List<Logs> log = new List<Logs>();
            foreach (Logs l in logs)
            {
                if (l.Name == "Привод главного движения")
                {
                    log.Add(l);
                }

            }

            logsGrid.ItemsSource = log;
        }

        private void btnSendLog_Click(object sender, RoutedEventArgs e)
        {
            _data.OpenConnection();
            MessageBox.Show(_data.SendLog(logs));
            _data.CloseConnection();
            logs.Clear();
        }
    }
}

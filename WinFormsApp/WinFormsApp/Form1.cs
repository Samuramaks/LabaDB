namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(OpenMonitoring);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }

        public void OpenMonitoring()
        {
            Application.Run(new Monitoring());
        }

    }
}

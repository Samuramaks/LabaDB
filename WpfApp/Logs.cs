using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    internal class Logs : INotifyPropertyChanged
    {
        private string date;
        private string name;
        private string type_error;
        private string msg;
        private int id_machine;
        public string Date
        {
            get { return date; }
            set
            {
                if (date != value)
                {
                    date = value;
                    OnPropertyChanged(nameof(Date));
                }
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public string TypeError
        {
            get { return type_error; }
            set
            {
                if(type_error != value)
                {
                    type_error = value;
                    OnPropertyChanged(nameof(TypeError));
                }
            }
        }
        public string Msg
        {
            get { return msg; }
            set
            {
                if(msg != value)
                {
                    msg = value;
                    OnPropertyChanged(nameof(Msg));
                }
            }
        }
        public int Id_machine
        {
            get { return id_machine; }
            set
            {
                if (id_machine != value)
                {
                    id_machine = value;
                    OnPropertyChanged(nameof(Id_machine));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

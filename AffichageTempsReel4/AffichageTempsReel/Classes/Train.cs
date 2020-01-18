using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Train : INotifyPropertyChanged
    {

        private int _IDTrain;
        private string _Line;
        private string _Destination;
        private string _TimeOfPassage;
        private string _Stops;
        private string _Platform;

        public int id_train
        {
            get { return _IDTrain; }
            set { _IDTrain = value; OnPropertyChanged(nameof(id_train)); }
        }
        public string ligne
        {
            get { return _Line; }
            set
            {
                _Line = value; OnPropertyChanged(nameof(ligne));
            }
        }

        public string direction
        {
            get { return _Destination; }
            set
            {
                _Destination = value; OnPropertyChanged(nameof(direction));
            }
        }
        public string horaire
        {
            get { return _TimeOfPassage; }
            set { _TimeOfPassage = value; OnPropertyChanged(nameof(horaire)); }
        }
        public string info
        {
            get { return _Stops; }
            set { _Stops = value; OnPropertyChanged(nameof(info)); }
        }
        public string voie
        {
            get { return _Platform; }
            set { _Platform = value; OnPropertyChanged(nameof(voie)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

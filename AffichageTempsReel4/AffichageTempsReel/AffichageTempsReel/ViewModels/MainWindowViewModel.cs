using Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace AffichageTempsReel.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private ObservableCollection<TrainModelView> _listTrains;

        public ObservableCollection<TrainModelView> ListTrains 
        {
            get
            {
                //return _listTrains;
                var Top5Trains = _listTrains.OrderByDescending(t => t.Destination).Take(5);
                return new ObservableCollection<TrainModelView>(Top5Trains);
            }
            set
            {
                _listTrains = value;
                NotifyPropertyChanged(nameof(ListTrains));
            }
        }



        public MainWindowViewModel ()
        {
            _listTrains = new ObservableCollection<TrainModelView>();
        }

        public void AddTrain(Train train)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                this._listTrains.Add(new TrainModelView(train));
                NotifyPropertyChanged(nameof(ListTrains));
            });
        }
        /*
        public void RemoveTrain(Train train)
        {
            this.ListTrains.Remove(train);
        }
        */

    }
}

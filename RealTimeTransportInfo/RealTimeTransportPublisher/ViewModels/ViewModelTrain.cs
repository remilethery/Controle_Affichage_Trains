using ActiveMq_Utils;
using Model;
using RealTimeTransportPublisher.Commands;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RealTimeTransportPublisher
{
    class ViewModelTrain : INotifyPropertyChanged
    {
        ActivMQPublisher publisher;
        private string user = ConfigurationManager.AppSettings["ActiveMQ_user"];
        private string pwd = ConfigurationManager.AppSettings["ActiveMQ_pwd"];
        private string host = ConfigurationManager.AppSettings["ActiveMQ_host"];
        private string port = ConfigurationManager.AppSettings["ActiveMQ_port"];
        private string topic = ConfigurationManager.AppSettings["ActiveMQ_topic"];

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModelTrain()
        {

            this.infoTrain = new InfoTrain();
            publisher = new ActivMQPublisher(user, pwd, host, port, topic);
            this._commandPublisher = new CommandPublisher(envoyer_message, peut_envoyer_message);
        }


        public ICommand _commandPublisher { get; set; }

        public void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        InfoTrain _infotrain;


        public InfoTrain infoTrain
        {
            get
            {
                return this._infotrain;
            }
            set
            {
                this._infotrain = value;
                RaisePropertyChanged("infoTrain");
            }
        }
        public string ligne
        {
            get
            {
                return this.infoTrain.ligne;
            }
            set
            {
                this.infoTrain.ligne = value;
                RaisePropertyChanged("ligne");
            }
        }

        public string id_train
        {
            get
            {
                return this.infoTrain.id_train.ToString();
            }
            set
            {
                this.infoTrain.id_train = Int32.Parse(value);
                RaisePropertyChanged("id_train");
            }
        }


        public string horaire
        {
            get
            {
                return this.infoTrain.horaire;
            }
            set
            {
                this.infoTrain.horaire = value;
                RaisePropertyChanged("horaire");
            }
        }


        public string direction
        {
            get
            {
                return this.infoTrain.direction;
            }
            set
            {
                this.infoTrain.direction = value;
                RaisePropertyChanged("direction");
            }
        }

        public string voie
        {
            get
            {
                return this.infoTrain.voie;
            }
            set
            {
                this.infoTrain.voie = value;
                RaisePropertyChanged("voie");
            }
        }


        public string info
        {
            get
            {
                return this.infoTrain.info;
            }
            set
            {
                this.infoTrain.info = value;
                RaisePropertyChanged("info");
            }
        }

        public bool peut_envoyer_message(object parameter)
        {
            return (this.horaire != null && this.horaire.Trim() != "");
        }

        public void envoyer_message(object parameter)
        {
            string msg = SerialisationTool.serialiser((InfoTrain)parameter);
            publisher.sendMsg(msg);
        }

    }
}

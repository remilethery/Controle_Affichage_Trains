using ActiveMq_Utils;
using AffichageTempsReel.ViewModels;
using Classes;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AffichageTempsReel
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private string user = ConfigurationManager.AppSettings["ActiveMQ_user"];
        private string pwd = ConfigurationManager.AppSettings["ActiveMQ_pwd"];
        private string host = ConfigurationManager.AppSettings["ActiveMQ_host"];
        private string port = ConfigurationManager.AppSettings["ActiveMQ_port"];
        private string topic = ConfigurationManager.AppSettings["ActiveMQ_topic"];

        private MainWindowViewModel viewModel;

        ActivMQListner listner;

        public MainWindow()
        {
            InitializeComponent();
            /*
            Train myTrain1 = new Train();
            // myTrain1.Destination = "Bourg la Run";
            myTrain1.Line = "5";
            myTrain1.Platform = "E";
            myTrain1.IDTrain = "4568";
            myTrain1.TimeOfPassage = "16:20";
            myTrain1.Stops = "Seine Saint Denis Style Sors doonc ton gilet Pare balle" ;


            Train myTrain2 = new Train();
            myTrain2.Destination = "Bourg la Reum";
            myTrain2.Line = "6";
            myTrain2.Platform = "E";
            myTrain2.IDTrain = "4568";
            myTrain2.TimeOfPassage = "15:20";
            myTrain2.Stops = "A base de POPOPOPOP" ;

            ObservableCollection<Train> listTrains = new ObservableCollection<Train>();
            listTrains.Add(myTrain1);
            listTrains.Add(myTrain2);
            */

            viewModel = new MainWindowViewModel();
            this.DataContext = viewModel;

            listner = new ActivMQListner(user, pwd, host, port, topic);
            listner.eventMsg += Listner_eventMsg;

            Thread thread = new Thread(listenMsg);
            thread.Start();
        }

        public void listenMsg()
        {
            listner.start();
        }

        public void Listner_eventMsg(ActivMQListner l, Apache.NMS.ITextMessage msg)
        {
            //Console.WriteLine(msg.Text);
            //viewModel.ListTrains[0].Destination = msg.Text;

            // Désérialiser => Récupérer dans un objet train dans le mainviewmodel
            Train myTrain = SerialisationTool.deserialiser(msg.Text);
            // L'envoyer dans le MainViewModel avec la fonction Add
            Console.WriteLine(msg.Text);

            viewModel.AddTrain(myTrain);

        }
    }
}

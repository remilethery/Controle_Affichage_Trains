using ActiveMq_Utils;
using System;
using System.Collections.Generic;
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
using Apache.NMS;
using System.Configuration;
using System.Configuration;
using Model;
using Services;
using System.IO;

namespace RealTimeTransportInfo
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string user = ConfigurationManager.AppSettings["ActiveMQ_user"];
        private string pwd =  ConfigurationManager.AppSettings["ActiveMQ_pwd"];
        private string host = ConfigurationManager.AppSettings["ActiveMQ_host"];
        private string port = ConfigurationManager.AppSettings["ActiveMQ_port"];
        private string topic =ConfigurationManager.AppSettings["ActiveMQ_topic"];
        ActivMQListner listner;

        public MainWindow()
        {
             
            InitializeComponent();
            listner = new ActivMQListner(user, pwd, host, port, topic);
            listner.eventMsg += this.Listner_eventMsg;
            
            Thread th = new Thread(listenMsg);
            th.Start();
        }
        InfoTrain infoTrain;
        private void Listner_eventMsg(ActivMQListner l, ITextMessage msg)
        {
            Console.WriteLine(msg.Text);
            string path = Directory.GetCurrentDirectory();
            infoTrain = SerialisationTool.deserialiser(msg.Text);
            Dispatcher.Invoke(() =>
            {
                this.uc_1.info = infoTrain.info;
                //this.uc_1.lbl_horaire_ligne.Content = infoTrain.horaire.ToString();
                this.uc_1.lbl_id_ligne.Content = infoTrain.id_train;
                this.uc_1.lbl_direction.Content = infoTrain.direction;
                this.uc_1.lbl_voie.Content = infoTrain.voie;
            
                this.uc_1.img_ligne.Source = new BitmapImage(new Uri(path + @"\images\ligne"+ infoTrain.ligne +".png")); 
            });
        }

        public void listenMsg()
        {
            listner.start();
        }
    }
}

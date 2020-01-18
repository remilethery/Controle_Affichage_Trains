using Model;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using ActiveMq_Utils;
using System.Configuration;

namespace RealTimeTransportPublisher
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        InfoTrain infoTrain;
        ActivMQPublisher publisher;
        private string user = ConfigurationManager.AppSettings["ActiveMQ_user"];
        private string pwd = ConfigurationManager.AppSettings["ActiveMQ_pwd"];
        private string host = ConfigurationManager.AppSettings["ActiveMQ_host"];
        private string port = ConfigurationManager.AppSettings["ActiveMQ_port"];
        private string topic = ConfigurationManager.AppSettings["ActiveMQ_topic"];
        public MainWindow()
        {
            InitializeComponent();

            publisher = new ActivMQPublisher(user, pwd, host, port, topic);

        }

        private void btn_envoyer_Click(object sender, RoutedEventArgs e)
        {
            infoTrain = new InfoTrain();
            infoTrain.ligne = cmb_ligne.Text;
            infoTrain.id_train = Int32.Parse (txt_id_train.Text);
            //infoTrain.horaire = (DateTime) date_picker.SelectedDate;
            infoTrain.direction = txt_direction.Text;
            infoTrain.voie = txt_voie.Text;
            infoTrain.info = txt_info.Text;

            string msg = SerialisationTool.serialiser(infoTrain);
            publisher.sendMsg(msg);

        }
    }
}

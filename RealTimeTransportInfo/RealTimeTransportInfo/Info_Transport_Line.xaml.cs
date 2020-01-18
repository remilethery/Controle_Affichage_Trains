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

namespace RealTimeTransportInfo
{
    /// <summary>
    /// Logique d'interaction pour Info_Transport_Line.xaml
    /// </summary>
    public partial class Info_Transport_Line : UserControl
    {
        public Info_Transport_Line()
        {
            InitializeComponent();
        }

        public string info 
        { 
            get { return this.lbl_info.Content.ToString(); }
            set { this.lbl_info.Content = value; } 
        }

    }
}

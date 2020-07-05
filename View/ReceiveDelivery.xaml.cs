using BroongBroong.Data;
using BroongBroong.Model;
using BroongBroong.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

namespace BroongBroong.View
{
    /// <summary>
    /// ReceiveDelivery.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ReceiveDelivery : Page
    {
        string id;

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            id = Application.Current.Properties["ID"].ToString();
          
        }
        public ReceiveDelivery()
        {
            InitializeComponent();
            this.DataContext = new DeliveryViewModel();
            
        }
       
        private void receiveButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(
                        new Uri("/View/DriverMenu.xaml", UriKind.Relative));
        }
    }
}
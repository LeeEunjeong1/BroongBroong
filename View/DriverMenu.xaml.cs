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

namespace BroongBroong.View
{
    /// <summary>
    /// DriverMenu.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DriverMenu : Page
    {
        public DriverMenu()
        {
            InitializeComponent();
        }

        private void receiveDelivery_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(
              new Uri("/View/ReceiveDelivery.xaml", UriKind.Relative));
        }
        private void completeDelivery_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(
              new Uri("/View/CompleteDelivery.xaml", UriKind.Relative));
        }
        private void delivering_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(
              new Uri("/View/Delivering.xaml", UriKind.Relative));
        }
        private void exchangeBalance_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(
              new Uri("/View/DriverBalance.xaml", UriKind.Relative));
        }

       
    }
}
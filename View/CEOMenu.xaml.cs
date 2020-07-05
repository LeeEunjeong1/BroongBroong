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

namespace BroongBroong
{
    /// <summary>
    /// CEOMenu.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CEOMenu : Page
    {
        public CEOMenu()
        {
            InitializeComponent();
        }
        string id;
       
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            id = Application.Current.Properties["ID"].ToString();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(
                new Uri("/View/RequestDelivery.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(
               new Uri("/View/CEOBalance.xaml", UriKind.Relative));

            
        }

        private void trackingButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(
              new Uri("/View/CEOTracking.xaml", UriKind.Relative));

        }
    }
}

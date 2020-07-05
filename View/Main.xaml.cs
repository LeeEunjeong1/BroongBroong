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
    /// Main.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
        }

        private void CEOButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(
                new Uri("/View/CEOLogin.xaml", UriKind.Relative) );
        }

        private void DriverButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(
                 new Uri("/View/DriverLogin.xaml", UriKind.Relative)
                 );
        }
    }
}

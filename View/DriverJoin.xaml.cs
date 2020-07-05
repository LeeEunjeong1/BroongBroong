using BroongBroong.Data;
using BroongBroong.Model;
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
    /// DriverJoin.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DriverJoin : Page
    {
        public DriverJoin()
        {
            InitializeComponent();
        }
        DataManager co = new DataManager();
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Driver driver = new Driver();
            driver.Id = id.Text;
            driver.Password = pwd.Password.ToString();
            driver.Name = name.Text;
            driver.PhoneNumber = Int32.Parse(telNumber.Text);
            driver.MainArea = mainArea.Text;

            co.Driverjoin(driver);

            NavigationService.Navigate(
                new Uri("/View/DriverLogin.xaml", UriKind.Relative));
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool check = DataManager.DriverCheckId(id.Text);
            if (check == true)
                MessageBox.Show("사용할 수 없는 Id입니다.");
            else
                MessageBox.Show("사용가능한 Id입니다.");
        }
    }
}

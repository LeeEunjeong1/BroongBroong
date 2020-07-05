
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

namespace BroongBroong
{
    /// <summary>
    /// CEOJoin.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CEOJoin : Page
    {
        public CEOJoin()
        {
            InitializeComponent();
        }
        DataManager co = new DataManager();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //DateTime? bb = null;

            CEO ceo = new CEO();
            ceo.Id = id.Text;
            ceo.Password = pwd.Password.ToString();
            ceo.StoreAddress = storeAddress.Text;
            ceo.StoreName = storeName.Text;
            ceo.StoreNumber = Int32.Parse(storeNumber.Text);
           
            co.CEOjoin(ceo);

            NavigationService.Navigate(
                new Uri("/View/CEOLogin.xaml", UriKind.Relative));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            bool check = DataManager.CheckId(id.Text);
            if (check == true)
                MessageBox.Show("사용할 수 없는 Id입니다.");
            else
                MessageBox.Show("사용가능한 Id입니다.");
        }
    }
}

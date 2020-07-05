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
    /// CEOBalance.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CEOBalance : Page
    {
        CEO ceo = new CEO();
        DataManagerCEO ceodb = new DataManagerCEO();
        public CEOBalance()
        {
            
            
            InitializeComponent();
            totalBalance.Text = ceodb.SelectCeoBalnce(id).ToString(); 
           
        }
        string id;

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            id = Application.Current.Properties["ID"].ToString();

        }

        DataManager co = new DataManager();
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
            ceo.CeoBalance = Int32.Parse(balance.Text) + ceodb.SelectCeoBalnce(id); 
            co.CeoBalanceUpdate(ceo,id);

            MessageBox.Show($"총 예치금은 {ceo.CeoBalance} 입니다.");
            NavigationService.Navigate(
                new Uri("/View/CEOMenu.xaml", UriKind.Relative));
        }
        
        
    }
}

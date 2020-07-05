using BroongBroong.Data;
using BroongBroong.ViewModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// CEOTracking.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CEOTracking : Page
    {
        
        string id;
        protected override void OnInitialized(EventArgs e)
        {
            
            base.OnInitialized(e);
            id = Application.Current.Properties["ID"].ToString();

        }
        public CEOTracking()
        {
            InitializeComponent();
            this.DataContext = new CEOViewModel();
           
        }
    }
}

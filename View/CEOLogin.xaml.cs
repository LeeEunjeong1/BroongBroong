using BroongBroong.Data;
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
    /// CEOLogin.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CEOLogin : Page
    {

        string LoginPassword;
        public static string LoginId;

        public string ReturnId()
        {
            return LoginId;
        }
        public CEOLogin()
        {
            InitializeComponent();

        }

     
        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            LoginId = id.Text;
            LoginPassword = password.Password.ToString();

            string dbpwd = DataManager.CEOlogin(LoginId);

            Application.Current.Properties["ID"] = LoginId;



            if (string.IsNullOrEmpty(LoginId) || string.IsNullOrEmpty(LoginPassword))
            {
                MessageBox.Show("아이디또는 비밀번호를 입력해주세요");

                return;
            }
            if (dbpwd == null)
            {
                MessageBox.Show("존재하지 않는 아이디입니다.");
            }
            else
            {
                if (!dbpwd.Equals(LoginPassword))
                {
                    MessageBox.Show("비밀번호가 틀립니다.");
                }
                else if (dbpwd.Equals(LoginPassword))
                {
                    NavigationService.Navigate(
                new Uri("/View/CEOMenu.xaml", UriKind.Relative));
                }
            }
        }

    }
}
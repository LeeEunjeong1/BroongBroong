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
    /// RequestDelivery.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class RequestDelivery : Page
    {
        public RequestDelivery()
        {
            InitializeComponent();
        }
        string id ;
        
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            id = Application.Current.Properties["ID"].ToString();
            
        }
       
        DataManagerCEO co = new DataManagerCEO();
        private void requestDelivery_Click(object sender, RoutedEventArgs e)
        {
             double distance = Convert.ToDouble(dist.Text);
             distance = Math.Round(distance, 0);
            int extraCharge=0;
            int totalCharge=0;
            int baseCharge = 3000;
            int tel = Int32.Parse(customerTel.Text);
            string addr = cusAddress.Text;
            string addrDtail = cusDetailAddress.Text;
            var requestTimeList = this.requestTimeList.Children;
            string selectedTime = string.Empty;

            foreach (var child in requestTimeList)
            {
                if (child is RadioButton &&
                    (child as RadioButton).IsChecked != null &&
                    (child as RadioButton).IsChecked.Value == true)
                {
                    selectedTime = (child as RadioButton).Tag.ToString();
                    break;
                }
            }

            var paymentMethodButtonList = this.paymentMethodButtonList.Children;
            var selectedPaymentMethod = string.Empty;
            foreach (var child in paymentMethodButtonList)
            {
                if (child is RadioButton &&
                    (child as RadioButton).IsChecked != null &&
                    (child as RadioButton).IsChecked.Value == true)
                {
                    selectedPaymentMethod = (child as RadioButton).Content.ToString();
                    break;
                }
            }
           

            int price = Int32.Parse(productPrice.Text);
 
            string msg = deliveryText.Text;

            string storeName = co.SelectStoreName(id);

            if (distance<=3)
            {
                switch (distance)
                {
                    case 1:

                        totalCharge = baseCharge;
                        break;
                    case 2:
                        extraCharge = 1000;
                        totalCharge = baseCharge + extraCharge;
                        break;
                    case 3:
                        extraCharge = 2000;
                        totalCharge = baseCharge + extraCharge;
                        break;
                    default:
                        return;

                }
                Delivery delivery = new Delivery();
                delivery.OrderTel = tel;
                delivery.DetailAddress = addrDtail;
                delivery.Address = addr;
                delivery.PaymentMethod = selectedPaymentMethod;
                delivery.Price = price;
                delivery.StoreName = storeName;

                delivery.Message = msg;
                delivery.DeliveryMoney = totalCharge;
                delivery.PicupreqTime = Convert.ToInt32(selectedTime);
                int ceoBalance = co.SelectCeoBalnce(id);
                CEO ceo = new CEO();
                ceo.CeoBalance = ceoBalance - totalCharge;
                co.RequestDelivery(delivery,ceo,id);

                MessageBox.Show("배송신청이 되었습니다.");
                NavigationService.Navigate(
                    new Uri("/View/CEOMenu.xaml", UriKind.Relative));


            }

            else
            {
                MessageBox.Show("배송 불가 지역입니다.");
                
            }
                
            
            
        }


    }
}

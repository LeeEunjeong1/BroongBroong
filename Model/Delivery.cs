
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace BroongBroong.Model
{
    class Delivery : Notifier
    {
        public bool IsSelected { get; set; } = false;

        private int orderNum;

        public int OrderNum
        {
            get { return orderNum; }
            set { orderNum = value;
                OnPropertyChanged("OrderNum");
            }
        }


        public DateTime? requestTime;

        public DateTime? RequestTime
        {
            get { return requestTime; }
            set
            {
                requestTime = value;
                OnPropertyChanged("RequestTime");
            }
        }
        public DateTime? completeDelTime;

        public DateTime? CompleteDelTime
        {
            get { return completeDelTime; }
            set
            {
                completeDelTime = value;
                OnPropertyChanged("CompleteDelTime");
            }
        }
        public int orderTel;

        public int OrderTel
        {
            get { return orderTel; }
            set
            {
                orderTel = value;
                OnPropertyChanged("OrderTel");
            }
        }
        public string address;

        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }
        public string detailAddress;

        public string DetailAddress
        {
            get { return detailAddress; }
            set
            {
                detailAddress = value;
                OnPropertyChanged("DetailAddress");
            }
        }
        public string paymentMethod;

        public string PaymentMethod
        {
            get { return paymentMethod; }
            set
            {
                paymentMethod = value;
                OnPropertyChanged("PaymentMethod");
            }
        }
        public int price;

        public int Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }
        public string deliveryStatus;

        public string DeliveryStatus
        {
            get { return deliveryStatus; }
            set
            {
                deliveryStatus = value;
                OnPropertyChanged("DeliveryStatus");
            }
        }
        public string driverName;

        public string DriverName
        {
            get { return driverName; }
            set
            {
                driverName = value;
                OnPropertyChanged("DriverName");
            }
        }
        public string storeName;



        public string StoreName
        {
            get { return storeName; }
            set
            {
                storeName = value;
                OnPropertyChanged("StoreName");
            }
        }
        private string message;

        public string Message
        {
            get { return message; }
            set {
                message = value;
                OnPropertyChanged("Message");
            }
        }
        private int picupreqTime;

        public int PicupreqTime
        {
            get { return picupreqTime; }
            set {
                picupreqTime = value;
                OnPropertyChanged("PicupreqTime");
            }
        }
        private int deliveryMoney;

        public int DeliveryMoney
        {
            get { return deliveryMoney; }
            set {
                deliveryMoney = value;
                OnPropertyChanged("DeliveryMoney");
            }
        }

    }
}
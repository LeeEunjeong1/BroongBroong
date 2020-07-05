using BroongBroong.Data;
using BroongBroong.Model;
using BroongBroong.View;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BroongBroong.ViewModel
{
    class DeliveryViewModel : Notifier
    {
        //session 문제
        DriverLogin driverLogin = new DriverLogin();    
        DataManagerDriver driverdb = new DataManagerDriver();
        Delivery delivery = new Delivery();
       
        //배달대기 리스트
        private ObservableCollection<Delivery> deliveries;

        public ObservableCollection<Delivery> Deliveries
        {
            get { return deliveries; }
            set { deliveries = value;
               
            }
        }
        //배달중 리스트
        private ObservableCollection<Delivery> delivering;

        public ObservableCollection<Delivery> Delivering
        {
            get { return delivering; }
            set { delivering = value;
               
            }
        }

        //배달완료 리스트
        private ObservableCollection<Delivery> completeDeliveries;

        public ObservableCollection<Delivery> CompleteDeliveries
        {
            get { return completeDeliveries; }
            set { completeDeliveries = value;
             
            }
        }

        private List<Driver> drivers;
        public List<Driver> Drivers
        {
            get { return drivers; }
            set { drivers = value;
                OnPropertyChanged("Drivers");
            }
        }
        private bool isSelected=false;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }
        public Command ReceiveCommand { get; set; }
        public Command CompleteCommand { get; set; }

        public DeliveryViewModel()
        {
            Drivers = driverdb.ListDriver();
            string mainArea=null;
            
            foreach(Driver driver in Drivers)
            {
                if(driver.Id == driverLogin.ReturnId())
                {
                    mainArea = driver.MainArea;
                    
                    Deliveries = driverdb.ListDelivery(mainArea);
        
                    Delivering = driverdb.ListDelivering(driver.Name);

                    CompleteDeliveries = driverdb.ListCompleteDelivery(driver.Name);
                }           
            }
            delivery.driverName = driverdb.SelectDriverName(driverLogin.ReturnId());           
            ReceiveCommand = new Command(ExecuteReceive);
            CompleteCommand = new Command(ExecuteComplete);
        }

        private void ExecuteReceive()
        {
            foreach (Delivery item in Deliveries)
            {
                if (item.IsSelected)
                {                   
                    driverdb.ReceiveDelivery(delivery, item.OrderNum);
                    Deliveries = driverdb.ListCompleteDelivery(item.driverName);
                }
            }
        }

        private void ExecuteComplete()
        {
            foreach (Delivery item in Delivering)
            {
                if (item.IsSelected)
                {
                    int deliveryMoney = item.DeliveryMoney;                    
                    driverdb.CompleteDelivery(driverLogin.ReturnId(), item.OrderNum, deliveryMoney);
                }
            }
        }

    }
}


using BroongBroong.Data;
using BroongBroong.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace BroongBroong.ViewModel
{
    class CEOViewModel :Notifier
    {
        //session
        CEOLogin ceoLogin = new CEOLogin();
        DataManagerCEO ceodb = new DataManagerCEO();
        Delivery delivery = new Delivery();

        //진행중 리스트
        private ObservableCollection<Delivery> deliveries;

        public ObservableCollection<Delivery> Deliveries
        {
            get { return deliveries; }
            set { deliveries = value;
                OnPropertyChanged("Deliveries");
            }
            
        }

        //진행완료 리스트
        private ObservableCollection<Delivery> completeDeliveries;

        public ObservableCollection<Delivery> CompleteDeliveries
        {
            get { return completeDeliveries; }
            set { completeDeliveries = value;
                OnPropertyChanged("CompleteDeliveries");
            }
        }

        private List<CEO> ceos;

        public List<CEO> Ceos
        {
            get { return ceos; }
            set { ceos = value;
                OnPropertyChanged("Ceos");
            }
        }
        public Command ReceiveCommand { get; set; }
        public CEOViewModel()
        {
            Ceos = ceodb.ListCEO();
            string storeName = null;

            foreach(CEO item in Ceos)
            {
                if(item.Id == ceoLogin.ReturnId())
                {
                    storeName = item.StoreName;
                }
            }

            Deliveries = ceodb.ListDelivery(storeName);
            CompleteDeliveries = ceodb.EndDelivery(storeName);

            ReceiveCommand = new Command(ExecuteReceive);
        }

        private void ExecuteReceive()
        {
            throw new NotImplementedException();
        }
    }
}
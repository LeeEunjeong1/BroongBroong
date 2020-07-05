using BroongBroong.Data;
using BroongBroong.Model;
using BroongBroong.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BroongBroong.ViewModel
{
    class DriverViewModel : Notifier
    {
        Driver driver = new Driver();
        DataManagerDriver driverdb = new DataManagerDriver();
        DriverLogin driverLogin = new DriverLogin();

        private int balance;
        public int Balance
        {
            get { return driver.DriverBalance; }
            set
            {
                driver.DriverBalance = value;
                OnPropertyChanged("Balance");
            }
        }
        private int returnBalance;

        public int ReturnBalance
        {
            get { return returnBalance; }
            set {

                returnBalance = value;
                OnPropertyChanged("ReturnBalance");
            }
        }


        private List<Driver> drivers;

        public List<Driver> Drivers
        {
            get { return drivers; }
            set {
                drivers = value;
                OnPropertyChanged("Drivers");
            }
        }

        public Command ExchangeCommand { get; set; }
        public DriverViewModel()
        {
            Drivers =  driverdb.ListDriver();            
            foreach (Driver driver in Drivers)
            {
                if (driver.Id == driverLogin.ReturnId())
                {
                   
                    Balance = driver.DriverBalance;                   
                }
            }
            ExchangeCommand = new Command(ExecuteExchange);

        }

        private void ExecuteExchange()
        {           
            Balance -= ReturnBalance;
            driverdb.ExchangeMoney(ReturnBalance, driverLogin.ReturnId());
        }
    }
}

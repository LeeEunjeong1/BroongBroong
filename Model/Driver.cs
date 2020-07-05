using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroongBroong.Model
{
    class Driver : Notifier
    {
        //public string Id { get; set; }
        //public string Password { get; set; }
        //public string Name { get; set; }
        //public int PhoneNumber { get; set; }
        //public string MainArea { get; set; }
        //public int DriverBalance { get; set; }

        private string id;

        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private int phoneNumber;

        public int PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }

        }
        private string mainArea;

        public string MainArea
        {
            get { return mainArea; }
            set
            {
                mainArea = value;
                OnPropertyChanged("MainArea");
            }
        }

        private int driverBalance;

        public int DriverBalance
        {
            get { return driverBalance; }
            set
            {
                driverBalance = value;
                OnPropertyChanged("DriverBalance");
            }
        }
    }
}
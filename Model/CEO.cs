using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroongBroong.Model
{
    class CEO : Notifier
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value;
                OnPropertyChanged("Id");
            }
        }
        
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value;
                OnPropertyChanged("Password");
            }
        }
        private string storeName;

        public string StoreName
        {
            get { return storeName; }
            set { storeName = value;
                OnPropertyChanged("StoreName");
            }
        }

        private int storeNumber;

        public int StoreNumber
        {
            get { return storeNumber; }
            set { storeNumber = value;
                OnPropertyChanged("StoreNumber");
            }
        }

        private string storeAddress;

        public string StoreAddress
        {
            get { return storeAddress; }
            set { storeAddress = value;
                OnPropertyChanged("StoreAddress");
            }
        }

        private int ceoBalance;

        public int CeoBalance
        {
            get { return ceoBalance; }
            set { ceoBalance = value;
                OnPropertyChanged("CeoBalance");
            }
        }



    }
}

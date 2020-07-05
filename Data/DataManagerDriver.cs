using BroongBroong.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BroongBroong.Data
{
    class DataManagerDriver
    {
        ObservableCollection<Delivery> deliveries = new ObservableCollection<Delivery>();
        ObservableCollection<Delivery> receivedDeliveries = new ObservableCollection<Delivery>();
        ObservableCollection<Delivery> compelteDelivereies = new ObservableCollection<Delivery>();
        List<Driver> drivers = new List<Driver>();
        
        public static string mainArea;
        public string SelectMainArea(string id)
        {
            string connectionString = "server=localhost;database=broong;uid=root;pwd=cs1234;SslMode=none";
            MySqlConnection conn = null;
            if (conn == null)
                conn = new MySqlConnection(connectionString);
            DataSet ds = new DataSet();
            string sql = "select MainArea from driver where Id='" + id + "'";
            MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
            adpt.Fill(ds, "driver");
            foreach (DataRow ceo in ds.Tables[0].Rows)
            {
                mainArea = ceo["MainArea"] as string;
            }
            return mainArea;
        }
        public List<Driver> ListDriver()
        {

            string connectionString = "server=localhost;database=broong;uid=root;pwd=cs1234;";
            MySqlConnection conn = null;
            if (conn == null) conn = new MySqlConnection(connectionString);

            DataSet ds = new DataSet();
            string sql = "SELECT * FROM driver ";
            MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);

            adpt.Fill(ds, "driver");

            //List<Driver> driverlist = new List<Driver>();
            
            foreach (DataRow driver in ds.Tables[0].Rows)
            {
                Driver d = new Driver();
                d.Id = driver["Id"] as string;
                d.MainArea = driver["MainArea"] as string;
                d.Name = driver["Name"] as string;
                d.Password = driver["Passwd"] as string;
                d.PhoneNumber = (int)driver["PhoneNumber"];
                d.DriverBalance = (int)driver["DriverBalance"];
                drivers.Add(d);
            }return drivers;
        }
        public ObservableCollection<Delivery> ListDelivery(string mainArea)
        {
            string connectionString = "server=localhost;database=broong;uid=root;pwd=cs1234;";
            MySqlConnection conn = null;
            if (conn == null) conn = new MySqlConnection(connectionString);

            DataSet ds = new DataSet();
            string sql = "SELECT * FROM delivery WHERE address = '" + mainArea + "' AND deliveryStatus ='배송대기'";
            MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);

            adpt.Fill(ds, "delivery");

            DateTime? completeDelTime = null;
            DateTime? requestTime = null;
            bool isSelected=false;
            foreach (DataRow delivery in ds.Tables[0].Rows)
            {
                if (delivery["completeDelTime"] != DBNull.Value)
                    completeDelTime = DateTime.Parse(delivery["completeDelTime"].ToString());
                if (delivery["requestTime"] != DBNull.Value)
                    requestTime = DateTime.Parse(delivery["requestTime"].ToString());
                //if (delivery["isSelected"] != DBNull.Value)
                //    isSelected = bool.Parse(delivery["isSelected"].ToString());
                Delivery d = new Delivery();
                d.Address = delivery["address"] as string;
                d.DeliveryStatus = delivery["deliveryStatus"] as string;
                d.DetailAddress = delivery["detailAddress"] as string;
                d.DriverName = delivery["driverName"] as string;
                d.OrderTel = (int)delivery["orderTel"];
                d.PaymentMethod = delivery["paymentMethod"] as string;
                d.CompleteDelTime = completeDelTime;
                d.Price = (int)delivery["price"];
                d.RequestTime = requestTime;
                d.StoreName = delivery["storeName"] as string;
                d.OrderNum = (int)delivery["orderNum"];
                d.IsSelected = isSelected;
                d.Message = delivery["message"] as string;
                d.PicupreqTime = (int)delivery["picupreqTime"];
                d.DeliveryMoney = (int)delivery["deliveryMoney"];
                deliveries.Add(d);
            }
            return deliveries;
        }
        public void ReceiveDelivery(Delivery delivery,int orderNum)
        {
            ObservableCollection<Delivery> deliverylist = new ObservableCollection<Delivery>();
            string connectionString = "server=localhost;database=broong;uid=root;pwd=cs1234;";
            MySqlConnection conn = null;
            if (conn == null)
                conn = new MySqlConnection(connectionString);
            DataSet ds = new DataSet();
            string sql1 = "update delivery set driverName='" + delivery.DriverName + "', deliveryStatus='배송중'  where orderNum= " +orderNum+ " ";
     
            MySqlDataAdapter adpt1 = new MySqlDataAdapter(sql1, conn);
            //MySqlDataAdapter adpt2 = new MySqlDataAdapter(sql2, conn);
            adpt1.Fill(ds, "delivery");
            //adpt2.Fill(ds, "delivery");
        }
        public ObservableCollection<Delivery> ListDelivering(string driverName)
        {
            string connectionString = "server=localhost;database=broong;uid=root;pwd=cs1234;";
            MySqlConnection conn = null;
            if (conn == null)
                conn = new MySqlConnection(connectionString);
            DataSet ds = new DataSet();
            string sql = "SELECT * FROM delivery WHERE driverName = '" + driverName + "' AND deliveryStatus ='배송중'";

            MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
            adpt.Fill(ds, "delivery");
            DateTime? completeDelTime = null;
            DateTime? requestTime = null;
            bool isSelected = false;
            foreach (DataRow delivery in ds.Tables[0].Rows)
            {
                if (delivery["completeDelTime"] != DBNull.Value)
                    completeDelTime = DateTime.Parse(delivery["completeDelTime"].ToString());
                if (delivery["requestTime"] != DBNull.Value)
                    requestTime = DateTime.Parse(delivery["requestTime"].ToString());
                //if (delivery["isSelected"] != DBNull.Value)
                //    isSelected = bool.Parse(delivery["isSelected"].ToString());
                Delivery d = new Delivery();
                d.Address = delivery["address"] as string;
                d.DeliveryStatus = delivery["deliveryStatus"] as string;
                d.DetailAddress = delivery["detailAddress"] as string;
                d.DriverName = delivery["driverName"] as string;
                d.OrderTel = (int)delivery["orderTel"];
                d.PaymentMethod = delivery["paymentMethod"] as string;
                d.CompleteDelTime = completeDelTime;
                d.Price = (int)delivery["price"];
                d.RequestTime = requestTime;
                d.StoreName = delivery["storeName"] as string;
                d.OrderNum = (int)delivery["orderNum"];
                d.IsSelected = isSelected;
                d.Message = delivery["message"] as string;
                d.PicupreqTime = (int)delivery["picupreqTime"];
                d.DeliveryMoney = (int)delivery["deliveryMoney"];
                receivedDeliveries.Add(d);
            }
            return receivedDeliveries;
        }
        public ObservableCollection<Delivery> ListCompleteDelivery(string driverName)
        {
            string connectionString = "server=localhost;database=broong;uid=root;pwd=cs1234;";
            MySqlConnection conn = null;
            if (conn == null)
                conn = new MySqlConnection(connectionString);
            DataSet ds = new DataSet();
            string sql = "SELECT * FROM delivery WHERE driverName = '" + driverName + "' AND deliveryStatus ='배송완료'";
            MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
            adpt.Fill(ds, "delivery");
            DateTime? completeDelTime = null;
            DateTime? requestTime = null;
            bool isSelected = false;
            foreach (DataRow delivery in ds.Tables[0].Rows)
            {
                if (delivery["completeDelTime"] != DBNull.Value)
                    completeDelTime = DateTime.Parse(delivery["completeDelTime"].ToString());
                if (delivery["requestTime"] != DBNull.Value)
                    requestTime = DateTime.Parse(delivery["requestTime"].ToString());
                //if (delivery["isSelected"] != DBNull.Value)
                //    isSelected = bool.Parse(delivery["isSelected"].ToString());
                Delivery d = new Delivery();
                d.Address = delivery["address"] as string;
                d.DeliveryStatus = delivery["deliveryStatus"] as string;
                d.DetailAddress = delivery["detailAddress"] as string;
                d.DriverName = delivery["driverName"] as string;
                d.OrderTel = (int)delivery["orderTel"];
                d.PaymentMethod = delivery["paymentMethod"] as string;
                d.CompleteDelTime = completeDelTime;
                d.Price = (int)delivery["price"];
                d.RequestTime = requestTime;
                d.StoreName = delivery["storeName"] as string;
                d.OrderNum = (int)delivery["orderNum"];
                d.IsSelected = isSelected;
                d.Message = delivery["message"] as string;
                d.PicupreqTime = (int)delivery["picupreqTime"];
                d.DeliveryMoney = (int)delivery["deliveryMoney"];
                compelteDelivereies.Add(d);
            }
            return compelteDelivereies;
        }

        public void CompleteDelivery(string driverId, int orderNum, int deliveryMoney)
        {
            ObservableCollection<Delivery> deliverylist = new ObservableCollection<Delivery>();
            string connectionString = "server=localhost;database=broong;uid=root;pwd=cs1234;";
            MySqlConnection conn = null;
            if (conn == null)
                conn = new MySqlConnection(connectionString);
            DataSet ds = new DataSet();
            string sql1 = "update delivery set deliveryStatus='배송완료', completeDelTime = Now() where orderNum = " + orderNum + "";
            string sql2 = "update driver set DriverBalance = DriverBalance +" + deliveryMoney + " where Id= '" + driverId + "'";

            MySqlDataAdapter adpt1 = new MySqlDataAdapter(sql1, conn);
            MySqlDataAdapter adpt2 = new MySqlDataAdapter(sql2, conn);
            adpt1.Fill(ds, "delivery");
            adpt2.Fill(ds, "delivery");
        }

        public static string driverName;
        public string SelectDriverName(string id)
        {
            string connectionString = "server=localhost;database=broong;uid=root;pwd=cs1234;SslMode=none";
            MySqlConnection conn = null;
            if (conn == null) conn = new MySqlConnection(connectionString);

            DataSet ds = new DataSet();

            string sql = "select Name from driver where Id='" + id + "'";

            MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
            adpt.Fill(ds, "driver");
            foreach (DataRow driver in ds.Tables[0].Rows)
            {
                driverName = driver["Name"] as string;
            }
            return driverName;
        }
        public void ExchangeMoney(int returnBalance, string driverId)
        {   
            string connectionString = "server=localhost;database=broong;uid=root;pwd=cs1234;";
            MySqlConnection conn = null;
            if (conn == null)
                conn = new MySqlConnection(connectionString);
            DataSet ds = new DataSet();     
            string sql1 = "update driver set DriverBalance = DriverBalance -"  + returnBalance + " where Id= '" + driverId + "'";

            MySqlDataAdapter adpt1 = new MySqlDataAdapter(sql1, conn);
           
            adpt1.Fill(ds, "delivery");
            
        }



    }
}

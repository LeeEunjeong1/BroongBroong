using BroongBroong.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BroongBroong.Data
{
    class DataManagerCEO
    {
        public static string storeName;
        ObservableCollection<Delivery> deliveries = new ObservableCollection<Delivery>();
        ObservableCollection<Delivery> compeleteDeliveries = new ObservableCollection<Delivery>();
        List<CEO> ceo = new List<CEO>();
        public string SelectStoreName(string id)
        {
     
            string connectionString = "server=localhost;database=broong;uid=root;pwd=cs1234;SslMode=none";
            MySqlConnection conn = null;
            if (conn == null) conn = new MySqlConnection(connectionString);

            DataSet ds = new DataSet();

            string sql = "select StoreName from ceo where Id='" + id + "'";

            MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
            adpt.Fill(ds, "ceo");
            foreach (DataRow ceo in ds.Tables[0].Rows)
            {
                storeName = ceo["StoreName"] as string;
            }
            return storeName;
        }
        public static int ceoBalance;
        public int SelectCeoBalnce(string id)
        {
            string connectionString = "server=localhost;database=broong;uid=root;pwd=cs1234;SslMode=none";
            MySqlConnection conn = null;
            if (conn == null) conn = new MySqlConnection(connectionString);

            DataSet ds = new DataSet();

            string sql = "select ceoBalance from ceo where Id='" + id + "'";

            MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
            adpt.Fill(ds, "ceo");
            foreach (DataRow ceo in ds.Tables[0].Rows)
            {
                ceoBalance = (int)ceo["ceoBalance"] ;
            }
            return ceoBalance;
        }

        public void RequestDelivery(Delivery delivery,  CEO ceo, string id)
        {
            
            string connectionString = "server=localhost;database=broong;uid=root;pwd=cs1234;";
            MySqlConnection conn = null;
            if (conn == null) conn = new MySqlConnection(connectionString);

            DataSet ds = new DataSet();
          
            string sql1 = "insert into delivery(requestTime, orderTel, address, detailAddress, paymentMethod, price, deliveryStatus, storeName,  message, picupreqTime, deliveryMoney) values(Now(), " +
                "" + delivery.OrderTel+", '"+delivery.Address+"','"+delivery.DetailAddress+"', '"+delivery.PaymentMethod+"', "+delivery.Price+",'배송대기','"+ delivery.StoreName+ "' ,'" + delivery.Message + "'," + delivery.PicupreqTime + "," + delivery.DeliveryMoney + ")";
      
            string sql2 = "update `ceo` set ceoBalance= " + ceo.CeoBalance + " where Id= '" + id + "'";

            MySqlDataAdapter adpt1 = new MySqlDataAdapter(sql1, conn);       
            MySqlDataAdapter adpt2 = new MySqlDataAdapter(sql2, conn);
            adpt1.Fill(ds, "delivery");  
            adpt2.Fill(ds, "ceo");
            
        }
        public ObservableCollection<Delivery> ListDelivery(string storeName)
        {    
            string connectionString = "server=localhost;database=broong;uid=root;pwd=cs1234;";
            MySqlConnection conn = null;
            if (conn == null)
                conn = new MySqlConnection(connectionString);
            DataSet ds = new DataSet();
            string sql = "SELECT * FROM delivery WHERE storeName = '" + storeName + "' AND deliveryStatus IN( '배송중','배송대기')";
            MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
            adpt.Fill(ds, "delivery");
        
            DateTime? completeDelTime = null;
            DateTime? requestTime = null;
            foreach (DataRow delivery in ds.Tables[0].Rows)
            {
                if (delivery["completeDelTime"] != DBNull.Value)
                    completeDelTime = DateTime.Parse(delivery["completeDelTime"].ToString());
                if (delivery["requestTime"] != DBNull.Value)
                    requestTime = DateTime.Parse(delivery["requestTime"].ToString());
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
                d.Message = delivery["message"] as string;
                d.PicupreqTime = (int)(delivery["picupreqTime"]);
                d.DeliveryMoney = (int)delivery["deliveryMoney"];
                d.OrderNum = (int)delivery["orderNum"];
                deliveries.Add(d);
            }
            return deliveries;
        }
        public ObservableCollection<Delivery> EndDelivery(string storeName)
        {
            string connectionString = "server=localhost;database=broong;uid=root;pwd=cs1234;";
            MySqlConnection conn = null;
            if (conn == null) conn = new MySqlConnection(connectionString);

            DataSet ds = new DataSet();
            string sql = "SELECT * FROM delivery WHERE storeName = '" + storeName + "' AND deliveryStatus = '배송완료'";
            MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);

            adpt.Fill(ds, "delivery");
            
            DateTime? completeDelTime = null;
            DateTime? requestTime = null;
            foreach (DataRow delivery in ds.Tables[0].Rows)
            {
                if (delivery["completeDelTime"] != DBNull.Value)
                    completeDelTime = DateTime.Parse(delivery["completeDelTime"].ToString());
                if (delivery["requestTime"] != DBNull.Value)
                    requestTime = DateTime.Parse(delivery["requestTime"].ToString());
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
                d.Message = delivery["message"] as string;
                d.PicupreqTime = (int)delivery["picupreqTime"];
                d.DeliveryMoney = (int)delivery["deliveryMoney"];
                d.OrderNum = (int)delivery["orderNum"];
                compeleteDeliveries.Add(d);

            }
            return compeleteDeliveries;
        }
        public List<CEO> ListCEO()
        {
            string connectionString = "server=localhost;database=broong;uid=root;pwd=cs1234;";
            MySqlConnection conn = null;
            if (conn == null) conn = new MySqlConnection(connectionString);

            DataSet ds = new DataSet();

            string sql = "select * from CEO";
            MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
            adpt.Fill(ds, "CEO");
            

            foreach (DataRow CEO in ds.Tables[0].Rows)
            {
                CEO e = new CEO();
               
                e.Id = CEO["Id"] as string;
                e.Password = CEO["Passwd"] as string;
                e.StoreAddress = CEO["StoreAddress"] as string;
                e.StoreName = CEO["StoreName"] as string;
                e.StoreNumber = (int)CEO["StoreTelNumber"];
                e.CeoBalance = (int)CEO["ceoBalance"];
                ceo.Add(e);
            }
            return ceo;
        }



    }
}

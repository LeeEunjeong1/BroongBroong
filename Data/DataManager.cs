using BroongBroong.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BroongBroong.Data
{
    class DataManager
    {

        public static string ceopwd;
        public static string CEOlogin(string id)
        {
             string connectionString = "server=localhost;database=broong;uid=root;pwd=cs1234;";
             MySqlConnection conn = null;
             if (conn == null) conn = new MySqlConnection(connectionString);
              
            DataSet ds = new DataSet();

            string sql = "select Passwd from CEO where Id='"+id+"'";
           
            MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
            adpt.Fill(ds, "CEO");
            foreach (DataRow CEO in ds.Tables[0].Rows)
            {
                ceopwd = CEO["Passwd"] as string;
            }
            return ceopwd;
        }
        public static void InsertId(string id)
        {
            string connectionString = "server=localhost;database=broong;uid=root;pwd=cs1234;";
            MySqlConnection conn = null;
            if (conn == null) conn = new MySqlConnection(connectionString);

            DataSet ds = new DataSet();
            string sql = "insert into id(id) values('" + id + "')";

            MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
            adpt.Fill(ds, "id");

        }
        
        public void CEOjoin(CEO ceo)
        {
            string connectionString = "server=localhost;database=broong;uid=root;pwd=cs1234;";
            MySqlConnection conn = null;
            if (conn == null) conn = new MySqlConnection(connectionString);

            DataSet ds = new DataSet();
            string sql = "insert into ceo(Id, Passwd, StoreName, StoreTelnumber, StoreAddress) values('"+ceo.Id+"','"+ceo.Password+"','"+ceo.StoreName+"',"+ceo.StoreNumber+",'"+ceo.StoreAddress+"')";

            MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
            adpt.Fill(ds, "CEO");

        }

        public void CeoBalanceUpdate(CEO ceo, string id)
        {
            string connectionString = "server=localhost;database=broong;uid=root;pwd=cs1234;";
            MySqlConnection conn = null;
            if (conn == null) conn = new MySqlConnection(connectionString);

            DataSet ds = new DataSet();
        
            string sql = "update `ceo` set ceoBalance=" + ceo.CeoBalance + " where Id = '"+id+"' ";

            MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
            adpt.Fill(ds, "ceo");
        }
        
        static public bool CheckId(string id)
        {
            bool success = false;
            string connectionString = "server=localhost;database=broong;uid=root;pwd=cs1234;";
            MySqlConnection conn = null;
            if (conn == null)
                conn = new MySqlConnection(connectionString);
            string sql = "select * from CEO where Id='" + id + "'";
            DataSet ds = new DataSet();

            MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
            adpt.Fill(ds, "CEO");

            foreach (DataRow CEO in ds.Tables[0].Rows)
            {
                success = true;
            }
            return success;
        }
        public List<CEO> Select()
        {
            string connectionString = "server=localhost;database=broong;uid=root;pwd=cs1234;";
            MySqlConnection conn = null;
            if (conn == null) conn = new MySqlConnection(connectionString);

            DataSet ds = new DataSet();

            string sql = "select * from CEO";
            MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
            adpt.Fill(ds, "CEO");

            List<CEO> ceo = new List<CEO>();
            DateTime? bb = null;
            foreach(DataRow CEO in ds.Tables[0].Rows)
            {
                CEO e = new CEO();
                if (CEO["RequestedTime"] != DBNull.Value)
                    bb = DateTime.Parse(CEO["RequestedTime"].ToString());
                e.Id = CEO["Id"] as string;
                e.Password = CEO["Passwd"] as string;
                e.StoreAddress = CEO["StoreAddress"] as string;
                e.StoreName = CEO["StoreName"] as string;
                e.StoreNumber = (int)CEO["StoreNumber"];
                e.CeoBalance = (int)CEO["ceoBalance"];
               
            }
            return ceo;
        }

        public static string driverpwd;
        public static string Driverlogin(string id)
        {
            string connectionString = "server=localhost;database=broong;uid=root;pwd=cs1234;SslMode=none";
            MySqlConnection conn = null;
            if (conn == null) conn = new MySqlConnection(connectionString);

            DataSet ds = new DataSet();

            string sql = "select Passwd from driver where Id='" + id + "'";

            MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
            adpt.Fill(ds, "driver");
            foreach (DataRow driver in ds.Tables[0].Rows)
            {
                driverpwd = driver["Passwd"] as string;
            }
            return driverpwd;
        }

        public void Driverjoin(Driver driver)
        {
            string connectionString = "server=localhost;database=broong;uid=root;pwd=cs1234;";
            MySqlConnection conn = null;
            if (conn == null) conn = new MySqlConnection(connectionString);

            DataSet ds = new DataSet();
            string sql = "insert into driver(Id, Passwd, Name, PhoneNumber, MainArea) values('" + driver.Id + "','" + driver.Password + "','" + driver.Name + "'," + driver.PhoneNumber + ",'" + driver.MainArea + "')";

            MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
            adpt.Fill(ds, "driver");

        }
        static public bool DriverCheckId(string id)
        {
            bool success = false;
            string connectionString = "server=localhost;database=broong;uid=root;pwd=cs1234;";
            MySqlConnection conn = null;
            if (conn == null)
                conn = new MySqlConnection(connectionString);
            string sql = "select * from driver where Id='" + id + "'";
            DataSet ds = new DataSet();

            MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
            adpt.Fill(ds, "driver");

            foreach (DataRow driver in ds.Tables[0].Rows)
            {
                success = true;
            }
            return success;
        }


    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class DBHelper : IDisposable
    {
        //private static string conn= System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        // string conn = "@localhost;port=3306;Uid=root;Pwd=123456789;database=ass3;Convert Zero Datetime=True";
        string conn;
        MySqlConnection mySqlcon = null;
        public DBHelper()
        {
            
            MySqlConnectionStringBuilder bu = new MySqlConnectionStringBuilder();
            bu.Server = "localhost";
            bu.UserID = "root";
            bu.Password = "123456789";
            bu.Database = "ass3";
            bu.ConvertZeroDateTime = true;
            conn=bu.ToString();
            //bu.DataSource = @"localhost\SQLEXPRESS2016";
            //bu.InitialCatalog = "Ass3";
            //bu.UserID = "sa";
            //bu.Password = "123456789";
            //conn = bu.ToString();
            mySqlcon = new MySqlConnection(conn);
            mySqlcon.Open();
        }
        public int returnRows(string Query)
        {
            MySqlCommand command = new MySqlCommand(Query, mySqlcon);
            var count = command.ExecuteNonQuery();
            return count;

        }
        public Object returnObject(string Query)
        {
            MySqlCommand command = new MySqlCommand(Query, mySqlcon);
            return command.ExecuteScalar();
        }
        public MySqlDataReader returnPointer(string Query)
        {
            MySqlCommand command = new MySqlCommand(Query, mySqlcon);
            return command.ExecuteReader();
        }

        public void Dispose()
        {
            if (mySqlcon != null && mySqlcon.State == System.Data.ConnectionState.Open)
                mySqlcon.Close();
        }
    }
}

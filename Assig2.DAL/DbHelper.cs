using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Assig2.DAL
{
    internal class DBHelper : IDisposable
    {
        string conn = "";
        SqlConnection sqlcon = null;
        public DBHelper()
        {
                SqlConnectionStringBuilder bu = new SqlConnectionStringBuilder();
                bu.DataSource = @"localhost\SQLEXPRESS2016";
                bu.InitialCatalog = "Ass2";
                bu.UserID = "sa";
                bu.Password = "123456789";
                conn = bu.ToString();
                sqlcon = new SqlConnection(conn);
                sqlcon.Open();
        }
        public int returnRows(string Query)
        {
            SqlCommand command = new SqlCommand(Query, sqlcon);
            var count = command.ExecuteNonQuery();
            return count;

        }
        public Object returnObject(string Query)
        {
            SqlCommand command = new SqlCommand(Query, sqlcon);
            return command.ExecuteScalar();
        }
        public SqlDataReader returnPointer(string Query)
        {
            SqlCommand command = new SqlCommand(Query, sqlcon);
            return command.ExecuteReader();
        }

        public void Dispose()
        {
            if (sqlcon != null && sqlcon.State == System.Data.ConnectionState.Open)
                sqlcon.Close();
        }
    }
}

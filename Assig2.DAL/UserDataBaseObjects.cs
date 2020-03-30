using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserData;

namespace Assig2.DAL
{
    public static class UserDataBaseObjects
    {
        public static bool isUser(UserDataHolder u)
        {
            using(DBHelper helper=new DBHelper())
            {
                String query = String.Format("select Login from dbo.Users where Login='{0}' or Email='{1}'", u.Login,u.Email);
                var reader = helper.returnPointer(query);
                if(reader.Read())
                    return true;
                return false;
            }
        }
        public static bool insertUser(UserDataHolder u)
        {
            using (DBHelper helper = new DBHelper())
            {             
                String query = String.Format("INSERT INTO dbo.Users(Name,Login,Password,Gender,Address,Age,NIC,DOB,IsCricket,IsHockey,IsChess,ImageName,CreatedOn,Email)VALUES('{0}','{1}','{2}','{3}','{4}',{5},'{6}',{7},{8},{9},{10},'{11}',{12},'{13}')", u.userName, u.Login, u.Password, u.gender, u.Address, u.age, u.NIC, u.DOB, u.isCricket, u.isHockey, u.isChess, u.ImageName, DateTime.Now.ToString(),u.Email);
                if (helper.returnRows(query) == 1)
                    return true;
                return false;
            }
        }
        public static bool isValidUser(UserDataHolder u)
        {
            using(DBHelper helper=new DBHelper())
            {
                String query = String.Format("select * from dbo.Users where Login='{0}' AND Password='{1}'", u.Login, u.Password);
                var reader = helper.returnPointer(query);
                if(reader.Read())
                {
                    u.ImageName = reader.GetString(reader.GetOrdinal("ImageName"));
                    u.Login= reader.GetString(reader.GetOrdinal("Login"));
                    u.userName = reader.GetString(reader.GetOrdinal("Name"));
                    u.gender = reader.GetString(reader.GetOrdinal("Gender"));
                    u.age= reader.GetInt32(reader.GetOrdinal("Age"));
                    u.Address = reader.GetString(reader.GetOrdinal("Address"));
                    u.NIC = reader.GetString(reader.GetOrdinal("NIC"));
                    u.Email = reader.GetString(reader.GetOrdinal("Email"));
                    bool chess= reader.GetBoolean(reader.GetOrdinal("isChess"));
                    bool cricket = reader.GetBoolean(reader.GetOrdinal("isCricket"));
                    bool hockey = reader.GetBoolean(reader.GetOrdinal("isHockey"));
                    u.isHockey = hockey == true ? 1 : 0;
                    u.isChess = chess == true ? 1 : 0;
                    u.isCricket = cricket == true ? 1 : 0;
                    u.UserId = reader.GetInt32(reader.GetOrdinal("UserID"));
                    return true;
                }
                return false;
            }
        }
        public static bool isValidEmail(String email)
        {
            using (DBHelper helper = new DBHelper())
            {
                String query = String.Format("Select Email from dbo.Users where Email='{0}'", email);
                var reader = helper.returnPointer(query);
                if (reader.Read())
                {
                    return true;
                }
                return false;
            }
        }
        public static bool deleteUser(UserDataHolder u)
        {
            return true;
        }
    }





    
}
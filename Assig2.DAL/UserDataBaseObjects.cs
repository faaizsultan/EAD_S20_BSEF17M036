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
        public static bool isAdmin(string login,string password)
        {
            String query = String.Format("select Login from dbo.Admin1 where Login='{0}' AND Password='{1}'",login,password);
            using(DBHelper helper=new DBHelper())
            {
                var reader = helper.returnPointer(query);
                if(reader.Read())
                {
                    return true;
                }
                return false;
            }
        }

        public static List<UserDataHolder> fetchAllDataFromDataBase()
        {
            List<UserDataHolder> list = new List<UserDataHolder>();
            using(DBHelper helper=new DBHelper())
            {
                String query = String.Format("Select * from dbo.Users");
                var reader= helper.returnPointer(query);
                while(reader.Read())
                {
                    var obj = new UserDataHolder();
                    obj.UserId = reader.GetInt32(reader.GetOrdinal("UserID"));
                    obj.age = reader.GetInt32(reader.GetOrdinal("Age"));

                    obj.Login = reader.GetString(reader.GetOrdinal("Login"));
                    obj.userName = reader.GetString(reader.GetOrdinal("Name"));
                    obj.gender = reader.GetString(reader.GetOrdinal("Gender"));
                    obj.Address = reader.GetString(reader.GetOrdinal("Address"));
                    obj.NIC = reader.GetString(reader.GetOrdinal("NIC"));
                    obj.DOB = reader.GetString(reader.GetOrdinal("DOB"));

                    var check = reader.GetBoolean(reader.GetOrdinal("isHockey"));
                    obj.isHockey = check == true ? 1 : 0;
                    check = reader.GetBoolean(reader.GetOrdinal("isChess"));
                    obj.isChess = check == true ? 1 : 0;
                    check = reader.GetBoolean(reader.GetOrdinal("isCricket"));
                    obj.isCricket = check == true ? 1 : 0;
                    obj.ImageName = reader.GetString(reader.GetOrdinal("ImageName"));
                    obj.Email = reader.GetString(reader.GetOrdinal("Email"));
                    obj.createdOn = reader.GetString(reader.GetOrdinal("CreatedOn"));
                    list.Add(obj);
                }
                return list;
            }
        }

        public static int getUserID(String email)
        {
            String query = String.Format("select UserID from dbo.USers where Email='{0}'",email);
            using(DBHelper helper=new DBHelper())
            {
                var reader = helper.returnPointer(query);
                if(reader.Read())
                {
                    return reader.GetInt32(reader.GetOrdinal("UserID"));
                }
                return 0;
            }

        }
        public static bool updatePassword(int id,String password)
        {
            String query = String.Format("UPDATE dbo.Users SET Password ='{0}' WHERE UserID = {1};", password,id);
            using(DBHelper helper=new DBHelper())
            {
                var count = helper.returnRows(query);
                if(count==1)
                {
                    return true;
                }
                return false;
            }


        }
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
                String query = String.Format("INSERT INTO dbo.Users(Name,Login,Password,Gender,Address,Age,NIC,DOB,IsCricket,IsHockey,IsChess,ImageName,CreatedOn,Email)VALUES('{0}','{1}','{2}','{3}','{4}',{5},'{6}','{7}',{8},{9},{10},'{11}','{12}','{13}')", u.userName, u.Login, u.Password, u.gender, u.Address, u.age, u.NIC, u.DOB, u.isCricket, u.isHockey, u.isChess, u.ImageName, u.createdOn,u.Email);
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
                    u.Password= reader.GetString(reader.GetOrdinal("Password"));
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
        public static UserDataHolder fecthDataForASingleUser(int id)
        {
            String query = String.Format("select * from dbo.Users where UserID={0}", id);
            using(DBHelper helper=new DBHelper())
            {
                UserDataHolder u = new UserDataHolder();
                var reader = helper.returnPointer(query);
                if(reader.Read())
                {
                    u.ImageName = reader.GetString(reader.GetOrdinal("ImageName"));
                    u.Login = reader.GetString(reader.GetOrdinal("Login"));
                    u.userName = reader.GetString(reader.GetOrdinal("Name"));
                    u.Password = reader.GetString(reader.GetOrdinal("Password"));
                    u.gender = reader.GetString(reader.GetOrdinal("Gender"));
                    u.age = reader.GetInt32(reader.GetOrdinal("Age"));
                    u.Address = reader.GetString(reader.GetOrdinal("Address"));
                    u.NIC = reader.GetString(reader.GetOrdinal("NIC"));
                    u.Email = reader.GetString(reader.GetOrdinal("Email"));
                    bool chess = reader.GetBoolean(reader.GetOrdinal("isChess"));
                    bool cricket = reader.GetBoolean(reader.GetOrdinal("isCricket"));
                    bool hockey = reader.GetBoolean(reader.GetOrdinal("isHockey"));
                    u.isHockey = hockey == true ? 1 : 0;
                    u.isChess = chess == true ? 1 : 0;
                    u.isCricket = cricket == true ? 1 : 0;
                    u.UserId = reader.GetInt32(reader.GetOrdinal("UserID"));
                    u.DOB= reader.GetString(reader.GetOrdinal("DOB"));
                    return u;
                }
                return u;
            }
                
        }

        public static bool updateAllData(UserDataHolder u)
        {
            String query = String.Format("Update  dbo.Users SET Name='{0}', Login='{1}', Password='{2}', Gender='{3}', Address='{4}', Age={5}, NIC='{6}', DOB='{7}', IsCricket={8}, IsHockey={9}, IsChess={10}, ImageName='{11}', Email='{12}' where UserID={13};", u.userName, u.Login, u.Password, u.gender, u.Address, u.age, u.NIC, u.DOB, u.isCricket, u.isHockey, u.isChess, u.ImageName, u.Email,u.UserId);
            using(DBHelper helper=new DBHelper())
            {
                var reader = helper.returnRows(query);
                if(reader==1)
                {
                    return true;
                }
                return false;
            }
        }
    }





    
}
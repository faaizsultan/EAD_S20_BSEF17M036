using DataHolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  static class UserTableOps
    {
         public static bool insertUser(string uname,string password)
        {
            using(DBHelper helper=new DBHelper())
            {
                String query = String.Format("Insert INTO users VALUES ('{0}','{1}')", uname, password);
                var rowsAffected = helper.returnRows(query);
                if (rowsAffected == 1)
                    return true;
                return false;    
            }
        }
        public static bool isValidUser(string userName,string password)
        {
            using(DBHelper helper=new DBHelper())
            {
                String query = String.Format("Select count(*) from users where username='{0}' AND password='{1}'", userName,password);
                var reader = helper.returnPointer(query);
                while(reader.Read())
                {
                    int noOfUser = reader.GetInt32(0);
                    if (noOfUser == 1)
                        return false;
                    return true;
                }
                return true;

            }
        }
        public static List<FolerData> getParentFolders()
        {
            List<FolerData>  list = new List<FolerData>();

            using(DBHelper helper=new DBHelper())
            {
                String query = String.Format("Select folderName,folderId from folderTable where parentId IS NULL");
                var pointer = helper.returnPointer(query);
                
                while(pointer.Read())
                {
                
                    FolerData u = new FolerData();
                    u.folderName = pointer.GetString(pointer.GetOrdinal("folderName"));
                    u.ID= pointer.GetInt32(pointer.GetOrdinal("folderId"));
                    list.Add(u);
                }
            }
            return list;
        }
        public static FolerData makeNewFolder(FolerData data)
        {
            
            using(DBHelper helper=new DBHelper())
            {
                String query;
                if(data.ID!=0)
                {
                    query = String.Format("Insert into folderTable(folderName,parentId) Values('{0}',{1})", data.folderName, data.ID);
                }
                else
                {
                    query= String.Format("Insert into folderTable(folderName) Values('{0}')", data.folderName);
                }
                if (helper.returnRows(query) == 1)
                {
                    query = String.Format("select folderName,folderId  from folderTable where folderName='{0}'", data.folderName);
                    using (DBHelper helper1 = new DBHelper())
                    {
                        var pointer = helper1.returnPointer(query);
                        FolerData user = new FolerData();
                        while (pointer.Read())
                        {
                            user.ID = pointer.GetInt32(pointer.GetOrdinal("folderId"));
                            user.folderName = pointer.GetString(pointer.GetOrdinal("folderName"));
                            return user;
                        }
                    }
                }
                return new FolerData();
            }
            
        }
        public static List<FolerData> getChildFolders(int id)
        {
            List<FolerData> list = new List<FolerData>();
            using (DBHelper helper=new DBHelper())
            {
                String query = String.Format("select folderName,folderId from folderTable where parentId={0}", id);
                var pointer = helper.returnPointer(query);
                while(pointer.Read())
                {
                    FolerData u = new FolerData();
                    u.folderName = pointer.GetString(pointer.GetOrdinal("folderName"));
                    u.ID = pointer.GetInt32(pointer.GetOrdinal("folderId"));
                    list.Add(u);
                }
            }
            return list;
        }
    }
}

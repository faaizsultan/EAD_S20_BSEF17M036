using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DataHolder;

namespace BAL
{
    public static class UserActions
    {
        public static bool registerUser(string userName,string password,string userTable)
        {
            if(validateUser(userName,password))
            {
                return UserTableOps.insertUser(userName, password, userTable);
            }
            return false;
            
        }
        public static bool validateUser(string userName,string password)
        {
            return UserTableOps.isValidUser(userName,password);
        }
        public static bool isAlreadyUser(string userName,string password)
        {
            return (!UserTableOps.isValidUser(userName,password));
        }
        public static UserData makenewFolder(UserData data)
        {
            return UserTableOps.makeNewFolder(data);
        }

        public static List<UserData> getChildFolder(int id)
        {
            return UserTableOps.getChildFolders(id);
        }
        public static List<UserData> getMainFolder()
        {
            return UserTableOps.getParentFolders();
        }
    }
}

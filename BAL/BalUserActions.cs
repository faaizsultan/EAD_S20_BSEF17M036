using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DataHolder;

namespace BAL
{
    public static class BalUserActions
    {
        public static bool registerUser(string userName, string password)
        {
            if(validateUser(userName,password))
            {
                return UserTableOps.insertUser(userName, password);
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
        public static FolerData makenewFolder(FolerData data)
        {
            return UserTableOps.makeNewFolder(data);
        }

        public static List<FolerData> getChildFolder(int id)
        {
            return UserTableOps.getChildFolders(id);
        }
        public static List<FolerData> getMainFolder()
        {
            return UserTableOps.getParentFolders();
        }
    }
}

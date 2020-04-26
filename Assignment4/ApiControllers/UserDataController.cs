using BAL;
using DataHolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Assignment4.ApiControllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserDataController : ApiController
    {
        #region Folder Related Functions
        [Authorize]
        [HttpGet]
        public string get()
        {
            if (User.Identity.IsAuthenticated)
                return "Valid";
            return "Invalid";
        }
        
        [HttpPost]
        public List<DataHolder.FolerData> GetParentFolders()
        {
           
            if (User.Identity.IsAuthenticated)
            {
                return BalUserActions.getMainFolder();
            }
            return new List<DataHolder.FolerData>();
        }
        
        [HttpPost]
        public List<DataHolder.FolerData> GetChildFolders(int id)
        {
            if (User.Identity.IsAuthenticated)
                return BalUserActions.getChildFolder(id);
            return new List<DataHolder.FolerData>();
        }
        
        [HttpPost]
        public Object MakeNewFolder(FolerData user)
        {
            if (User.Identity.IsAuthenticated)
            {
                FolerData u = BalUserActions.makenewFolder(user);

                if (u != null)
                {
                    var h = new
                    {
                        statusbit = 1,
                        msg = "Success",
                        data = u
                    };
                    return h;
                }
                else
                {
                    var h = new
                    {
                        statusbit = 0,
                        msg = "Failed",
                        data = u
                    };
                    return h;
                }
            }
            else
            {
                FolerData u = BalUserActions.makenewFolder(user);

                if (u != null)
                {
                    var h = new
                    {
                        statusbit = 1,
                        msg = "Success",
                        data = u
                    };
                    return h;
                }
                else
                {
                    var h = new
                    {
                        statusbit = 0,
                        msg = "Failed",
                        data = u
                    };
                    return h;
                }
            }


        }

        #endregion



        //sign up
        [HttpPost]
        public Object signUpbyAjax(UserData user)
        {
            
            if (String.IsNullOrEmpty(user.userName) || String.IsNullOrEmpty(user.password))
            {
                var h = new
                {
                    data = "Strings Are Empty"
                };
                return h;
            }
            else if (BalUserActions.registerUser(user.userName, user.password))
            {
                var h = new
                {
                    data="Successfull signup"
                };
                return h;
            }
            else
            {
                var h = new
                {
                    data = "Already A User"
                };
                return h;
            }
        }
    }
}
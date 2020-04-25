using BAL;
using DataHolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment4.ApiControllers
{
    public class UserDataController : ApiController
    {
        #region Folder Related Functions
        [HttpGet]
        public List<DataHolder.FolerData> GetParentFolders()
        {
            return BalUserActions.getMainFolder();            
        }
        [HttpPost]
        public List<DataHolder.FolerData> GetChildFolders(int id)
        {
            return BalUserActions.getChildFolder(id);   
        }
        [HttpPost]
        public Object MakeNewFolder(FolerData user)
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

        #endregion

    }
}
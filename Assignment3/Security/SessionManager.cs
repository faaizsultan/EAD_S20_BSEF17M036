
using DataHolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Security
{
    public static class SessionManager
    {

        public static UserData User
        {
            get
            {
                UserData dto = null;
                if (HttpContext.Current.Session["User"] != null)
                {
                    dto = HttpContext.Current.Session["User"] as UserData;
                }

                return dto;
            }
            set
            {
                HttpContext.Current.Session["User"] = value;
            }
        }

        public static Boolean IsValidUser
        {
            get
            {
                if (User != null)
                    return true;
                else
                    return false;
            }
        }

        public static void ClearSession()
        {
            HttpContext.Current.Session.RemoveAll();
            HttpContext.Current.Session.Abandon();
        }
    }
}
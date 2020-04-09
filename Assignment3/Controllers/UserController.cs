using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment3.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult signUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult signUp(string userTable,string Name, string password,string confirmPassword,string btnSubmit, string btnLogin)
        {
            if (String.IsNullOrEmpty(btnLogin))
            {
                return View();
            }
            else
            {
                return Redirect("~/User/login");
            }


        }
        
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]s
        public ActionResult login(string user,string password,string btnSubmit,string btnSignup)
        {
            if (String.IsNullOrEmpty(btnSignup))
            {
                return View();
            }
            else
            {
                return Redirect("~/User/signUp");
            }
        }




    }
}
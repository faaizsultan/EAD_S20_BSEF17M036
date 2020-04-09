using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL;
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
        public ActionResult signUp(string userTable,string userName, string password,string confirmPassword,string btnSubmit, string btnLogin)
        {
            ViewData["EmptyStrings"] = "";
            ViewData["Passwords"] = "";
            ViewData["Successfull"] = "";

            if(String.IsNullOrEmpty(btnSubmit) && (!String.IsNullOrEmpty(btnLogin))) //has clicked on Login Button
            {
                return Redirect("~/User/login");
            }
            
           else if (String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(confirmPassword) || String.IsNullOrEmpty(password))
                {
                    ViewData["EmptyStrings"] = "One of the fields is Empty";
                    return View();

                }
           else if (password != confirmPassword)
           {
                    ViewData["Passwords"] = "Passwords Do not Match";
                    return View();
                }
           else //has pressed Submit button to register himself..   
           {

                    if ((UserActions.registerUser(userName, password, userTable)))
                    {
                        ViewData["Successfull"] = "You have been successfully registered";
                        return View();
                    }
                    else
                    {
                        ViewData["SuccessFull"] = "Already Registered";
                        return View();
                    }

           }
        }
        
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(string userName,string password,string btnSubmit,string btnSignup)
        {
            if (String.IsNullOrEmpty(btnSignup) && !String.IsNullOrEmpty(btnSubmit)) //means hasnt clicked on signup button. && condition used for for resubission.
            {
                if (String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(password))
                {
                    ViewData["Msg"] = "One of the fields is Missing";
                    return View();
                }
                else if (UserActions.isAlreadyUser(userName,password))
                {
                    ViewData["Msg"] = "Logged in Successfully";
                    return View();
                }
                else
                {
                    ViewData["Msg"] = "Invalid Credentials.";
                    return View();
                }
            }
            else
            {
                return Redirect("~/User/signUp");
            }
        }




    }
}
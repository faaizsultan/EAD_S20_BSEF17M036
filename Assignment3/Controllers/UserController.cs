using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL;
using DataHolder;
namespace Assignment3.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        #region Folder Related Functions
        [HttpGet]
        public JsonResult GetParentFolders()
        {


            List<DataHolder.FolderData> h = BalUserActions.getMainFolder();
            return Json(h, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetChildFolders(int id)
        {
            List<DataHolder.FolderData> h = BalUserActions.getChildFolder(id);
            return Json(h, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult MakeNewFolder(FolderData user)
        {

            FolderData u = BalUserActions.makenewFolder(user);
            
            if(u!=null)
            {
                var h = new
                {
                    statusbit = 1,
                    msg = "Success",
                    data = u
                };
                return Json(h, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var h = new
                {
                    statusbit = 0,
                    msg = "Failed",
                    data = u
                };
            return Json(h, JsonRequestBehavior.AllowGet);
        }
            

        }
        public ActionResult home()
        {
            return View();
        }
        #endregion



        #region Signing in sFuctions
        [HttpGet]
        public ActionResult signUp()
        {
            return View();
        }
        [HttpPost]
        public JsonResult signUpbyAjax(UserData user)
        {
            ViewData["EmptyStrings"] = "";
            ViewData["Passwords"] = "";
            ViewData["Successfull"] = "";
            if(String.IsNullOrEmpty(user.userName) || String.IsNullOrEmpty(user.password))
            {
                var h = new {msg="UserName or Password is Empty" };
                ViewData["EmptryStrings"] = "One of the field is Empty";
                return Json(h, JsonRequestBehavior.AllowGet);
            }
            else if(BalUserActions.registerUser(user.userName,user.password))
            {
                var h = new { msg = "SuccessFull signup" };
                
                return Json(h, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var h = new { msg = "Already A user" };
                return Json(h, JsonRequestBehavior.AllowGet);
            }
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

                    if ((BalUserActions.registerUser(userName, password)))
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
                else if (BalUserActions.isAlreadyUser(userName,password))
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
        #endregion

    }
}
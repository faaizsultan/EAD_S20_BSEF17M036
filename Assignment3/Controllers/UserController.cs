using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL;
using DataHolder;
using Security;
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


            List<DataHolder.FolerData> h = BalUserActions.getMainFolder();
            return Json(h, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetChildFolders(int id)
        {
            List<DataHolder.FolerData> h = BalUserActions.getChildFolder(id);
            return Json(h, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult MakeNewFolder(FolerData user)
        {

            FolerData u = BalUserActions.makenewFolder(user);
            
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
                    UserData temp = new UserData();
                    temp.userName = userName;
                    temp.password = password;
                    Security.SessionManager.User = temp;
                    
                    ViewData["Msg"] = "Logged in Successfully";
                    
                    return Redirect("~/User/home");
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
        public ActionResult home()
        {
            if(SessionManager.IsValidUser)
            {
                return View();
            }
            return View("login");
        }
        #endregion

    }
}
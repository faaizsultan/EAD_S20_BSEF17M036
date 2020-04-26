using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BAL;
using DataHolder;
using Microsoft.IdentityModel.Tokens;
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
                    Security.SessionManager.User = temp;//setting the session
                    
                    
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

            if (SessionManager.IsValidUser) //if user is already Logged in..
            {
                if (SessionManager.User.isTokenGiven == false)
                {
                    string key = "my_secret_key_12345";
                    var issuer = "http://mysite.com";
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var permClaims = new List<Claim>();
                    permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                    permClaims.Add(new Claim("Name", SessionManager.User.userName));


                    var token = new JwtSecurityToken(issuer,
                                issuer,
                                permClaims,
                                expires: DateTime.Now.AddDays(1),
                                signingCredentials: credentials);
                    var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
                    //token generated..
                    TempData["Token"] = jwt_token;
                    SessionManager.User.isTokenGiven = true;
                }
                return View();
            }
            return View("login");
        }
        #endregion

    }
}
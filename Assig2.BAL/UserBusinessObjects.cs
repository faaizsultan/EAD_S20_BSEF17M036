using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserData;
using Assig2.DAL;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace Assig2.BAL
{
    public static class UserBusinessObjects
    {
        public static bool updateAllTheThings(UserDataHolder userData)
        {
            return UserDataBaseObjects.updateAllData(userData);
        }
        
        public static UserDataHolder fetchAllDataForSingleUser(int id)
        {
            return UserDataBaseObjects.fecthDataForASingleUser(id);
        }
        
        public static List<UserDataHolder> fetchAllUserData()
        {
            return UserDataBaseObjects.fetchAllDataFromDataBase();
        }
       public static int getUserIDByEmail(String email)
        {
            return UserDataBaseObjects.getUserID(email);
        }
        public static bool updatePassword(int id,String pass)
        {
            return UserDataBaseObjects.updatePassword(id, pass);
        }
        public static bool isAlreadyUser(UserDataHolder user) //will check from database..
        {
            return UserDataBaseObjects.isUser(user);
        }
        public static bool isValidUser(UserDataHolder user)
        {
            return UserDataBaseObjects.isValidUser(user);
        }
        public static bool createNewUser(UserDataHolder u)
        {
            if (isAlreadyUser(u))
                return false;
            else
            {
                return UserDataBaseObjects.insertUser(u);
            }
        }
        public static bool isAdmin(string Login,string pass)
        {
            return UserDataBaseObjects.isAdmin(Login, pass);
        }
        public static bool sendEmail(String email)
        {
            if (UserDataBaseObjects.isValidEmail(email))
            {
            //sending code..
//            Email: EAD.SEMorning @gmail.com
//             Password: SEMorning2017
                try
                {
                    String fromdisplayEmail = "EAD.SEMorning@gmail.com";
                    String fromPassword = "SEMorning2017";
                    String fromDisplayName = "User Management System";
                    MailAddress fromAdress = new MailAddress(fromdisplayEmail, fromDisplayName);
                    MailAddress toAddress = new MailAddress(email);
                    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
                    {

                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAdress.Address, fromPassword)


                    };

                    using (var message = new MailMessage(fromAdress, toAddress)
                    {
                        Subject = "User Management Reset Password",
                        Body = "Your Verification Code is:       0900-7860-1\n Please Do Not Reply to this Email."
                    
                    })
                    {
                        smtp.Send(message);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
                return false;
        }
    }
}

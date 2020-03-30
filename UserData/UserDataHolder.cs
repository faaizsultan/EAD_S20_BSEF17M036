using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserData
{
    public class UserDataHolder
    {
        
        public String ApplicationPath { get; set; }
        public int UserId { get; set; }
        public String userName { get; set; }

        public String Login { get; set; }
        public String Email { get; set; }

        public String Password { get; set; }
        public String gender { get; set; }
        public String Address{get; set;}
        public int age { get; set; }
        public String NIC { get; set; }
        public DateTime  DOB { get; set; } ////Here i changed the data type to String rather Than THis.
        public int isCricket { get; set; }
        public int isHockey { get; set; }
        public int isChess { get; set; }
        public String ImageName { get; set; }
        public DateTime createdOn { get; set; } //Here i changed the data type to String rather Than THis.
    }
}

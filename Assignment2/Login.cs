using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assig2.BAL;
using UserData;
namespace Assignment2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var f1 = Application.OpenForms["mainScreen"];
            if(f1!=null)
            {
                this.Hide();
                f1.Show();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            var f1 = Application.OpenForms["mainScreen"];
            if (f1 != null)
            {
                this.Hide();
                f1.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim().Length==0)
            {
                MessageBox.Show("Login Missing!!");
            }
            else if (textBox2.Text.Length == 0)
            {
                MessageBox.Show("Password Missing!!");
            }
            else
            {
                UserDataHolder u = new UserDataHolder();
                u.Login = textBox1.Text.Trim();
                u.Password = textBox2.Text;
                if (UserBusinessObjects.isValidUser(u))
                {
                    this.Hide();
                    Home obj = new Home(u);
                    obj.Show();
                }
                else
                    MessageBox.Show("Not A Valid User!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String email =textBox3.Text.Trim();
            if(email.Length==0 || (!email.Contains("@")) || (!email.Contains(".com")))
            {
                MessageBox.Show("Not A Valid Email Entered");
            }
            else
            {
                if(UserBusinessObjects.sendEmail(email))
                {
                    MessageBox.Show("A Verification Code has been sent to your email");
                    this.Hide();
                    Enter_Reset_Code obj = new Enter_Reset_Code();
                    
                    obj.Show();
                }
            }
            
        }
    }
}

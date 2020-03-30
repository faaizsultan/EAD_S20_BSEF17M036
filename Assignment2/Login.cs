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
                MessageBox.Show("USer Naem Missing!!");
            }
            else if (textBox2.Text.Length == 0)
            {
                MessageBox.Show("USer Naem Missing!!");
            }
            else
            {
                UserDataHolder u=new UserDataHolder();
                u.Login = textBox1.Text.Trim();
                u.Password = textBox2.Text;
                if (UserBusinessObjects.isAlreadyUser(u))
                {
                    this.Hide();
                    Home obj = new Home();
                    obj.Show();

                }
                else
                    MessageBox.Show("Not A Valid User!");
            }
        }
    }
}

using Assig2.BAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class Admin_Login : Form
    {
        public Admin_Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

             string Login = textBox1.Text;
             string Password = textBox2.Text;
              Login.Trim();
            if (Login.Length == 0 || Password.Length == 0)
            {
                MessageBox.Show("One of the CREDENTIALS is MISSING!!");
            }
            else
            {
                if(UserBusinessObjects.isAdmin(Login,Password))
                {
                    adminPortal obj = new adminPortal();
                    this.Hide();
                    obj.Show();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f1 = Application.OpenForms["mainScreen"];
            if (f1 != null)
            {
                this.Close();
                f1.Show();
            }
        }

        private void Admin_Login_Load(object sender, EventArgs e)
        {
            var f1 = Application.OpenForms["mainScreen"];
            if (f1 != null)
            {
                this.Hide();
                f1.Show();
            }
        }
    }
}

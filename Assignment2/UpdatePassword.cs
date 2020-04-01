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
    public partial class UpdatePassword : Form
    {
        int userID;
        public UpdatePassword()
        {
            InitializeComponent();
        }
        public UpdatePassword(int UserID)
        {
            InitializeComponent();
            this.userID = UserID;
        }

        private void UpdatePassword_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sString newPassword = textBox1.Text;
            String confirm = textBox2.Text;
            if(newPassword.Length==0)
            {
                MessageBox.Show("Enter Some Password");
            }
            else if(newPassword!=confirm)
            {
                MessageBox.Show("Passwords do not match!");
            }
            else
            {

                if (UserBusinessObjects.updatePassword(userID, newPassword))
                {
                    MessageBox.Show("Password Updated Successfully.");
                    this.Close();
                    var f1 = Application.OpenForms["mainScreen"];
                    if (f1 != null)
                    {
                        this.Hide();
                        f1.Show();
                    }
                }
                else
                    MessageBox.Show("Some error occured in the DATABASE!!!");   
            }
        }
    }
}

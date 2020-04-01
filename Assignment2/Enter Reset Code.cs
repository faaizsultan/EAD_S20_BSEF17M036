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
    public partial class Enter_Reset_Code : Form
    {
        int userId;
        public Enter_Reset_Code()
        {
            InitializeComponent();
        }
        public Enter_Reset_Code(int userID)
        {
            InitializeComponent();
            this.userId = userID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!maskedTextBox1.MaskCompleted)
            {
                MessageBox.Show("Please Fill Out the complete Code Sent to YOU!");
            }
            else if (maskedTextBox1.Text == "0900-7860-1")
            {
                MessageBox.Show("Code Verified");
                this.Close();
                UpdatePassword obj = new UpdatePassword(userId);
                obj.Show();
            }
            else
                MessageBox.Show("Incorrect Code");
        }

        private void Enter_Reset_Code_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Close();
            var f1 = Application.OpenForms["mainScreen"];
            if (f1 != null)
            {
                this.Close();
                f1.Show();
            }
        }
    }
}

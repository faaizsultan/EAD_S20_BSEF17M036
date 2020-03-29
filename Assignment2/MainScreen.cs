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
    public partial class mainScreen : Form
    {
        public mainScreen()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            newUser obj = new newUser();
            obj.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login obj = new Login();
            obj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Login obj = new Admin_Login();
            obj.Show();
        }
    }
}

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
    public partial class Home : Form
    {
        String fileName;
        String userName;
        public Home()
        {
            InitializeComponent();
        }

        public Home(String fileN,String userN)
        {
            this.fileName = fileN;
            this.userName = userN;
            InitializeComponent();
            pictureBox1.Load(fileName);
            label1.Text = "Welcome " + userName;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            var f1 = Application.OpenForms["mainScreen"];
            if (f1 != null)
            {
                this.Hide();
                f1.Show();
            }

        }

        private void Home_Load(object sender, EventArgs e)
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

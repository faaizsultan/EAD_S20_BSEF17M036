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
        String pathFromLoad=System.IO.Path.GetDirectoryName(Application.ExecutablePath);
        String userName;
        public Home()
        {
            InitializeComponent();
        }

        public Home(UserData.UserDataHolder u)
        {
            this.userName = u.userName;
            InitializeComponent();
            pathFromLoad = pathFromLoad + @"\images\" + u.ImageName;
            
            pictureBox1.Load(pathFromLoad);
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

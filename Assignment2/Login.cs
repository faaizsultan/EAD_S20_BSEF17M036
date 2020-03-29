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
    }
}

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
    public partial class adminPortal : Form
    {
        public adminPortal()
        {
            
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = UserBusinessObjects.fetchAllUserData();


        }

        private void AdminPortal_Load(object sender, EventArgs e)
        {
            
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==5)
            {
                var id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                this.Hide();
                UserDataHolder b = UserBusinessObjects.fetchAllDataForSingleUser(id);
                newUser newUserForm = new newUser(b);
                newUserForm.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f1 = Application.OpenForms["mainScreen"];
            if (f1 != null)
            {
                this.Close();
                f1.Show();
            }

        }
    }
}

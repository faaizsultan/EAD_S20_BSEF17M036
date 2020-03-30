using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserData;
using Assig2.BAL;
namespace Assignment2
{
    public partial class newUser : Form
    {
        String filename;
        public newUser()
        {
            InitializeComponent();
        }

        private void newUser_Load(object sender, EventArgs e)
        {
            
          
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

        private void button4_Click(object sender, EventArgs e)
        {
            //Uploading a file.
            var result = openFileDialog1.ShowDialog();
            if(result== System.Windows.Forms.DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                pictureBox1.Load(filename);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserData.UserDataHolder u = new UserDataHolder();
            String name = textBox1.Text.Trim();
            String login = textBox2.Text.Trim();
            String password = textBox3.Text.Trim();
            String email= textBox4.Text.Trim();
            String gender = comboBox1.Text.Trim();  
            String address = richTextBox1.Text.Trim();
            int age = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
            
            String NIC = maskedTextBox1.Text;
            DateTime dateTime = dateTimePicker1.Value;
            Boolean isHockey = checkBox2.Checked;
            Boolean isCricket = checkBox3.Checked;
            Boolean isChess = checkBox4.Checked;
            //validating the input from User..
            
            u.userName = name;
            u.Login = login;
            u.Password = password;
            u.Email = email;
            u.gender = gender;
            u.Address = address;
            u.age = age;
            u.NIC = NIC;
            u.DOB = dateTime;
            u.isHockey = isHockey;
            u.isCricket = isCricket;
            u.isChess = isChess;
            if (name.Length != 0 && login.Length != 0 && password.Length != 0 && gender.Length != 0 && address.Length != 0  && (maskedTextBox1.MaskCompleted) && (isHockey || isCricket || isChess)  && pictureBox1.Image!=null) 
            {
                if (UserBusinessObjects.createNewUser(u))
                {
                    MessageBox.Show("New User Created");
                    this.Hide();
                    Home obj = new Home(filename,u.userName);
                    obj.Show();

                }
                else
                    MessageBox.Show("Already a User");
            }
            else
            {
                MessageBox.Show("One of fields is missing");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class newUser : Form
    {
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
            var result = openFileDialog1.ShowDialog();
            if(result== System.Windows.Forms.DialogResult.OK)
            {
                String filename = openFileDialog1.FileName;
                pictureBox1.Load(filename);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String name = textBox1.Text.Trim();
            String login = textBox2.Text.Trim();
            String password = textBox3.Text.Trim();
            String email= textBox4.Text.Trim();
            String gender = comboBox1.Text.Trim();  
            String address = richTextBox1.Text.Trim();
            int count = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
            String age = count.ToString();
            String NIC = maskedTextBox1.Text;
            MessageBox.Show(NIC);
            DateTime dateTime = dateTimePicker1.Value;
            String DOB = dateTime.ToString();
            Boolean isHockey = checkBox2.Checked;
            Boolean isCricket = checkBox3.Checked;
            Boolean isChess = checkBox4.Checked;
            
            if (name.Length != 0 && login.Length != 0 && password.Length != 0 && gender.Length != 0 && address.Length != 0 && age.Length != 0 && (maskedTextBox1.MaskCompleted) && DOB.Length!=0 && (isHockey || isCricket || isChess)  && pictureBox1.Image!=null) 
            {
                MessageBox.Show("Its ok..")
            }
            else
            {
                MessageBox.Show("One of fields is missing");
            }


            //MessageBox.Show(dateTime.ToString());
            //MessageBox.Show(name);
            //MessageBox.Show(login);
            //MessageBox.Show(password);
            //MessageBox.Show(email);
            //MessageBox.Show(gender);
            //MessageBox.Show(age);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

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
using System.IO;

namespace Assignment2
{
    public partial class newUser : Form
    {
        String filename;
        bool isEdit = false;
        string pathToLoadImage = "";
        int userId = 0;
        public newUser()
        {
            userId = 0;
            pathToLoadImage = "";

            isEdit = false;
                
            InitializeComponent();
            isEdit = false;
        }

        public newUser(UserDataHolder user)
        {
            InitializeComponent();
            this.isEdit = true;
            this.userId = user.UserId;
            
            button2.Text = "Update";
            textBox1.Text = user.userName;
            textBox2.Text = user.Login;
            textBox3.Text = user.Password;   textBox3.ReadOnly = true;
            textBox4.Text = user.Email;
            comboBox2.Text = user.gender;
            richTextBox1.Text = user.Address;
            numericUpDown1.Value = user.age;
            maskedTextBox1.Text = user.NIC;
            dateTimePicker1.Value = Convert.ToDateTime(user.DOB);
            //checkBox2 Hockey chec3 Cricket check 4 Chess
            checkBox2.Checked = user.isHockey == 1 ? true : false;
            checkBox3.Checked = user.isCricket == 1 ? true : false;
            checkBox4.Checked = user.isChess == 1 ? true : false;
            filename = user.ImageName;
            user.ApplicationPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            this.pathToLoadImage = user.ApplicationPath + @"\images\" + filename;
            pictureBox2.Load(pathToLoadImage);
        }
        private void newUser_Load(object sender, EventArgs e)
        {
            
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!isEdit)
            {
                var f1 = Application.OpenForms["mainScreen"];
                if (f1 != null)
                {
                    this.Close();
                    f1.Show();
                }
                else
                    Application.Exit();
            }
            else
            {
                var f1 = Application.OpenForms["adminPortal"];
                    this.Close();
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
                pictureBox2.Load(filename);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserData.UserDataHolder u = new UserDataHolder();
            String name = textBox1.Text.Trim();
            String login = textBox2.Text.Trim();
            String password = textBox3.Text.Trim();
            String email= textBox4.Text.Trim();
            String gender = comboBox2.Text.Trim();  
            String address = richTextBox1.Text.Trim();
            int age = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
            
            String NIC = maskedTextBox1.Text;
            String dateTime = dateTimePicker1.Value.ToShortDateString();
            
            bool isHockey = checkBox2.Checked;
            bool isCricket = checkBox3.Checked;
            bool isChess = checkBox4.Checked;
            //validating the input from User..
            
            u.userName = name;
            u.Login = login;
            u.Password = password;
            u.Email = email;
            u.gender = gender;
            u.Address = address;
            u.age = age;
            u.NIC = NIC;
            u.DOB = dateTimePicker1.Value.ToShortDateString();
            u.createdOn = DateTime.Now.ToShortDateString();
            
            
            u.isHockey = isHockey == true ? 1 : 0;
            u.isCricket = isCricket == true ? 1 : 0;
            u.isChess = isChess == true ? 1 : 0;
            if (!isEdit) //we are not editing the user.
            {
                if (name.Length != 0 && login.Length != 0 && password.Length != 0 && gender.Length != 0 && address.Length != 0 && (maskedTextBox1.MaskCompleted) && (isHockey || isCricket || isChess) && pictureBox2.Image != null)
                {
                    u.ApplicationPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                    String pathToSaveImage = u.ApplicationPath + @"\images\";
                    String extension = Path.GetExtension(openFileDialog1.FileName);
                    u.ImageName = Guid.NewGuid().ToString() + extension;
                    if (u.age == 0)
                    {
                        MessageBox.Show("Your Age Canot be ZERO!");
                    }
                    else if ((!u.Email.Contains("@")) || (!u.Email.Contains(".com")))
                    {
                        MessageBox.Show("Not a Valid Email Address");
                    }
                    else if (UserBusinessObjects.createNewUser(u))
                    {

                        pathToSaveImage = pathToSaveImage + u.ImageName;
                        pictureBox2.Image.Save(pathToSaveImage);
                        MessageBox.Show("New User Created");
                        this.Hide();
                        Home obj = new Home(u);
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
            else // editing the form
            {
                if (name.Length != 0 && login.Length != 0 && password.Length != 0 && gender.Length != 0 && address.Length != 0 && (maskedTextBox1.MaskCompleted) && (isHockey || isCricket || isChess) && pictureBox2.Image != null)
                {
                    if (u.age == 0)
                    {
                        MessageBox.Show("Age Can Not be Zero");
                    }
                    else if ((!u.Email.Contains("@")) || (!u.Email.Contains(".")))
                    {
                        MessageBox.Show("Not a Valid Email Address");
                    }
                    else if(pathToLoadImage!=openFileDialog1.FileName) //has changed the picture. now just update the picture name.. and save it in images folder..
                    {
                        String extension = Path.GetExtension(openFileDialog1.FileName);
                        u.ImageName= Guid.NewGuid().ToString() + extension;
                        String pathtoSaveImage = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\images\";
                        pathtoSaveImage = pathtoSaveImage + u.ImageName;
                        pictureBox2.Image.Save(pathtoSaveImage);
                        u.UserId = this.userId;
                        if(UserBusinessObjects.updateAllTheThings(u))
                        {
                            MessageBox.Show("Record Updated Successfully");
                            this.Close();
                            adminPortal obj = new adminPortal();
                            obj.Show();
                            

                        }
                        else
                        {
                            MessageBox.Show("Some Error occured while updating your record");
                        }
                    }
                    else //update everything
                    {
                        u.UserId = this.userId;
                        if(UserBusinessObjects.updateAllTheThings(u))
                        {
                            MessageBox.Show("Updated without picture");
                            this.Close();
                            adminPortal obj = new adminPortal();
                            obj.Show();


                        }
                        else
                        {
                            MessageBox.Show("Error without picture");
                        }

                    }

                }
                else
                    MessageBox.Show("One of the fields are missing");


            }
        }

        

        private void newUser_FormClosing(object sender, FormClosingEventArgs e)
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DBMS_PROJECT_HOTEL_MANAGEMENT_SYSTEM
{
    public partial class SIGN_UP : Form
    {
       SqlConnection con = new SqlConnection("Data Source=DESKTOP-E7I2LP6\\SQLEXPRESS;Initial Catalog=assign03;Integrated Security=True");

        public SIGN_UP()
        {
            InitializeComponent();
        }

        public static string imgname = "";

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SIGNUP_LOGIN_PANEL obj = new SIGNUP_LOGIN_PANEL();
            this.Hide();
            obj.Show();
        }

        private void SIGN_UP_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            //browse
            OpenFileDialog img = new OpenFileDialog();
            if (img.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = new Bitmap(img.FileName); //panel k uper image cover ho rahi hai

                imgname = img.FileName.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //save
            File.Copy(imgname, Path.Combine(@"C:\Users\Haris Khalid\Downloads\DBMS_PROJECT_HOTEL_MANAGEMENT_SYSTEM\DBMS_PROJECT_HOTEL_MANAGEMENT_SYSTEM\DBMS_PROJECT_HOTEL_MANAGEMENT_SYSTEM\image", Path.GetFileName(imgname)), true);
                                                                                                              
            //name
            if (Regex.Match(textBox1.Text, "^[a-zA-Z ]{1,30}$").Success && !string.IsNullOrEmpty(textBox1.Text))
            {
                label9.Text = "";
                errorProvider1.SetError(textBox1, string.Empty);
            }
            else
            {
                errorProvider1.SetError(textBox1, "plz fill");
                label9.Text = "Enter Your Name!";
            }

            //email
            if (Regex.Match(textBox2.Text, "^[a-zA-Z]{1,30}[0-9]{1,10}@[a-z]{5,7}.[a-z]{2,3}$").Success ||
                Regex.Match(textBox2.Text, "^[a-zA-Z]{1,30}@[a-z]{5,7}.[a-z]{2,3}$").Success
                || Regex.Match(textBox2.Text, "^[a-zA-Z]{1,30}[0-9]{1,10}[a-zA-Z]{1,30}[0-9]{1,10}@[a-z]{5,7}.[a-z]{2,3}.[a-z]{2,3}$").Success
                && !string.IsNullOrEmpty(textBox2.Text))
            {
                label10.Text = "";
                errorProvider2.SetError(textBox2, string.Empty);
            }
            else
            {
                errorProvider2.SetError(textBox2, "plz fill");
                label10.Text = "Enter Your Email!";
            }

            //username
            if (Regex.Match(textBox3.Text, "^[a-zA-Z ]{1,30}$").Success && !string.IsNullOrEmpty(textBox3.Text))
            {
                label11.Text = "";
                errorProvider3.SetError(textBox3, string.Empty);
            }
            else
            {
                errorProvider3.SetError(textBox3, "plz fill");
                label11.Text = "Enter Your Username!";
            }

            //password
            if (Regex.Match(textBox4.Text, "^[a-zA-Z ]{1,30}$").Success && !string.IsNullOrEmpty(textBox4.Text))
            {
                label12.Text = "";
                errorProvider4.SetError(textBox4, string.Empty);
            }
            else
            {
                errorProvider4.SetError(textBox4, "plz fill");
                label12.Text = "Enter Your Password!";
            }

            //confirm password
            if (Regex.Match(textBox5.Text, "^[a-zA-Z ]{1,30}$").Success && !string.IsNullOrEmpty(textBox5.Text))
            {
                label13.Text = "";
            }
            else
            {
                label13.Text = "Confirm Your Password!";
            }

            SqlCommand cmd = new SqlCommand("insert into signup(name,email,username,password,confirmpass,images) values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "',, '" + textBox4.Text + "', '" + textBox5.Text + "','" + imgname + "',)", con);

            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Data save Successfully");
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = " ";
            }
            else
            {
                MessageBox.Show("Data not save");
            }
            con.Close();

            MessageBox.Show("Data Save Successfully!");
            pictureBox2.Image = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            this.Hide();
            obj.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

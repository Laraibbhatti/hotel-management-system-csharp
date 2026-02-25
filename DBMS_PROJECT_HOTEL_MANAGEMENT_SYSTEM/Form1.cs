using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DBMS_PROJECT_HOTEL_MANAGEMENT_SYSTEM
{
    public partial class Login : Form
    {
        public static bool flag = false;
        public static string userType = "";
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-G8CP3NV\\SQLEXPRESS;Initial Catalog=ProjectDB;Integrated Security=True;Encrypt=False");
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                label4.Text = "Plz Enter Email";
                label5.Text = "Plz Enter Password";
            }
            else if (textBox1.Text=="")
            {
                label5.Text = "";
                label4.Text = "Plz Enter Email";
               
            }
            else if(textBox2.Text == "")
            {
                label4.Text = "";
                label5.Text = "Plz Enter Password";
            }
            
            else
            {


                label4.Text = "";
                label5.Text = "";
                
                if (!Regex.Match(textBox1.Text,"^[a-zA-Z]{1,20}[0-9]{1,10}@[a-z]{5,7}.[a-z]{3}$").Success)
                {
                    errorProvider1.SetError(textBox1, "Enter Valid Email Address");
                    label4.Text = "Enter Valid Email Address ";
                }
                else
                {
                    string email = textBox1.Text;
                    string password = textBox2.Text;

                    errorProvider1.SetError(textBox1, string.Empty);

                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE email=@Email AND password=@Password", con);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        flag = true;

                         userType = reader["Name"].ToString(); 

                        MessageBox.Show("Hi  " + email + "  You Are Logged In Successfully ");
                        textBox1.Text = textBox2.Text = "";

                        if (userType == "Admin")
                        {

                            ADMIN_FORM obj = new ADMIN_FORM();
                            this.Hide();
                            obj.Show();
                        }
                       
                    }
                    else
                    {
                        flag = false;
                        MessageBox.Show("Authentication Failed !! ");
                    }

                    reader.Close();

                    con.Close();
                }
              
                

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            pictureBox1.Hide();
            pictureBox2.Show();
            textBox2.UseSystemPasswordChar = false;
           
          
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Hide();
            pictureBox1.Show();
            textBox2.UseSystemPasswordChar = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

      

       
     

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            HOME_PAGE obj = new HOME_PAGE();
            this.Hide();
            obj.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SIGN_UP obj = new SIGN_UP();
            this.Hide();
            obj.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
           string url= "https://accounts.google.com/AddSession?service=accountsettings&continue=https://myaccount.google.com/&ec=GAlAwAE&hl=en_GB&authuser=0";
            try
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute=true});
                   
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message, "Error Occured",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            string url = "https://m.facebook.com/login/?privacy_mutation_token=eyJ0eXBlIjowLCJjcmVhdGlvbl90aW1lIjoxNzA0NTE4MDI0LCJjYWxsc2l0ZV9pZCI6NDkyNDY4Nzk4MzkxMDk5fQ%3D%3D";
            try
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });

            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

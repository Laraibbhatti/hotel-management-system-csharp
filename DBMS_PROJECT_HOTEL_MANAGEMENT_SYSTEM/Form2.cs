using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_PROJECT_HOTEL_MANAGEMENT_SYSTEM
{
    public partial class HOME_PAGE : Form
    {
        public static string checkinDate = "";
        public static string checkOutDate = "";
        public static string adults = "";
        public static string childrens = "";


        public HOME_PAGE()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = Login.userType;
            if (Login.userType == "Admin")
            {
                // Open admin form
                // AdminForm adminForm = new AdminForm();
                this.Hide();
                // adminForm.Show();
            }
            
            monthCalendar1.DateSelected += monthCalendar1_DateSelected;
            monthCalendar2.DateSelected += monthCalendar2_DateSelected;

        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            BOOKING_PAGE obj = new BOOKING_PAGE();
            this.Hide();
            obj.Show();



        }

      

        private void textBox1_Click(object sender, EventArgs e)
        {
            
          monthCalendar1.Visible = true;
           
            
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            textBox1.Text = monthCalendar1.SelectionStart.ToShortDateString();
            monthCalendar1.Visible = false; 
        
    }

       

        private void textBox2_Click(object sender, EventArgs e)
        {
            monthCalendar2.Visible = true;
        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            textBox2.Text = monthCalendar2.SelectionStart.ToShortDateString();
            monthCalendar2.Visible = false; 

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "CHECK-IN DATE")
            {
                checkinDate = textBox1.Text;

            }
            if (textBox2.Text != "CHECK-OUT DATE")
            {
                checkOutDate = textBox2.Text;
            }
            if (comboBox1.Text != "ADULTS")
            {
                adults = comboBox1.Text;
            }
            if (comboBox2.Text != "CHILDREN")
            {
                childrens = comboBox2.Text;
            }

            BOOKING_PAGE obj1 = new BOOKING_PAGE();
            this.Hide();
            obj1.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            SIGNUP_LOGIN_PANEL obj = new SIGNUP_LOGIN_PANEL();
            this.Hide();
            obj.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ROOMS_FORM obj = new ROOMS_FORM();
            this.Hide();
            obj.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Pages obj = new Pages();
            //this.Hide();
            //Pages.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ABOUT_US obj = new ABOUT_US();
            this.Hide();
            obj.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            REVIEWS obj = new REVIEWS();
            this.Hide();
            obj.Show();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CONTACT_FORM obj = new CONTACT_FORM();
            this.Hide();
            obj.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string url = "";
            try
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });

            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string url = "";
            try
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });

            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

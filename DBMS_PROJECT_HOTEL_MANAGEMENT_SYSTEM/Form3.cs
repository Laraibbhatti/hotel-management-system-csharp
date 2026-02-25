using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_PROJECT_HOTEL_MANAGEMENT_SYSTEM
{
    public partial class BOOKING_PAGE : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-8JNRUG4;Initial Catalog=ProjectDB;Integrated Security=True");
        public BOOKING_PAGE()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = HOME_PAGE.checkinDate;
            textBox2.Text = HOME_PAGE.checkOutDate;
            comboBox2.Text = HOME_PAGE.adults;
            comboBox3.Text = HOME_PAGE.childrens;



            monthCalendar1.DateSelected += monthCalendar2_DateSelected;
            monthCalendar2.DateSelected += monthCalendar2_DateSelected;
     

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            HOME_PAGE obj = new HOME_PAGE();
            this.Hide();
            obj.Show();
        }

       

        private void textBox1_Click(object sender, EventArgs e)
        {
            monthCalendar2.Visible = false;
            monthCalendar1.Visible = true;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = false;
            monthCalendar2.Visible = true;
           
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            monthCalendar2.Visible = false;
            textBox1.Text = monthCalendar1.SelectionStart.ToShortDateString();
           
        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.Visible = false;
            textBox2.Text = monthCalendar2.SelectionStart.ToShortDateString();
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == ""&&comboBox1.Text==""&& comboBox2.Text=="" && comboBox3.Text=="")
            {
                label7.Text = "Plz Select checkIn Date";
                label8.Text = "Plz Select checkOut Date";
                label9.Text = "Plz Select Rooms";
                label10.Text = "Plz Select Number of Adults";
                label11.Text = "Plz Select Number of Children";

            }
            else if (textBox1.Text == "")
            {
                label8.Text=label9.Text=label10.Text=label11.Text= "";
                label7.Text = "Plz Select checkIn Date";

            }
            else if (textBox2.Text == "")
            {
                label7.Text = label9.Text = label10.Text = label11.Text  = "";
                label8.Text = "Plz Select checkOut Date";
            }
            else if (comboBox1.Text == "")
            {
                label7.Text = label8.Text = label10.Text = label11.Text = "";
                label9.Text = "Plz Select Rooms";
            }
            else if (comboBox2.Text == "")
            {
                label7.Text = label8.Text = label9.Text = label11.Text = "";
                label10.Text = "Plz Select Number of Adults";
            }
            else if (comboBox3.Text == "")
            {
                label7.Text = label8.Text = label9.Text = label10.Text = "";
                label11.Text = "Plz  Select Number of Children";
            }
            else
            {
                label7.Text = label8.Text = label9.Text = label10.Text= label11.Text = "";
                if (Login.flag == true)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into bookingInfo(CheckinDate,CheckoutDate,RoomType,Adults,Childrens) values('"+textBox1.Text+"','"+textBox2.Text+"','"+comboBox1.Text+"','"+comboBox2.Text+"','"+comboBox3.Text+"'  )",con);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Your Request has been Proceeeded Succuessfully   " +
                " Check your Email For more Information ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        textBox1.Text = textBox2.Text =  comboBox1.Text =  comboBox2.Text =  comboBox3.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Data Not Inserted");
                    }


                    con.Close();

                }
                else
                {
                    MessageBox.Show("You must have LogIn first " + " ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Login obj = new Login();
                    obj.Show();


                }



            }


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

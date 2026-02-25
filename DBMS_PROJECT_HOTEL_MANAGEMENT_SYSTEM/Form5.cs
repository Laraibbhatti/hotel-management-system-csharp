using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DBMS_PROJECT_HOTEL_MANAGEMENT_SYSTEM
{
    public partial class ADMIN_FORM : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-G8CP3NV\\SQLEXPRESS;Initial Catalog=ProjectDB;Integrated Security=True;Encrypt=False");
        static public string id = "";

        public ADMIN_FORM()
        {
           InitializeComponent();
        }

        private void ADMIN_FORM_Load(object sender, EventArgs e)
        {

        }

        private void ADMIN_FORM_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectDBDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.projectDBDataSet.Users);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Users where id = '" + id + "' ", con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("delete successfully");
                SqlDataAdapter adp = new SqlDataAdapter("select * from Users", con);
                DataTable dbl = new DataTable();
                adp.Fill(dbl);
                dataGridView1.DataSource = dbl;
                textBox1.Text = textBox2.Text = "";
                
            }
            else
            {
                MessageBox.Show("not deleted");
            }
            con.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "")
            {
                label4.Text = "Plz Fill";
                label5.Text = "Plz Fill";
                label6.Text = "Plz Fill";
            }
            else if (textBox2.Text == "")
            {
                label5.Text = label6.Text = "";
                label4.Text = "Plz FILL";

            }
            else if (textBox3.Text == "")
            {
                label4.Text = label6.Text = "";
                label5.Text = "Plz Fill";
            }
            else if (textBox4.Text == "")
            {
                label4.Text = label5.Text = "";
                label6.Text = "Plz Fill";
            }

            else
            {
                label4.Text = label5.Text = label6.Text = "";
              
                
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Users(Name,email,password) values ('" + textBox2.Text + "' , '" + textBox3.Text + "' , '" + textBox4.Text + "')", con);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("insert successfully");
                        SqlDataAdapter adp = new SqlDataAdapter("select * from Users", con);
                        DataTable dbl = new DataTable();
                        adp.Fill(dbl);
                        dataGridView1.DataSource = dbl;

                    }
                    else
                    {
                        MessageBox.Show("not inserted");
                    }
                    con.Close();
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();

            string update = "update Users set Name='" + textBox2.Text + "',email='" + textBox3.Text + "',password='" + textBox4.Text + "' where id='" + id + "'";
            SqlDataAdapter adp = new SqlDataAdapter(update, con);
            if (adp.SelectCommand.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("updated");
            }
            else
            {
                MessageBox.Show("not updated");
            }

            SqlDataAdapter adp2 = new SqlDataAdapter("select*from Users", con);
            DataTable dbl = new DataTable();
            adp2.Fill(dbl);
            dataGridView1.DataSource = dbl;

            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter("select*from Users where concat(id,name,email,password) like '%" + textBox1.Text + "%' ", con);
            DataTable dbl = new DataTable();
            adp.Fill(dbl);
            dataGridView1.DataSource = dbl;
            con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            HOME_PAGE obj = new HOME_PAGE();
            this.Hide();
            obj.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}

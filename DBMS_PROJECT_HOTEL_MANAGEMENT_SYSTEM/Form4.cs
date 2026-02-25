using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_PROJECT_HOTEL_MANAGEMENT_SYSTEM
{
    public partial class SIGNUP_LOGIN_PANEL : Form
    {
        public SIGNUP_LOGIN_PANEL()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            HOME_PAGE obj = new HOME_PAGE();
            this.Hide();
            obj.Show();
        }

     

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SIGN_UP obj = new SIGN_UP();
            this.Hide();
            obj.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            this.Hide();
            obj.Show();
        }

        private void SIGNUP_LOGIN_PANEL_Load(object sender, EventArgs e)
        {

        }
    }
}

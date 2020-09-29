using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;

namespace BloodDonation
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            error();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=EXCELANCE\SQLEXPRESS;Initial Catalog=BloodDonation;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) From LOGIN Where userid='"+textBox1.Text+"' and password='"+textBox2.Text+"'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if(dt.Rows[0][0].ToString() == "1")
            {
                Welcome sd = new Welcome();
                sd.Show();
                this.Hide();
                Clear();
            }
            else
            {
                MessageBox.Show("Username or Password is Incorrect..");
            }
        }

        private void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            error();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Signup s = new Signup();
            s.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forgot f = new Forgot();
            f.Show();
            this.Hide();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                errorProvider1.SetError(textBox1, "Please Enter the Username");
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                errorProvider1.SetError(textBox2, "Please Enter the Password");
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
            }
        }

        private void error()
        {
            errorProvider1.SetError(textBox1, "Please Enter the Username");
            errorProvider1.SetError(textBox2, "Please Enter the Password");
        }

        }
    }



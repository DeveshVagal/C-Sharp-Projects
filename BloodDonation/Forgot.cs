using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BloodDonation
{
    public partial class Forgot : Form
    {
        public Forgot()
        {
            InitializeComponent();
            error();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=EXCELANCE\SQLEXPRESS;Initial Catalog=BloodDonation;Integrated Security=True");
            con.Open();

            if (textBox2.Text == textBox3.Text)
            {
                SqlCommand cmd = new SqlCommand("UPDATE LOGIN SET password='" + textBox2.Text + "' WHERE userid='" + textBox1.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Password Changed Successfully");
                Login l = new Login();
                l.Show();
                this.Hide();
                con.Close();
                Clear();
            }
            else
            {
                MessageBox.Show("Password Does not Match..");
                Clear();
            }
        }

        private void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            error();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
                errorProvider1.SetError(textBox2, "Please Enter the New Password");
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (textBox3.Text == string.Empty)
            {
                errorProvider1.SetError(textBox3, "Please Confirm the Password");
            }
            else
            {
                errorProvider1.SetError(textBox3, "");
            }
        }

        private void error()
        {
            errorProvider1.SetError(textBox1, "Please Enter the Username");
            errorProvider1.SetError(textBox2, "Please Enter the New Password");
            errorProvider1.SetError(textBox3, "Please Confirm the Password");
        }
    }
}

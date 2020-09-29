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
    public partial class Signup : Form
    {
        public Signup()
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=EXCELANCE\SQLEXPRESS;Initial Catalog=BloodDonation;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) From LOGIN Where userid = '" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (int.Parse(dt.Rows[0][0].ToString()) == 0)
            {
                label3.Text = textBox1.Text + " Available";
                this.label3.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label3.Text = textBox1.Text + " not Available";
                this.label3.ForeColor = System.Drawing.Color.Red;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=EXCELANCE\SQLEXPRESS;Initial Catalog=BloodDonation;Integrated Security=True");
            con.Open();

            if (label3.ForeColor == System.Drawing.Color.Green)
            {

                if (textBox2.Text == textBox3.Text)
                {
                    SqlCommand cmd = new SqlCommand("Insert into Login(userid,Password) Values ('" + textBox1.Text + "','" + textBox3.Text + "')", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Registered");
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
            else
            {
                MessageBox.Show("Please use Available username..");
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

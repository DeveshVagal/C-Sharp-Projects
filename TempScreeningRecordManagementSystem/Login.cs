using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TempScreeningRecordManagementSystem
{
    public partial class Login : Form
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        public static string passingtext;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            error();
            button1.Visible = false;
            label4.Visible = false;
            timer1.Start();
            label8.Text = DateTime.Now.ToLongDateString();
            label9.Text = DateTime.Now.ToLongTimeString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string sql = "SELECT Name FROM LOGIN WHERE USERNAME = '" + textBox1.Text + "' and PASSWORD = '" + textBox2.Text + "'";
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    label4.Text = reader[0].ToString();

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                label4.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            SqlDataAdapter sda = new SqlDataAdapter("Select * From LOGIN Where USERNAME='" + textBox1.Text + "' and PASSWORD='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                passingtext = label4.Text;
                DataEntry de = new DataEntry();
                de.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username or Password is Incorrect..");
                clear();
            }
        }

        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            button1.Visible = false;
            error();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                errorProvider1.SetError(textBox2, "Please Enter the Password.");
            }

            if (textBox1.Text == "" && textBox2.Text == "")
            {
                button1.Visible = false;
            }
            else
            {
                button1.Visible = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Please Enter the Username.");
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                errorProvider1.SetError(textBox1, "Please Enter the Username.");
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
                errorProvider1.SetError(textBox2, "Please Enter the Password.");
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
            }
        }

        private void error()
        {
            errorProvider1.SetError(textBox1, "Please Enter the Username.");
            errorProvider1.SetError(textBox2, "Please Enter the Password.");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword fp = new ForgotPassword();
            fp.Show();
            this.Hide();
        }
    }
}

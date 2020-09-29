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
    public partial class ForgotPassword : Form
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void ForgotPassword_Load(object sender, EventArgs e)
        {
            button2.Visible = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            error();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE LOGIN SET PASSWORD='" + textBox2.Text + "' WHERE USERNAME='" + textBox1.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Password Changed Successfully");
                Login lp = new Login();
                lp.Show();
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
            button2.Visible = false;
            error();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label2.Visible = false;
                errorProvider1.SetError(textBox1, "Please Enter the Username.");
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }

            SqlConnection con = new SqlConnection(conn);
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) From LOGIN Where USERNAME = '" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (int.Parse(dt.Rows[0][0].ToString()) == 0)
            {
                label2.Text = textBox1.Text + " not Available";
                this.label2.ForeColor = System.Drawing.Color.Red;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                if (textBox1.Text == "")
                {
                    label2.Text = "";
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                }
                else
                {
                    label2.Visible = true;
                }
            }
            else
            {
                label2.Text = textBox1.Text + " Available";
                this.label2.ForeColor = System.Drawing.Color.Green;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                if (textBox1.Text == "")
                {
                    label2.Text = "";
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                }
                else
                {
                    label2.Visible = true;
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                errorProvider1.SetError(textBox2, "Please Enter the Password.");
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                errorProvider1.SetError(textBox3, "Please Confirm the Password.");
            }
            else
            {
                errorProvider1.SetError(textBox3, "");
            }

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                button2.Visible = true;
            }
            else
            {
                button2.Visible = false;
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

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (textBox3.Text == string.Empty)
            {
                errorProvider1.SetError(textBox3, "Please Confirm the Password.");
            }
            else
            {
                errorProvider1.SetError(textBox3, "");
            }
        }

        private void error()
        {
            errorProvider1.SetError(textBox1, "Please Enter the Username.");
            errorProvider1.SetError(textBox2, "Please Enter the Password.");
            errorProvider1.SetError(textBox3, "Please Confirm your Password.");
        }

        private void ForgotPassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login lp = new Login();
            lp.Show();
            this.Hide();
        }
    }
}

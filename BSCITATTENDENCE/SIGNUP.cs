using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace BSCITATTENDENCE
{
    public partial class SIGNUP : Form
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        public SIGNUP()
        {
            InitializeComponent();
            button2.Visible = false;
            label13.Visible = false;
            error();
        }

        private void SIGNUP_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoginPage lp = new LoginPage();
            lp.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Please Enter the Username.");
            }

            SqlConnection con = new SqlConnection(conn);
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) From LOGIN Where USERNAME = '" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (int.Parse(dt.Rows[0][0].ToString()) == 0)
            {
                label12.Text = textBox1.Text + " Available";
                this.label12.ForeColor = System.Drawing.Color.Green;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                if (textBox1.Text == "")
                {
                    label12.Text = "";
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                }
                else
                {
                    label12.Visible = true;
                }
            }
            else
            {
                label12.Text = textBox1.Text + " not Available";
                this.label12.ForeColor = System.Drawing.Color.Red;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                if (textBox1.Text == "")
                {
                    label12.Text = "";
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                }
                else
                {
                    label12.Visible = true;
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label12.ForeColor == System.Drawing.Color.Green)
            {
                if (textBox2.Text == textBox3.Text)
                {
                    SqlConnection con = new SqlConnection(conn);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO LOGIN (USERNAME, PASSWORD, Name, Gender, ContactNumber, EmailId, DateOfJoining, Address, Qualification, PastExperiences, CurrentClassCourse, Status) VALUES ('"+textBox1.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+comboBox2.Text+"','"+textBox5.Text+"','"+textBox6.Text+"','"+dateTimePicker1.Text+"','"+textBox7.Text+"','"+textBox8.Text+"','"+textBox9.Text+"','"+comboBox1.Text+"', '"+label13.Text+"')", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registration Request Send to Admin Successfully");
                    LoginPage lp = new LoginPage();
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
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            comboBox1.SelectedIndex = -1;
            error();
        }

        private void SIGNUP_Load(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            textBox3.Enabled = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && comboBox1.Text != "" && comboBox2.Text != "")
            {
                button2.Visible = true;
            }
            else
            {
                button2.Visible = false;
            }

            if (textBox3.Text == "")
            {
                errorProvider1.SetError(textBox3, "Please Confirm the password");
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
                errorProvider1.SetError(textBox3, "Please Confirm the Password");
            }
            else
            {
                errorProvider1.SetError(textBox3, "");
            }
        }

        private void error()
        {
            errorProvider1.SetError(textBox4, "Please Enter the Name of the Staff.");
            errorProvider1.SetError(textBox5, "Please Enter the Contact Number of the Staff.");
            errorProvider1.SetError(textBox6, "Please Enter the Email Address of the Staff.");
            errorProvider1.SetError(textBox7, "Please Enter the Address of the Staff.");
            errorProvider1.SetError(textBox8, "Please Enter the Qualification of the Staff.");
            errorProvider1.SetError(textBox9, "Please Enter the Past Experiences of the Staff.");
            errorProvider1.SetError(comboBox1, "Please Enter the Current ClassCourse of the Staff.");
            errorProvider1.SetError(textBox1, "Please Enter the Username.");
            errorProvider1.SetError(textBox2, "Please Enter the Password.");
            errorProvider1.SetError(textBox3, "Please Confirm the Password");
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (textBox4.Text == string.Empty)
            {
                errorProvider1.SetError(textBox4, "Please Enter the Name of the Staff.");
            }
            else
            {
                errorProvider1.SetError(textBox4, "");
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (textBox5.Text == string.Empty)
            {
                errorProvider1.SetError(textBox5, "Please Enter the Contact Number of the Staff.");
            }
            else
            {
                errorProvider1.SetError(textBox5, "");
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (textBox6.Text == string.Empty)
            {
                errorProvider1.SetError(textBox6, "Please Enter the Email Address of the Staff.");
            }
            else
            {
                errorProvider1.SetError(textBox6, "");
            }

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(textBox6.Text);
            if (match.Success)
                errorProvider1.SetError(textBox6, "");
            else
                errorProvider1.SetError(textBox6, "Please Enter a Valid Email Address");
        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            if (textBox7.Text == string.Empty)
            {
                errorProvider1.SetError(textBox7, "Please Enter the Address of the Staff.");
            }
            else
            {
                errorProvider1.SetError(textBox7, "");
            }
        }

        private void textBox8_Validating(object sender, CancelEventArgs e)
        {
            if (textBox8.Text == string.Empty)
            {
                errorProvider1.SetError(textBox8, "Please Enter the Qualification of the Staff.");
            }
            else
            {
                errorProvider1.SetError(textBox8, "");
            }
        }

        private void textBox9_Validating(object sender, CancelEventArgs e)
        {
            if (textBox9.Text == string.Empty)
            {
                errorProvider1.SetError(textBox9, "Please Enter the Past Experiences of the Staff.");
            }
            else
            {
                errorProvider1.SetError(textBox9, "");
            }
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox1.Text == string.Empty)
            {
                errorProvider1.SetError(comboBox1, "Please Enter the Current ClassCourse of the Staff.");
            }
            else
            {
                errorProvider1.SetError(comboBox1, "");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                errorProvider1.SetError(textBox4, "Please Enter the Name of the Staff.");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                errorProvider1.SetError(textBox5, "Please Enter the Contact Number of the Staff.");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                errorProvider1.SetError(textBox6, "Please Enter the Email Address of the Staff.");
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                errorProvider1.SetError(textBox7, "Please Enter the Address of the Staff.");
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                errorProvider1.SetError(textBox8, "Please Enter the Qualification of the Staff.");
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
            {
                errorProvider1.SetError(textBox9, "Please Enter the Past Expereinces of the Staff.");
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                errorProvider1.SetError(comboBox1, "Please Enter the Current ClassCourse of the Staff.");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                errorProvider1.SetError(textBox2, "Please Enter the Password");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == "Male")
            {
                textBox4.Text = "Mr.";
            }
            else if (comboBox2.SelectedItem == "Female")
            {
                textBox4.Text = "Miss./Mrs.";
            }
        }
    }
}

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
    public partial class loginapprovalandstaffupdate : Form
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        public loginapprovalandstaffupdate()
        {
            InitializeComponent();
        }

        private void loginapprovalandstaffupdate_Load(object sender, EventArgs e)
        {
            label13.Text = LoginPage.passingText;

            SqlConnection con = new SqlConnection(conn);   
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select Name from LOGIN", con);
            SqlDataReader reader;
            reader = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Name", typeof(string));
            dt1.Load(reader);

            comboBox3.DisplayMember = "Name";
            comboBox3.DataSource = dt1;
            con.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = comboBox3.SelectedValue.ToString();

            button1.Visible = true;
            button2.Visible = true;

            SqlConnection con = new SqlConnection(conn);
            string query = "select * from LOGIN where Name = '" + comboBox3.Text + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dbr;
            try
            {
                con.Open();
                dbr = cmd.ExecuteReader();
                while (dbr.Read())
                {
                    string username = (string)dbr["USERNAME"].ToString();
                    string password = (string)dbr["PASSWORD"].ToString();
                    string gender = (string)dbr["Gender"].ToString();
                    string contactnumber = (string)dbr["ContactNumber"].ToString();
                    string email = (string)dbr["EmailId"].ToString();
                    string doj = (string)dbr["DateOfJoining"].ToString();
                    string address = (string)dbr["Address"].ToString();
                    string qualification = (string)dbr["Qualification"].ToString();
                    string status = (string)dbr["Status"].ToString();
                    string pastexp = (string)dbr["PastExperiences"].ToString();
                    string classcourse = (string)dbr["CurrentClassCourse"].ToString();
                    textBox1.Text = username;
                    textBox2.Text = password;
                    textBox3.Text = password;
                    comboBox4.Text = gender;
                    textBox5.Text = contactnumber;
                    textBox6.Text = email;
                    dateTimePicker1.Text = doj;
                    textBox7.Text = address;
                    textBox8.Text = qualification;
                    comboBox2.Text = status;
                    textBox9.Text = pastexp;
                    comboBox1.Text = classcourse;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE LOGIN SET USERNAME ='"+textBox1.Text+"', PASSWORD ='"+textBox3.Text+"', Gender='"+comboBox4.Text+"', ContactNumber ='"+textBox5.Text+"', EmailId ='"+textBox6.Text+"', DateOfJoining='"+dateTimePicker1.Text+"', Address ='"+textBox7.Text+"', Qualification ='"+textBox8.Text+"', PastExperiences ='"+textBox9.Text+"', CurrentClassCourse ='"+comboBox1.Text+"', Status ='"+comboBox2.Text+"' WHERE Name='"+comboBox3.Text+"'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Details Updated Successfully");
                AdminSection admin = new AdminSection();
                admin.Show();
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
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            error();
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

        private void textBox5_Validated(object sender, EventArgs e)
        {

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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                button1.Visible = true;
                button2.Visible = true;
            }
            else
            {
                button1.Visible = false;
                button2.Visible = false;
            }

            if (textBox5.Text == "")
            {
                errorProvider1.SetError(textBox5, "Please Enter the Contact Number of the Staff.");
            }
            else
            {
                errorProvider1.SetError(textBox5, "");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                button1.Visible = true;
                button2.Visible = true;
            }
            else
            {
                button1.Visible = false;
                button2.Visible = false;
            }

            if (textBox6.Text == "")
            {
                errorProvider1.SetError(textBox6, "Please Enter the Email Address of the Staff.");
            }
            else
            {
                errorProvider1.SetError(textBox6, "");
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text != "")
            {
                button1.Visible = true;
                button2.Visible = true;
            }
            else
            {
                button1.Visible = false;
                button2.Visible = false;
            }

            if (textBox7.Text == "")
            {
                errorProvider1.SetError(textBox7, "Please Enter the Address of the Staff.");
            }
            else
            {
                errorProvider1.SetError(textBox7, "");
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text != "")
            {
                button1.Visible = true;
                button2.Visible = true;
            }
            else
            {
                button1.Visible = false;
                button2.Visible = false;
            }

            if (textBox8.Text == "")
            {
                errorProvider1.SetError(textBox8, "Please Enter the Qualification of the Staff.");
            }
            else
            {
                errorProvider1.SetError(textBox8, "");
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox9.Text != "")
            {
                button1.Visible = true;
                button2.Visible = true;
            }
            else
            {
                button1.Visible = false;
                button2.Visible = false;
            }

            if (textBox9.Text == "")
            {
                errorProvider1.SetError(textBox9, "Please Enter the Past Expereinces of the Staff.");
            }
            else
            {
                errorProvider1.SetError(textBox9, "");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                button1.Visible = true;
                button2.Visible = true;
            }
            else
            {
                button1.Visible = false;
                button2.Visible = false;
            }

            if (textBox1.Text == "")
            {
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
                label12.Text = textBox1.Text + " Available";
                this.label12.ForeColor = System.Drawing.Color.Green;
                if (textBox1.Text == "")
                {
                    label12.Text = "";
                }
            }
            else
            {
                label12.Text = textBox1.Text + " not Available";
                this.label12.ForeColor = System.Drawing.Color.Red;
                if (textBox1.Text == "")
                {
                    label12.Text = "";
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                button1.Visible = true;
                button2.Visible = true;
            }
            else
            {
                button1.Visible = false;
                button2.Visible = false;
            }

            if (textBox2.Text == "")
            {
                errorProvider1.SetError(textBox2, "Please Enter the Password");
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                button1.Visible = true;
                button2.Visible = true;
            }
            else
            {
                button1.Visible = false;
                button2.Visible = false;
            }

            if (textBox3.Text == "")
            {
                errorProvider1.SetError(textBox3, "Please Confirm the password");
            }
            else
            {
                errorProvider1.SetError(textBox3, "");
            }
        }

        private void error()
        {
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

        private void loginapprovalandstaffupdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            AdminSection admin = new AdminSection();
            admin.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("Delete from LOGIN WHERE Name='" + comboBox3.Text + "'", con);
            cmd.CommandType = CommandType.Text;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Details Deleted Successfully");
                AdminSection admin = new AdminSection();
                admin.Show();
                this.Hide();
                Clear();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == "ADMIN")
            {
                textBox2.PasswordChar = '\0';
                textBox3.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
                textBox3.PasswordChar = '*';
            }

        }

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text != "")
            {
                button1.Visible = true;
                button2.Visible = true;
            }
            else
            {
                button1.Visible = false;
                button2.Visible = false;
            }
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text != "")
            {
                button1.Visible = true;
                button2.Visible = true;
            }
            else
            {
                button1.Visible = false;
                button2.Visible = false;
            }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                button1.Visible = true;
                button2.Visible = true;
            }
            else
            {
                button1.Visible = false;
                button2.Visible = false;
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                button1.Visible = true;
                button2.Visible = true;
            }
            else
            {
                button1.Visible = false;
                button2.Visible = false;
            }
        }
    }
}

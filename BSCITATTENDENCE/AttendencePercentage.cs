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
    public partial class AttendencePercentage : Form
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        public AttendencePercentage()
        {
            InitializeComponent();
            error();
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
        }

        private void AttendencePercentage_Load(object sender, EventArgs e)
        {
            label9.Text = LoginPage.passingText;
            textBox3.Text = AttendenceRecord.number;
            textBox4.Text = AttendenceRecord.ClassCourse;
            textBox1.Text = AttendenceRecord.RollNo;
            button1.Visible = false;
            label8.Visible = false;
        }

        private void AttendencePercentage_FormClosed(object sender, FormClosedEventArgs e)
        {
            AttendenceRecord ar = new AttendenceRecord();
            ar.Show();
            this.Hide();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            /*string query = "select * from AddStudents where ClassCourse = '" + textBox4.Text + "' AND  RollNo='" + textBox1.Text + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dbr;
            try
            {
                con.Open();
                dbr = cmd.ExecuteReader();
                while (dbr.Read())
                {
                    string sn = (string)dbr["NameofStudent"].ToString();
                    textBox2.Text = sn;
                    button1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();

            if (textBox1.Text == "" || textBox4.Text == null)
            {
                textBox2.Text = "";
            }*/
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("INSERT INTO StudentMonthlyAttendence (ClassCourse, RollNo, NameofStudent, DaysPresent, Month, MonthDays, AttendencePercentage, MonthYear, CalculatedBy) Values ('"+textBox4.Text+"','"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+comboBox2.Text+"','"+label8.Text+"','"+textBox5.Text+"','"+dateTimePicker1.Text+"','"+label9.Text+"')", con);
            cmd.CommandType = CommandType.Text;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student Monthly Attendence Percentage Added Successfully...");
                Clear();
                AttendenceRecord ar = new AttendenceRecord();
                ar.Show();
                this.Hide();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox2.SelectedIndex = -1;
            textBox5.Text = "";
            textBox4.Text = "";
            error();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            string query = "select * from AddStudents where ClassCourse = '" + textBox4.Text + "' AND  RollNo='" + textBox1.Text + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dbr;
            try
            {
                con.Open();
                dbr = cmd.ExecuteReader();
                while (dbr.Read())
                {
                    string sn = (string)dbr["NameofStudent"].ToString();
                    textBox2.Text = sn;
                    button1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();

            if (textBox1.Text == "" || textBox4.Text == null)
            {
                textBox2.Text = "";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                button1.Visible = false;
            }


            if (comboBox2.SelectedItem == "January")
            {
                label8.Text = "31";
                button1.Visible = true;
            }

            if (comboBox2.SelectedItem == "February")
            {
                label8.Text = "28";
                button1.Visible = true;
            }

            if (comboBox2.SelectedItem == "February (LEAP YEAR)")
            {
                label8.Text = "29";
                button1.Visible = true;
            }

            if (comboBox2.SelectedItem == "March")
            {
                label8.Text = "31";
                button1.Visible = true;
            }

            if (comboBox2.SelectedItem == "April")
            {
                label8.Text = "30";
                button1.Visible = true;
            }

            if (comboBox2.SelectedItem == "May")
            {
                label8.Text = "31";
                button1.Visible = true;
            }

            if (comboBox2.SelectedItem == "June")
            {
                label8.Text = "30";
                button1.Visible = true;
            }

            if (comboBox2.SelectedItem == "July")
            {
                label8.Text = "31";
                button1.Visible = true;
            }

            if (comboBox2.SelectedItem == "August")
            {
                label8.Text = "31";
                button1.Visible = true;
            }

            if (comboBox2.SelectedItem == "September")
            {
                label8.Text = "30";
                button1.Visible = true;
            }

            if (comboBox2.SelectedItem == "October")
            {
                label8.Text = "31";
                button1.Visible = true;
            }

            if (comboBox2.SelectedItem == "November")
            {
                label8.Text = "30";
                button1.Visible = true;
            }

            if (comboBox2.SelectedItem == "December")
            {
                label8.Text = "31";
                button1.Visible = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void comboBox2_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox2.Text == string.Empty)
            {
                errorProvider1.SetError(comboBox2, "Please Select the Month of Attendence.");
            }
            else
            {
                errorProvider1.SetError(comboBox2, "");
            }
        }

        private void error()
        {
            errorProvider1.SetError(comboBox2, "Please Select the Month of Attendence.");
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            double days = double.Parse(textBox3.Text);
            double monthdays = double.Parse(label8.Text);
            double per = days / monthdays * 100;
            textBox5.Text = per.ToString();
        }
    }
}

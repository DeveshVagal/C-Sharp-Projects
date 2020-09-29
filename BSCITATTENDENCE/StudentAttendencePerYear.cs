using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BSCITATTENDENCE
{
    public partial class StudentAttendencePerYear : Form
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        public StudentAttendencePerYear()
        {
            InitializeComponent();
            button1.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void StudentAttendencePerYear_FormClosed(object sender, FormClosedEventArgs e)
        {
            AttendenceRecord ar = new AttendenceRecord();
            ar.Show();
            this.Hide();
        }

        private void StudentAttendencePerYear_Load(object sender, EventArgs e)
        {
            label9.Text = LoginPage.passingText;
            textBox4.Text = AttendenceRecord.ClassCourse;
            textBox1.Text = AttendenceRecord.RollNo;
            textBox6.Text = AttendenceRecord.number;
            textBox5.Text = AttendenceRecord.noofstudents;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            string query = "select * from AddStudents where ClassCourse='"+textBox4.Text+"' and RollNo='"+textBox1.Text+"'";
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("INSERT INTO StudentYearlyAttendence (ClassCourse, RollNo, NameofStudent, NoOfAttendence, NoOfWorkingDays, AttendencePercentage, Year, CalculatedBy) VALUES ('"+textBox4.Text+"','"+textBox1.Text+"','"+textBox2.Text+"','"+textBox6.Text+"','"+textBox5.Text+"','"+textBox3.Text+"','"+dateTimePicker1.Text+"','"+label9.Text+"')", con);
            cmd.CommandType = CommandType.Text;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student Yearly Attendence Percentage Added Successfully...");
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

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            string query = "select * from AddStudents where ClassCourse='" + textBox4.Text + "' and RollNo='" + textBox1.Text + "'";
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
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            double presentdays = double.Parse(textBox6.Text);
            double workingdays = double.Parse(textBox5.Text);
            double per = presentdays / workingdays * 100;
            textBox3.Text = per.ToString();
        }
    }
}

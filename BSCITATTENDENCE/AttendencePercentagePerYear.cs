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
    public partial class AttendencePercentagePerYear : Form
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        public AttendencePercentagePerYear()
        {
            InitializeComponent();
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
        }

        private void AttendencePercentagePerYear_Load(object sender, EventArgs e)
        {
            label9.Text = LoginPage.passingText;
            textBox1.Text = AttendenceRecord.number;
            textBox4.Text = AttendenceRecord.ClassCourse;
            textBox2.Text = AttendenceRecord.noofstudents;
        }

        private void AttendencePercentagePerYear_FormClosed(object sender, FormClosedEventArgs e)
        {
            AttendenceRecord ar = new AttendenceRecord();
            ar.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            double presentdays = double.Parse(textBox1.Text);
            double workingdays = double.Parse(textBox2.Text);
            double per = presentdays / workingdays * 100;
            textBox3.Text = per.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("INSERT INTO ClassAttendencePerYear (ClassCourse, NoOfAttendence, NoOfDaysWorking, AttendencePercentage, Year, CalculatedBy) VALUES ('"+textBox4.Text+"','"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+dateTimePicker1.Text+"','"+label9.Text+"')", con);
            cmd.CommandType = CommandType.Text;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Attendence Percentage for year"+dateTimePicker1.Text+ "Added Successfully...");
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

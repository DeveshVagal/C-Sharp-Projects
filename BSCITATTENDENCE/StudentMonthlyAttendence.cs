using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DGVPrinterHelper;

namespace BSCITATTENDENCE
{
    public partial class StudentMonthlyAttendence : Form
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        public StudentMonthlyAttendence()
        {
            InitializeComponent();
            error();
            BindData();
        }

        private void StudentMonthlyAttendence_Load(object sender, EventArgs e)
        {
            label4.Text = LoginPage.passingText;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            string query = "Select * from StudentMonthlyAttendence where ClassCourse='" + comboBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        void BindData()
        {
            SqlConnection con = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("SELECT * FROM StudentMonthlyAttendence", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECt * from StudentMonthlyAttendence where ClassCourse='" + comboBox1.Text + "' and RollNo ='" + textBox1.Text + "'", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            if (textBox1.Text == "")
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("SELECt * from StudentMonthlyAttendence where ClassCourse='" + comboBox1.Text + "'", con);
                cmd1.CommandType = CommandType.Text;
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                dataGridView1.DataSource = dt1;
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dateTimePicker1.ResetText();
            textBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            error();

            SqlConnection con = new SqlConnection(conn);
            string query = "Select * from StudentMonthlyAttendence";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();

            printer.Title = "\r\n\r\n\r\n ABC College of Technology \r\n\r\n";
            printer.SubTitle = " STUDENT MONTHLY ATTENDENCE PERCENTAGE RECORD \r\n\n Date :" + DateTime.Now.ToLongDateString();
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.PrintDataGridView(dataGridView1);
        }

        private void StudentMonthlyAttendence_FormClosed(object sender, FormClosedEventArgs e)
        {
            AdminSection admin = new AdminSection();
            admin.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                errorProvider1.SetError(textBox1, "");
            }
            else
            {
                errorProvider1.SetError(textBox1, "Please Enter the RollNo of the Student.");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            string query = "Select * from StudentMonthlyAttendence where Month='" + comboBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox1.Text == string.Empty)
            {
                errorProvider1.SetError(comboBox1, "Please Select the ClassCourse of the Student.");
            }
            else
            {
                errorProvider1.SetError(comboBox1, "");
            }
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

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                errorProvider1.SetError(textBox1, "Please Enter the RollNo of the Student.");
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void error()
        {
            errorProvider1.SetError(comboBox1, "Please Select the Class of the Student.");
            errorProvider1.SetError(textBox1, "Please Enter the RollNo of the Student.");
            errorProvider1.SetError(comboBox2, "Please Select the Month of Attendence.");
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                errorProvider1.SetError(comboBox1, "");
            }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                errorProvider1.SetError(comboBox2, "");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECt * from StudentMonthlyAttendence where MonthYear ='" + dateTimePicker1.Text + "'", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}

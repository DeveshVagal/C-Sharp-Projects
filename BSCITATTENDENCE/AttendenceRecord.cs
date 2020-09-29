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
    public partial class AttendenceRecord : Form
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        public static string number;
        public static string ClassCourse;
        public static string RollNo;
        public static string noofstudents;

        public AttendenceRecord()
        {
            InitializeComponent();
            error();
            BindData();
        }

        private void AttendenceRecord_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataView d = new DataView();
            d.Show();
            this.Hide();
        }

        private void AttendenceRecord_Load(object sender, EventArgs e)
        {
            label4.Text = LoginPage.passingText;
            label8.Visible = false;
            label10.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            string query = "Select * from AttendenceRecord where ClassCourse='" + comboBox1.Text + "'";
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
            SqlCommand cmd = new SqlCommand("SELECT * FROM AttendenceRecord", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECt * from AttendenceRecord where ClassCourse='"+comboBox1.Text+"' and RollNo ='" + textBox1.Text + "'", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            if (textBox1.Text == "")
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("SELECt * from AttendenceRecord where ClassCourse='" + comboBox1.Text + "'", con);
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
            dateTimePicker2.ResetText();
            label8.Text = "";
            textBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            error();

            SqlConnection con = new SqlConnection(conn);
            string query = "Select * from AttendenceRecord";
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
            printer.SubTitle = " ATTENDENCE RECORD \r\n\n Date :" + DateTime.Now.ToLongDateString();
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.PrintDataGridView(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
            }

            label8.Text = sum.ToString();

            number = label8.Text;
            ClassCourse = comboBox1.Text;
            RollNo = textBox1.Text;

            AttendencePercentage ap = new AttendencePercentage();
            ap.Show();
            this.Hide();
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void dateTimePicker1_KeyUp(object sender, KeyEventArgs e)
        {
            

           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECt * from AttendenceRecord where Date ='" + dateTimePicker1.Value.ToLongDateString() + "'", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECt * from AttendenceRecord where Date between '" + dateTimePicker1.Value.ToLongDateString() + "' and '" + dateTimePicker2.Value.ToLongDateString() + "'", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox1.Text == string.Empty)
            {
                errorProvider1.SetError(comboBox1, "Please Select the Class of the Student.");
            }
            else
            {
                errorProvider1.SetError(comboBox1, "");
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
            errorProvider1.SetError(comboBox2, "Please Select the Type of Attendence.");
            errorProvider1.SetError(comboBox3, "Please Select the Type of Attendence.");
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                errorProvider1.SetError(comboBox1, "");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            string query = "Select * from AttendenceRecord where Attendence='" + comboBox2.Text + "' and ClassCourse='"+comboBox1.Text+"' and RollNo='"+textBox1.Text+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                errorProvider1.SetError(comboBox2, "");
            }
        }

        private void comboBox2_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox2.Text == string.Empty)
            {
                errorProvider1.SetError(comboBox2, "Please Select the Type of Attendence.");
            }
            else
            {
                errorProvider1.SetError(comboBox2, "");
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            string query = "Select * from AttendenceRecord where Attendence='" + comboBox3.Text + "' and ClassCourse='"+comboBox1.Text+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text != "")
            {
                errorProvider1.SetError(comboBox3, "");
            }
        }

        private void comboBox3_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox3.Text == string.Empty)
            {
                errorProvider1.SetError(comboBox3, "Please Select the Type of Attendence.");
            }
            else
            {
                errorProvider1.SetError(comboBox3, "");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int count = dataGridView1.RowCount;
            label10.Text = count.ToString();

            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
            }

            label8.Text = sum.ToString();


            ClassCourse = comboBox1.Text;
            number = label8.Text;
            noofstudents = label10.Text;

            AttendencePercentagePerYear appy = new AttendencePercentagePerYear();
            appy.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int count = dataGridView1.RowCount;
            label10.Text = count.ToString();

            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
            }

            label8.Text = sum.ToString();

            ClassCourse = comboBox1.Text;
            RollNo = textBox1.Text;
            number = label8.Text;
            noofstudents = label10.Text;

            StudentAttendencePerYear sapy = new StudentAttendencePerYear();
            sapy.Show();
            this.Hide();
        }
    }
}

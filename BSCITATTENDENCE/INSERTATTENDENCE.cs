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
    public partial class INSERTATTENDENCE : Form
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        public INSERTATTENDENCE()
        {
            InitializeComponent();
            error();
            button1.Visible = false;
        }

        private void INSERTATTENDENCE_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label4.Text = LoginPage.passingText;
            label8.Text = DateTime.Now.ToLongDateString();
            label9.Text = DateTime.Now.ToLongTimeString();
            button1.Visible = false;
            label7.Visible = false;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'P')
            {
                textBox3.Text = "PRESENT";
                label7.Text = "1";
            }
            else if (e.KeyChar == 'p')
            {
                textBox3.Text = "PRESENT";
                label7.Text = "1";
            }
            else if (e.KeyChar == 'A')
            {
                textBox3.Text = "ABSENT";
                label7.Text = "0";
            }
            else if (e.KeyChar == 'a')
            {
                textBox3.Text = "ABSENT";
                label7.Text = "0";
            }
            else if (e.KeyChar == 'c')
            {
                textBox3.Text = "";
                label7.Text = "";
            }
            else if (e.KeyChar == 'C')
            {
                textBox3.Text = "";
                label7.Text = "";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void INSERTATTENDENCE_FormClosed(object sender, FormClosedEventArgs e)
        {
            attendencemenu aa = new attendencemenu();
            aa.Show();
            this.Hide();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            string query = "select * from AddStudents where ClassCourse = '" + comboBox1.Text + "' AND  RollNo='"+textBox1.Text+"' ";
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

            if (textBox1.Text == "" || comboBox1.Text==null)
            {
                textBox2.Text = "";
                button1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("INSERT INTO AttendenceRecord (ClassCourse, RollNo, NameofStudent, Attendence, Number, Date, Time, AddedBy) VALUES ('"+comboBox1.Text+"','"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+label7.Text+"','"+label8.Text+"','"+label9.Text+"','"+label4.Text+"')", con);
            cmd.CommandType = CommandType.Text;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Attendence Recorded Successfully");
                clear();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            textBox1.Focus();
        }

        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            label7.Text = "";
            error();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && textBox1.Text != "" && textBox3.Text != "")
            {
                button1.Visible = true;
            }
            else
            {
                button1.Visible = false;
            }
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox1.Text == string.Empty)
            {
                errorProvider1.SetError(comboBox1, "Please Select the class of the Student.");
            }
            else
            {
                errorProvider1.SetError(comboBox1, "");
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

        private void error()
        {
            errorProvider1.SetError(comboBox1, "Please Select the class of the Student.");
            errorProvider1.SetError(textBox1, "Please Enter the RollNo of the Student.");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                textBox3.Focus();
            }
        }
    }
}

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
    public partial class AddingStudents : Form
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        
        public AddingStudents()
        {
            InitializeComponent();
            error();
        }

        private void AddingStudents_Load(object sender, EventArgs e)
        {
            label4.Text = LoginPage.passingText;
            button1.Visible = false;
            label6.Visible = false;
        }

        private void AddingStudents_FormClosed(object sender, FormClosedEventArgs e)
        {
            menunew mn = new menunew();
            mn.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("INSERT INTO AddStudents (ClassCourse, RollNo, NameofStudent, AddedBy) VALUES ('"+comboBox1.Text+"','"+textBox1.Text+"','"+textBox2.Text+"','"+label4.Text+"')", con);
            cmd.CommandType = CommandType.Text;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student Added Successfully");
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
            error();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "")
            {
                button1.Visible = true;
            }
            else
            {
                button1.Visible = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

            if (textBox1.Text == "")
            {
                label6.Visible = false;
            }
            else
            {
                label6.Visible = true;
            }

            SqlConnection con = new SqlConnection(conn);
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) From AddStudents Where RollNo = '" + textBox1.Text + "' and ClassCourse='"+comboBox1.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (int.Parse(dt.Rows[0][0].ToString()) == 0)
            {
                label6.Text = textBox1.Text + "  has not been Allocated.";
                this.label6.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label6.Text = textBox1.Text + "  has been Allocated.";
                this.label6.ForeColor = System.Drawing.Color.Red;
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                errorProvider1.SetError(textBox2, "Please Enter the Name of the Student.");
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
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

        private void error()
        {
            errorProvider1.SetError(comboBox1, "Please Select the Class of the Student.");
            errorProvider1.SetError(textBox1, "Please Enter the RollNo of the Student.");
            errorProvider1.SetError(textBox2, "Please Enter the Name of the Student.");
        }
    }
}

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
    public partial class ScreenTemperatureRecord : Form
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        public ScreenTemperatureRecord()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked == true)
            {
                label3.Text = "Male";
                textBox1.Text = "Mr. ";
            }
            else
            {
                radioButton1.Checked = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton2.Checked == true)
            {
                label3.Text = "Female";
                textBox1.Text = "Mrs./Miss. ";
            }
            else
            {
                radioButton2.Checked = false;
            }
        }

        private void ScreenTemperatureRecord_Load(object sender, EventArgs e)
        {
            error();
            button1.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label3.Visible = false;
            timer1.Start();
            label7.Text = DateTime.Now.ToLongDateString();
            label8.Text = DateTime.Now.ToLongTimeString();
            label9.Text = Login.passingtext;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label8.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO ScreeningTemperatureRecord (FlatNo, Name, Age, Gender, ScreeningTemprature, PulseRate, ScreeningDate, ScreeningTime, CalculatedBy, AddedBy) VALUES ('"+textBox6.Text+"','"+textBox1.Text+"','"+textBox2.Text+"','"+label3.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+label7.Text+"','"+label8.Text+"','"+textBox5.Text+"','"+label9.Text+"')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Inserted Successfully");
                con.Close();
                Clear();
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
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                errorProvider1.SetError(textBox1, "Please Enter the Name.");
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
                errorProvider1.SetError(textBox2, "Please Enter the Age.");
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
                errorProvider1.SetError(textBox3, "Please Enter the Screening Temperature.");
            }
            else
            {
                errorProvider1.SetError(textBox3, "");
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (textBox4.Text == string.Empty)
            {
                errorProvider1.SetError(textBox4, "Please Enter the Pulse Rate.");
            }
            else
            {
                errorProvider1.SetError(textBox4, "");
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (textBox5.Text == string.Empty)
            {
                errorProvider1.SetError(textBox5, "Please Enter the Name of the person who Calculated the Screening Temperature & Pluse Rate.");
            }
            else
            {
                errorProvider1.SetError(textBox5, "");
            }
        }

        private void error()
        {
            errorProvider1.SetError(textBox1, "Please Enter the Name.");
            errorProvider1.SetError(textBox2, "Please Enter the Age.");
            errorProvider1.SetError(textBox3, "Please Enter the Screening Temperature.");
            errorProvider1.SetError(textBox4, "Please Enter the Pulse Rate.");
            errorProvider1.SetError(textBox5, "Please Enter the Name of the person who Calculated the Screening Temperature & Pluse Rate.");
            errorProvider1.SetError(textBox6, "Please Enter the Flat No.");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Please Enter the Name.");
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                errorProvider1.SetError(textBox2, "Please Enter the Age.");
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
                errorProvider1.SetError(textBox3, "Please Enter the Screening Temperature.");
            }
            else
            {
                errorProvider1.SetError(textBox3, "");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                errorProvider1.SetError(textBox4, "Please Enter the Pulse Rate.");
            }
            else
            {
                errorProvider1.SetError(textBox4, "");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                errorProvider1.SetError(textBox5, "Please Enter the Name of the person who Calculated the Screening Temperature & Pluse Rate.");
            }
            else
            {
                errorProvider1.SetError(textBox5, "");
            }

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                button1.Visible = true;
            }
            else
            {
                button1.Visible = false;
            }
        }

        private void ScreenTemperatureRecord_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                errorProvider1.SetError(textBox6, "Please Enter the Flat No.");
            }
            else
            {
                errorProvider1.SetError(textBox6, "");
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (textBox6.Text == string.Empty)
            {
                errorProvider1.SetError(textBox6, "Please Enter the Flat No.");
            }
            else
            {
                errorProvider1.SetError(textBox6, "");
            }
        }
    }
}

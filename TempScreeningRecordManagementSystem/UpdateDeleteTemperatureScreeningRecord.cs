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
    public partial class UpdateDeleteTemperatureScreeningRecord : Form
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        public UpdateDeleteTemperatureScreeningRecord()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label7_TextChanged(object sender, EventArgs e)
        {
            if (label7.Text == "Male")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else if (label7.Text == "Female")
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
            }
        }

        private void UpdateDeleteTemperatureScreeningRecord_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
            label7.Visible = false;

            label3.Text = DataofScreeningTemperatureRecord.id;
            textBox1.Text = DataofScreeningTemperatureRecord.name;
            textBox5.Text = DataofScreeningTemperatureRecord.flatno;
            textBox2.Text = DataofScreeningTemperatureRecord.Age;
            label7.Text = DataofScreeningTemperatureRecord.Gender;
            textBox3.Text = DataofScreeningTemperatureRecord.st;
            textBox4.Text = DataofScreeningTemperatureRecord.pr;
        }

        private void UpdateDeleteTemperatureScreeningRecord_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataofScreeningTemperatureRecord dostr = new DataofScreeningTemperatureRecord();
            dostr.Show();
            this.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label7.Text = "Male";

                if (textBox1.Text == "" || textBox1.Text == "Miss./Mrs. ")
                {
                    textBox1.Text = "Mr. ";
                }
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
                label7.Text = "Female";

                if (textBox1.Text == "" || textBox1.Text == "Mr. ")
                {
                    textBox1.Text = "Miss./Mrs. ";
                }
            }
            else
            {
                radioButton2.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("UPDATE ScreeningTemperatureRecord SET FlatNo = '"+textBox5.Text+"', Name ='"+textBox1.Text+"', Age ='"+textBox2.Text+"', Gender ='"+label7.Text+"', ScreeningTemprature ='"+textBox3.Text+"', PulseRate ='"+textBox4.Text+"' WHERE id='"+label3.Text+"'", con);
            cmd.CommandType = CommandType.Text;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                DataofScreeningTemperatureRecord dostr = new DataofScreeningTemperatureRecord();
                dostr.Show();
                this.Hide();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("Delete from ScreeningTemperatureRecord WHERE id='"+label3.Text+"'", con);
            cmd.CommandType = CommandType.Text;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Deleted Successfully");
                DataofScreeningTemperatureRecord dostr = new DataofScreeningTemperatureRecord();
                dostr.Show();
                this.Hide();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                errorProvider1.SetError(textBox5, "Please Enter the Flat No.");
            }
            else
            {
                errorProvider1.SetError(textBox5, "");
            }
        }
    }
}

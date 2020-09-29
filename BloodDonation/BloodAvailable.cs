using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BloodDonation
{
    public partial class BloodAvailable : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=EXCELANCE\SQLEXPRESS;Initial Catalog=BloodDonation;Integrated Security=True");

        public BloodAvailable()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE BloodAvailable SET CostPerUnit='" + textBox1.Text + "' WHERE BloodGroup='" + comboBox4.Text + "'", con);
            cmd.CommandType = CommandType.Text;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully");
                Clear();
                con.Close();

            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
            }
        }

        private void Clear()
        {
            comboBox4.SelectedIndex = -1;
            textBox1.Text = "";
            textBox3.Text = "";
            error();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            RecordsList rl = new RecordsList();
            rl.Show();
            this.Hide();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=EXCELANCE\SQLEXPRESS;Initial Catalog=BloodDonation;Integrated Security=True");
            string query = "select * from BloodAvailable where BloodGroup = '" + comboBox4.Text + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dbr;
            try
            {
                con.Open();
                dbr = cmd.ExecuteReader();
                while (dbr.Read())
                {
                    string ua = (string)dbr["UnitsAvailable"].ToString();
                    string cpu = (string)dbr["CostPerUnit"].ToString();
                    textBox3.Text = ua;
                    textBox1.Text = cpu;
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void error()
        {
            errorProvider1.SetError(comboBox4, "Please Select an Bloood Group");

        }

        private void comboBox4_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox4.Text == string.Empty)
            {
                errorProvider1.SetError(comboBox4, "Please Select an Bloood Group");
            }
            else
            {
                errorProvider1.SetError(comboBox4, "");
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void BloodAvailable_Load(object sender, EventArgs e)
        {
            error();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && textBox1.Text.Length == 10)
            {
                e.Handled = true;
                errorProvider1.SetError(textBox1, "");
            }
            else
            {
                errorProvider1.SetError(textBox1, "Invalid Number");
            }
        }

        
    }
}

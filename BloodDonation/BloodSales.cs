using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BloodDonation
{
    public partial class BloodSales : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=EXCELANCE\SQLEXPRESS;Initial Catalog=BloodDonation;Integrated Security=True");


        public BloodSales()
        {
            InitializeComponent();
            label4.Visible = false;
            label7.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label13.Visible = false;
        }

        private void BloodSales_Load(object sender, EventArgs e)
        {
            error();
            label6.Text = DateTime.Now.ToLongDateString();
            

            con.Open();
            SqlCommand cmd = new SqlCommand("select PatientName from HospitalDetails", con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("PatientName", typeof(string));
            dt.Load(reader);

            comboBox1.DisplayMember = "PatientName";
            comboBox1.DataSource = dt;
            con.Close();

            con.Open();
            SqlCommand cmd1 = new SqlCommand("select NameOfHospital from HospitalDetails", con);
            SqlDataReader reader1;
            reader1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("NameOfHospital", typeof(string));
            dt1.Load(reader1);

            comboBox2.DisplayMember = "NameOfHospital";
            comboBox2.DataSource = dt1;
            con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Choose c = new Choose();
            c.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = comboBox1.SelectedValue.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = comboBox2.SelectedValue.ToString();
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
      /*    if (Convert.ToInt32(textBox2.Text) > Convert.ToInt32(textBox3.Text))
          {
              MessageBox.Show("Required Units Not Available");
              textBox2.Text = "";
          }
        else
          {
              
          }*/

            if (textBox2.Text == "")
            {
                textBox2.Text = "";
                textBox4.Text="";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
          /*  textBox3.Text = (Convert.ToInt32(textBox3.Text) - Convert.ToInt32(textBox2.Text)).ToString();
            textBox4.Text = (Convert.ToInt32(textBox1.Text) * Convert.ToInt32(textBox2.Text)).ToString();

            if (Convert.ToInt32(textBox2.Text) < 0 ||Convert.ToInt32(textBox2.Text) > Convert.ToInt32(textBox3.Text) )
            {
                MessageBox.Show("Required Units Not Available");
                textBox2.Text = "";
                textBox4.Text = "";
            }

            if (textBox2.Text == textBox3.Text)
            {
                textBox3.Text = "0";
            }

            SqlCommand cmd = new SqlCommand("UPDATE BloodAvailable SET UnitsAvailable ='" + textBox3.Text + "' WHERE BloodGroup='" + comboBox4.Text + "'", con);
            cmd.CommandType = CommandType.Text;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
            }*/
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string date, hn, ua, mystrdate, mystrhn, mystrua;

            date = label6.Text;
            hn = comboBox2.Text;
            ua = textBox3.Text;
            mystrdate = date.Substring(1, 5);
            mystrhn = hn.Substring(1, 2);
            mystrua = ua.Substring(0, 1);

            label5.Text = mystrdate + mystrhn + mystrua;

            if (textBox2.Text == "")
            {
                label5.Text = "";
                textBox3.Text = "";
                textBox1.Text = "";
                textBox4.Text = "";
                comboBox4.SelectedIndex = -1;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("INSERT INTO BloodSales (BillNo, Date, PatientName, HospitalName, BloodGroup, UnitsAvailable, CostPerUnit, UnitsSoled, TotalCost) VALUES ('"+label5.Text+"','"+label6.Text+"','"+comboBox1.Text+"','"+comboBox2.Text+"','"+comboBox4.Text+"','"+textBox3.Text+"','"+textBox1.Text+"','"+textBox2.Text+"','"+textBox4.Text+"')", con);
            cmd.CommandType = CommandType.Text;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Blood Sales Recorded Successfully");
                clear();
                con.Close();

            }
            catch (Exception ex)
            {
                label13.Text = ex.Message;
            }
        }

        private void clear()
        {
            comboBox1.ResetText();
            comboBox2.ResetText();
            comboBox4.SelectedIndex = -1;
            textBox3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            label5.Text = "";
            error();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox1.Text == string.Empty)
            {
                errorProvider1.SetError(comboBox1, "Please Select an Patient`s Name");
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
                errorProvider1.SetError(comboBox2, "Please Select an Doctor`s Name");
            }
            else
            {
                errorProvider1.SetError(comboBox2, "");
            }
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

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                errorProvider1.SetError(textBox2, "Please Enter Units Needed");
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void error()
        {
            errorProvider1.SetError(comboBox1, "Please Select an Patient`s Name");
            errorProvider1.SetError(comboBox2, "Please Select an Doctor`s Name");
            errorProvider1.SetError(comboBox4, "Please Select an Bloood Group");
            errorProvider1.SetError(textBox2, "Please Enter Units Needed");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = (Convert.ToInt32(textBox3.Text) - Convert.ToInt32(textBox2.Text)).ToString();
            textBox4.Text = (Convert.ToInt32(textBox1.Text) * Convert.ToInt32(textBox2.Text)).ToString();

            if (Convert.ToInt32(textBox2.Text) < 0 || Convert.ToInt32(textBox3.Text) < Convert.ToInt32(textBox2.Text))
            {
                MessageBox.Show("Required Units Not Available");
                textBox3.Text = "0";
            }

            if (textBox2.Text == textBox3.Text)
            {
                textBox3.Text = "0";
            }

            SqlCommand cmd = new SqlCommand("UPDATE BloodAvailable SET UnitsAvailable ='" + textBox3.Text + "' WHERE BloodGroup='" + comboBox4.Text + "'", con);
            cmd.CommandType = CommandType.Text;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
            }
        }
    }
}

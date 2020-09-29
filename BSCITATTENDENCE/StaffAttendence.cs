using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Speech.Synthesis;
using System.Speech.Recognition;

namespace BSCITATTENDENCE
{
    public partial class StaffAttendence : Form
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        public StaffAttendence()
        {
            InitializeComponent();
        }

        private void StaffAttendence_Load(object sender, EventArgs e)
        {
            label4.Text = LoginPage.passingText;
            timer1.Start();
            label9.Text = DateTime.Now.ToLongTimeString();
            label10.Text = DateTime.Now.ToString("D");
            label3.Visible = false;
            label6.Visible = false;
            label8.Visible = false;
            label7.Visible = false;
            label11.Visible = false;
        }

        private void StaffAttendence_FormClosed(object sender, FormClosedEventArgs e)
        {
            menunew mn = new menunew();
            mn.Show();
            this.Hide();
        }

        private void label4_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            string query = "select * from LOGIN Where Name='" + label4.Text + "' and Status='" + label8.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dbr;
            try
            {
                con.Open();
                dbr = cmd.ExecuteReader();
                while (dbr.Read())
                {
                    string username = (string)dbr["USERNAME"].ToString();


                    label3.Text = username;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = label9.Text;
            label11.Text = "TimeIn Recorded";

            SqlConnection con = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("INSERT INTO StaffandAdminAttendence (Name, USERNAME, TimeIn, Date, Status) VALUES ('" + label4.Text + "','" + label3.Text + "','" + textBox1.Text + "','" + label10.Text + "','" + label7.Text + "')", con);
            cmd.CommandType = CommandType.Text;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("TimeIn Recorded");
                SpeechSynthesizer speechSynth = new SpeechSynthesizer();
                speechSynth.Volume = 100;
                speechSynth.Rate = -2;
                PromptBuilder builder = new PromptBuilder();
                builder.ClearContent();
                builder.AppendText(label11.Text);
                speechSynth.Speak(builder);
                menunew mn = new menunew();
                mn.Show();
                this.Hide();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
        }

        private void label10_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            string query = "select * from StaffandAdminAttendence Where Name='" + label4.Text + "' and Status='" + label7.Text + "' and Date='" + label10.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dbr;
            try
            {
                con.Open();
                dbr = cmd.ExecuteReader();
                while (dbr.Read())
                {
                    string TimeIn = (string)dbr["TimeIn"].ToString();
                    string TimeOut = (string)dbr["TimeOut"].ToString();


                    textBox1.Text = TimeIn;
                    textBox2.Text = TimeOut;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = label9.Text;
            label11.Text = "TimeOut Recorded";

            DateTime timein = Convert.ToDateTime(textBox1.Text);
            DateTime timeout = Convert.ToDateTime(textBox2.Text);

            TimeSpan timediff = timeout - timein;

            double hrs = timediff.Hours;

            if (hrs <= 8)
            {
                label6.Text = "Half Day";
            }
            else if (hrs > 8 && hrs <= 10)
            {
                label6.Text = "Full Day";
            }
            else if (hrs >= 10)
            {
                label6.Text = "OverTime";
            }

            SqlConnection con = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("UPDATE StaffandAdminAttendence SET TimeOut ='" + textBox2.Text + "', WorkingHours ='" + label6.Text + "' WHERE Date='" + label10.Text + "' and Name='" + label4.Text + "'", con);
            cmd.CommandType = CommandType.Text;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("TimeOut Recorded");
                SpeechSynthesizer speechSynth = new SpeechSynthesizer();
                speechSynth.Volume = 100;
                speechSynth.Rate = -2;
                PromptBuilder builder = new PromptBuilder();
                builder.ClearContent();
                builder.AppendText(label11.Text);
                speechSynth.Speak(builder);
                textBox1.Text = "";
                textBox2.Text = "";
                menunew mn = new menunew();
                mn.Show();
                this.Hide();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            
        }
    }
}

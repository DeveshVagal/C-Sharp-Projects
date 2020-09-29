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
    public partial class LoginPage : Form
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        public static string passingText;

        public LoginPage()
        {
            InitializeComponent();
            error();
            button1.Visible = false;
            label3.Visible = false;
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            label4.Visible = false;
            timer1.Start();
            label8.Text = DateTime.Now.ToLongDateString();
            label9.Text = DateTime.Now.ToLongTimeString();
        }

        private void LoginPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SIGNUP su = new SIGNUP();
            su.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label3.Text == "Approved")
            {
                SqlConnection con = new SqlConnection(conn);
                SqlDataAdapter sda = new SqlDataAdapter("Select * From LOGIN Where  USERNAME='" + textBox1.Text + "' and PASSWORD='" + textBox2.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    passingText = label4.Text;
                    string message = "Login Successfully";
                    string title = "Welcome";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.OK)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO LOGINHistory (Name, USERNAME, Date, Time) VALUES ('" + label4.Text + "','" + textBox1.Text + "','" + label8.Text + "','" + label9.Text + "')", con);
                        cmd.CommandType = CommandType.Text;

                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                    menunew mn = new menunew();
                    mn.Show();
                    this.Hide();

                    SpeechSynthesizer speechSynth = new SpeechSynthesizer();
                    speechSynth.Volume = 100;
                    speechSynth.Rate = -2;
                    PromptBuilder builder = new PromptBuilder();
                    PromptBuilder builder1 = new PromptBuilder();
                    builder.ClearContent();
                    builder1.ClearContent();
                    builder1.AppendText("welcome");
                    builder.AppendText(label4.Text);
                    speechSynth.Speak(builder1);
                    speechSynth.Speak(builder);

                    Clear();
                }
            }
            else if (label3.Text == "ADMIN")
            {
                string message = "Login Successfully";
                string title = "Welcome";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.OK)
                {
                    SqlConnection con = new SqlConnection(conn);
                    SqlCommand cmd = new SqlCommand("INSERT INTO LOGINHistory (Name, USERNAME, Date, Time) VALUES ('" + label4.Text + "','" + textBox1.Text + "','" + label8.Text + "','" + label9.Text + "')", con);
                    cmd.CommandType = CommandType.Text;

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                passingText = label4.Text;
                AdminSection admin = new AdminSection();
                admin.Show();
                this.Hide();

                SpeechSynthesizer speechSynth = new SpeechSynthesizer();
                speechSynth.Volume = 100;
                speechSynth.Rate = -2;
                PromptBuilder builder = new PromptBuilder();
                PromptBuilder builder1 = new PromptBuilder();
                builder.ClearContent();
                builder1.ClearContent();
                builder1.AppendText("welcome");
                builder.AppendText(label4.Text);
                speechSynth.Speak(builder1);
                speechSynth.Speak(builder);

                Clear();
            }
            else
            {
                MessageBox.Show("Incorrect credentials OR NOT APPROVED BY ADMIN");
                textBox1.Text = "";
                textBox2.Text = "";
                label3.Text = "";
            }
        }

        private void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            label3.Text = "";
            error();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FORGOTPASSWORD FP = new FORGOTPASSWORD();
            FP.Show();
            this.Hide();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                errorProvider1.SetError(textBox1, "Please Enter the Username.");
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
                errorProvider1.SetError(textBox2, "Please Enter the Password.");
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                button1.Visible = true;
            }
            else
            {
                label4.Text = "";
                button1.Visible = false;
            }


            SqlConnection con = new SqlConnection(conn);
            string query = "select * from LOGIN where USERNAME = '" + textBox1.Text + "' AND  PASSWORD='" + textBox2.Text + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dbr;
            try
            {
                con.Open();
                dbr = cmd.ExecuteReader();
                while (dbr.Read())
                {
                    string sn = (string)dbr["Name"].ToString();
                    label4.Text = sn;
                    button1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                label4.Text = "";
                button1.Visible = false;
            }
        }

        private void error()
        {
            errorProvider1.SetError(textBox1, "Please Enter the Username.");
            errorProvider1.SetError(textBox2, "Please Enter the Password.");
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string sql = "SELECT Status FROM LOGIN WHERE USERNAME = '" + textBox1.Text + "' and PASSWORD = '" + textBox2.Text + "'";
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    label3.Text = reader[0].ToString();

                }
                con.Close();
            }
            catch (Exception ex)
            {

                label1.Text = ex.Message;
            }

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                label3.Text = "";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

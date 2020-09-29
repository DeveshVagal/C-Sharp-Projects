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
    public partial class DeleteAllData : Form
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        public DeleteAllData()
        {
            InitializeComponent();
        }

        private void DeleteAllData_Load(object sender, EventArgs e)
        {
            label1.Text = LoginPage.passingText;
        }

        private void DeleteAllData_FormClosed(object sender, FormClosedEventArgs e)
        {
            AdminSection admin = new AdminSection();
            admin.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
                  string message = "Are you Sure ?";
                  string title = "Warning";
                  MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                  DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                  if (result == DialogResult.Yes)
                  {
                      SqlConnection con = new SqlConnection(conn);
                      SqlCommand cmd = new SqlCommand("TRUNCATE TABLE LOGINHistory", con);
                      cmd.CommandType = CommandType.Text;

                      try
                      {
                          con.Open();
                          cmd.ExecuteNonQuery();
                          MessageBox.Show("All Data in LOGIN HISTORY is been Deleted");
                          AdminSection admin = new AdminSection();
                          admin.Show();
                          this.Hide();
                          con.Close();

                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }
                  else if (result==DialogResult.No)
                  {
                      AdminSection admin = new AdminSection();
                      admin.Show();
                      this.Hide();
                  }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "Are you Sure ?";
            string title = "Warning";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand("TRUNCATE TABLE LOGIN", con);
                cmd.CommandType = CommandType.Text;

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("All Data in LOGIN is been Deleted");
                    AdminSection admin = new AdminSection();
                    admin.Show();
                    this.Hide();
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (result == DialogResult.No)
            {
                AdminSection admin = new AdminSection();
                admin.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string message = "Are you Sure ?";
            string title = "Warning";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand("TRUNCATE TABLE AddStudents", con);
                cmd.CommandType = CommandType.Text;

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("All Data in AddStudents is been Deleted");
                    AdminSection admin = new AdminSection();
                    admin.Show();
                    this.Hide();
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (result == DialogResult.No)
            {
                AdminSection admin = new AdminSection();
                admin.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string message = "Are you Sure ?";
            string title = "Warning";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand("TRUNCATE TABLE AttendenceRecord", con);
                cmd.CommandType = CommandType.Text;

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("All Data in Attenence Record is been Deleted");
                    AdminSection admin = new AdminSection();
                    admin.Show();
                    this.Hide();
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (result == DialogResult.No)
            {
                AdminSection admin = new AdminSection();
                admin.Show();
                this.Hide();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string message = "Are you Sure ?";
            string title = "Warning";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand("TRUNCATE TABLE StudentMonthlyAttendence", con);
                cmd.CommandType = CommandType.Text;

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("All Data in Student Monthly Attendence is been Deleted");
                    AdminSection admin = new AdminSection();
                    admin.Show();
                    this.Hide();
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (result == DialogResult.No)
            {
                AdminSection admin = new AdminSection();
                admin.Show();
                this.Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string message = "Are you Sure ?";
            string title = "Warning";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand("TRUNCATE TABLE StudentYearlyAttendence", con);
                cmd.CommandType = CommandType.Text;

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("All Data in Student Yearly Attendence is been Deleted");
                    AdminSection admin = new AdminSection();
                    admin.Show();
                    this.Hide();
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (result == DialogResult.No)
            {
                AdminSection admin = new AdminSection();
                admin.Show();
                this.Hide();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string message = "Are you Sure ?";
            string title = "Warning";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand("TRUNCATE TABLE ClassAttendencePerYear", con);
                cmd.CommandType = CommandType.Text;

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("All Data in Class Attendence PerYear is been Deleted");
                    AdminSection admin = new AdminSection();
                    admin.Show();
                    this.Hide();
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (result == DialogResult.No)
            {
                AdminSection admin = new AdminSection();
                admin.Show();
                this.Hide();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string message = "Are you Sure ?";
            string title = "Warning";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand("TRUNCATE TABLE StaffandAdminAttendence", con);
                cmd.CommandType = CommandType.Text;

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("All Data in Staff and Admin Atttendence is been Deleted");
                    AdminSection admin = new AdminSection();
                    admin.Show();
                    this.Hide();
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (result == DialogResult.No)
            {
                AdminSection admin = new AdminSection();
                admin.Show();
                this.Hide();
            }
        }
    }
}

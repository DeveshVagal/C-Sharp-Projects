using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMS
{
    public partial class Login1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6CS3N61\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");
        public static string passingText;
        private void Login1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            pictureBox3.Visible = false;
            panel3.Visible = false;
            
        }
        public Login1()
        {
            InitializeComponent();
            error();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        

        

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Increment(1);
            if(progressBar1.Value == 100)
            {
                timer1.Stop();
                panel3.Visible = true;
                pictureBox3.Visible = true;
            }

        }

        

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == "Admin")
            {
                SqlDataAdapter sda = new SqlDataAdapter("Select * From LOGIN Where Username='" + Username.Text + "' and Password='" + bunifuMaterialTextbox1.Text + "' and Usertype='" + comboBox2.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    passingText = Username.Text;
                    Dashboard d = new Dashboard();
                    d.Show();
                    this.Hide();
                    Clear();
                }
                else
                {
                    MessageBox.Show("Information Entered is Incorrect..");
                }
            }


            if (comboBox2.SelectedItem == "Employee")
            {
                SqlDataAdapter sda = new SqlDataAdapter("Select * From LOGIN Where Username='" + Username.Text + "' and Password='" + bunifuMaterialTextbox1.Text + "' and Usertype='" + comboBox2.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    passingText = Username.Text;
                    EmployeeAttendance ea = new EmployeeAttendance();
                    ea.Show();
                    this.Hide();
                    Clear();
                }
                else
                {
                    MessageBox.Show("Information Entered is Incorrect..");
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox3.Visible = false;
           
            panel3.Visible = false;
            



        }

        private void Clear()
        {
            Username.Text = "";
            bunifuMaterialTextbox1.Text="";
            comboBox2.SelectedIndex = -1;
        }

        private void Username_Validating(object sender, CancelEventArgs e)
        {
            if (Username.Text == string.Empty)
            {
                errorProvider1.SetError(Username, "Please Enter Username");
            }
            else
            {
                errorProvider1.SetError(Username, "");
            }
        }

        void error()
        {
            errorProvider1.SetError(Username, "Please Enter Username");
            errorProvider1.SetError(bunifuMaterialTextbox1, "Please Enter Password");
            errorProvider1.SetError(comboBox2, "Please Select an Role");
        }

        private void bunifuMaterialTextbox1_Validating(object sender, CancelEventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == string.Empty)
            {
                errorProvider1.SetError(bunifuMaterialTextbox1, "Please Enter Password");
            }
            else
            {
                errorProvider1.SetError(bunifuMaterialTextbox1, "");
            }
        }

        private void comboBox2_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox2.Text == string.Empty)
            {
                errorProvider1.SetError(comboBox2, "Please Select an Role");
            }
            else
            {
                errorProvider1.SetError(comboBox2, "");
            }
        }
    }
    }


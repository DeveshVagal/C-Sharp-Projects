﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DGVPrinterHelper;

namespace BSCITATTENDENCE
{
    public partial class StaffDetails : Form
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        public StaffDetails()
        {
            InitializeComponent();
            error();
            BindData();
        }

        private void StaffDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            AdminSection admin = new AdminSection();
            admin.Show();
            this.Hide();
        }

        private void StaffDetails_Load(object sender, EventArgs e)
        {
            label4.Text = LoginPage.passingText;
        }

        void BindData()
        {
            SqlConnection con = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("SELECT * FROM LOGIN", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();

            printer.Title = "\r\n\r\n\r\n ABC College of Technology \r\n\r\n";
            printer.SubTitle = " STAFF DETAILS \r\n\n Date :" + DateTime.Now.ToLongDateString();
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.PrintDataGridView(dataGridView1);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECt * from LOGIN where Name like ('" + textBox1.Text + "%') OR USERNAME like ('" + textBox1.Text + "%')OR PASSWORD like ('" + textBox1.Text + "%') OR ContactNumber like ('" + textBox1.Text + "%')  OR EmailId like ('" + textBox1.Text + "%') OR Address like ('" + textBox1.Text + "%') OR Qualification like ('" + textBox1.Text + "%') OR PastExperiences like ('" + textBox1.Text + "%') OR CurrentClassCourse like ('" + textBox1.Text + "%') OR Status like ('" + textBox1.Text + "%')", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                errorProvider1.SetError(textBox1, "");
            }
            else
            {
                errorProvider1.SetError(textBox1, "Please Enter the Text to Search.");
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                errorProvider1.SetError(textBox1, "Please Enter the Text to Search.");
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }
        }

        private void error()
        {
            errorProvider1.SetError(textBox1, "Please Enter the Text to Search.");
        }
    }
}

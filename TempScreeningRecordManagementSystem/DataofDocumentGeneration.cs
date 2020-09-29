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
    public partial class DataofDocumentGeneration : Form
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        public DataofDocumentGeneration()
        {
            InitializeComponent();
        }

        private void DataofDocumentGeneration_Load(object sender, EventArgs e)
        {
            Binddata();
            errorProvider1.SetError(textBox1, "Please Enter the Text to Search.");
        }

        private void Binddata()
        {
            SqlConnection con = new SqlConnection(conn);
            string query = "Select * from DocumentGenerationRecord";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void DataofDocumentGeneration_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECt * from DocumentGenerationRecord where DocumentFormat like ('" + textBox1.Text + "%')OR DateofGeneration like ('" + textBox1.Text + "%') OR TimeofGeneration like ('" + textBox1.Text + "%') OR GeneratedBy like ('" + textBox1.Text + "%')", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Please Enter the Text to Search.");
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.SqlClient;

namespace BloodDonation
{
    public partial class certificategeneration : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=EXCELANCE\SQLEXPRESS;Initial Catalog=BloodDonation;Integrated Security=True");

        public certificategeneration()
        {
            InitializeComponent();

            label2.Text = DateTime.Now.ToString();
            label2.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Choose c = new Choose();
            c.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO CertificateRecord(Name, DateTime) VALUES ('"+comboBox1.Text+"', '"+label2.Text+"')", con);
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

            CrystalReport1 cr = new CrystalReport1();
            TextObject text = (TextObject)cr.ReportDefinition.Sections["Section3"].ReportObjects["Text3"];
            text.Text = comboBox1.Text;
            crystalReportViewer1.ReportSource = cr;
        }

        private void certificategeneration_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select Name from DonorDetails", con);
            SqlDataReader reader;
            reader = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Name", typeof(string));
            dt1.Load(reader);

            comboBox1.DisplayMember = "Name";
            comboBox1.DataSource = dt1;
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = comboBox1.SelectedValue.ToString();
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DGVPrinterHelper;

namespace BloodDonation
{
    public partial class certificaterecords : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=EXCELANCE\SQLEXPRESS;Initial Catalog=BloodDonation;Integrated Security=True");


        public certificaterecords()
        {
            InitializeComponent();
            Binddata();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Records R = new Records();
            R.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = comboBox1.SelectedValue.ToString();
        }

        private void certificaterecords_Load(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            Binddata();
        }

        private void Binddata()
        {
            string query = "Select * from CertificateRecord";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECt * from CertificateRecord where Name='"+comboBox1.Text+"'", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem == "EXCEL FORMAT")
            {
                saveFileDialog1.InitialDirectory = "C:";
                saveFileDialog1.Title = "Save as Excel File";
                saveFileDialog1.FileName = "";
                saveFileDialog1.Filter = "Excel Files(2003)|*.xls|Excel Files(2007)|*.xlsx|Excel Files(2010)|*.xlsx|Excel Files(2013)|*.xlsx|Excel Files(2016)|*.xlsx";

                if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
                {
                    Microsoft.Office.Interop.Excel.ApplicationClass ExcelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                    ExcelApp.Application.Workbooks.Add(Type.Missing);

                    //Change Properties of the WorkBook
                    ExcelApp.Columns.ColumnWidth = 20;

                    //Storing the Header Value in Excel
                    for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                    {
                        ExcelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                    }

                    //Storing Each row and column value to excel sheet
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            if (dataGridView1.Rows[i].Cells[j].Value != null)
                            {
                                ExcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }

                    ExcelApp.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName.ToString());
                    ExcelApp.ActiveWorkbook.Saved = true;
                    ExcelApp.Quit();
                }
            }

            if (comboBox3.SelectedItem == "PDF FORMAT")
            {
                DGVPrinter printer = new DGVPrinter();

                printer.Title = "\r\n\r\n\r\n LIFE BLOOD BANK \r\n\r\n";
                printer.SubTitle = " CERTIFICATE RECORDS \r\n";
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.PrintDataGridView(dataGridView1);
            }

        }
    }
}

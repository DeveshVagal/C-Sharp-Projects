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
    public partial class bloodsalesrecords : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=EXCELANCE\SQLEXPRESS;Initial Catalog=BloodDonation;Integrated Security=True");
        public static string billno;
        public static string date;
        public static string patientname;
        public static string hospitalname;
        public static string bloodgroup;
        public static string unitsavailable;
        public static string costperunit;
        public static string unitssold;
        public static string totalcost;


        public bloodsalesrecords()
        {
            InitializeComponent();
            Binddata();

            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Records r = new Records();
            r.Show();
            this.Hide();
        }

        private void Binddata()
        {
            string query = "Select * from BloodSales";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Binddata();
            textBox1.Text = "";
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Please Enter Keywords to Search");
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECt * from BloodSales where BillNo like ('" + textBox1.Text + "%') OR Date like ('" + textBox1.Text + "%')OR PatientName like ('" + textBox1.Text + "%') OR HospitalName like ('" + textBox1.Text + "%') OR BloodGroup like ('" + textBox1.Text + "%') OR UnitsAvailable like ('" + textBox1.Text + "%') OR CostPerUnit like ('" + textBox1.Text + "%') OR UnitsSoled like ('" + textBox1.Text + "%') OR TotalCost like ('" + textBox1.Text + "%')", con);
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
                printer.SubTitle = " BLOOD SALES RECORDS \r\n";
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.PrintDataGridView(dataGridView1);
            }

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;

            label2.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            label3.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            label4.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            label5.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            label6.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            label7.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
            label8.Text = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
            label9.Text = dataGridView1.Rows[rowIndex].Cells[7].Value.ToString();
            label10.Text = dataGridView1.Rows[rowIndex].Cells[8].Value.ToString();

            billno = label2.Text;
            date = label3.Text;
            patientname = label4.Text;
            hospitalname = label5.Text;
            bloodgroup = label6.Text;
            unitsavailable = label7.Text;
            costperunit = label8.Text;
            unitssold = label9.Text;
            totalcost = label10.Text;

            BloodSalesReceipt bsr = new BloodSalesReceipt();
            bsr.Show();
            this.Hide();
        }

        private void bloodsalesrecords_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                errorProvider1.SetError(textBox1, "Please Enter Keywords to Search");
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }
        }


        private void error()
        {
            errorProvider1.SetError(textBox1, "Please Enter Keywords to Search");
        }
        
    }
}

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
    public partial class DataofScreeningTemperatureRecord : Form
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        
        public static string id;
        public static string flatno;
        public static string name;
        public static string Age;
        public static string Gender;
        public static string st;
        public static string pr;

        public DataofScreeningTemperatureRecord()
        {
            InitializeComponent();
        }

        private void DataofScreeningTemperatureRecord_Load(object sender, EventArgs e)
        {
            label11.Text = Login.passingtext;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label9.Visible = false;
            label8.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label14.Visible = false;
            Binddata();
            timer1.Start();
            label8.Text = DateTime.Now.ToLongDateString();
            label10.Text = DateTime.Now.ToLongTimeString();
            errorProvider1.SetError(textBox1, "Please Enter the Text to Search.");
        }

        private void Binddata()
        {
            SqlConnection con = new SqlConnection(conn);
            string query = "Select * from ScreeningTemperatureRecord";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
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

                label9.Text = "EXCEL SHEET";
            }
        }

        private void DataofScreeningTemperatureRecord_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void textBox1_KeyUp_1(object sender, KeyEventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECt * from ScreeningTemperatureRecord where FlatNo like ('" + textBox1.Text + "%')OR Name like ('" + textBox1.Text + "%')OR Age like ('" + textBox1.Text + "%') OR Gender like ('" + textBox1.Text + "%') OR ScreeningTemprature like ('" + textBox1.Text + "%') OR PulseRate like ('" + textBox1.Text + "%') OR ScreeningDate like ('" + textBox1.Text + "%') OR ScreeningTime like ('" + textBox1.Text + "%') OR CalculatedBy like ('" + textBox1.Text + "%') OR AddedBy like ('" + textBox1.Text + "%')", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
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

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;

            label2.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            label14.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            label3.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            label4.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            label5.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            label6.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
            label7.Text = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();

            id = label2.Text;
            name = label3.Text;
            flatno = label14.Text;
            Age = label4.Text;
            Gender = label5.Text;
            st = label6.Text;
            pr = label7.Text;

            UpdateDeleteTemperatureScreeningRecord upstr = new UpdateDeleteTemperatureScreeningRecord();
            upstr.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void label9_TextChanged(object sender, EventArgs e)
        {
            if (label9.Text == "EXCEL SHEET")
            {
                try
                {
                    SqlConnection con = new SqlConnection(conn);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO DocumentGenerationRecord (DocumentFormat, DateofGeneration, TimeofGeneration, GeneratedBy) VALUES ('"+label9.Text+"','"+label8.Text+"','"+label10.Text+"','"+label11.Text+"')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    label9.Text = "DOCUMENT FORMAT";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (label9.Text == "DOCUMENT FORMAT")
            {

            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            label10.Text = DateTime.Now.ToLongTimeString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECt * from ScreeningTemperatureRecord where ScreeningDate ='" + dateTimePicker1.Value.ToLongDateString() + "'", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECt * from ScreeningTemperatureRecord where ScreeningDate between '" + dateTimePicker1.Value.ToLongDateString() + "' and '" + dateTimePicker2.Value.ToLongDateString() + "'", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Binddata();
        }
    }
}

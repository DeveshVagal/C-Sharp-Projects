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
    public partial class Hospital : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=EXCELANCE\SQLEXPRESS;Initial Catalog=BloodDonation;Integrated Security=True");

        public Hospital()
        {
            InitializeComponent();
            BindData();
            error();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            RecordsList rl = new RecordsList();
            rl.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO HospitalDetails(NameOfHospital, PhoneNumber, TelephoneNumber, Address, EmailID, DoctorName, PatientName) VALUES ('"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"','"+textBox6.Text+"','"+textBox7.Text+"','"+textBox8.Text+"')", con);
            cmd.CommandType = CommandType.Text;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted Successfully");
                BindData();
                clear();
                con.Close();

            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
            }
        }

        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox10.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            error();
        }

        void BindData()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM HospitalDetails", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;

            textBox1.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.Rows[rowIndex].Cells[7].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox10.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            error();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE HospitalDetails SET NameOfHospital ='" + textBox2.Text + "', PhoneNumber ='" + textBox3.Text + "', TelephoneNumber ='" + textBox4.Text + "', Address ='" + textBox5.Text + "', EmailID ='" + textBox6.Text + "', DoctorName='" + textBox7.Text + "', PatientName='"+textBox8.Text+"' WHERE id='" + textBox1.Text + "'", con);
            cmd.CommandType = CommandType.Text;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully");
                BindData();
                clear();
                con.Close();

            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete From HospitalDetails WHERE id='" + textBox1.Text + "'", con);
            cmd.CommandType = CommandType.Text;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully");
                BindData();
                clear();
                con.Close();

            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
            }
        }

        private void button4_Click(object sender, EventArgs e)
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
                printer.SubTitle = " HOSPITAL DETAILS \r\n";
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.PrintDataGridView(dataGridView1);
            }

        }

        private void textBox10_KeyUp(object sender, KeyEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECt * from HospitalDetails where id like ('" + textBox10.Text + "%') OR NameOfHospital like ('" + textBox10.Text + "%')OR PhoneNumber like ('" + textBox10.Text + "%') OR TelephoneNumber like ('" + textBox10.Text + "%') OR Address like ('" + textBox10.Text + "%') OR EmailID like ('" + textBox10.Text + "%') OR DoctorName like ('" + textBox10.Text + "%') OR PatientName like ('" + textBox10.Text + "%')", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                errorProvider1.SetError(textBox2, "Please Enter the Name of Hospital");
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (textBox3.Text == string.Empty)
            {
                errorProvider1.SetError(textBox3, "Please Enter the Mobile Number");
            }
            else
            {
                errorProvider1.SetError(textBox3, "");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && textBox3.Text.Length == 10)
            {
                e.Handled = true;
                errorProvider1.SetError(textBox3, "");
            }
            else
            {
                errorProvider1.SetError(textBox3, "Please Enter Valid Contact Number");
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (textBox4.Text == string.Empty)
            {
                errorProvider1.SetError(textBox4, "Please Enter the Telephone Number");
            }
            else
            {
                errorProvider1.SetError(textBox4, "");
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && textBox4.Text.Length == 10)
            {
                e.Handled = true;
                errorProvider1.SetError(textBox4, "");
            }
            else
            {
                errorProvider1.SetError(textBox4, "Please Enter Valid Telephone Number");
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (textBox5.Text == string.Empty)
            {
                errorProvider1.SetError(textBox5, "Please Enter the Address");
            }
            else
            {
                errorProvider1.SetError(textBox5, "");
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (textBox6.Text == string.Empty)
            {
                errorProvider1.SetError(textBox6, "Please Enter the E-mail ID");
            }
            else
            {
                errorProvider1.SetError(textBox6, "");
            }
        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            if (textBox7.Text == string.Empty)
            {
                errorProvider1.SetError(textBox7, "Please Enter the Reference Doctor`s Name");
            }
            else
            {
                errorProvider1.SetError(textBox7, "");
            }
        }

        private void textBox8_Validating(object sender, CancelEventArgs e)
        {
            if (textBox8.Text == string.Empty)
            {
                errorProvider1.SetError(textBox8, "Please Enter the Patient`s Name ");
            }
            else
            {
                errorProvider1.SetError(textBox8, "");
            }
        }

        private void error()
        {
            errorProvider1.SetError(textBox2, "Please Enter the Name of Hospital");
            errorProvider1.SetError(textBox3, "Please Enter the Mobile Number");
            errorProvider1.SetError(textBox4, "Please Enter the Telephone Number");
            errorProvider1.SetError(textBox5, "Please Enter the Address");
            errorProvider1.SetError(textBox6, "Please Enter the E-mail ID");
            errorProvider1.SetError(textBox7, "Please Enter the Reference Doctor`s Name");
            errorProvider1.SetError(textBox8, "Please Enter the Patient`s Name ");
        }
        
    }
}

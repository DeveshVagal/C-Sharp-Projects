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
using System.Globalization;

namespace BloodDonation
{
    public partial class Donor : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=EXCELANCE\SQLEXPRESS;Initial Catalog=BloodDonation;Integrated Security=True");

        public Donor()
        {
            InitializeComponent();
            BindData();
            
        }
        
       

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            RecordsList rl = new RecordsList();
            rl.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO DonorDetails(Name, BloodGroup, Email, MobileNo, Gender, DOB, Age, Nationality, State, City, Address, UnitsDonated) VALUES ('"+textBox1.Text+"','"+comboBox1.Text+"','"+textBox6.Text+"','"+textBox5.Text+"','"+comboBox2.Text+"','"+dateTimePicker1.Value.ToShortDateString()+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox7.Text+"','"+textBox8.Text+"','"+textBox9.Text+"','"+textBox2.Text+"')", con);
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
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox11.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            error();
        }

        void BindData()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM DonorDetails", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;

            textBox11.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            /*textBox1.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            textBox6.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
            dataGridView1.Rows[rowIndex].Cells[6].Value = dateTimePicker1.Value.ToShortDateString();
            textBox4.Text = dataGridView1.Rows[rowIndex].Cells[7].Value.ToString();
            textBox7.Text = dataGridView1.Rows[rowIndex].Cells[8].Value.ToString();
            textBox8.Text = dataGridView1.Rows[rowIndex].Cells[9].Value.ToString();
            textBox9.Text = dataGridView1.Rows[rowIndex].Cells[10].Value.ToString();*/
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox11.Text = "";
            textBox3.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            error();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE DonorDetails SET Name ='" + textBox1.Text + "', BloodGroup ='" + comboBox1.Text + "', Email ='" + textBox6.Text + "', MobileNo ='" + textBox5.Text + "', Gender ='" + comboBox2.Text + "',DOB='" + dateTimePicker1.Value + "',Age='"+textBox3.Text+"',Nationality ='" + textBox4.Text + "', State ='" + textBox7.Text + "', City ='" + textBox8.Text + "', Address ='" + textBox9.Text + "', UnitsDonated='"+textBox2.Text+"' WHERE id='" + textBox11.Text + "'", con);
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
            SqlCommand cmd = new SqlCommand("Delete from DonorDetails WHERE id='" + textBox11.Text + "'", con);
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
                printer.SubTitle = " DONOR DETAILS \r\n";
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
            SqlCommand cmd = new SqlCommand("SELECt * from DonorDetails where Name like ('" + textBox10.Text + "%') OR id like ('" + textBox10.Text + "%')OR BloodGroup like ('" + textBox10.Text + "%') OR MobileNo like ('" + textBox10.Text + "%') OR Gender like ('" + textBox10.Text + "%') OR Nationality like ('" + textBox10.Text + "%') OR State like ('" + textBox10.Text + "%') OR City like ('" + textBox10.Text + "%') OR DOB like ('" + textBox10.Text + "%') OR UnitsDonated like ('" + textBox10.Text + "%') OR Age like ('" + textBox10.Text + "%')", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM DonorDetails WHERE id = '" + textBox11.Text + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    textBox1.Text = reader[1].ToString();
                    comboBox1.Text = reader[2].ToString();
                    textBox6.Text = reader[3].ToString();
                    textBox5.Text = reader[4].ToString();
                    comboBox2.Text = reader[5].ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(reader[6]);
                    textBox3.Text = reader[7].ToString();
                    textBox4.Text = reader[8].ToString();
                    textBox7.Text = reader[9].ToString();
                    textBox8.Text = reader[10].ToString();
                    textBox9.Text = reader[11].ToString();
                    textBox2.Text = reader[12].ToString();
                    
                }
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                label2.Text = ex.Message;
            }

            if (textBox11.Text == "")
            {
                clear();
            }

        }

        private void Donor_Load(object sender, EventArgs e)
        {
            error();
            label2.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label17_TextChanged(object sender, EventArgs e)
        {

            
        }


        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
             
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("UPDATE BloodAvailable set UnitsAvailable=UnitsAvailable + " + textBox2.Text + " WHERE BloodGroup='" + comboBox1.Text + "'", con);
            cmd1.CommandType = CommandType.Text;

            try
            {
                con.Open();
                cmd1.ExecuteNonQuery();
                MessageBox.Show("BloodGroup Updated Successfully");
                con.Close();

            }
            catch (Exception ex)
            {
                label2.Text = ex.Message;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan age = DateTime.Now - dateTimePicker1.Value;
            int years = DateTime.Now.Year - dateTimePicker1.Value.Year;
            if (dateTimePicker1.Value.AddYears(years) > DateTime.Now) years--;
            textBox3.Text = years.ToString();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                errorProvider1.SetError(textBox1, "Please Enter the Name");
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox1.Text == string.Empty)
            {
                errorProvider1.SetError(comboBox1, "Please Select an Blood Group");
            }
            else
            {
                errorProvider1.SetError(comboBox1, "");
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

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (textBox5.Text == string.Empty)
            {
                errorProvider1.SetError(textBox5, "Please Enter the Mobile Number");
            }
            else
            {
                errorProvider1.SetError(textBox5, "");
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && textBox5.Text.Length == 10)
            {
                e.Handled = true;
                errorProvider1.SetError(textBox5, "");
            }
            else
            {
                errorProvider1.SetError(textBox5, "Please Enter Valid Contact Number");
            }
        }

        private void comboBox2_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox2.Text == string.Empty)
            {
                errorProvider1.SetError(comboBox2, "Please Select an Gender");
            }
            else
            {
                errorProvider1.SetError(comboBox2, "");
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (textBox4.Text == string.Empty)
            {
                errorProvider1.SetError(textBox4, "Please Enter the Nationality");
            }
            else
            {
                errorProvider1.SetError(textBox4, "");
            }
        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            if (textBox7.Text == string.Empty)
            {
                errorProvider1.SetError(textBox7, "Please Enter the State");
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
                errorProvider1.SetError(textBox8, "Please Enter the City");
            }
            else
            {
                errorProvider1.SetError(textBox8, "");
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                errorProvider1.SetError(textBox2, "Please Enter the Units Donated");
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
            }
        }

        private void textBox9_Validating(object sender, CancelEventArgs e)
        {
            if (textBox9.Text == string.Empty)
            {
                errorProvider1.SetError(textBox9, "Please Enter the Address");
            }
            else
            {
                errorProvider1.SetError(textBox9, "");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && textBox2.Text.Length == 10)
            {
                e.Handled = true;
                errorProvider1.SetError(textBox2, "");
            }
            else
            {
                errorProvider1.SetError(textBox2, "Invalid Number");
            }
        }

        private void error()
        {
            errorProvider1.SetError(textBox1, "Please Enter the Name");
            errorProvider1.SetError(comboBox1, "Please Select an Blood Group");
            errorProvider1.SetError(textBox6, "Please Enter the E-mail ID");
            errorProvider1.SetError(textBox5, "Please Enter the Mobile Number");
            errorProvider1.SetError(comboBox2, "Please Select an Gender");
            errorProvider1.SetError(textBox4, "Please Enter the Nationality");
            errorProvider1.SetError(textBox7, "Please Enter the State");
            errorProvider1.SetError(textBox8, "Please Enter the City");
            errorProvider1.SetError(textBox2, "Please Enter the Units Donated");
            errorProvider1.SetError(textBox9, "Please Enter the Address");
        }
    }
}

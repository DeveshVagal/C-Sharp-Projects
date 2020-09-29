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
    public partial class EmpBankDetails : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6CS3N61\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");
        public EmpBankDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeJob ej = new EmployeeJob();
            ej.Show();
            this.Hide();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            AddDept ad = new AddDept();
            ad.Show();
            this.Hide();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            EmployeeBioData ebio = new EmployeeBioData();
            ebio.Show();
            this.Hide();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            EmployeeAttendanceAdmin ea = new EmployeeAttendanceAdmin();
            ea.Show();
            this.Hide();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            EmployeeSalary esal = new EmployeeSalary();
            esal.Show();
            this.Hide();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "INSERT INTO EmployeeBankDetails (EmployeeId, EmployeeName, AadharNumber, PanNumber, BankName, IFSCCode, AccountName, AccountNumber) VALUES ('" + textBox4.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Employee Bank Details Inserted Successfully...");
                Clear();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }


        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            string query = "select * from Employee where EmployeeId = '" + textBox4.Text + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dbr;
            try
            {
                con.Open();
                dbr = cmd.ExecuteReader();
                while (dbr.Read())
                {
                    string en = (string)dbr["EmployeeName"].ToString();

                    textBox1.Text = en;
                    bunifuFlatButton8.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();

            if (textBox4.Text == "")
            {
                Clear();
                bunifuFlatButton8.Visible = false;
                bunifuFlatButton7.Visible = false;
                bunifuFlatButton9.Visible = false;
                bunifuFlatButton6.Visible = true;
            }

        }

        private void Clear()
        {
            textBox4.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void EmpBankDetails_Load(object sender, EventArgs e)
        {
            bunifuFlatButton8.Visible = false;
            bunifuFlatButton7.Visible = false;
            bunifuFlatButton9.Visible = false;
            error();
            label11.Text = Login1.passingText;
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            string query = "select * from EmployeeBankDetails where EmployeeId = '" + textBox4.Text + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dbr;
            try
            {
                con.Open();
                dbr = cmd.ExecuteReader();
                while (dbr.Read())
                {
                    string en = (string)dbr["EmployeeName"].ToString();
                    string an = (string)dbr["AadharNumber"].ToString();
                    string pn = (string)dbr["PanNumber"].ToString();
                    string bn = (string)dbr["BankName"].ToString();
                    string ifsc = (string)dbr["IFSCCode"].ToString();
                    string accn = (string)dbr["AccountName"].ToString();
                    string accnum = (string)dbr["AccountNumber"].ToString();

                    textBox1.Text = en;
                    textBox2.Text = an;
                    textBox3.Text = pn;
                    textBox5.Text = bn;
                    textBox6.Text = ifsc;
                    textBox7.Text = accn;
                    textBox8.Text = accnum;

                    bunifuFlatButton8.Visible = true;
                    bunifuFlatButton7.Visible = true;
                    bunifuFlatButton9.Visible = true;
                    bunifuFlatButton6.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();

            if (textBox4.Text == "")
            {
                Clear();
                bunifuFlatButton8.Visible = false;
                bunifuFlatButton7.Visible = false;
                bunifuFlatButton6.Visible = true;
                bunifuFlatButton9.Visible = false;
            }

        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "UPDATE EmployeeBankDetails SET EmployeeName ='" + textBox1.Text + "', AadharNumber ='" + textBox2.Text + "', PanNumber ='" + textBox3.Text + "', BankName ='" + textBox5.Text + "', IFSCCode ='" + textBox6.Text + "', AccountName ='" + textBox7.Text + "', AccountNumber ='" + textBox8.Text + "' WHERE EmployeeId='" + textBox4.Text + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Employee Bank Details Updated Successfully...");
                bunifuFlatButton7.Visible = false;
                bunifuFlatButton9.Visible = false;
                bunifuFlatButton6.Visible = true;
                bunifuFlatButton8.Visible = true;
                Clear();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }


        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "DELETE FROM EmployeeBankDetails WHERE EmployeeId='" + textBox4.Text + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Employee Bank Details Deleted Successfully...");
                bunifuFlatButton7.Visible = false;
                bunifuFlatButton9.Visible = false;
                bunifuFlatButton6.Visible = true;
                bunifuFlatButton8.Visible = true;
                Clear();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard ds = new EMS.Dashboard();
            this.Hide();
            ds.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Login1 log = new Login1();
            this.Hide();
            log.Show();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (textBox4.Text == string.Empty)
            {
                errorProvider1.SetError(textBox4, "Please Enter Employee ID");
            }
            else
            {
                errorProvider1.SetError(textBox4, "");
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                errorProvider1.SetError(textBox1, "Please Enter Employee Name");
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                errorProvider1.SetError(textBox2, "Please Enter Aadhar Card Number");
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
                errorProvider1.SetError(textBox3, "Please Enter Pan card Number");
            }
            else
            {
                errorProvider1.SetError(textBox3, "");
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (textBox5.Text == string.Empty)
            {
                errorProvider1.SetError(textBox5, "Please Enter Bank Name");
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
                errorProvider1.SetError(textBox6, "Please Enter IFSC Code");
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
                errorProvider1.SetError(textBox7, "Please Enter Account Name");
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
                errorProvider1.SetError(textBox8, "Please Enter Account Number");
            }
            else
            {
                errorProvider1.SetError(textBox8, "");
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                errorProvider1.SetError(textBox8, "");
            }
            else
            {
                errorProvider1.SetError(textBox8, "Please Enter Account Number");
            }
        }

        void error()
        {
            errorProvider1.SetError(textBox4, "Please Enter Employee ID");
            errorProvider1.SetError(textBox1, "Please Enter Employee Name");
            errorProvider1.SetError(textBox2, "Please Enter Aadhar Card Number");
            errorProvider1.SetError(textBox3, "Please Enter Pan card Number");
            errorProvider1.SetError(textBox5, "Please Enter Bank Name");
            errorProvider1.SetError(textBox6, "Please Enter IFSC Code");
            errorProvider1.SetError(textBox7, "Please Enter Account Name");
            errorProvider1.SetError(textBox8, "Please Enter Account Number");
        }
    }
}

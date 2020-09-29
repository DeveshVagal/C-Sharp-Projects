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
    public partial class EmployeeJob : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6CS3N61\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");
        public EmployeeJob()
        {
            InitializeComponent();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Next_Click(object sender, EventArgs e)
        {
            EmpBankDetails empBank = new EmpBankDetails();
            empBank.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmpQualification eq = new EmpQualification();
            eq.Show();
            this.Hide();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            AddDept ad = new AddDept();
            this.Hide();
            ad.Show();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            EmployeeBioData empbio = new EmployeeBioData();
            empbio.Show();
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
                    bunifuFlatButton7.Visible = true;
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
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox4.Text = "";
        }

        private void EmployeeJob_Load(object sender, EventArgs e)
        {
            bunifuFlatButton8.Visible = false;
            bunifuFlatButton7.Visible = false;
            bunifuFlatButton9.Visible = false;
            error();
            label11.Text = Login1.passingText;
        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "Delete from EmployeeJobExperience WHERE EmployeeId='" + textBox4.Text + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Employee Job Experience Deleted Successfully...");
                bunifuFlatButton8.Visible = false;
                bunifuFlatButton7.Visible = true;
                bunifuFlatButton6.Visible = true;
                bunifuFlatButton9.Visible = false;
                Clear();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            string query = "select * from EmployeeJobExperience where EmployeeId = '" + textBox4.Text + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dbr;
            try
            {
                con.Open();
                dbr = cmd.ExecuteReader();
                while (dbr.Read())
                {
                    string en = (string)dbr["EmployeeName"].ToString();
                    string we = (string)dbr["WorkExperience"].ToString();
                    string po = (string)dbr["PastOrganisation"].ToString();
                    string pd = (string)dbr["PastDepartment"].ToString();
                    string pdes = (string)dbr["PastDesignation"].ToString();
                    string psal = (string)dbr["PastSalary"].ToString();

                    textBox1.Text = en;
                    textBox2.Text = we;
                    textBox3.Text = po;
                    textBox5.Text = pd;
                    textBox6.Text = pdes;
                    textBox7.Text = psal;

                    bunifuFlatButton8.Visible = true;
                    bunifuFlatButton6.Visible = false;
                    bunifuFlatButton9.Visible = true;
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
                bunifuFlatButton7.Visible = true;
                bunifuFlatButton6.Visible = true;
                bunifuFlatButton9.Visible = false;
            }
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "INSERT INTO EmployeeJobExperience (EmployeeId, EmployeeName, WorkExperience, PastOrganisation, PastDepartment, PastDesignation, PastSalary) VALUES ('" + textBox4.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Job Experience Recorded Successfully...");
                Clear();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "UPDATE EmployeeJobExperience SET EmployeeName ='" + textBox1.Text + "', WorkExperience ='" + textBox2.Text + "', PastOrganisation ='" + textBox3.Text + "', PastDepartment ='" + textBox5.Text + "', PastDesignation ='" + textBox6.Text + "', PastSalary ='" + textBox7.Text + "' WHERE EmployeeId='" + textBox4.Text + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Employee Job Experience Updated Successfully...");
                bunifuFlatButton8.Visible = false;
                bunifuFlatButton7.Visible = true;
                bunifuFlatButton6.Visible = true;
                bunifuFlatButton9.Visible = false;
                Clear();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                errorProvider1.SetError(textBox2, "");
            }
            else
            {
                errorProvider1.SetError(textBox2, "Please Enter Work Experience in Years");
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                errorProvider1.SetError(textBox2, "Please Enter Work Experience in Years");
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
                errorProvider1.SetError(textBox3, "Please Enter Name of Past Organisation");
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
                errorProvider1.SetError(textBox5, "Please Enter Name of Department in Past Organisation");
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
                errorProvider1.SetError(textBox6, "Please Enter Name of Designation in Past organisation");
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
                errorProvider1.SetError(textBox7, "Please Enter Salary in Past Organisation");
            }
            else
            {
                errorProvider1.SetError(textBox7, "");
            }
        }

        void error()
        {
            errorProvider1.SetError(textBox4, "Please Enter Employee ID");
            errorProvider1.SetError(textBox1, "Please Enter Employee Name");
            errorProvider1.SetError(textBox2, "Please Enter Work Experience in Years");
            errorProvider1.SetError(textBox3, "Please Enter Name of Past Organisation");
            errorProvider1.SetError(textBox5, "Please Enter Name of Department in Past Organisation");
            errorProvider1.SetError(textBox6, "Please Enter Name of Designation in Past Organisation");
            errorProvider1.SetError(textBox7, "Please Enter Salary in Past Organisation");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Login1 l = new Login1();
            l.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            d.Show();
            this.Hide();
        }
    }
}

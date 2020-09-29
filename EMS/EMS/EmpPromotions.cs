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
    public partial class EmpPromotions : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6CS3N61\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");
        public EmpPromotions()
        {
            InitializeComponent();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            string query = "select * from EmployeeDepartmentDetails where EmployeeId = '" + textBox1.Text + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dbr;
            try
            {
                con.Open();
                dbr = cmd.ExecuteReader();
                while (dbr.Read())
                {
                    string en = (string)dbr["EmployeeName"].ToString();
                    string dn = (string)dbr["DeptName"].ToString();
                    string des = (string)dbr["Designation"].ToString();
                    string sal = (string)dbr["Salary"].ToString();

                    EmpName.Text = en;
                    textBox5.Text = dn;
                    textBox3.Text = des;
                    textBox6.Text = sal;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();

            if (textBox1.Text == "")
            {
                Clear();
            }
        }
        private void Clear()
        {
            textBox1.Text = "";
            EmpName.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox4.Text = "";
            textBox7.Text = "";
        }

        private void EmpPromotions_Load(object sender, EventArgs e)
        {
            //label11.Visible = false;
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select DeptName from DepartmentDetails", con);
            SqlDataReader reader;
            reader = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("DeptName", typeof(string));
            dt1.Load(reader);

            comboBox1.DisplayMember = "DeptName";
            comboBox1.DataSource = dt1;
            con.Close();

            error();

            label25.Text = Login1.passingText;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = comboBox1.SelectedValue.ToString();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "UPDATE EmployeeDepartmentDetails SET DeptName ='" + comboBox1.Text + "', Designation ='" + textBox4.Text + "', Salary ='" + textBox7.Text + "' Where EmployeeId='" + textBox1.Text + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Employee Promoted!");
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "INSERT INTO EmployeePromotion (EmployeeId, EmployeeName, DepartmentName, Designation, Salary, PromotedDepartmentName, PromotedDesignation, PromotedSalary) VALUES ('" + textBox1.Text + "','" + EmpName.Text + "','" + textBox5.Text + "','" + textBox3.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "','" + textBox4.Text + "','" + textBox7.Text + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                errorProvider1.SetError(textBox1, "Please Enter Employee ID");
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
                errorProvider1.SetError(comboBox1, "Please Select an Department");
            }
            else
            {
                errorProvider1.SetError(comboBox1, "");
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (textBox4.Text == string.Empty)
            {
                errorProvider1.SetError(textBox4, "Please Assign an Designation");
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
                errorProvider1.SetError(textBox7, "Please Assign new Salary");
            }
            else
            {
                errorProvider1.SetError(textBox7, "");
            }
        }

        void error()
        {
            errorProvider1.SetError(textBox1, "Please Enter Employee ID");
            errorProvider1.SetError(comboBox1, "Please Select an Department");
            errorProvider1.SetError(textBox4, "Please Assign an Designation");
            errorProvider1.SetError(textBox7, "Please Assign new Salary");
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                errorProvider1.SetError(textBox7, "");
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void bunifuFlatButton2_Click_1(object sender, EventArgs e)
        {
            AddDept ad = new AddDept();
            ad.Show();
            this.Hide();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            EmployeeBioData ebd = new EmployeeBioData();
            ebd.Show();
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
            EmployeeSalary es = new EmployeeSalary();
            es.Show();
            this.Hide();
        }
    }
}

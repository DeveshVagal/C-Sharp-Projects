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
    public partial class EmployeeDept : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6CS3N61\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");

        public EmployeeDept()
        {
            InitializeComponent();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            EmpQualification empQual = new EmpQualification();
            empQual.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            AddDept ad = new AddDept();
            ad.Show();
            this.Hide();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            EmployeeBioData eb = new EmployeeBioData();
            eb.Show();
            this.Hide();
      
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            EmployeeAttendance ea = new EmployeeAttendance();
            ea.Show();
            this.Hide();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            EmployeeSalary esal = new EmployeeSalary();
            esal.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeBioData ebio = new EmployeeBioData();
            ebio.Show();
            this.Hide();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "INSERT INTO EmployeeDepartmentDetails (EmployeeName, EmployeeId, JoinDate, DeptName, Designation, Shift, Salary, Status) VALUES ('"+textBox1.Text+"','"+textBox4.Text+"','"+bunifuDatepicker1.Value.ToLongDateString()+"','"+comboBox2.Text+"','"+textBox2.Text+"','"+comboBox1.Text+"','"+textBox3.Text+"','"+label10.Text+"')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Employee Designation Successful...");
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();

            if(textBox4.Text == "")
            {
                Clear();
            }
        }

        private void EmployeeDept_Load(object sender, EventArgs e)
        {
            label10.Visible = false;
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select DeptName from DepartmentDetails", con);
            SqlDataReader reader;
            reader = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("DeptName", typeof(string));
            dt1.Load(reader);

            comboBox2.DisplayMember = "DeptName";
            comboBox2.DataSource = dt1;
            con.Close();

            error();

            label9.Text = Login1.passingText;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = comboBox2.SelectedValue.ToString();
        }

        private void Clear()
        {
            textBox1.Text = "";
            textBox4.Text = "";
            bunifuDatepicker1.ResetText();
            textBox2.Text = "";
            comboBox1.SelectedValue = "";
            textBox3.Text = "";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            

        }

        private void TopPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {

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

        private void comboBox2_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox2.Text == string.Empty)
            {
                errorProvider1.SetError(comboBox2, "Please Select an Department");
            }
            else
            {
                errorProvider1.SetError(comboBox2, "");
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                errorProvider1.SetError(textBox2, "Please Enter Designation");
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
            }
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox1.Text == string.Empty)
            {
                errorProvider1.SetError(comboBox1, "Please Select a Shift");
            }
            else
            {
                errorProvider1.SetError(comboBox1, "");
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (textBox3.Text == string.Empty)
            {
                errorProvider1.SetError(textBox3, "Please Enter Salary");
            }
            else
            {
                errorProvider1.SetError(textBox3, "");
            }
        }

        void error()
        {
            errorProvider1.SetError(textBox1, "Please Enter Employee Name");
            errorProvider1.SetError(textBox4, "Please Enter Employee ID");
            errorProvider1.SetError(comboBox2, "Please Select an Department");
            errorProvider1.SetError(textBox2, "Please Enter Designation");
            errorProvider1.SetError(comboBox1, "Please Select a Shift");
            errorProvider1.SetError(textBox3, "Please Enter Salary");
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

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            AddDept ad = new AddDept();
            ad.Show();
            this.Hide();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            EmployeeAttendance ea = new EmployeeAttendance();
            this.Hide();
            ea.Show();
        }

        private void bunifuFlatButton8_Click_1(object sender, EventArgs e)
        {
            EmployeeSalary es = new EmployeeSalary();
            this.Hide();
            es.Show();
        }
    }
}

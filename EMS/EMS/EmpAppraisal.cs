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
    public partial class EmpAppraisal : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6CS3N61\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");
        public EmpAppraisal()
        {
            InitializeComponent();
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
            EmployeeAttendanceAdmin ea = new EmployeeAttendanceAdmin();
            ea.Show();
            this.Hide();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            EmployeeSalary esal = new EmployeeSalary();
            esal.Show();
            esal.Hide();
        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "UPDATE EmployeeDepartmentDetails SET Salary ='" + textBox4.Text + "' Where EmployeeId='" + textBox1.Text + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Updated Successfully...");
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        
        private void Clear()
        {
            EmpName.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            bunifuDatepicker2.ResetText();
            textBox1.Text = "";
            textBox4.Text = "";
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
                    string jd = (string)dbr["JoinDate"].ToString();
                    string dn = (string)dbr["DeptName"].ToString();
                    string des = (string)dbr["Designation"].ToString();
                    string sal = (string)dbr["Salary"].ToString();

                    EmpName.Text = en;
                    textBox6.Text = jd;
                    textBox5.Text = dn;
                    textBox2.Text = des;
                    textBox3.Text = sal;
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

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "INSERT INTO EmployeeApprasial (EmployeeId, EmployeeName, JoiningDate, DepartmentName, Designation, Salary, AppraisalSalary, Apprasialwef) VALUES ('" + textBox1.Text + "','" + EmpName.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + bunifuDatepicker2.Value.ToLongDateString() + "')";
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

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard ds = new Dashboard();
            ds.Show();
            this.Hide();
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

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (textBox4.Text == string.Empty)
            {
                errorProvider1.SetError(textBox4, "Please Enter Appraisal Salary");
            }
            else
            {
                errorProvider1.SetError(textBox4, "");
            }
        }

        void error()
        {
            errorProvider1.SetError(textBox1, "Please Enter Employee ID");
            errorProvider1.SetError(textBox4, "Please Enter Appraisal Salary");
        }

        private void EmpAppraisal_Load(object sender, EventArgs e)
        {
            error();
            label10.Text = Login1.passingText;
        }
    }
}

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
    public partial class ManageDept : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6CS3N61\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");
        public ManageDept()
        {
            InitializeComponent();
            BindData();
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
                    textBox3.Text = en;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();

            if (textBox4.Text == "")
            {
                
            }
        }

        private void ManageDept_Load(object sender, EventArgs e)
        {
            error();
            label25.Text = Login1.passingText;
        }
        void BindData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM DepartmentDetails", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            con.Close();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;

            textBox2.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "UPDATE DepartmentDetails SET DeptName ='" + textBox1.Text + "', HeadofDept ='" + textBox3.Text + "', EmployeeId ='" + textBox4.Text + "' Where DeptId='" + textBox2.Text + "' ";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Department Updated Successfully...");
                Clear();

                BindData();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "Delete from DepartmentDetails Where DeptId='" + textBox2.Text + "' ";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Department Deleted Successfully...");
                Clear();

                BindData();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
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

        void error()
        {
            errorProvider1.SetError(textBox4, "Please Enter Employee ID");
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
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
    }
    }

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
    public partial class ManageEmployee : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6CS3N61\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");
        public ManageEmployee()
        {
            InitializeComponent();
            BindData();
        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
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
            EmployeeBioData ebio = new EmployeeBioData();
            this.Hide();
            ebio.Show();
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

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            EmpBankDetails ebd = new EmpBankDetails();
            ebd.Show();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string sql = "UPDATE view_manageemployee SET Status ='" + comboBox1.Text + "' Where EmployeeId='" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully..");
                Clear();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            BindData();

        }

        private void Clear()
        {
            EmpName.Text = "";
            textBox1.Text = "";
            textBox5.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
        }

        void BindData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM view_manageemployee", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            con.Close();
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECt * from view_manageemployee where Designation like ('" + textBox3.Text + "%') OR DeptName like ('" + textBox3.Text + "%')OR EmployeeName like ('" + textBox3.Text + "%') OR EmployeeId like ('" + textBox3.Text + "%') OR Status like ('" + textBox3.Text + "%')", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;

            EmpName.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            EmployeeBioData ebd = new EmployeeBioData();
            ebd.Show();
        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            EmployeeJob ej = new EmployeeJob();
            ej.Show();
        }

        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {
            EmpQualification eq = new EmpQualification();
            eq.Show();
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox1.Text == string.Empty)
            {
                errorProvider1.SetError(comboBox1, "Please Select an Status");
            }
            else
            {
                errorProvider1.SetError(comboBox1, "");
            }
        }

        void error()
        {
            errorProvider1.SetError(comboBox1, "Please Select an Status");
        }

        private void ManageEmployee_Load(object sender, EventArgs e)
        {
            error();
            label25.Text = Login1.passingText;
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

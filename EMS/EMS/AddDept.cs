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
    public partial class AddDept : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6CS3N61\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");

        public AddDept()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            AddDept ad = new AddDept();
            ad.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
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
            EmployeeBioData empbio = new EmployeeBioData();
            empbio.Show();
            this.Hide();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            EmployeeAttendanceAdmin eatt = new EmployeeAttendanceAdmin();
            eatt.Show();
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
                string sql = "INSERT INTO DepartmentDetails (DeptName, HeadofDept, EmployeeId) VALUES ('" + textBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Department Added Successfully...");
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
                Clear();
            }

        }

        private void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            
        }

        private void AddDept_Load(object sender, EventArgs e)
        {
            error();
            label19.Text = Login1.passingText;
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

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                errorProvider1.SetError(textBox1, "Please Enter Department Name");
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (textBox3.Text == string.Empty)
            {
                errorProvider1.SetError(textBox3, "Please Enter Name of Head of Department");
            }
            else
            {
                errorProvider1.SetError(textBox3, "");
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (textBox4.Text == string.Empty)
            {
                errorProvider1.SetError(textBox4, "Please Enter ID of Head of Department");
            }
            else
            {
                errorProvider1.SetError(textBox4, "");
            }
        }

        void error()
        {
            errorProvider1.SetError(textBox1, "Please Enter Department Name");
            errorProvider1.SetError(textBox3, "Please Enter Name of Head of Department");
            errorProvider1.SetError(textBox4, "Please Enter ID of Head of Department");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Login1 l = new Login1();
            l.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            d.Show();
            this.Hide();
        }
    }
}

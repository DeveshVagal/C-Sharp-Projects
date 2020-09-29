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
    public partial class EmpPerformance : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6CS3N61\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");
        public EmpPerformance()
        {
            InitializeComponent();
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMM, yyyy";

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
            this.Hide();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "INSERT INTO EmployeePerformance (EmployeeId, EmployeeName, Designation, DepartmentName, Month, TargetSet, Absenties, TargetAcheived, ConnectionsMade, ClientFeedback, ClientRetained) VALUES ('"+textBox1.Text+"','"+EmpName.Text+"','"+textBox2.Text+"','"+textBox5.Text+ "','"+dateTimePicker1.Value.ToString("MMM, yyyy") +"','"+textBox3.Text+"','"+textBox8.Text+"','"+textBox4.Text+"','"+textBox6.Text+"','"+comboBox1.Text+"','"+textBox9.Text+"')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Performance Rating Done...");
                Clear();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
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
                  

                    EmpName.Text = en;
                    textBox5.Text = dn;
                    textBox2.Text = des;
                    
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
            comboBox1.Text = "";
            textBox2.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            dateTimePicker1.ResetText();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (textBox3.Text == string.Empty)
            {
                errorProvider1.SetError(textBox3, "Please Set No. of Targets");
            }
            else
            {
                errorProvider1.SetError(textBox3, "");
            }
        }

        private void textBox8_Validating(object sender, CancelEventArgs e)
        {
            if (textBox8.Text == string.Empty)
            {
                errorProvider1.SetError(textBox8, "Please Set No. of Absent");
            }
            else
            {
                errorProvider1.SetError(textBox8, "");
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (textBox4.Text == string.Empty)
            {
                errorProvider1.SetError(textBox4, "Please Set No. of Targets Achieved");
            }
            else
            {
                errorProvider1.SetError(textBox4, "");
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (textBox6.Text == string.Empty)
            {
                errorProvider1.SetError(textBox6, "Please Set No. of Connections Made");
            }
            else
            {
                errorProvider1.SetError(textBox6, "");
            }
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox1.Text == string.Empty)
            {
                errorProvider1.SetError(comboBox1, "Please Select an Client Feedback");
            }
            else
            {
                errorProvider1.SetError(comboBox1, "");
            }
        }

        private void textBox9_Validating(object sender, CancelEventArgs e)
        {
            if (textBox9.Text == string.Empty)
            {
                errorProvider1.SetError(textBox9, "Please Set No. of Clients Retained");
            }
            else
            {
                errorProvider1.SetError(textBox9, "");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                errorProvider1.SetError(textBox3, "");
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
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                errorProvider1.SetError(textBox4, "");
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                errorProvider1.SetError(textBox6, "");
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                errorProvider1.SetError(textBox9, "");
            }
        }

        void error()
        {
            errorProvider1.SetError(textBox1, "Please Enter Employee ID");
            errorProvider1.SetError(textBox3, "Please Set No. of Targets");
            errorProvider1.SetError(textBox8, "Please Set No. of Absent");
            errorProvider1.SetError(textBox4, "Please Set No. of Targets Achieved");
            errorProvider1.SetError(textBox6, "Please Set No. of Connections Made");
            errorProvider1.SetError(comboBox1, "Please Select an Client Feedback");
            errorProvider1.SetError(textBox9, "Please Set No. of Clients Retained");
        }

        private void EmpPerformance_Load(object sender, EventArgs e)
        {
            error();
            label25.Text = Login1.passingText;
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

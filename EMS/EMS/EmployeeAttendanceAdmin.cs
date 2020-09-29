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
    public partial class EmployeeAttendanceAdmin : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6CS3N61\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");
        public EmployeeAttendanceAdmin()
        {
            InitializeComponent();
        }
        private void EmployeeAttendanceAdmin_Load(object sender, EventArgs e)
        {
            timer1.Start();
            datetoday.Text = DateTime.Now.ToLongDateString();
            timenow.Text = DateTime.Now.ToLongTimeString();
            label5.Text = Login1.passingText;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timenow.Text = DateTime.Now.ToLongTimeString();
            datetoday.Text = DateTime.Now.ToLongDateString();
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = DateTime.Now.ToLongTimeString();
            timenow.Text = textBox3.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = DateTime.Now.ToLongTimeString();
            timenow.Text = textBox4.Text;
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "UPDATE Attendence SET TimeIn='" + textBox3.Text + "', TimeOut ='" + textBox4.Text + "', PresencyRemark ='" + comboBox1.Text + "' Where EmployeeId='" + textBox1.Text + "' ";
                con.Open();
                SqlCommand cmd1 = new SqlCommand(sql, con);
                cmd1.CommandType = CommandType.Text;
                cmd1.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Attendence Recorded Successfully...");
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
            string query = "select * from Attendence where EmployeeId = '" + textBox1.Text + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dbr;
            try
            {
                con.Open();
                dbr = cmd.ExecuteReader();
                while (dbr.Read())
                {
                    string eid = (string)dbr["EmployeeId"].ToString();
                    string en = (string)dbr["EmployeeName"].ToString();
                    string dept = (string)dbr["DepartmentName"].ToString();
                    string ti = (string)dbr["TimeIn"].ToString();
                    string to = (string)dbr["TimeOut"].ToString();
                    string pr = (string)dbr["PresencyRemark"].ToString();

                    textBox1.Text = eid;
                    EmpName.Text = en;
                    textBox2.Text = dept;
                    textBox3.Text = ti;
                    textBox4.Text = to;
                    comboBox1.Text = pr;
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
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.SelectedValue = "";
            EmpName.Text = "";
        }

        private void datetoday_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            timenow.Text = DateTime.Now.ToLongTimeString();
            datetoday.Text = DateTime.Now.ToLongDateString();
            timer1.Start();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         /*   if(comboBox1.SelectedIndex.ToString() == "Absent")
            {
                textBox3.Text = "";
                textBox4.Text = "";
            }*/
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dashboard ds = new Dashboard();
            this.Hide();
            ds.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Login1 log = new EMS.Login1();
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
        void error()
        {
            errorProvider1.SetError(textBox1, "Please Enter Employee ID");
        }

        private void EmployeeAttendanceAdmin_Load_1(object sender, EventArgs e)
        {
            timer1.Start();
            datetoday.Text = DateTime.Now.ToLongDateString();
            timenow.Text = DateTime.Now.ToLongTimeString();
            label5.Text = Login1.passingText;
            error();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            EmployeeAttendanceAdmin ea = new EmployeeAttendanceAdmin();
            ea.Show();
            this.Hide();
        }
    }
}

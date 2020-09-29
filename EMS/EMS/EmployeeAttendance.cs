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
    public partial class EmployeeAttendance : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6CS3N61\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");
        public EmployeeAttendance()
        {
            InitializeComponent();
        }

        private void EmployeeAttendance_Load(object sender, EventArgs e)
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

       

      

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            SalRep ad = new SalRep();
            ad.Show();
            this.Hide();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Resume rr = new Resume();
            this.Hide();
            rr.Show();
        }

        p

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = DateTime.Now.ToLongTimeString();

            try
            {
                string sql = "INSERT INTO Attendence (EmployeeId, EmployeeName, DepartmentName, Date, TimeIn) VALUES ('" + textBox1.Text + "','" + EmpName.Text + "','" + textBox2.Text + "','" + datetoday.Text + "','" + textBox3.Text + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = DateTime.Now.ToLongTimeString();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            DateTime timeIn = Convert.ToDateTime(textBox3.Text);
            DateTime timeOut = Convert.ToDateTime(textBox4.Text);

            TimeSpan timediff = timeOut - timeIn;

            double hrs = timediff.Hours;

            if (hrs <= 8)
            {
                try
                {
                    label2.Text = "Half-Day";
                    string sql = "UPDATE Attendence SET TimeOut ='" + textBox4.Text + "', PresencyRemark ='" + label2.Text + "' Where EmployeeId='" + textBox1.Text + "' ";
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

            else if (hrs > 8 && hrs <= 10)
            {
                try
                {
                    label2.Text = "Full-Day";
                    string sql = "UPDATE Attendence SET TimeOut ='" + textBox4.Text + "', PresencyRemark ='" + label2.Text + "' Where EmployeeId='" + textBox1.Text + "' ";
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
            else if (hrs >= 10)
            {
                try
                {
                    label2.Text = "Over-Time";
                    string sql = "UPDATE Attendence SET TimeOut ='" + textBox4.Text + "', PresencyRemark ='" + label2.Text + "' Where EmployeeId='" + textBox1.Text + "' ";
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




        }

        private void Clear()
        {
            EmpName.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
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
                    string dept = (string)dbr["DeptName"].ToString();

                    EmpName.Text = en;
                    textBox2.Text = dept;

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

        private void EmployeeAttendance_Load_1(object sender, EventArgs e)
        {
            label5.Text = Login1.passingText;
            error();
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

        private void button3_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            d.Show();
            this.Hide();
        }
    }
}


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
    public partial class EmpQualification : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6CS3N61\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");
        public EmpQualification()
        {
            InitializeComponent();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            EmployeeJob emjob = new EmployeeJob();
            emjob.Show();
            this.Hide();
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
            ebio.Show();
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
            EmployeeDept empd = new EmployeeDept();
            empd.Show();
            this.Hide();
        }

        private void EmpQualification_Load(object sender, EventArgs e)
        {
            bunifuFlatButton7.Visible = false;
            bunifuFlatButton8.Visible = false;
            bunifuFlatButton9.Visible = false;
            error();
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
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "INSERT INTO EmployeeQualification (EmployeeId, EmployeeName, SSCBoardName, SSCYOP, SSCPercentage, HSCBoardName, HSCYOP, HSCPercentage, UGCourseName, UGUniversity, UGYOP, UGPercentage, PGCourseName, PGUniversity, PGYOP, PGPercentage) VALUES ('"+textBox4.Text+"','"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox5.Text+"','"+textBox8.Text+"','"+textBox7.Text+"','"+textBox6.Text+"','"+textBox11.Text+"','"+textBox10.Text+"','"+textBox12.Text+"','"+textBox9.Text+"','"+textBox16.Text+"','"+textBox15.Text+"','"+textBox13.Text+"','"+textBox14.Text+"')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Employee Qualification Details Inserted Successfully...");
                Clear();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            string query = "select * from EmployeeQualification where EmployeeId = '" + textBox4.Text + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dbr;
            try
            {
                con.Open();
                dbr = cmd.ExecuteReader();
                while (dbr.Read())
                {
                    string en = (string)dbr["EmployeeName"].ToString();
                    string sscbn = (string)dbr["SSCBoardName"].ToString();
                    string sscyop = (string)dbr["SSCYOP"].ToString();
                    string sscper = (string)dbr["SSCPercentage"].ToString();
                    string hscbn = (string)dbr["HSCBoardName"].ToString();
                    string hscyop = (string)dbr["HSCYOP"].ToString();
                    string hscper = (string)dbr["HSCPercentage"].ToString();
                    string ugcn = (string)dbr["UGCourseName"].ToString();
                    string uguni = (string)dbr["UGUniversity"].ToString();
                    string ugyop = (string)dbr["UGYOP"].ToString();
                    string ugper = (string)dbr["UGPercentage"].ToString();
                    string pgcn = (string)dbr["PGCourseName"].ToString();
                    string pguni = (string)dbr["PGUniversity"].ToString();
                    string pgyop = (string)dbr["PGYOP"].ToString();
                    string pgper = (string)dbr["PGPercentage"].ToString();

                    textBox1.Text = en;
                    textBox2.Text = sscbn;
                    textBox3.Text = sscyop;
                    textBox5.Text = sscper;
                    textBox8.Text = hscbn;
                    textBox7.Text = hscyop;
                    textBox6.Text = hscper;
                    textBox11.Text = ugcn;
                    textBox10.Text = uguni;
                    textBox12.Text = ugyop;
                    textBox9.Text = ugper;
                    textBox16.Text = pgcn;
                    textBox15.Text = pguni;
                    textBox13.Text = pgyop;
                    textBox14.Text = pgper;
                    bunifuFlatButton9.Visible = false;
                    bunifuFlatButton6.Visible = false;
                    bunifuFlatButton7.Visible = true;
                    bunifuFlatButton8.Visible = true;
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

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "UPDATE EmployeeQualification SET SSCBoardName ='"+textBox2.Text+"', SSCYOP ='"+textBox3.Text+"', SSCPercentage ='"+textBox5.Text+"', HSCBoardName ='"+textBox8.Text+"', HSCYOP ='"+textBox7.Text+"', HSCPercentage ='"+textBox6.Text+"', UGCourseName ='"+textBox11.Text+"', UGUniversity ='"+textBox10.Text+"', UGYOP ='"+textBox12.Text+"', UGPercentage ='"+textBox9.Text+"', PGCourseName ='"+textBox16.Text+"', PGUniversity ='"+textBox15.Text+"', PGYOP ='"+textBox13.Text+"', PGPercentage ='"+textBox14.Text+"' WHERE EmployeeId='" + textBox4.Text + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Employee Qualification Details Updated Successfully...");
                bunifuFlatButton7.Visible = false;
                bunifuFlatButton9.Visible = true;
                bunifuFlatButton6.Visible = true;
                bunifuFlatButton8.Visible = false;
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
                string sql = "DELETE FROM EmployeeQualification WHERE EmployeeId='" + textBox4.Text + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Employee Qualification Details Deleted Successfully...");
                bunifuFlatButton7.Visible = false;
                bunifuFlatButton9.Visible = true;
                bunifuFlatButton6.Visible = true;
                bunifuFlatButton8.Visible = false;
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
            Dashboard d = new Dashboard();
            d.Show();
            this.Hide();
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

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                errorProvider1.SetError(textBox2, "Please Enter SSC Board Name");
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
                errorProvider1.SetError(textBox3, "Please Enter SSC YEAR OF PASSING");
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
                errorProvider1.SetError(textBox5, "Please Enter SSC Percentage");
            }
            else
            {
                errorProvider1.SetError(textBox5, "");
            }
        }

        private void textBox8_Validating(object sender, CancelEventArgs e)
        {
            if (textBox8.Text == string.Empty)
            {
                errorProvider1.SetError(textBox8, "Please Enter HSC Board Name");
            }
            else
            {
                errorProvider1.SetError(textBox8, "");
            }
        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            if (textBox7.Text == string.Empty)
            {
                errorProvider1.SetError(textBox7, "Please Enter HSC YEAR OF PASSING");
            }
            else
            {
                errorProvider1.SetError(textBox7, "");
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (textBox6.Text == string.Empty)
            {
                errorProvider1.SetError(textBox6, "Please Enter HSC Percentage");
            }
            else
            {
                errorProvider1.SetError(textBox6, "");
            }
        }

        private void textBox11_Validating(object sender, CancelEventArgs e)
        {
            if (textBox11.Text == string.Empty)
            {
                errorProvider1.SetError(textBox11, "Please Enter UG Course Name");
            }
            else
            {
                errorProvider1.SetError(textBox11, "");
            }
        }

        private void textBox10_Validating(object sender, CancelEventArgs e)
        {
            if (textBox10.Text == string.Empty)
            {
                errorProvider1.SetError(textBox10, "Please Enter UG University Name");
            }
            else
            {
                errorProvider1.SetError(textBox10, "");
            }
        }

        private void textBox12_Validating(object sender, CancelEventArgs e)
        {
            if (textBox12.Text == string.Empty)
            {
                errorProvider1.SetError(textBox12, "Please Enter UG YEAR OF PASSING");
            }
            else
            {
                errorProvider1.SetError(textBox12, "");
            }
        }

        private void textBox9_Validating(object sender, CancelEventArgs e)
        {
            if (textBox9.Text == string.Empty)
            {
                errorProvider1.SetError(textBox9, "Please Enter UG Percentage");
            }
            else
            {
                errorProvider1.SetError(textBox9, "");
            }
        }

        private void textBox16_Validating(object sender, CancelEventArgs e)
        {
            if (textBox16.Text == string.Empty)
            {
                errorProvider1.SetError(textBox16, "Please Enter PG Course Name");
            }
            else
            {
                errorProvider1.SetError(textBox16, "");
            }
        }

        private void textBox15_Validating(object sender, CancelEventArgs e)
        {
            if (textBox15.Text == string.Empty)
            {
                errorProvider1.SetError(textBox15, "Please Enter PG University Name");
            }
            else
            {
                errorProvider1.SetError(textBox15, "");
            }
        }

        private void textBox13_Validated(object sender, EventArgs e)
        {

        }

        private void textBox13_Validating(object sender, CancelEventArgs e)
        {
            if (textBox13.Text == string.Empty)
            {
                errorProvider1.SetError(textBox13, "Please Enter PG YEAR OF PASSING");
            }
            else
            {
                errorProvider1.SetError(textBox13, "");
            }
        }

        private void textBox14_Validating(object sender, CancelEventArgs e)
        {
            if (textBox14.Text == string.Empty)
            {
                errorProvider1.SetError(textBox14, "Please Enter PG Percentage");
            }
            else
            {
                errorProvider1.SetError(textBox14, "");
            }
        }

        void error()
        {
            errorProvider1.SetError(textBox4, "Please Enter Employee ID");
            errorProvider1.SetError(textBox1, "Please Enter Employee Name");
            errorProvider1.SetError(textBox2, "Please Enter SSC Board Name");
            errorProvider1.SetError(textBox3, "Please Enter SSC YEAR OF PASSING");
            errorProvider1.SetError(textBox5, "Please Enter SSC Percentage");
            errorProvider1.SetError(textBox8, "Please Enter HSC Board Name");
            errorProvider1.SetError(textBox7, "Please Enter HSC YEAR OF PASSING");
            errorProvider1.SetError(textBox6, "Please Enter HSC Percentage");
            errorProvider1.SetError(textBox11, "Please Enter UG Course Name");
            errorProvider1.SetError(textBox10, "Please Enter UG University Name");
            errorProvider1.SetError(textBox12, "Please Enter UG YEAR OF PASSING");
            errorProvider1.SetError(textBox9, "Please Enter UG Percentage");
            errorProvider1.SetError(textBox16, "Please Enter PG Course Name");
            errorProvider1.SetError(textBox15, "Please Enter PG University Name");
            errorProvider1.SetError(textBox13, "Please Enter PG YEAR OF PASSING");
            errorProvider1.SetError(textBox14, "Please Enter PG Percentage");
        }
    }
}

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
    public partial class EmployeeSalary : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6CS3N61\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");
        public EmployeeSalary()
        {
            InitializeComponent();
        }

        private void EmployeeSalary_Load(object sender, EventArgs e)
        {
            timer1.Start();
            dt.Text = DateTime.Now.ToLongDateString();
            error();
            label25.Text = Login1.passingText;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            dt.Text = DateTime.Now.ToLongDateString();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e) //Inserting Salary in database
        {
            try
            {
                string sql = "INSERT INTO EmployeeSalary (EmployeeId, Month, Year, EmployeeName, DepartmentName, Designation, PancardNumber, BankName, AccountNumber, BasicSalary, DA, HRA, TA, MA, SP, GrossSalary, PF, IT, PT, ESIC, Others, Deductions, NetPay) VALUES ('"+textBox1.Text+"','"+comboBox1.Text+"','"+comboBox2.Text+"','"+EmpName.Text+"','"+textBox5.Text+"','"+textBox2.Text+"','"+textBox4.Text+"','"+textBox3.Text+"','"+textBox8.Text+"','"+textBox9.Text+"','"+textBox7.Text+"','"+textBox10.Text+"','"+textBox11.Text+"','"+textBox14.Text+"','"+textBox13.Text+"','"+textBox12.Text+"','"+textBox19.Text+"','"+textBox18.Text+"','"+textBox17.Text+"','"+textBox15.Text+"','"+textBox16.Text+"','"+textBox20.Text+"','"+textBox21.Text+"')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Inserted Successfully...");
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e) //Retrieving Data From View
        {
            string query = "select * from view_empsalary where EmployeeId = '" + textBox1.Text + "' ";
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
                    string pn = (string)dbr["PanNumber"].ToString();
                    string an = (string)dbr["AccountNumber"].ToString();
                    string bn = (string)dbr["BankName"].ToString();
                    string sal = (string)dbr["Salary"].ToString();

                    EmpName.Text = en;
                    textBox5.Text = dn;
                    textBox2.Text = des;
                    textBox4.Text = pn;
                    textBox8.Text = an;
                    textBox3.Text = bn;
                    textBox9.Text = sal;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();

            

        }

        private void Clear() //Clearing All fields of Key_Up Event
        {
            EmpName.Text = "";
            textBox5.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox8.Text = "";
            textBox3.Text = "";
            textBox9.Text = "";
        }

        private void button1_Click(object sender, EventArgs e) //Calculating GrossPay
        {
            double bs, da, hra, ta, ma, sp, gs;
            bs = Convert.ToDouble(textBox9.Text);

             da = bs * 0.08;
            hra = bs * 0.07;
             ta = bs * 0.06;
             ma = bs * 0.05;
             sp = bs * 0.04;
             gs = bs + da + hra + ta + ma + sp;


            textBox7.Text = da.ToString();
            textBox10.Text = hra.ToString();
            textBox11.Text = ta.ToString();
            textBox14.Text = ma.ToString();
            textBox13.Text = sp.ToString();
            textBox12.Text = gs.ToString();
        }

        private void button2_Click(object sender, EventArgs e)  //Calculating Deductions
        {
            double bs, pf, pt, esic, it, dec, oth;
            bs = Convert.ToDouble(textBox7.Text);

            pf = bs * 0.08;                         //PF              
            pt = bs * 0.07;                         //PT
            esic = bs * 0.05;                       //ESIC
            oth = Convert.ToDouble(textBox16.Text); //oth
                              //Total DEDS
            

            textBox19.Text = pf.ToString();
            textBox17.Text = pt.ToString();
            textBox15.Text = esic.ToString();
           
            //Calculating IT with Filling Up Deduction Columns and displaying total Deductions
            if (bs <= 200000)
            {
                it = 0;
                textBox18.Text = it.ToString();
                dec = pf + pt + esic + oth + it;
                textBox20.Text = dec.ToString();

            }

            if (bs > 200000 || bs <= 500000)
            {
                it = bs * 0.10;
                textBox18.Text = it.ToString();
                dec = pf + pt + esic + oth + it;
                textBox20.Text = dec.ToString();
            }

            if (bs > 500000 || bs <= 1000000)
            {
                it = bs * 0.2;
                textBox18.Text = it.ToString();
                dec = pf + pt + esic + oth + it;
                textBox20.Text = dec.ToString();
            }

            if (bs > 1000000)
            {
                it = bs * 0.3;
                textBox18.Text = it.ToString();
                dec = pf + pt + esic + oth + it;
                textBox20.Text = dec.ToString();
            }

            //Calculating NetPay

            double gs = Convert.ToDouble(textBox12.Text);
            double ded = Convert.ToDouble(textBox20.Text);
            double netpay = gs - ded;
            textBox21.Text = netpay.ToString();          


        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            EmpName.Text = "";
            textBox5.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox8.Text = "";
            textBox3.Text = "";
            textBox9.Text = "";

            textBox7.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
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

        private void textBox16_Validating(object sender, CancelEventArgs e)
        {

        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                errorProvider1.SetError(textBox16, "");
            }
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

        private void EmployeeSalary_Load_1(object sender, EventArgs e)
        {
            timer1.Start();
            dt.Text = DateTime.Now.ToLongDateString();
            error();
            label25.Text = Login1.passingText;
        }
    }
}


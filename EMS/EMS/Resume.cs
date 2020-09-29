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
    public partial class Resume : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6CS3N61\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");
        public Resume()
        {
            InitializeComponent();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            CrystalReport1 cr = new CrystalReport1();
            string sql = "SELECT * from view_resume where EmployeeId='" + textBox1.Text + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            sda.Fill(ds, "view_resume");
            cr.SetDataSource(ds.Tables["view_resume"]);
            crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.Refresh();
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

        private void Resume_Load(object sender, EventArgs e)
        {
            error();
            label5.Text = Login1.passingText;
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

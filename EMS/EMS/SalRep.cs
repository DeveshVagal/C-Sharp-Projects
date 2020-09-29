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
    public partial class SalRep : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6CS3N61\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");
        public SalRep()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            CrystalReport3 cr = new CrystalReport3();
            string sql = "SELECT * from EmployeeSalary where EmployeeId='" + textBox1.Text + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            sda.Fill(ds, "EmployeeSalary");
            cr.SetDataSource(ds.Tables["EmployeeSalary"]);
            crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.Refresh();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Login1 log = new Login1();
            this.Hide();
            log.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dashboard ds = new Dashboard();
            ds.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

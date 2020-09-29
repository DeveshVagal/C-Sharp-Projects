using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMS
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            ManageEmployee me = new ManageEmployee();
            me.Show();
            this.Hide();
        }

        private void pictureBox12_Click_1(object sender, EventArgs e)
        {
            ManageDept md = new ManageDept();
            md.Show();
            this.Hide();
        }

        private void pictureBox15_Click_1(object sender, EventArgs e)
        {
            EmpPromotions ep = new EmpPromotions();
            ep.Show();
            this.Hide();
        }

        private void pictureBox16_Click_1(object sender, EventArgs e)
        {
            EmpAppraisal ea = new EmpAppraisal();
            ea.Show();
            this.Hide();
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            EmpPerformance ep = new EmpPerformance();
            ep.Show();
            this.Hide();
        }

        private void bunifuFlatButton2_Click_2(object sender, EventArgs e)
        {
            AddDept ad = new AddDept();
            ad.Show();
            this.Hide();
        }

        private void bunifuFlatButton1_Click_2(object sender, EventArgs e)
        {
            EmployeeBioData eb = new EmployeeBioData();
            eb.Show();
            this.Hide();

        }

        private void bunifuFlatButton3_Click_2(object sender, EventArgs e)
        {
            EmployeeAttendanceAdmin eaa = new EmployeeAttendanceAdmin();
            eaa.Show();
            this.Hide();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            EmployeeSalary es = new EmployeeSalary();
            es.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddUpdateAdmin ad = new AddUpdateAdmin();
            ad.Show();
            this.Hide();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Login1 log = new Login1();
            log.Show();
            this.Hide();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            label3.Text = Login1.passingText;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            IDCARD id = new IDCARD();
            this.Hide();
            id.Show();
           
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Resume rr = new Resume();
            this.Hide();
            rr.Show();
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            SalRep sr = new SalRep();
            this.Hide();
            sr.Show();
        }
    }
}

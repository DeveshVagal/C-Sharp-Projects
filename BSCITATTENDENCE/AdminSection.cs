using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BSCITATTENDENCE
{
    public partial class AdminSection : Form
    {
        public AdminSection()
        {
            InitializeComponent();
        }

        private void AdminSection_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoginPage lp = new LoginPage();
            lp.Show();
            this.Hide();
        }

        private void AdminSection_Load(object sender, EventArgs e)
        {
            label1.Text = LoginPage.passingText;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminStudentView asv = new AdminStudentView();
            asv.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StudentAttendenceRecord sar = new StudentAttendenceRecord();
            sar.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            StudentMonthlyAttendence sma = new StudentMonthlyAttendence();
            sma.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StudentYearlyAttendence sya = new StudentYearlyAttendence();
            sya.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ClassYearlyAttendence cya = new ClassYearlyAttendence();
            cya.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            loginapprovalandstaffupdate laasud = new loginapprovalandstaffupdate();
            laasud.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LoginHistory lh = new LoginHistory();
            lh.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StaffDetails sd = new StaffDetails();
            sd.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DeleteAllData dad = new DeleteAllData();
            dad.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DataStaffandAdminAttendence dsaaa = new DataStaffandAdminAttendence();
            dsaaa.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AdminAttendence aa = new AdminAttendence();
            aa.Show();
            this.Hide();
        }
    }
}

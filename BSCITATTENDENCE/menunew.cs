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
    public partial class menunew : Form
    {
        public menunew()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddingStudents ass = new AddingStudents();
            ass.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            attendencemenu am = new attendencemenu();
            am.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView();
            dv.Show();
            this.Hide();
        }

        private void menunew_Load(object sender, EventArgs e)
        {
            label2.Text = LoginPage.passingText;
        }

        private void menunew_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoginPage lp = new LoginPage();
            lp.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StaffAttendence sa = new StaffAttendence();
            sa.Show();
            this.Hide();
        }
    }
}

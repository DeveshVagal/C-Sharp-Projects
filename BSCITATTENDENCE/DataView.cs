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
    public partial class DataView : Form
    {
        public DataView()
        {
            InitializeComponent();
        }

        private void DataView_Load(object sender, EventArgs e)
        {
            label4.Text = LoginPage.passingText;
        }

        private void DataView_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void DataView_FormClosed(object sender, FormClosedEventArgs e)
        {
            menunew mn = new menunew();
            mn.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StudentsView sv = new StudentsView();
            sv.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AttendenceRecord ar = new AttendenceRecord();
            ar.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataAttendencePercentage dap = new DataAttendencePercentage();
            dap.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataStudentYearlyAttendencePercentage dsyap = new DataStudentYearlyAttendencePercentage();
            dsyap.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Data_Class_Attendence_Per_Year dcpy = new Data_Class_Attendence_Per_Year();
            dcpy.Show();
            this.Hide();
        }
    }
}

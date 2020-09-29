using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BloodDonation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Maximum = 100;
            progressBar1.PerformStep();
            if (progressBar1.Value == 100)
            {
                timer1.Enabled = false;
                this.Hide();
                Login l = new Login();
                l.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 500;
        }

       
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TempScreeningRecordManagementSystem
{
    public partial class LoadingScreen : Form
    {
        public LoadingScreen()
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
                Login lp = new Login();
                lp.Show();
                this.Hide();
            }
        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 500;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class Records : Form
    {
        public Records()
        {
            InitializeComponent();
        }

        private void Records_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Choose c = new Choose();
            c.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            certificaterecords cr = new certificaterecords();
            cr.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bloodsalesrecords bsr = new bloodsalesrecords();
            bsr.Show();
            this.Hide();
        }
    }
}

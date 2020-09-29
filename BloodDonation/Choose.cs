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
    public partial class Choose : Form
    {
        public Choose()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RecordsList rl = new RecordsList();
            rl.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BloodSales bs = new BloodSales();
            bs.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Records r = new Records();
            r.Show();
            this.Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            certificategeneration cg = new certificategeneration();
            cg.Show();
            this.Hide();
        }
    }
}

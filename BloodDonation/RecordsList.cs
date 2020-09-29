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
    public partial class RecordsList : Form
    {
        public RecordsList()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Welcome w = new Welcome();
            w.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Donor d = new Donor();
            d.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hospital h = new Hospital();
            h.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BloodAvailable ba = new BloodAvailable();
            ba.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Choose c = new Choose();
            c.Show();
            this.Hide();
        }
    }
}

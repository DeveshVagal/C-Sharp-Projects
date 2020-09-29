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
    public partial class attendencemenu : Form
    {
        public attendencemenu()
        {
            InitializeComponent();
        }

        private void attendencemenu_Load(object sender, EventArgs e)
        {
            label2.Text = LoginPage.passingText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            INSERTATTENDENCE ia = new INSERTATTENDENCE();
            ia.Show();
            this.Hide();
        }

        private void attendencemenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            menunew mn = new menunew();
            mn.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MANAGEATTENDENCE ma = new MANAGEATTENDENCE();
            ma.Show();
            this.Hide();
        }
    }
}

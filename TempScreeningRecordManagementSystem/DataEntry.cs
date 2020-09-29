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
    public partial class DataEntry : Form
    {
        public DataEntry()
        {
            InitializeComponent();
        }

        private void DataEntry_Load(object sender, EventArgs e)
        {
            label1.Text = Login.passingtext;
        }

        private void DataEntry_FormClosed(object sender, FormClosedEventArgs e)
        {

            Login lp = new Login();
            lp.Show();
            this.Hide();
        }

        private void temperatureScreeningRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScreenTemperatureRecord str = new ScreenTemperatureRecord();
            str.Show();
        }

        private void dataOfTemperatureScreeningRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataofScreeningTemperatureRecord dostr = new DataofScreeningTemperatureRecord();
            dostr.Show();
        }

        private void documentGenerationRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataofDocumentGeneration dodg = new DataofDocumentGeneration();
            dodg.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help h = new Help();
            h.Show();
        }
    }
}

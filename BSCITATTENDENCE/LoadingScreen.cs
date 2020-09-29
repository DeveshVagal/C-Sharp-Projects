using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;

namespace BSCITATTENDENCE
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
                LoginPage lp = new LoginPage();
                lp.Show();
                this.Hide();

                SpeechSynthesizer speechSynth = new SpeechSynthesizer();
                speechSynth.Volume = 100;
                speechSynth.Rate = -2;
                PromptBuilder builder = new PromptBuilder();
                builder.ClearContent();
                builder.AppendText(label5.Text);
                speechSynth.Speak(builder);
            }
        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            label5.Visible = false;
            timer1.Enabled = true;
            timer1.Interval = 500;
        }
    }
}

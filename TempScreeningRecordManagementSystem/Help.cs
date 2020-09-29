using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace TempScreeningRecordManagementSystem
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Send the URL to the operating system.
            Process.Start(e.Link.LinkData as string);
        }

        private void Help_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void Help_Load(object sender, EventArgs e)
        {
            // Add a link to the LinkLabel.
            LinkLabel.Link link = new LinkLabel.Link();
            link.LinkData = "https://forms.gle/9aLFwRyCQcUTp4HTA";
            linkLabel1.Links.Add(link);
        }
    }
}

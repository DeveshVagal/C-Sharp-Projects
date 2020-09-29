using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BloodDonation
{
    public partial class BloodSalesReceipt : Form
    {
        public BloodSalesReceipt()
        {
            InitializeComponent();

            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
        }

        private void BloodSalesReceipt_Load(object sender, EventArgs e)
        {
            label2.Text = bloodsalesrecords.billno;
            label3.Text = bloodsalesrecords.date;
            label4.Text = bloodsalesrecords.patientname;
            label5.Text = bloodsalesrecords.hospitalname;
            label6.Text = bloodsalesrecords.bloodgroup;
            label7.Text = bloodsalesrecords.unitsavailable;
            label8.Text = bloodsalesrecords.costperunit;
            label9.Text = bloodsalesrecords.unitssold;
            label10.Text = bloodsalesrecords.totalcost;

            CrystalReport2 cr = new CrystalReport2();
            TextObject patientname = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["Text5"];
            patientname.Text = label4.Text;
            crystalReportViewer1.ReportSource = cr;

            TextObject hospitalname = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["Text9"];
            hospitalname.Text = label5.Text;
            crystalReportViewer1.ReportSource = cr;

            TextObject billno = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["Text11"];
            billno.Text = label2.Text;
            crystalReportViewer1.ReportSource = cr;

            TextObject date = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["Text13"];
            date.Text = label3.Text;
            crystalReportViewer1.ReportSource = cr;

            TextObject bloodgroup = (TextObject)cr.ReportDefinition.Sections["Section3"].ReportObjects["Text18"];
            bloodgroup.Text = label6.Text;
            crystalReportViewer1.ReportSource = cr;

            TextObject costperunit = (TextObject)cr.ReportDefinition.Sections["Section3"].ReportObjects["Text19"];
            costperunit.Text = label8.Text;
            crystalReportViewer1.ReportSource = cr;

            TextObject unitssold = (TextObject)cr.ReportDefinition.Sections["Section3"].ReportObjects["Text20"];
            unitssold.Text = label9.Text;
            crystalReportViewer1.ReportSource = cr;

            TextObject totalcost = (TextObject)cr.ReportDefinition.Sections["Section3"].ReportObjects["Text21"];
            totalcost.Text = label10.Text;
            crystalReportViewer1.ReportSource = cr;

            TextObject grandtotal = (TextObject)cr.ReportDefinition.Sections["Section3"].ReportObjects["Text24"];
            grandtotal.Text = label10.Text;
            crystalReportViewer1.ReportSource = cr;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            bloodsalesrecords bsr = new bloodsalesrecords();
            bsr.Show();
            this.Hide();
        }
    }
}

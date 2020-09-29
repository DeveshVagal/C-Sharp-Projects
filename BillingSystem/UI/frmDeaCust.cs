using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BillingSystem.BLL;
using BillingSystem.DAL;
using DGVPrinterHelper;
using System.Text.RegularExpressions;

namespace BillingSystem.UI
{
    public partial class frmDeaCust : Form
    {
        public frmDeaCust()
        {
            InitializeComponent();
            error();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        DeaCustBLL dc = new DeaCustBLL();
        DeaCustDAL dcDal = new DeaCustDAL();
        userDAL udal = new userDAL();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //get the values from form
            dc.type = cmbDeaCust.Text;
            dc.name = txtName.Text;
            dc.email = txtEmail.Text;
            dc.contact = txtContact.Text;
            dc.address = txtAddress.Text;
            dc.added_date = DateTime.Now;

            //getting the ID of logged in user and passing its value to Dealer or Customer module
            string loggedUsr = frmLogin.loggedIn;
            userBLL usr = udal.GetIDFromUsername(loggedUsr);
            dc.added_by = usr.id;

            //Creating a Boolean Variable to check the dealer or customer is added or not
            bool success = dcDal.INSERT(dc);

            if (success == true)
            {
                MessageBox.Show("Dealer or Customer Added Successfully.");
                Clear();

                //Refresh Data Grid View
                DataTable dt = dcDal.Select();
                dgvDeaCust.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed to Add Dealer or Customer.");   
            }
        }

        public void Clear()
        {
            txtDeaCustID.Text = "";
            txtName.Text = "";
            txtEmail.Text="";
            txtContact.Text = "";
            txtAddress.Text = "";
            txtSearch.Text = "";
        }

        private void frmDeaCust_Load(object sender, EventArgs e)
        {
            //Refresh Data Grid View
            DataTable dt = dcDal.Select();
            dgvDeaCust.DataSource = dt;
        }

        private void dgvDeaCust_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Int variable to get the identity of row clicked
            int rowIndex = e.RowIndex;

            txtDeaCustID.Text = dgvDeaCust.Rows[rowIndex].Cells[0].Value.ToString();
            cmbDeaCust.Text = dgvDeaCust.Rows[rowIndex].Cells[1].Value.ToString();
            txtName.Text = dgvDeaCust.Rows[rowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dgvDeaCust.Rows[rowIndex].Cells[3].Value.ToString();
            txtContact.Text = dgvDeaCust.Rows[rowIndex].Cells[4].Value.ToString();
            txtAddress.Text = dgvDeaCust.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Get the values from form
            dc.id = int.Parse(txtDeaCustID.Text);
            dc.type = cmbDeaCust.Text;
            dc.name = txtName.Text;
            dc.email = txtEmail.Text;
            dc.contact = txtContact.Text;
            dc.address = txtAddress.Text;
            dc.added_date = DateTime.Now;

            //getting the ID of logged in user and passing its value to Dealer or Customer module
            string loggedUsr = frmLogin.loggedIn;
            userBLL usr = udal.GetIDFromUsername(loggedUsr);
            dc.added_by = usr.id;

            //Boolean variable to Check whether the dealer or customer is updated or not
            bool success = dcDal.Update(dc);

            if (success == true)
            {
                MessageBox.Show("Dealer or Customer Updated Successfully.");
                Clear();

                //Refresh Data Grid View
                DataTable dt = dcDal.Select();
                dgvDeaCust.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed to Update Dealer or Customer.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Get the ID of the user to be Deleted from form
            dc.id = int.Parse(txtDeaCustID.Text);

            //Boolean Variable to check the dealer or Customer is Deleted or not
            bool success = dcDal.Delete(dc);

            if (success == true)
            {
                MessageBox.Show("Dealer or Customer Deleted Successfully.");
                Clear();

                //Refresh Data Grid View
                DataTable dt = dcDal.Select();
                dgvDeaCust.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed to Delete Dealer or Customer.");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Get the keyword from textbox
            string keywords = txtSearch.Text;

            if (keywords != null)
            {
                DataTable dt = dcDal.Search(keywords);
                dgvDeaCust.DataSource = dt;
            }
            else
            {
                DataTable dt = dcDal.Select();
                dgvDeaCust.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = "C:";
            saveFileDialog1.Title = "Save as Excel File";
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Excel Files(2003)|*.xls|Excel Files(2007)|*.xlsx|Excel Files(2010)|*.xlsx|Excel Files(2013)|*.xlsx|Excel Files(2016)|*.xlsx";

            if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Microsoft.Office.Interop.Excel.ApplicationClass ExcelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                ExcelApp.Application.Workbooks.Add(Type.Missing);

                //Change Properties of the WorkBook
                ExcelApp.Columns.ColumnWidth = 20;

                //Storing the Header Value in Excel
                for (int i = 1; i < dgvDeaCust.Columns.Count + 1; i++)
                {
                    ExcelApp.Cells[1, i] = dgvDeaCust.Columns[i - 1].HeaderText;
                }

                //Storing Each row and column value to excel sheet
                for (int i = 0; i < dgvDeaCust.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvDeaCust.Columns.Count; j++)
                    {
                        if (dgvDeaCust.Rows[i].Cells[j].Value != null)
                        {
                            ExcelApp.Cells[i + 2, j + 1] = dgvDeaCust.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }

                ExcelApp.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName.ToString());
                ExcelApp.ActiveWorkbook.Saved = true;
                ExcelApp.Quit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();

            printer.Title = "\r\n\r\n\r\n PRIYA ELECTRICALS \r\n\r\n";
            printer.SubTitle = " DEALER & CUSTOMER REPORT \r\n";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.PrintDataGridView(dgvDeaCust);
        }

        private void cmbDeaCust_Validating(object sender, CancelEventArgs e)
        {
            if (cmbDeaCust.Text == string.Empty)
            {
                errorProvider1.SetError(cmbDeaCust, "Please Select the Type");
            }
            else
            {
                errorProvider1.SetError(cmbDeaCust, "");
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (txtName.Text == string.Empty)
            {
                errorProvider1.SetError(txtName, "Please Enter the Name");
            }
            else
            {
                errorProvider1.SetError(txtName, "");
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            string email = txtEmail.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
            {
                errorProvider1.SetError(txtEmail, "");
            }
            else
            {
                errorProvider1.SetError(txtEmail, "Please Enter a Valid Email Address");
            }
        }

        private void txtContact_Validating(object sender, CancelEventArgs e)
        {
            Regex ex = new Regex("^[0-9]{10}");
            bool isValid = ex.IsMatch(txtContact.Text);
            if (isValid)
            {
                errorProvider1.SetError(txtContact, "");
            }
            else
            {
                errorProvider1.SetError(txtContact, "Please Enter a Valid Mobile Number");
            }

        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (txtAddress.Text == string.Empty)
            {
                errorProvider1.SetError(txtAddress, "Please Enter the Address");
            }
            else
            {
                errorProvider1.SetError(txtAddress, "");
            }
        }

        private void error()
        {
            errorProvider1.SetError(cmbDeaCust, "Please Select the Type");
            errorProvider1.SetError(txtName, "Please Enter the Name");
            errorProvider1.SetError(txtEmail, "Please Enter the Email Address");
            errorProvider1.SetError(txtContact, "Please Enter the Mobile Number");
            errorProvider1.SetError(txtAddress, "Please Enter the Address");
        }
    }
}

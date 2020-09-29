using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BillingSystem.DAL;
using BillingSystem.BLL;
using DGVPrinterHelper;

namespace BillingSystem.UI
{
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
            error();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        categoriesDAL cdal = new categoriesDAL();
        productsBLL p = new productsBLL();
        productsDAL pdal = new productsDAL();
        userDAL udal = new userDAL();

        private void frmProducts_Load(object sender, EventArgs e)
        {
            //Creating DAtaTable to hold the categorties from Database
            DataTable categoriesDT = cdal.Select();

            //Specify DataSource for Category ComboBox
            cmbCategory.DataSource = categoriesDT;

            //Specify Display Memeber and value Member for Combobox
            cmbCategory.DisplayMember = "title";
            cmbCategory.ValueMember = "title";

            //Load all the products in Data Grid View
            DataTable dt = pdal.Select();
            dgvProducts.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Get all the values from Products Form
            p.name = txtName.Text;
            p.category = cmbCategory.Text;
            p.description = txtDescription.Text;
            p.rate = decimal.Parse(txtRate.Text);
            p.qty = 0;
            p.added_date = DateTime.Now;
            
            //Getting the username of logged in user
            string loggedUsr = frmLogin.loggedIn;
            userBLL usr = udal.GetIDFromUsername(loggedUsr);

            p.added_by = usr.id;

            //Create Boolean variable to check if the product is added successfully or not
            bool success = pdal.Insert(p);

            if (success == true)
            {
                MessageBox.Show("Product Added Successfully.");

                //Calling the clear method
                Clear();

                //Refersh the Data Grid View
                DataTable dt = pdal.Select();
                dgvProducts.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed to Add New Product");
            }
        }

        public void Clear()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtDescription.Text = "";
            txtRate.Text = "";
            txtSearch.Text = "";
        }

        private void dgvProducts_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //create Integer variable to know which product was clicked
            int rowIndex = e.RowIndex;

            //Display the values on respective textboxes
            txtID.Text = dgvProducts.Rows[rowIndex].Cells[0].Value.ToString();
            txtName.Text = dgvProducts.Rows[rowIndex].Cells[1].Value.ToString();
            cmbCategory.Text = dgvProducts.Rows[rowIndex].Cells[2].Value.ToString();
            txtDescription.Text = dgvProducts.Rows[rowIndex].Cells[3].Value.ToString();
            txtRate.Text = dgvProducts.Rows[rowIndex].Cells[4].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //get the values from UI or Product Form
            p.id = int.Parse(txtID.Text);
            p.name = txtName.Text;
            p.category = cmbCategory.Text;
            p.description = txtDescription.Text;
            p.rate = decimal.Parse(txtRate.Text);
            p.added_date = DateTime.Now;
            
            //Getting Username of logged in user for added_by
            string loggedUsr = frmLogin.loggedIn;
            userBLL usr = udal.GetIDFromUsername(loggedUsr);

            p.added_by = usr.id;

            //Create a Boolean variable to check if the product is upadted or not
            bool success = pdal.Update(p);

            if (success == true)
            {
                MessageBox.Show("Product Upadted Successfully.");
                Clear();

                //Refresh the data grid view
                DataTable dt = pdal.Select();
                dgvProducts.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed to Update Product.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //get the ID of Product to be Deleted
            p.id = int.Parse(txtID.Text);

            //Creating a bool variable to check the data is deleted or not
            bool success = pdal.Delete(p);

            if (success == true)
            {
                MessageBox.Show("Product Deleted Successfully.");
                Clear();

                //Refresh the data grid view
                DataTable dt = pdal.Select();
                dgvProducts.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed to Delete the Product.");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Get the keywords from Form
            string keywords = txtSearch.Text;

            if (keywords != null)
            {
                //Search the products from DataBase
                DataTable dt = pdal.Search(keywords);
                dgvProducts.DataSource = dt;
            }
            else
            {
                //Displaying All the Products
                DataTable dt = pdal.Select();
                dgvProducts.DataSource = dt;
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
                for (int i = 1; i < dgvProducts.Columns.Count + 1; i++)
                {
                    ExcelApp.Cells[1, i] = dgvProducts.Columns[i - 1].HeaderText;
                }

                //Storing Each row and column value to excel sheet
                for (int i = 0; i < dgvProducts.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvProducts.Columns.Count; j++)
                    {
                        if (dgvProducts.Rows[i].Cells[j].Value != null)
                        {
                            ExcelApp.Cells[i + 2, j + 1] = dgvProducts.Rows[i].Cells[j].Value.ToString();
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
            printer.SubTitle = " PRODUCTS REPORT \r\n";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.PrintDataGridView(dgvProducts);
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

        private void cmbCategory_Validating(object sender, CancelEventArgs e)
        {
            if (cmbCategory.Text == string.Empty)
            {
                errorProvider1.SetError(cmbCategory, "Please Select the Category");
            }
            else
            {
                errorProvider1.SetError(cmbCategory, "");
            }
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (txtDescription.Text == string.Empty)
            {
                errorProvider1.SetError(txtDescription, "Please Enter the Description");
            }
            else
            {
                errorProvider1.SetError(txtDescription, "");
            }
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtRate_Validating(object sender, CancelEventArgs e)
        {
            if (txtRate.Text == string.Empty)
            {
                errorProvider1.SetError(txtRate, "Please Enter the Rate");
            }
            else
            {
                errorProvider1.SetError(txtRate, "");
            }
        }

        private void error()
        {
            errorProvider1.SetError(txtName, "Please Enter the Name");
            errorProvider1.SetError(cmbCategory, "Please Select the Category");
            errorProvider1.SetError(txtDescription, "Please Enter the Description");
            errorProvider1.SetError(txtRate, "Please Enter the Rate");
        }

    }
}

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

namespace BillingSystem.UI
{
    public partial class frmCategories : Form
    {
        public frmCategories()
        {
            InitializeComponent();
            error();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        categoriesBLL c = new categoriesBLL();
        categoriesDAL dal = new categoriesDAL();
        userDAL udal = new userDAL();

        private void btnADD_Click(object sender, EventArgs e)
        {
            //Get the values from the category form
            c.title = txtTitle.Text;
            c.description = txtDescription.Text;
            c.added_date = DateTime.Now;

            //Getting ID in Added by field
            string loggedUser = frmLogin.loggedIn;
            userBLL usr = udal.GetIDFromUsername(loggedUser);
            
            //Passing the ID of Logged in user in added by field
            c.added_by = usr.id;

            //Creating Boolean Method to Insert data into Database
            bool success = dal.Insert(c);

            if (success == true)
            {
                MessageBox.Show("New Category Inserted Successfully.");
                Clear();

                //Refersh Data Grid View
                DataTable dt = dal.Select();
                dgvCategories.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed to Insert New Category");
            }
        }

        public void Clear()
        {
            txtCategoryID.Text = "";
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtSearch.Text = "";
        }

        private void frmCategories_Load(object sender, EventArgs e)
        {
            //Here write the code to display all the categories in data grid view
            DataTable dt = dal.Select();
            dgvCategories.DataSource = dt;
        }

        private void dgvCategories_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Finding the row index of the row Clicked on Data Grid View
            int RowIndex = e.RowIndex;
            txtCategoryID.Text = dgvCategories.Rows[RowIndex].Cells[0].Value.ToString();
            txtTitle.Text = dgvCategories.Rows[RowIndex].Cells[1].Value.ToString();
            txtDescription.Text = dgvCategories.Rows[RowIndex].Cells[2].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Get the values from the Categotry form
            c.id = int.Parse(txtCategoryID.Text);
            c.title = txtTitle.Text;
            c.description = txtDescription.Text;
            c.added_date = DateTime.Now;
            //Getting ID in Added by field
            string loggedUser = frmLogin.loggedIn;
            userBLL usr = udal.GetIDFromUsername(loggedUser);

            //Passing the ID of Logged in user in added by field
            c.added_by = usr.id;

            //creating Variable to update categories and check
            bool success = dal.Update(c);

            if (success == true)
            {
                MessageBox.Show("Category Updated Successfully.");
                Clear();
                //Refersh Data Grid View
                DataTable dt = dal.Select();
                dgvCategories.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed to Update Category.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Get the ID of the Category which we want to Delete
            c.id = int.Parse(txtCategoryID.Text);

            //Creating Boolean Variable to Delete the Category 
            bool success = dal.Delete(c);

            if (success == true)
            {
                MessageBox.Show("Category Deleted Successfully.");
                Clear();
                //Refreshing Data Grid View
                DataTable dt = dal.Select();
                dgvCategories.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed to Delete Category.");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Get the keywords
            string keywords = txtSearch.Text;

            //Filter the Categories Based on Keywords
            if (keywords != null)
            {
                DataTable dt = dal.Search(keywords);
                dgvCategories.DataSource = dt;
            }
            else
            {
                DataTable dt = dal.Select();
                dgvCategories.DataSource = dt;
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
                for (int i = 1; i < dgvCategories.Columns.Count + 1; i++)
                {
                    ExcelApp.Cells[1, i] = dgvCategories.Columns[i - 1].HeaderText;
                }

                //Storing Each row and column value to excel sheet
                for (int i = 0; i < dgvCategories.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvCategories.Columns.Count; j++)
                    {
                        if (dgvCategories.Rows[i].Cells[j].Value != null)
                        {
                            ExcelApp.Cells[i + 2, j + 1] = dgvCategories.Rows[i].Cells[j].Value.ToString();
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
            printer.SubTitle = " CATEGORY REPORT \r\n";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.PrintDataGridView(dgvCategories);
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (txtTitle.Text == string.Empty)
            {
                errorProvider1.SetError(txtTitle, "Please Enter the Title");
            }
            else
            {
                errorProvider1.SetError(txtTitle, "");
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

        private void error()
        {
            errorProvider1.SetError(txtTitle, "Please Enter the Title");
            errorProvider1.SetError(txtDescription, "Please Enter the Description");

        }
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using BillingSystem.BLL;
using BillingSystem.DAL;
using DGVPrinterHelper;
using System.Text.RegularExpressions;

namespace BillingSystem.UI
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
            error();
        }

        userBLL u = new userBLL();
        userDAL dal = new userDAL();

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Getting data from UI
            u.first_name = txtFirstName.Text;
            u.last_name = txtLastName.Text;
            u.email = txtEmail.Text;
            u.username = txtUsername.Text;
            u.password = txtPassword.Text;
            u.contact = txtContact.Text;
            u.address = txtAddress.Text;
            u.gender = cmbGender.Text;
            u.user_type = cmbUserType.Text;
            u.added_date = DateTime.Now;

            //Getting username of loggedin user
            string loggedUser = frmLogin.loggedIn;

            userBLL usr = dal.GetIDFromUsername(loggedUser);

            u.added_by = usr.id;

            //Inserting data into Database
            bool success = dal.Insert(u);
            //IF the data is successfully inserted then the value of success will be true else it will be false
            if (success == true)
            {
                MessageBox.Show("User Successfully Created.");
                clear();
            }
            else
            {
                MessageBox.Show("Failed to add new user");
            }

            //refreshing data grid view
            DataTable dt = dal.select();
            dgvUsers.DataSource = dt;

            

        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.select();
            dgvUsers.DataSource = dt;

        }

        private void clear()
        {
            txtUserID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtUsername.Text = "";
            txtPassword.Text= "";
            txtContact.Text = "";
            txtAddress.Text = "";
            cmbGender.Text = "";
            cmbUserType.Text= "";
        }

        private void dgvUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the Index of particular row
            int rowIndex = e.RowIndex;
            txtUserID.Text = dgvUsers.Rows[rowIndex].Cells[0].Value.ToString();
            txtFirstName.Text = dgvUsers.Rows[rowIndex].Cells[1].Value.ToString();
            txtLastName.Text = dgvUsers.Rows[rowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dgvUsers.Rows[rowIndex].Cells[3].Value.ToString();
            txtUsername.Text = dgvUsers.Rows[rowIndex].Cells[4].Value.ToString();
            txtPassword.Text = dgvUsers.Rows[rowIndex].Cells[5].Value.ToString();
            txtContact.Text = dgvUsers.Rows[rowIndex].Cells[6].Value.ToString();
            txtAddress.Text = dgvUsers.Rows[rowIndex].Cells[7].Value.ToString();
            cmbGender.Text = dgvUsers.Rows[rowIndex].Cells[8].Value.ToString();
            cmbUserType.Text = dgvUsers.Rows[rowIndex].Cells[9].Value.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Get the values from user UI
            u.id = Convert.ToInt32(txtUserID.Text);
            u.first_name = txtFirstName.Text;
            u.last_name = txtLastName.Text;
            u.email = txtEmail.Text;
            u.username = txtUsername.Text;
            u.password = txtPassword.Text;
            u.contact = txtContact.Text;
            u.address = txtAddress.Text;
            u.gender = cmbGender.Text;
            u.user_type = cmbUserType.Text;
            u.added_date = DateTime.Now;
            u.added_by = 1;

            //Updating Data into DataBase
            bool success = dal.Update(u);
            //If data is updated successfully the value of success will be true else it will be false
            if (success == true)
            {
                MessageBox.Show("User Successfully Updated");
                clear();
            }
            else
            {
                MessageBox.Show("Failed to Update User");
            }

            //Refresh the Data Grid View
            DataTable dt = dal.select();
            dgvUsers.DataSource = dt;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Getting User ID from form
            u.id = Convert.ToInt32(txtUserID.Text);

            bool success = dal.Delete(u);
            //If the data is deleted the value of success will be true else it will be false
            if (success == true)
            {
                MessageBox.Show("User Deleted Successfully");
                clear();
            }
            else
            {
                MessageBox.Show("Failed to Delete User");
            }

            //Refreshing Datagrid view
            DataTable dt = dal.select();
            dgvUsers.DataSource = dt;

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Get Keyword from Textbox
            string keywords = txtSearch.Text;

            //Check if the keywords has values or not
            if (keywords != null)
            {
                DataTable dt = dal.Search(keywords);
                dgvUsers.DataSource = dt;
            }
            else
            {
                DataTable dt = dal.select();
                dgvUsers.DataSource = dt;
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
                for (int i = 1; i < dgvUsers.Columns.Count + 1; i++)
                {
                    ExcelApp.Cells[1, i] = dgvUsers.Columns[i - 1].HeaderText;
                }

                //Storing Each row and column value to excel sheet
                for (int i = 0; i < dgvUsers.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvUsers.Columns.Count; j++)
                    {
                        if (dgvUsers.Rows[i].Cells[j].Value != null)
                        {
                            ExcelApp.Cells[i + 2, j + 1] = dgvUsers.Rows[i].Cells[j].Value.ToString();
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
            printer.SubTitle = " USERS / EMPLOYEE REPORT \r\n";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.PrintDataGridView(dgvUsers);
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (txtFirstName.Text == string.Empty)
            {
                errorProvider1.SetError(txtFirstName, "Please Enter your FirstName");
            }
            else
            {
                errorProvider1.SetError(txtFirstName, "");
            }
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (txtLastName.Text == string.Empty)
            {
                errorProvider1.SetError(txtLastName, "Please Enter your LastName");
            }
            else
            {
                errorProvider1.SetError(txtLastName, "");
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

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (txtUsername.Text == string.Empty)
            {
                errorProvider1.SetError(txtUsername, "Please Enter the Username");
            }
            else
            {
                errorProvider1.SetError(txtUsername, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text == string.Empty)
            {
                errorProvider1.SetError(txtPassword, "Please Enter the Password");
            }
            else
            {
                errorProvider1.SetError(txtPassword, "");
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

        private void cmbGender_Validating(object sender, CancelEventArgs e)
        {
            if (cmbGender.Text == string.Empty)
            {
                errorProvider1.SetError(cmbGender, "Please Select your Gender");
            }
            else
            {
                errorProvider1.SetError(cmbGender, "");
            }
        }

        private void error()
        {
            errorProvider1.SetError(txtFirstName, "Please Enter your FirstName");
            errorProvider1.SetError(txtLastName, "Please Enter your LastName");
            errorProvider1.SetError(txtEmail, "Please Enter your Email Address");
            errorProvider1.SetError(txtUsername, "Please Enter the Username");
            errorProvider1.SetError(txtPassword, "Please Enter the Password");
            errorProvider1.SetError(txtContact, "Please Enter your Mobile Number");
            errorProvider1.SetError(txtAddress, "Please Enter the Address");
            errorProvider1.SetError(cmbGender, "Please Select your Gender");
        }

    }
}

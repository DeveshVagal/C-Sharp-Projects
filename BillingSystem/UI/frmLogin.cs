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

namespace BillingSystem.UI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            error();
        }

        loginBLL l = new loginBLL();
        loginDAL dal = new loginDAL();
        public static string loggedIn;

        private void pboxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            l.username = txtUsername.Text.Trim();
            l.password = txtPassword.Text.Trim();
            l.user_type = cmbUserType.Text.Trim();

            //Checking the login credentials
            bool success = dal.loginCheck(l);
            if (success == true)
            {
                MessageBox.Show("Login Successfull");
                loggedIn = l.username;

                //Need to open forms based on usertype
                switch (l.user_type)
                {
                    case "Admin":
                        {
                            AdminDashboard admin = new AdminDashboard();
                            admin.Show();
                            this.Hide();
                        }
                        break;

                    case "User":
                        {
                            UserDashboard user = new UserDashboard();
                            user.Show();
                            this.Hide();
                        }
                        break;

                    default:
                        {
                            MessageBox.Show("Invalid User Type");
                        }
                        break;
                }
            }
            else
            {
                MessageBox.Show("Login Failed.Try again");
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

        private void cmbUserType_Validating(object sender, CancelEventArgs e)
        {
            if (cmbUserType.Text == string.Empty)
            {
                errorProvider1.SetError(cmbUserType, "Please Select the User Type");
            }
            else
            {
                errorProvider1.SetError(cmbUserType, "");
            }
        }

        private void error()
        {
            errorProvider1.SetError(txtUsername, "Please Enter the Username");
            errorProvider1.SetError(txtPassword, "Please Enter the Password");
            errorProvider1.SetError(cmbUserType, "Please Select the User Type");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}

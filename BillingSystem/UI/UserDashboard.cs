using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BillingSystem.UI;

namespace BillingSystem
{
    public partial class UserDashboard : Form
    {
        public UserDashboard()
        {
            InitializeComponent();
        }

        //Set a public static method to specify where the form is purchase or sales
        public static string transactionType;

        private void UserDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }

        private void UserDashboard_Load(object sender, EventArgs e)
        {
            lblLoggedInUser.Text = frmLogin.loggedIn;
        }

        private void dealerAndCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDeaCust DeaCust = new frmDeaCust();
            DeaCust.Show();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Set value on transactiontype static method
            transactionType = "Purchase";

            frmPurchaseAndSales purchase = new frmPurchaseAndSales();
            purchase.Show();
        }

        private void salesFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Set value on transactiontype static method
            transactionType = "Sales";

            frmPurchaseAndSales sales = new frmPurchaseAndSales();
            sales.Show();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventory inventory = new frmInventory();
            inventory.Show();
        }
    }
}

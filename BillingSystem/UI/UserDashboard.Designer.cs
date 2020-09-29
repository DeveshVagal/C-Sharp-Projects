namespace BillingSystem
{
    partial class UserDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.purchaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dealerAndCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSHead = new System.Windows.Forms.Label();
            this.lblLAppName = new System.Windows.Forms.Label();
            this.lblAppFName1 = new System.Windows.Forms.Label();
            this.lblLoggedInUser = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.pnlfooter = new System.Windows.Forms.Panel();
            this.lblfooter1 = new System.Windows.Forms.Label();
            this.lblfooter = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.pnlfooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchaseToolStripMenuItem,
            this.salesFormToolStripMenuItem,
            this.dealerAndCustomerToolStripMenuItem,
            this.inventoryToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1263, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // purchaseToolStripMenuItem
            // 
            this.purchaseToolStripMenuItem.Name = "purchaseToolStripMenuItem";
            this.purchaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.purchaseToolStripMenuItem.Text = "Purchase";
            this.purchaseToolStripMenuItem.Click += new System.EventHandler(this.purchaseToolStripMenuItem_Click);
            // 
            // salesFormToolStripMenuItem
            // 
            this.salesFormToolStripMenuItem.Name = "salesFormToolStripMenuItem";
            this.salesFormToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.salesFormToolStripMenuItem.Text = "Sales";
            this.salesFormToolStripMenuItem.Click += new System.EventHandler(this.salesFormToolStripMenuItem_Click);
            // 
            // dealerAndCustomerToolStripMenuItem
            // 
            this.dealerAndCustomerToolStripMenuItem.Name = "dealerAndCustomerToolStripMenuItem";
            this.dealerAndCustomerToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
            this.dealerAndCustomerToolStripMenuItem.Text = "Dealer and Customer";
            this.dealerAndCustomerToolStripMenuItem.Click += new System.EventHandler(this.dealerAndCustomerToolStripMenuItem_Click);
            // 
            // inventoryToolStripMenuItem
            // 
            this.inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            this.inventoryToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.inventoryToolStripMenuItem.Text = "Inventory";
            this.inventoryToolStripMenuItem.Click += new System.EventHandler(this.inventoryToolStripMenuItem_Click);
            // 
            // lblSHead
            // 
            this.lblSHead.AutoSize = true;
            this.lblSHead.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSHead.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblSHead.Location = new System.Drawing.Point(445, 244);
            this.lblSHead.Name = "lblSHead";
            this.lblSHead.Size = new System.Drawing.Size(429, 37);
            this.lblSHead.TabIndex = 12;
            this.lblSHead.Text = "Billing And Inventory Management";
            // 
            // lblLAppName
            // 
            this.lblLAppName.AutoSize = true;
            this.lblLAppName.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLAppName.Location = new System.Drawing.Point(610, 198);
            this.lblLAppName.Name = "lblLAppName";
            this.lblLAppName.Size = new System.Drawing.Size(94, 37);
            this.lblLAppName.TabIndex = 11;
            this.lblLAppName.Text = "STORE";
            // 
            // lblAppFName1
            // 
            this.lblAppFName1.AutoSize = true;
            this.lblAppFName1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppFName1.Location = new System.Drawing.Point(547, 198);
            this.lblAppFName1.Name = "lblAppFName1";
            this.lblAppFName1.Size = new System.Drawing.Size(71, 37);
            this.lblAppFName1.TabIndex = 10;
            this.lblAppFName1.Text = "IKEA";
            // 
            // lblLoggedInUser
            // 
            this.lblLoggedInUser.AutoSize = true;
            this.lblLoggedInUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoggedInUser.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblLoggedInUser.Location = new System.Drawing.Point(48, 33);
            this.lblLoggedInUser.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblLoggedInUser.Name = "lblLoggedInUser";
            this.lblLoggedInUser.Size = new System.Drawing.Size(0, 17);
            this.lblLoggedInUser.TabIndex = 9;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(6, 33);
            this.lblUser.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(43, 17);
            this.lblUser.TabIndex = 8;
            this.lblUser.Text = "User :";
            // 
            // pnlfooter
            // 
            this.pnlfooter.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.pnlfooter.Controls.Add(this.lblfooter1);
            this.pnlfooter.Controls.Add(this.lblfooter);
            this.pnlfooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlfooter.Location = new System.Drawing.Point(0, 460);
            this.pnlfooter.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.pnlfooter.Name = "pnlfooter";
            this.pnlfooter.Size = new System.Drawing.Size(1263, 55);
            this.pnlfooter.TabIndex = 13;
            // 
            // lblfooter1
            // 
            this.lblfooter1.AutoSize = true;
            this.lblfooter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfooter1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblfooter1.Location = new System.Drawing.Point(614, 15);
            this.lblfooter1.Name = "lblfooter1";
            this.lblfooter1.Size = new System.Drawing.Size(207, 16);
            this.lblfooter1.TabIndex = 1;
            this.lblfooter1.Text = "Developed By : DEVESH VAGAL";
            // 
            // lblfooter
            // 
            this.lblfooter.AutoSize = true;
            this.lblfooter.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfooter.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblfooter.Location = new System.Drawing.Point(1387, 26);
            this.lblfooter.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblfooter.Name = "lblfooter";
            this.lblfooter.Size = new System.Drawing.Size(227, 20);
            this.lblfooter.TabIndex = 0;
            this.lblfooter.Text = "Developed By : DEVESH VAGAL";
            // 
            // UserDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 515);
            this.Controls.Add(this.pnlfooter);
            this.Controls.Add(this.lblSHead);
            this.Controls.Add(this.lblLAppName);
            this.Controls.Add(this.lblAppFName1);
            this.Controls.Add(this.lblLoggedInUser);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UserDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserDashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UserDashboard_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserDashboard_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlfooter.ResumeLayout(false);
            this.pnlfooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem purchaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.Label lblSHead;
        private System.Windows.Forms.Label lblLAppName;
        private System.Windows.Forms.Label lblAppFName1;
        private System.Windows.Forms.Label lblLoggedInUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Panel pnlfooter;
        private System.Windows.Forms.Label lblfooter1;
        private System.Windows.Forms.Label lblfooter;
        private System.Windows.Forms.ToolStripMenuItem dealerAndCustomerToolStripMenuItem;
    }
}
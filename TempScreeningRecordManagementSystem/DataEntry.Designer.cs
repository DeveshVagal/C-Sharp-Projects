namespace TempScreeningRecordManagementSystem
{
    partial class DataEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataEntry));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.temperatureScreeningRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataOfTemperatureScreeningRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentGenerationRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.temperatureScreeningRecordToolStripMenuItem,
            this.dataOfTemperatureScreeningRecordToolStripMenuItem,
            this.documentGenerationRecordToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(731, 24);
            this.menuStrip1.TabIndex = 47;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // temperatureScreeningRecordToolStripMenuItem
            // 
            this.temperatureScreeningRecordToolStripMenuItem.Name = "temperatureScreeningRecordToolStripMenuItem";
            this.temperatureScreeningRecordToolStripMenuItem.Size = new System.Drawing.Size(181, 20);
            this.temperatureScreeningRecordToolStripMenuItem.Text = "Temperature Screening Record";
            this.temperatureScreeningRecordToolStripMenuItem.Click += new System.EventHandler(this.temperatureScreeningRecordToolStripMenuItem_Click);
            // 
            // dataOfTemperatureScreeningRecordToolStripMenuItem
            // 
            this.dataOfTemperatureScreeningRecordToolStripMenuItem.Name = "dataOfTemperatureScreeningRecordToolStripMenuItem";
            this.dataOfTemperatureScreeningRecordToolStripMenuItem.Size = new System.Drawing.Size(222, 20);
            this.dataOfTemperatureScreeningRecordToolStripMenuItem.Text = "Data of Temperature Screening Record";
            this.dataOfTemperatureScreeningRecordToolStripMenuItem.Click += new System.EventHandler(this.dataOfTemperatureScreeningRecordToolStripMenuItem_Click);
            // 
            // documentGenerationRecordToolStripMenuItem
            // 
            this.documentGenerationRecordToolStripMenuItem.Name = "documentGenerationRecordToolStripMenuItem";
            this.documentGenerationRecordToolStripMenuItem.Size = new System.Drawing.Size(176, 20);
            this.documentGenerationRecordToolStripMenuItem.Text = "Document Generation Record";
            this.documentGenerationRecordToolStripMenuItem.Click += new System.EventHandler(this.documentGenerationRecordToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 49;
            this.label4.Text = "Logged In as :-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(129, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 50;
            this.label1.Text = "Name";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // DataEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(731, 443);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DataEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataEntry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DataEntry_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DataEntry_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem temperatureScreeningRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataOfTemperatureScreeningRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentGenerationRecordToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}
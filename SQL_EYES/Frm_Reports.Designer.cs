namespace SQL_EYES
{
    partial class Frm_Reports
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnPerformanceReport = new System.Windows.Forms.Button();
            this.btnBackupReport = new System.Windows.Forms.Button();
            this.btnDatabaseReport = new System.Windows.Forms.Button();
            this.btnServerOverview = new System.Windows.Forms.Button();
            this.panelExport = new System.Windows.Forms.Panel();
            this.cmbDatabase = new System.Windows.Forms.ComboBox();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.btnExportHTML = new System.Windows.Forms.Button();
            this.btnExportCSV = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelTop.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1200, 60);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(207, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Raporlama & Export";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.White;
            this.panelButtons.Controls.Add(this.btnPerformanceReport);
            this.panelButtons.Controls.Add(this.btnBackupReport);
            this.panelButtons.Controls.Add(this.btnDatabaseReport);
            this.panelButtons.Controls.Add(this.btnServerOverview);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Location = new System.Drawing.Point(0, 60);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1200, 70);
            this.panelButtons.TabIndex = 1;
            // 
            // btnPerformanceReport
            // 
            this.btnPerformanceReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnPerformanceReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPerformanceReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPerformanceReport.ForeColor = System.Drawing.Color.White;
            this.btnPerformanceReport.Location = new System.Drawing.Point(730, 15);
            this.btnPerformanceReport.Name = "btnPerformanceReport";
            this.btnPerformanceReport.Size = new System.Drawing.Size(220, 40);
            this.btnPerformanceReport.TabIndex = 3;
            this.btnPerformanceReport.Text = "Performans Raporu";
            this.btnPerformanceReport.UseVisualStyleBackColor = false;
            this.btnPerformanceReport.Click += new System.EventHandler(this.btnPerformanceReport_Click);
            // 
            // btnBackupReport
            // 
            this.btnBackupReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnBackupReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackupReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBackupReport.ForeColor = System.Drawing.Color.White;
            this.btnBackupReport.Location = new System.Drawing.Point(490, 15);
            this.btnBackupReport.Name = "btnBackupReport";
            this.btnBackupReport.Size = new System.Drawing.Size(220, 40);
            this.btnBackupReport.TabIndex = 2;
            this.btnBackupReport.Text = "Yedekleme Raporu";
            this.btnBackupReport.UseVisualStyleBackColor = false;
            this.btnBackupReport.Click += new System.EventHandler(this.btnBackupReport_Click);
            // 
            // btnDatabaseReport
            // 
            this.btnDatabaseReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnDatabaseReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatabaseReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDatabaseReport.ForeColor = System.Drawing.Color.White;
            this.btnDatabaseReport.Location = new System.Drawing.Point(250, 15);
            this.btnDatabaseReport.Name = "btnDatabaseReport";
            this.btnDatabaseReport.Size = new System.Drawing.Size(220, 40);
            this.btnDatabaseReport.TabIndex = 1;
            this.btnDatabaseReport.Text = "Veritabaný Raporu";
            this.btnDatabaseReport.UseVisualStyleBackColor = false;
            this.btnDatabaseReport.Click += new System.EventHandler(this.btnDatabaseReport_Click);
            // 
            // btnServerOverview
            // 
            this.btnServerOverview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnServerOverview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServerOverview.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnServerOverview.ForeColor = System.Drawing.Color.White;
            this.btnServerOverview.Location = new System.Drawing.Point(10, 15);
            this.btnServerOverview.Name = "btnServerOverview";
            this.btnServerOverview.Size = new System.Drawing.Size(220, 40);
            this.btnServerOverview.TabIndex = 0;
            this.btnServerOverview.Text = "Sunucu Özeti";
            this.btnServerOverview.UseVisualStyleBackColor = false;
            this.btnServerOverview.Click += new System.EventHandler(this.btnServerOverview_Click);
            // 
            // panelExport
            // 
            this.panelExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelExport.Controls.Add(this.cmbDatabase);
            this.panelExport.Controls.Add(this.lblDatabase);
            this.panelExport.Controls.Add(this.btnExportHTML);
            this.panelExport.Controls.Add(this.btnExportCSV);
            this.panelExport.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelExport.Location = new System.Drawing.Point(0, 130);
            this.panelExport.Name = "panelExport";
            this.panelExport.Size = new System.Drawing.Size(1200, 50);
            this.panelExport.TabIndex = 2;
            // 
            // cmbDatabase
            // 
            this.cmbDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDatabase.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbDatabase.FormattingEnabled = true;
            this.cmbDatabase.Location = new System.Drawing.Point(100, 13);
            this.cmbDatabase.Name = "cmbDatabase";
            this.cmbDatabase.Size = new System.Drawing.Size(200, 23);
            this.cmbDatabase.TabIndex = 3;
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDatabase.Location = new System.Drawing.Point(15, 16);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(66, 15);
            this.lblDatabase.TabIndex = 2;
            this.lblDatabase.Text = "Veritabaný:";
            // 
            // btnExportHTML
            // 
            this.btnExportHTML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportHTML.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnExportHTML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportHTML.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportHTML.ForeColor = System.Drawing.Color.White;
            this.btnExportHTML.Location = new System.Drawing.Point(1040, 10);
            this.btnExportHTML.Name = "btnExportHTML";
            this.btnExportHTML.Size = new System.Drawing.Size(150, 30);
            this.btnExportHTML.TabIndex = 1;
            this.btnExportHTML.Text = "HTML Export";
            this.btnExportHTML.UseVisualStyleBackColor = false;
            this.btnExportHTML.Click += new System.EventHandler(this.btnExportHTML_Click);
            // 
            // btnExportCSV
            // 
            this.btnExportCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportCSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnExportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportCSV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportCSV.ForeColor = System.Drawing.Color.Black;
            this.btnExportCSV.Location = new System.Drawing.Point(870, 10);
            this.btnExportCSV.Name = "btnExportCSV";
            this.btnExportCSV.Size = new System.Drawing.Size(150, 30);
            this.btnExportCSV.TabIndex = 0;
            this.btnExportCSV.Text = "CSV Export";
            this.btnExportCSV.UseVisualStyleBackColor = false;
            this.btnExportCSV.Click += new System.EventHandler(this.btnExportCSV_Click);
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvResults.BackgroundColor = System.Drawing.Color.White;
            this.dgvResults.Location = new System.Drawing.Point(10, 190);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.Size = new System.Drawing.Size(1180, 455);
            this.dgvResults.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 655);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1200, 22);
            this.statusStrip1.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(34, 17);
            this.lblStatus.Text = "Hazýr";
            // 
            // Frm_Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1200, 677);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.panelExport);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelTop);
            this.Name = "Frm_Reports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Raporlama & Export - SQL EYES";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Reports_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelExport.ResumeLayout(false);
            this.panelExport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnServerOverview;
        private System.Windows.Forms.Button btnDatabaseReport;
        private System.Windows.Forms.Button btnBackupReport;
        private System.Windows.Forms.Button btnPerformanceReport;
        private System.Windows.Forms.Panel panelExport;
        private System.Windows.Forms.Button btnExportCSV;
        private System.Windows.Forms.Button btnExportHTML;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ComboBox cmbDatabase;
        private System.Windows.Forms.Label lblDatabase;
    }
}

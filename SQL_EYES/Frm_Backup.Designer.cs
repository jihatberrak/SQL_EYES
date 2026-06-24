namespace SQL_EYES
{
    partial class Frm_Backup
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnRestoreHistory = new System.Windows.Forms.Button();
            this.btnBackupSize = new System.Windows.Forms.Button();
            this.btnMissingBackups = new System.Windows.Forms.Button();
            this.btnBackupHistory = new System.Windows.Forms.Button();
            this.btnLastBackups = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelTop.SuspendLayout();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
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
            this.lblTitle.Size = new System.Drawing.Size(332, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Yedekleme && Kurtarma";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.White;
            this.panelButtons.Controls.Add(this.btnRestoreHistory);
            this.panelButtons.Controls.Add(this.btnBackupSize);
            this.panelButtons.Controls.Add(this.btnMissingBackups);
            this.panelButtons.Controls.Add(this.btnBackupHistory);
            this.panelButtons.Controls.Add(this.btnLastBackups);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Location = new System.Drawing.Point(0, 60);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(10);
            this.panelButtons.Size = new System.Drawing.Size(1200, 70);
            this.panelButtons.TabIndex = 1;
            // 
            // btnRestoreHistory
            // 
            this.btnRestoreHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnRestoreHistory.FlatAppearance.BorderSize = 0;
            this.btnRestoreHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestoreHistory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRestoreHistory.ForeColor = System.Drawing.Color.White;
            this.btnRestoreHistory.Location = new System.Drawing.Point(970, 15);
            this.btnRestoreHistory.Name = "btnRestoreHistory";
            this.btnRestoreHistory.Size = new System.Drawing.Size(220, 40);
            this.btnRestoreHistory.TabIndex = 4;
            this.btnRestoreHistory.Text = "Restore Geçmiþi";
            this.btnRestoreHistory.UseVisualStyleBackColor = false;
            this.btnRestoreHistory.Click += new System.EventHandler(this.btnRestoreHistory_Click);
            // 
            // btnBackupSize
            // 
            this.btnBackupSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnBackupSize.FlatAppearance.BorderSize = 0;
            this.btnBackupSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackupSize.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBackupSize.ForeColor = System.Drawing.Color.White;
            this.btnBackupSize.Location = new System.Drawing.Point(730, 15);
            this.btnBackupSize.Name = "btnBackupSize";
            this.btnBackupSize.Size = new System.Drawing.Size(220, 40);
            this.btnBackupSize.TabIndex = 3;
            this.btnBackupSize.Text = "Yedek Boyutlarý";
            this.btnBackupSize.UseVisualStyleBackColor = false;
            this.btnBackupSize.Click += new System.EventHandler(this.btnBackupSize_Click);
            // 
            // btnMissingBackups
            // 
            this.btnMissingBackups.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnMissingBackups.FlatAppearance.BorderSize = 0;
            this.btnMissingBackups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMissingBackups.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMissingBackups.ForeColor = System.Drawing.Color.White;
            this.btnMissingBackups.Location = new System.Drawing.Point(490, 15);
            this.btnMissingBackups.Name = "btnMissingBackups";
            this.btnMissingBackups.Size = new System.Drawing.Size(220, 40);
            this.btnMissingBackups.TabIndex = 2;
            this.btnMissingBackups.Text = "Yedeklenmeyen VT'ler";
            this.btnMissingBackups.UseVisualStyleBackColor = false;
            this.btnMissingBackups.Click += new System.EventHandler(this.btnMissingBackups_Click);
            // 
            // btnBackupHistory
            // 
            this.btnBackupHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnBackupHistory.FlatAppearance.BorderSize = 0;
            this.btnBackupHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackupHistory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBackupHistory.ForeColor = System.Drawing.Color.White;
            this.btnBackupHistory.Location = new System.Drawing.Point(250, 15);
            this.btnBackupHistory.Name = "btnBackupHistory";
            this.btnBackupHistory.Size = new System.Drawing.Size(220, 40);
            this.btnBackupHistory.TabIndex = 1;
            this.btnBackupHistory.Text = "Yedekleme Geçmiþi";
            this.btnBackupHistory.UseVisualStyleBackColor = false;
            this.btnBackupHistory.Click += new System.EventHandler(this.btnBackupHistory_Click);
            // 
            // btnLastBackups
            // 
            this.btnLastBackups.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.btnLastBackups.FlatAppearance.BorderSize = 0;
            this.btnLastBackups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLastBackups.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLastBackups.ForeColor = System.Drawing.Color.White;
            this.btnLastBackups.Location = new System.Drawing.Point(10, 15);
            this.btnLastBackups.Name = "btnLastBackups";
            this.btnLastBackups.Size = new System.Drawing.Size(220, 40);
            this.btnLastBackups.TabIndex = 0;
            this.btnLastBackups.Text = "Son Yedeklemeler";
            this.btnLastBackups.UseVisualStyleBackColor = false;
            this.btnLastBackups.Click += new System.EventHandler(this.btnLastBackups_Click);
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
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(10, 140);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(1180, 505);
            this.dgvResults.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 655);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1200, 22);
            this.statusStrip1.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(33, 17);
            this.lblStatus.Text = "Hazýr";
            // 
            // Frm_Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1200, 677);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelTop);
            this.Name = "Frm_Backup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yedekleme & Kurtarma - SQL EYES";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Backup_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnLastBackups;
        private System.Windows.Forms.Button btnBackupHistory;
        private System.Windows.Forms.Button btnMissingBackups;
        private System.Windows.Forms.Button btnBackupSize;
        private System.Windows.Forms.Button btnRestoreHistory;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}

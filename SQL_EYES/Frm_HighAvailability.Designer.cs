namespace SQL_EYES
{
    partial class Frm_HighAvailability
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
            this.btnClusterInfo = new System.Windows.Forms.Button();
            this.btnReplicationStatus = new System.Windows.Forms.Button();
            this.btnLogShipping = new System.Windows.Forms.Button();
            this.btnDatabaseMirroring = new System.Windows.Forms.Button();
            this.btnAlwaysOnStatus = new System.Windows.Forms.Button();
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
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
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
            this.lblTitle.Size = new System.Drawing.Size(356, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "High Availability && DR";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.White;
            this.panelButtons.Controls.Add(this.btnClusterInfo);
            this.panelButtons.Controls.Add(this.btnReplicationStatus);
            this.panelButtons.Controls.Add(this.btnLogShipping);
            this.panelButtons.Controls.Add(this.btnDatabaseMirroring);
            this.panelButtons.Controls.Add(this.btnAlwaysOnStatus);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Location = new System.Drawing.Point(0, 60);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1200, 70);
            this.panelButtons.TabIndex = 1;
            // 
            // btnClusterInfo
            // 
            this.btnClusterInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnClusterInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClusterInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClusterInfo.ForeColor = System.Drawing.Color.White;
            this.btnClusterInfo.Location = new System.Drawing.Point(970, 15);
            this.btnClusterInfo.Name = "btnClusterInfo";
            this.btnClusterInfo.Size = new System.Drawing.Size(220, 40);
            this.btnClusterInfo.TabIndex = 4;
            this.btnClusterInfo.Text = "Cluster Info";
            this.btnClusterInfo.Click += new System.EventHandler(this.btnClusterInfo_Click);
            // 
            // btnReplicationStatus
            // 
            this.btnReplicationStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnReplicationStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReplicationStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReplicationStatus.ForeColor = System.Drawing.Color.White;
            this.btnReplicationStatus.Location = new System.Drawing.Point(730, 15);
            this.btnReplicationStatus.Name = "btnReplicationStatus";
            this.btnReplicationStatus.Size = new System.Drawing.Size(220, 40);
            this.btnReplicationStatus.TabIndex = 3;
            this.btnReplicationStatus.Text = "Replication Status";
            this.btnReplicationStatus.Click += new System.EventHandler(this.btnReplicationStatus_Click);
            // 
            // btnLogShipping
            // 
            this.btnLogShipping.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnLogShipping.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogShipping.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogShipping.ForeColor = System.Drawing.Color.White;
            this.btnLogShipping.Location = new System.Drawing.Point(490, 15);
            this.btnLogShipping.Name = "btnLogShipping";
            this.btnLogShipping.Size = new System.Drawing.Size(220, 40);
            this.btnLogShipping.TabIndex = 2;
            this.btnLogShipping.Text = "Log Shipping";
            this.btnLogShipping.Click += new System.EventHandler(this.btnLogShipping_Click);
            // 
            // btnDatabaseMirroring
            // 
            this.btnDatabaseMirroring.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDatabaseMirroring.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatabaseMirroring.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDatabaseMirroring.ForeColor = System.Drawing.Color.White;
            this.btnDatabaseMirroring.Location = new System.Drawing.Point(250, 15);
            this.btnDatabaseMirroring.Name = "btnDatabaseMirroring";
            this.btnDatabaseMirroring.Size = new System.Drawing.Size(220, 40);
            this.btnDatabaseMirroring.TabIndex = 1;
            this.btnDatabaseMirroring.Text = "Database Mirroring";
            this.btnDatabaseMirroring.Click += new System.EventHandler(this.btnDatabaseMirroring_Click);
            // 
            // btnAlwaysOnStatus
            // 
            this.btnAlwaysOnStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnAlwaysOnStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlwaysOnStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAlwaysOnStatus.ForeColor = System.Drawing.Color.White;
            this.btnAlwaysOnStatus.Location = new System.Drawing.Point(10, 15);
            this.btnAlwaysOnStatus.Name = "btnAlwaysOnStatus";
            this.btnAlwaysOnStatus.Size = new System.Drawing.Size(220, 40);
            this.btnAlwaysOnStatus.TabIndex = 0;
            this.btnAlwaysOnStatus.Text = "AlwaysOn AG Status";
            this.btnAlwaysOnStatus.Click += new System.EventHandler(this.btnAlwaysOnStatus_Click);
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
            this.dgvResults.Location = new System.Drawing.Point(10, 140);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
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
            // Frm_HighAvailability
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1200, 677);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelTop);
            this.Name = "Frm_HighAvailability";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "High Availability & DR - SQL EYES";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_HighAvailability_Load);
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
        private System.Windows.Forms.Button btnAlwaysOnStatus;
        private System.Windows.Forms.Button btnDatabaseMirroring;
        private System.Windows.Forms.Button btnLogShipping;
        private System.Windows.Forms.Button btnReplicationStatus;
        private System.Windows.Forms.Button btnClusterInfo;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}

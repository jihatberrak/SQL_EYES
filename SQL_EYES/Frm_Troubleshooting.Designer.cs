namespace SQL_EYES
{
    partial class Frm_Troubleshooting
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
            this.btnTraceFlags = new System.Windows.Forms.Button();
            this.btnServerConfig = new System.Windows.Forms.Button();
            this.btnDeadlocks = new System.Windows.Forms.Button();
            this.btnBlockingChains = new System.Windows.Forms.Button();
            this.btnErrorLog = new System.Windows.Forms.Button();
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
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
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
            this.lblTitle.Size = new System.Drawing.Size(285, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Troubleshooting Tools";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.White;
            this.panelButtons.Controls.Add(this.btnTraceFlags);
            this.panelButtons.Controls.Add(this.btnServerConfig);
            this.panelButtons.Controls.Add(this.btnDeadlocks);
            this.panelButtons.Controls.Add(this.btnBlockingChains);
            this.panelButtons.Controls.Add(this.btnErrorLog);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Location = new System.Drawing.Point(0, 60);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1200, 70);
            this.panelButtons.TabIndex = 1;
            // 
            // btnTraceFlags
            // 
            this.btnTraceFlags.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnTraceFlags.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraceFlags.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTraceFlags.ForeColor = System.Drawing.Color.White;
            this.btnTraceFlags.Location = new System.Drawing.Point(970, 15);
            this.btnTraceFlags.Name = "btnTraceFlags";
            this.btnTraceFlags.Size = new System.Drawing.Size(220, 40);
            this.btnTraceFlags.TabIndex = 4;
            this.btnTraceFlags.Text = "Trace Flags";
            this.btnTraceFlags.Click += new System.EventHandler(this.btnTraceFlags_Click);
            // 
            // btnServerConfig
            // 
            this.btnServerConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnServerConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServerConfig.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnServerConfig.ForeColor = System.Drawing.Color.White;
            this.btnServerConfig.Location = new System.Drawing.Point(730, 15);
            this.btnServerConfig.Name = "btnServerConfig";
            this.btnServerConfig.Size = new System.Drawing.Size(220, 40);
            this.btnServerConfig.TabIndex = 3;
            this.btnServerConfig.Text = "Server Config";
            this.btnServerConfig.Click += new System.EventHandler(this.btnServerConfig_Click);
            // 
            // btnDeadlocks
            // 
            this.btnDeadlocks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDeadlocks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeadlocks.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeadlocks.ForeColor = System.Drawing.Color.White;
            this.btnDeadlocks.Location = new System.Drawing.Point(490, 15);
            this.btnDeadlocks.Name = "btnDeadlocks";
            this.btnDeadlocks.Size = new System.Drawing.Size(220, 40);
            this.btnDeadlocks.TabIndex = 2;
            this.btnDeadlocks.Text = "Deadlocks";
            this.btnDeadlocks.Click += new System.EventHandler(this.btnDeadlocks_Click);
            // 
            // btnBlockingChains
            // 
            this.btnBlockingChains.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnBlockingChains.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlockingChains.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBlockingChains.ForeColor = System.Drawing.Color.White;
            this.btnBlockingChains.Location = new System.Drawing.Point(250, 15);
            this.btnBlockingChains.Name = "btnBlockingChains";
            this.btnBlockingChains.Size = new System.Drawing.Size(220, 40);
            this.btnBlockingChains.TabIndex = 1;
            this.btnBlockingChains.Text = "Blocking Chains";
            this.btnBlockingChains.Click += new System.EventHandler(this.btnBlockingChains_Click);
            // 
            // btnErrorLog
            // 
            this.btnErrorLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnErrorLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnErrorLog.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnErrorLog.ForeColor = System.Drawing.Color.White;
            this.btnErrorLog.Location = new System.Drawing.Point(10, 15);
            this.btnErrorLog.Name = "btnErrorLog";
            this.btnErrorLog.Size = new System.Drawing.Size(220, 40);
            this.btnErrorLog.TabIndex = 0;
            this.btnErrorLog.Text = "Error Log";
            this.btnErrorLog.Click += new System.EventHandler(this.btnErrorLog_Click);
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
            // Frm_Troubleshooting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1200, 677);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelTop);
            this.Name = "Frm_Troubleshooting";
            this.Text = "Troubleshooting Tools - SQL EYES";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Troubleshooting_Load);
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
        private System.Windows.Forms.Button btnErrorLog;
        private System.Windows.Forms.Button btnBlockingChains;
        private System.Windows.Forms.Button btnDeadlocks;
        private System.Windows.Forms.Button btnServerConfig;
        private System.Windows.Forms.Button btnTraceFlags;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}

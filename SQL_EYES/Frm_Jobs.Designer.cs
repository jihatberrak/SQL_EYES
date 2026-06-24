namespace SQL_EYES
{
    partial class Frm_Jobs
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
            this.btnLongRunningJobs = new System.Windows.Forms.Button();
            this.btnJobHistory = new System.Windows.Forms.Button();
            this.btnRunningJobs = new System.Windows.Forms.Button();
            this.btnFailedJobs = new System.Windows.Forms.Button();
            this.btnAllJobs = new System.Windows.Forms.Button();
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
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
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
            this.lblTitle.Size = new System.Drawing.Size(248, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Job & Agent Monitoring";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.White;
            this.panelButtons.Controls.Add(this.btnLongRunningJobs);
            this.panelButtons.Controls.Add(this.btnJobHistory);
            this.panelButtons.Controls.Add(this.btnRunningJobs);
            this.panelButtons.Controls.Add(this.btnFailedJobs);
            this.panelButtons.Controls.Add(this.btnAllJobs);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Location = new System.Drawing.Point(0, 60);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(10);
            this.panelButtons.Size = new System.Drawing.Size(1200, 70);
            this.panelButtons.TabIndex = 1;
            // 
            // btnLongRunningJobs
            // 
            this.btnLongRunningJobs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnLongRunningJobs.FlatAppearance.BorderSize = 0;
            this.btnLongRunningJobs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLongRunningJobs.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLongRunningJobs.ForeColor = System.Drawing.Color.White;
            this.btnLongRunningJobs.Location = new System.Drawing.Point(970, 15);
            this.btnLongRunningJobs.Name = "btnLongRunningJobs";
            this.btnLongRunningJobs.Size = new System.Drawing.Size(220, 40);
            this.btnLongRunningJobs.TabIndex = 4;
            this.btnLongRunningJobs.Text = "Uzun Süren Job\'lar";
            this.btnLongRunningJobs.UseVisualStyleBackColor = false;
            this.btnLongRunningJobs.Click += new System.EventHandler(this.btnLongRunningJobs_Click);
            // 
            // btnJobHistory
            // 
            this.btnJobHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnJobHistory.FlatAppearance.BorderSize = 0;
            this.btnJobHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobHistory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnJobHistory.ForeColor = System.Drawing.Color.White;
            this.btnJobHistory.Location = new System.Drawing.Point(730, 15);
            this.btnJobHistory.Name = "btnJobHistory";
            this.btnJobHistory.Size = new System.Drawing.Size(220, 40);
            this.btnJobHistory.TabIndex = 3;
            this.btnJobHistory.Text = "Job Geçmiþi";
            this.btnJobHistory.UseVisualStyleBackColor = false;
            this.btnJobHistory.Click += new System.EventHandler(this.btnJobHistory_Click);
            // 
            // btnRunningJobs
            // 
            this.btnRunningJobs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnRunningJobs.FlatAppearance.BorderSize = 0;
            this.btnRunningJobs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunningJobs.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRunningJobs.ForeColor = System.Drawing.Color.Black;
            this.btnRunningJobs.Location = new System.Drawing.Point(490, 15);
            this.btnRunningJobs.Name = "btnRunningJobs";
            this.btnRunningJobs.Size = new System.Drawing.Size(220, 40);
            this.btnRunningJobs.TabIndex = 2;
            this.btnRunningJobs.Text = "Çalýþan Job\'lar";
            this.btnRunningJobs.UseVisualStyleBackColor = false;
            this.btnRunningJobs.Click += new System.EventHandler(this.btnRunningJobs_Click);
            // 
            // btnFailedJobs
            // 
            this.btnFailedJobs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnFailedJobs.FlatAppearance.BorderSize = 0;
            this.btnFailedJobs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFailedJobs.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnFailedJobs.ForeColor = System.Drawing.Color.White;
            this.btnFailedJobs.Location = new System.Drawing.Point(250, 15);
            this.btnFailedJobs.Name = "btnFailedJobs";
            this.btnFailedJobs.Size = new System.Drawing.Size(220, 40);
            this.btnFailedJobs.TabIndex = 1;
            this.btnFailedJobs.Text = "Baþarýsýz Job\'lar";
            this.btnFailedJobs.UseVisualStyleBackColor = false;
            this.btnFailedJobs.Click += new System.EventHandler(this.btnFailedJobs_Click);
            // 
            // btnAllJobs
            // 
            this.btnAllJobs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnAllJobs.FlatAppearance.BorderSize = 0;
            this.btnAllJobs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllJobs.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAllJobs.ForeColor = System.Drawing.Color.White;
            this.btnAllJobs.Location = new System.Drawing.Point(10, 15);
            this.btnAllJobs.Name = "btnAllJobs";
            this.btnAllJobs.Size = new System.Drawing.Size(220, 40);
            this.btnAllJobs.TabIndex = 0;
            this.btnAllJobs.Text = "Tüm Job\'lar";
            this.btnAllJobs.UseVisualStyleBackColor = false;
            this.btnAllJobs.Click += new System.EventHandler(this.btnAllJobs_Click);
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
            this.lblStatus.Size = new System.Drawing.Size(34, 17);
            this.lblStatus.Text = "Hazýr";
            // 
            // Frm_Jobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1200, 677);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelTop);
            this.Name = "Frm_Jobs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Job & Agent Monitoring - SQL EYES";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Jobs_Load);
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
        private System.Windows.Forms.Button btnAllJobs;
        private System.Windows.Forms.Button btnFailedJobs;
        private System.Windows.Forms.Button btnRunningJobs;
        private System.Windows.Forms.Button btnJobHistory;
        private System.Windows.Forms.Button btnLongRunningJobs;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}

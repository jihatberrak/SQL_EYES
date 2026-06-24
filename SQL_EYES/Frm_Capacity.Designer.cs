namespace SQL_EYES
{
    partial class Frm_Capacity
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
            this.btnResourceUsage = new System.Windows.Forms.Button();
            this.btnIndexSpace = new System.Windows.Forms.Button();
            this.btnTableGrowth = new System.Windows.Forms.Button();
            this.btnDatabaseGrowth = new System.Windows.Forms.Button();
            this.btnDiskSpace = new System.Windows.Forms.Button();
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
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
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
            this.lblTitle.Size = new System.Drawing.Size(203, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Kapasite Planlama";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.White;
            this.panelButtons.Controls.Add(this.btnResourceUsage);
            this.panelButtons.Controls.Add(this.btnIndexSpace);
            this.panelButtons.Controls.Add(this.btnTableGrowth);
            this.panelButtons.Controls.Add(this.btnDatabaseGrowth);
            this.panelButtons.Controls.Add(this.btnDiskSpace);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Location = new System.Drawing.Point(0, 60);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1200, 70);
            this.panelButtons.TabIndex = 1;
            // 
            // btnResourceUsage
            // 
            this.btnResourceUsage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnResourceUsage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResourceUsage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnResourceUsage.ForeColor = System.Drawing.Color.White;
            this.btnResourceUsage.Location = new System.Drawing.Point(970, 15);
            this.btnResourceUsage.Name = "btnResourceUsage";
            this.btnResourceUsage.Size = new System.Drawing.Size(220, 40);
            this.btnResourceUsage.TabIndex = 4;
            this.btnResourceUsage.Text = "Kaynak Kullanýmý";
            this.btnResourceUsage.UseVisualStyleBackColor = false;
            this.btnResourceUsage.Click += new System.EventHandler(this.btnResourceUsage_Click);
            // 
            // btnIndexSpace
            // 
            this.btnIndexSpace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnIndexSpace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIndexSpace.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIndexSpace.ForeColor = System.Drawing.Color.White;
            this.btnIndexSpace.Location = new System.Drawing.Point(730, 15);
            this.btnIndexSpace.Name = "btnIndexSpace";
            this.btnIndexSpace.Size = new System.Drawing.Size(220, 40);
            this.btnIndexSpace.TabIndex = 3;
            this.btnIndexSpace.Text = "Index Alan Kullanýmý";
            this.btnIndexSpace.UseVisualStyleBackColor = false;
            this.btnIndexSpace.Click += new System.EventHandler(this.btnIndexSpace_Click);
            // 
            // btnTableGrowth
            // 
            this.btnTableGrowth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnTableGrowth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTableGrowth.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTableGrowth.ForeColor = System.Drawing.Color.White;
            this.btnTableGrowth.Location = new System.Drawing.Point(490, 15);
            this.btnTableGrowth.Name = "btnTableGrowth";
            this.btnTableGrowth.Size = new System.Drawing.Size(220, 40);
            this.btnTableGrowth.TabIndex = 2;
            this.btnTableGrowth.Text = "En Büyük Tablolar";
            this.btnTableGrowth.UseVisualStyleBackColor = false;
            this.btnTableGrowth.Click += new System.EventHandler(this.btnTableGrowth_Click);
            // 
            // btnDatabaseGrowth
            // 
            this.btnDatabaseGrowth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnDatabaseGrowth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatabaseGrowth.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDatabaseGrowth.ForeColor = System.Drawing.Color.Black;
            this.btnDatabaseGrowth.Location = new System.Drawing.Point(250, 15);
            this.btnDatabaseGrowth.Name = "btnDatabaseGrowth";
            this.btnDatabaseGrowth.Size = new System.Drawing.Size(220, 40);
            this.btnDatabaseGrowth.TabIndex = 1;
            this.btnDatabaseGrowth.Text = "Büyüme Trendi";
            this.btnDatabaseGrowth.UseVisualStyleBackColor = false;
            this.btnDatabaseGrowth.Click += new System.EventHandler(this.btnDatabaseGrowth_Click);
            // 
            // btnDiskSpace
            // 
            this.btnDiskSpace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnDiskSpace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiskSpace.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDiskSpace.ForeColor = System.Drawing.Color.White;
            this.btnDiskSpace.Location = new System.Drawing.Point(10, 15);
            this.btnDiskSpace.Name = "btnDiskSpace";
            this.btnDiskSpace.Size = new System.Drawing.Size(220, 40);
            this.btnDiskSpace.TabIndex = 0;
            this.btnDiskSpace.Text = "Disk Alaný Kullanýmý";
            this.btnDiskSpace.UseVisualStyleBackColor = false;
            this.btnDiskSpace.Click += new System.EventHandler(this.btnDiskSpace_Click);
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
            this.lblStatus.Size = new System.Drawing.Size(34, 17);
            this.lblStatus.Text = "Hazýr";
            // 
            // Frm_Capacity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1200, 677);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelTop);
            this.Name = "Frm_Capacity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kapasite Planlama - SQL EYES";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Capacity_Load);
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
        private System.Windows.Forms.Button btnDiskSpace;
        private System.Windows.Forms.Button btnDatabaseGrowth;
        private System.Windows.Forms.Button btnTableGrowth;
        private System.Windows.Forms.Button btnIndexSpace;
        private System.Windows.Forms.Button btnResourceUsage;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}

namespace SQL_EYES
{
    partial class Frm_Performance
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnTopTables = new System.Windows.Forms.Button();
            this.btnMissingIndexes = new System.Windows.Forms.Button();
            this.btnIOStats = new System.Windows.Forms.Button();
            this.btnWaitStats = new System.Windows.Forms.Button();
            this.btnExpensiveQueries = new System.Windows.Forms.Button();
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
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
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
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(282, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Performans Ýzleme & Analiz";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.White;
            this.panelButtons.Controls.Add(this.btnTopTables);
            this.panelButtons.Controls.Add(this.btnMissingIndexes);
            this.panelButtons.Controls.Add(this.btnIOStats);
            this.panelButtons.Controls.Add(this.btnWaitStats);
            this.panelButtons.Controls.Add(this.btnExpensiveQueries);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Location = new System.Drawing.Point(0, 60);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(10);
            this.panelButtons.Size = new System.Drawing.Size(1200, 70);
            this.panelButtons.TabIndex = 1;
            // 
            // btnTopTables
            // 
            this.btnTopTables.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnTopTables.FlatAppearance.BorderSize = 0;
            this.btnTopTables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopTables.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTopTables.ForeColor = System.Drawing.Color.White;
            this.btnTopTables.Location = new System.Drawing.Point(970, 15);
            this.btnTopTables.Name = "btnTopTables";
            this.btnTopTables.Size = new System.Drawing.Size(220, 40);
            this.btnTopTables.TabIndex = 4;
            this.btnTopTables.Text = "En Çok Kullanýlan Tablolar";
            this.btnTopTables.UseVisualStyleBackColor = false;
            this.btnTopTables.Click += new System.EventHandler(this.btnTopTables_Click);
            // 
            // btnMissingIndexes
            // 
            this.btnMissingIndexes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnMissingIndexes.FlatAppearance.BorderSize = 0;
            this.btnMissingIndexes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMissingIndexes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMissingIndexes.ForeColor = System.Drawing.Color.White;
            this.btnMissingIndexes.Location = new System.Drawing.Point(730, 15);
            this.btnMissingIndexes.Name = "btnMissingIndexes";
            this.btnMissingIndexes.Size = new System.Drawing.Size(220, 40);
            this.btnMissingIndexes.TabIndex = 3;
            this.btnMissingIndexes.Text = "Eksik Index Önerileri";
            this.btnMissingIndexes.UseVisualStyleBackColor = false;
            this.btnMissingIndexes.Click += new System.EventHandler(this.btnMissingIndexes_Click);
            // 
            // btnIOStats
            // 
            this.btnIOStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnIOStats.FlatAppearance.BorderSize = 0;
            this.btnIOStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIOStats.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIOStats.ForeColor = System.Drawing.Color.White;
            this.btnIOStats.Location = new System.Drawing.Point(490, 15);
            this.btnIOStats.Name = "btnIOStats";
            this.btnIOStats.Size = new System.Drawing.Size(220, 40);
            this.btnIOStats.TabIndex = 2;
            this.btnIOStats.Text = "I/O Ýstatistikleri";
            this.btnIOStats.UseVisualStyleBackColor = false;
            this.btnIOStats.Click += new System.EventHandler(this.btnIOStats_Click);
            // 
            // btnWaitStats
            // 
            this.btnWaitStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnWaitStats.FlatAppearance.BorderSize = 0;
            this.btnWaitStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWaitStats.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnWaitStats.ForeColor = System.Drawing.Color.White;
            this.btnWaitStats.Location = new System.Drawing.Point(250, 15);
            this.btnWaitStats.Name = "btnWaitStats";
            this.btnWaitStats.Size = new System.Drawing.Size(220, 40);
            this.btnWaitStats.TabIndex = 1;
            this.btnWaitStats.Text = "Wait Statistics";
            this.btnWaitStats.UseVisualStyleBackColor = false;
            this.btnWaitStats.Click += new System.EventHandler(this.btnWaitStats_Click);
            // 
            // btnExpensiveQueries
            // 
            this.btnExpensiveQueries.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnExpensiveQueries.FlatAppearance.BorderSize = 0;
            this.btnExpensiveQueries.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpensiveQueries.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExpensiveQueries.ForeColor = System.Drawing.Color.Black;
            this.btnExpensiveQueries.Location = new System.Drawing.Point(10, 15);
            this.btnExpensiveQueries.Name = "btnExpensiveQueries";
            this.btnExpensiveQueries.Size = new System.Drawing.Size(220, 40);
            this.btnExpensiveQueries.TabIndex = 0;
            this.btnExpensiveQueries.Text = "En Pahalý Sorgular";
            this.btnExpensiveQueries.UseVisualStyleBackColor = false;
            this.btnExpensiveQueries.Click += new System.EventHandler(this.btnExpensiveQueries_Click);
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
            this.dgvResults.RowTemplate.Height = 24;
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
            // Frm_Performance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1200, 677);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelTop);
            this.MinimumSize = new System.Drawing.Size(1216, 716);
            this.Name = "Frm_Performance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Performans Ýzleme & Analiz - SQL EYES";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Performance_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnExpensiveQueries;
        private System.Windows.Forms.Button btnWaitStats;
        private System.Windows.Forms.Button btnIOStats;
        private System.Windows.Forms.Button btnMissingIndexes;
        private System.Windows.Forms.Button btnTopTables;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}

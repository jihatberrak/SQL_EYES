namespace SQL_EYES
{
    partial class Frm_Security
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
            this.btnPermissions = new System.Windows.Forms.Button();
            this.btnDatabaseRoles = new System.Windows.Forms.Button();
            this.btnServerRoles = new System.Windows.Forms.Button();
            this.btnDatabaseUsers = new System.Windows.Forms.Button();
            this.btnServerLogins = new System.Windows.Forms.Button();
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
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
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
            this.lblTitle.Size = new System.Drawing.Size(365, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Güvenlik & Yetkilendirme";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.White;
            this.panelButtons.Controls.Add(this.btnPermissions);
            this.panelButtons.Controls.Add(this.btnDatabaseRoles);
            this.panelButtons.Controls.Add(this.btnServerRoles);
            this.panelButtons.Controls.Add(this.btnDatabaseUsers);
            this.panelButtons.Controls.Add(this.btnServerLogins);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Location = new System.Drawing.Point(0, 60);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(10);
            this.panelButtons.Size = new System.Drawing.Size(1200, 70);
            this.panelButtons.TabIndex = 1;
            // 
            // btnPermissions
            // 
            this.btnPermissions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnPermissions.FlatAppearance.BorderSize = 0;
            this.btnPermissions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPermissions.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPermissions.ForeColor = System.Drawing.Color.White;
            this.btnPermissions.Location = new System.Drawing.Point(970, 15);
            this.btnPermissions.Name = "btnPermissions";
            this.btnPermissions.Size = new System.Drawing.Size(220, 40);
            this.btnPermissions.TabIndex = 4;
            this.btnPermissions.Text = "Ýzinler";
            this.btnPermissions.UseVisualStyleBackColor = false;
            this.btnPermissions.Click += new System.EventHandler(this.btnPermissions_Click);
            // 
            // btnDatabaseRoles
            // 
            this.btnDatabaseRoles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnDatabaseRoles.FlatAppearance.BorderSize = 0;
            this.btnDatabaseRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatabaseRoles.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDatabaseRoles.ForeColor = System.Drawing.Color.White;
            this.btnDatabaseRoles.Location = new System.Drawing.Point(730, 15);
            this.btnDatabaseRoles.Name = "btnDatabaseRoles";
            this.btnDatabaseRoles.Size = new System.Drawing.Size(220, 40);
            this.btnDatabaseRoles.TabIndex = 3;
            this.btnDatabaseRoles.Text = "Veritabaný Rolleri";
            this.btnDatabaseRoles.UseVisualStyleBackColor = false;
            this.btnDatabaseRoles.Click += new System.EventHandler(this.btnDatabaseRoles_Click);
            // 
            // btnServerRoles
            // 
            this.btnServerRoles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnServerRoles.FlatAppearance.BorderSize = 0;
            this.btnServerRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServerRoles.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnServerRoles.ForeColor = System.Drawing.Color.White;
            this.btnServerRoles.Location = new System.Drawing.Point(490, 15);
            this.btnServerRoles.Name = "btnServerRoles";
            this.btnServerRoles.Size = new System.Drawing.Size(220, 40);
            this.btnServerRoles.TabIndex = 2;
            this.btnServerRoles.Text = "Server Rolleri";
            this.btnServerRoles.UseVisualStyleBackColor = false;
            this.btnServerRoles.Click += new System.EventHandler(this.btnServerRoles_Click);
            // 
            // btnDatabaseUsers
            // 
            this.btnDatabaseUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnDatabaseUsers.FlatAppearance.BorderSize = 0;
            this.btnDatabaseUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatabaseUsers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDatabaseUsers.ForeColor = System.Drawing.Color.White;
            this.btnDatabaseUsers.Location = new System.Drawing.Point(250, 15);
            this.btnDatabaseUsers.Name = "btnDatabaseUsers";
            this.btnDatabaseUsers.Size = new System.Drawing.Size(220, 40);
            this.btnDatabaseUsers.TabIndex = 1;
            this.btnDatabaseUsers.Text = "Veritabaný Kullanýcýlarý";
            this.btnDatabaseUsers.UseVisualStyleBackColor = false;
            this.btnDatabaseUsers.Click += new System.EventHandler(this.btnDatabaseUsers_Click);
            // 
            // btnServerLogins
            // 
            this.btnServerLogins.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnServerLogins.FlatAppearance.BorderSize = 0;
            this.btnServerLogins.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServerLogins.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnServerLogins.ForeColor = System.Drawing.Color.White;
            this.btnServerLogins.Location = new System.Drawing.Point(10, 15);
            this.btnServerLogins.Name = "btnServerLogins";
            this.btnServerLogins.Size = new System.Drawing.Size(220, 40);
            this.btnServerLogins.TabIndex = 0;
            this.btnServerLogins.Text = "Server Login'leri";
            this.btnServerLogins.UseVisualStyleBackColor = false;
            this.btnServerLogins.Click += new System.EventHandler(this.btnServerLogins_Click);
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
            // Frm_Security
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1200, 677);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelTop);
            this.Name = "Frm_Security";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Güvenlik & Yetkilendirme - SQL EYES";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Security_Load);
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
        private System.Windows.Forms.Button btnServerLogins;
        private System.Windows.Forms.Button btnDatabaseUsers;
        private System.Windows.Forms.Button btnServerRoles;
        private System.Windows.Forms.Button btnDatabaseRoles;
        private System.Windows.Forms.Button btnPermissions;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}

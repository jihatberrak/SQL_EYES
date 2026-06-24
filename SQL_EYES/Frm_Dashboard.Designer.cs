namespace SQL_EYES
{
    partial class Frm_Dashboard
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
            this.btnAdvanced = new System.Windows.Forms.Button();
            this.btnRefreshDashboard = new System.Windows.Forms.Button();
            this.btnChangeConnection = new System.Windows.Forms.Button();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelServerInfo = new System.Windows.Forms.Panel();
            this.lblServerVersion = new System.Windows.Forms.Label();
            this.lblServerName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelQuickStats = new System.Windows.Forms.Panel();
            this.lblTempDBSize = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblActiveConnections = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDatabaseCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelCategories = new System.Windows.Forms.Panel();
            this.btnCapacity = new System.Windows.Forms.Button();
            this.btnMaintenance = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnTroubleshooting = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnHA = new System.Windows.Forms.Button();
            this.btnJobs = new System.Windows.Forms.Button();
            this.btnSecurity = new System.Windows.Forms.Button();
            this.btnPerformance = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelServerInfo.SuspendLayout();
            this.panelQuickStats.SuspendLayout();
            this.panelCategories.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelTop.Controls.Add(this.btnAdvanced);
            this.panelTop.Controls.Add(this.btnRefreshDashboard);
            this.panelTop.Controls.Add(this.btnChangeConnection);
            this.panelTop.Controls.Add(this.lblConnectionStatus);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1400, 80);
            this.panelTop.TabIndex = 0;
            // 
            // btnAdvanced
            // 
            this.btnAdvanced.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdvanced.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnAdvanced.FlatAppearance.BorderSize = 0;
            this.btnAdvanced.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdvanced.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdvanced.ForeColor = System.Drawing.Color.White;
            this.btnAdvanced.Location = new System.Drawing.Point(1240, 20);
            this.btnAdvanced.Name = "btnAdvanced";
            this.btnAdvanced.Size = new System.Drawing.Size(140, 40);
            this.btnAdvanced.TabIndex = 4;
            this.btnAdvanced.Text = "Geliþmiþ";
            this.btnAdvanced.UseVisualStyleBackColor = false;
            this.btnAdvanced.Click += new System.EventHandler(this.btnAdvanced_Click);
            // 
            // btnRefreshDashboard
            // 
            this.btnRefreshDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRefreshDashboard.FlatAppearance.BorderSize = 0;
            this.btnRefreshDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshDashboard.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefreshDashboard.ForeColor = System.Drawing.Color.White;
            this.btnRefreshDashboard.Location = new System.Drawing.Point(1110, 25);
            this.btnRefreshDashboard.Name = "btnRefreshDashboard";
            this.btnRefreshDashboard.Size = new System.Drawing.Size(110, 30);
            this.btnRefreshDashboard.TabIndex = 3;
            this.btnRefreshDashboard.Text = "Yenile";
            this.btnRefreshDashboard.UseVisualStyleBackColor = false;
            this.btnRefreshDashboard.Click += new System.EventHandler(this.btnRefreshDashboard_Click);
            // 
            // btnChangeConnection
            // 
            this.btnChangeConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnChangeConnection.FlatAppearance.BorderSize = 0;
            this.btnChangeConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeConnection.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnChangeConnection.ForeColor = System.Drawing.Color.Black;
            this.btnChangeConnection.Location = new System.Drawing.Point(960, 25);
            this.btnChangeConnection.Name = "btnChangeConnection";
            this.btnChangeConnection.Size = new System.Drawing.Size(130, 30);
            this.btnChangeConnection.TabIndex = 2;
            this.btnChangeConnection.Text = "Baðlantý Deðiþtir";
            this.btnChangeConnection.UseVisualStyleBackColor = false;
            this.btnChangeConnection.Click += new System.EventHandler(this.btnChangeConnection_Click);
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblConnectionStatus.ForeColor = System.Drawing.Color.White;
            this.lblConnectionStatus.Location = new System.Drawing.Point(20, 50);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(134, 19);
            this.lblConnectionStatus.TabIndex = 1;
            this.lblConnectionStatus.Text = "Baðlantý Bekleniyor...";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(464, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "SQL EYES - SQL Server Yönetim Merkezi";
            // 
            // panelServerInfo
            // 
            this.panelServerInfo.BackColor = System.Drawing.Color.White;
            this.panelServerInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelServerInfo.Controls.Add(this.lblServerVersion);
            this.panelServerInfo.Controls.Add(this.lblServerName);
            this.panelServerInfo.Controls.Add(this.label1);
            this.panelServerInfo.Location = new System.Drawing.Point(20, 100);
            this.panelServerInfo.Name = "panelServerInfo";
            this.panelServerInfo.Size = new System.Drawing.Size(450, 120);
            this.panelServerInfo.TabIndex = 1;
            // 
            // lblServerVersion
            // 
            this.lblServerVersion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblServerVersion.ForeColor = System.Drawing.Color.Gray;
            this.lblServerVersion.Location = new System.Drawing.Point(15, 80);
            this.lblServerVersion.Name = "lblServerVersion";
            this.lblServerVersion.Size = new System.Drawing.Size(420, 20);
            this.lblServerVersion.TabIndex = 2;
            this.lblServerVersion.Text = "Versiyon bilgisi yükleniyor...";
            // 
            // lblServerName
            // 
            this.lblServerName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblServerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblServerName.Location = new System.Drawing.Point(15, 45);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(420, 30);
            this.lblServerName.TabIndex = 1;
            this.lblServerName.Text = "Sunucu bilgisi yükleniyor...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sunucu Bilgisi";
            // 
            // panelQuickStats
            // 
            this.panelQuickStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelQuickStats.BackColor = System.Drawing.Color.White;
            this.panelQuickStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelQuickStats.Controls.Add(this.lblTempDBSize);
            this.panelQuickStats.Controls.Add(this.label6);
            this.panelQuickStats.Controls.Add(this.lblActiveConnections);
            this.panelQuickStats.Controls.Add(this.label4);
            this.panelQuickStats.Controls.Add(this.lblDatabaseCount);
            this.panelQuickStats.Controls.Add(this.label2);
            this.panelQuickStats.Location = new System.Drawing.Point(490, 100);
            this.panelQuickStats.Name = "panelQuickStats";
            this.panelQuickStats.Size = new System.Drawing.Size(890, 120);
            this.panelQuickStats.TabIndex = 2;
            // 
            // lblTempDBSize
            // 
            this.lblTempDBSize.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTempDBSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.lblTempDBSize.Location = new System.Drawing.Point(600, 50);
            this.lblTempDBSize.Name = "lblTempDBSize";
            this.lblTempDBSize.Size = new System.Drawing.Size(250, 40);
            this.lblTempDBSize.TabIndex = 5;
            this.lblTempDBSize.Text = "0 MB";
            this.lblTempDBSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(600, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(250, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "TempDB Boyutu";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblActiveConnections
            // 
            this.lblActiveConnections.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblActiveConnections.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblActiveConnections.Location = new System.Drawing.Point(310, 50);
            this.lblActiveConnections.Name = "lblActiveConnections";
            this.lblActiveConnections.Size = new System.Drawing.Size(250, 40);
            this.lblActiveConnections.TabIndex = 3;
            this.lblActiveConnections.Text = "0";
            this.lblActiveConnections.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(310, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(250, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Aktif Baðlantýlar";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDatabaseCount
            // 
            this.lblDatabaseCount.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblDatabaseCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblDatabaseCount.Location = new System.Drawing.Point(20, 50);
            this.lblDatabaseCount.Name = "lblDatabaseCount";
            this.lblDatabaseCount.Size = new System.Drawing.Size(250, 40);
            this.lblDatabaseCount.TabIndex = 1;
            this.lblDatabaseCount.Text = "0";
            this.lblDatabaseCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(20, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Toplam Veritabaný";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelCategories
            // 
            this.panelCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCategories.BackColor = System.Drawing.Color.White;
            this.panelCategories.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCategories.Controls.Add(this.btnCapacity);
            this.panelCategories.Controls.Add(this.btnMaintenance);
            this.panelCategories.Controls.Add(this.btnBackup);
            this.panelCategories.Controls.Add(this.btnTroubleshooting);
            this.panelCategories.Controls.Add(this.btnReports);
            this.panelCategories.Controls.Add(this.btnHA);
            this.panelCategories.Controls.Add(this.btnJobs);
            this.panelCategories.Controls.Add(this.btnSecurity);
            this.panelCategories.Controls.Add(this.btnPerformance);
            this.panelCategories.Controls.Add(this.label3);
            this.panelCategories.Location = new System.Drawing.Point(20, 240);
            this.panelCategories.Name = "panelCategories";
            this.panelCategories.Size = new System.Drawing.Size(1360, 500);
            this.panelCategories.TabIndex = 3;
            // 
            // btnCapacity
            // 
            this.btnCapacity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnCapacity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCapacity.FlatAppearance.BorderSize = 0;
            this.btnCapacity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapacity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCapacity.ForeColor = System.Drawing.Color.White;
            this.btnCapacity.Location = new System.Drawing.Point(930, 360);
            this.btnCapacity.Name = "btnCapacity";
            this.btnCapacity.Size = new System.Drawing.Size(400, 100);
            this.btnCapacity.TabIndex = 9;
            this.btnCapacity.Text = "Kapasite Planlama\r\n\r\nBüyüme Analizi • Tahmin Araçlarý";
            this.btnCapacity.UseVisualStyleBackColor = false;
            this.btnCapacity.Click += new System.EventHandler(this.btnCapacity_Click);
            // 
            // btnMaintenance
            // 
            this.btnMaintenance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnMaintenance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaintenance.FlatAppearance.BorderSize = 0;
            this.btnMaintenance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaintenance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnMaintenance.ForeColor = System.Drawing.Color.White;
            this.btnMaintenance.Location = new System.Drawing.Point(480, 360);
            this.btnMaintenance.Name = "btnMaintenance";
            this.btnMaintenance.Size = new System.Drawing.Size(400, 100);
            this.btnMaintenance.TabIndex = 8;
            this.btnMaintenance.Text = "Bakým & Optimizasyon\r\n\r\nÝndex • Ýstatistikler • DBCC";
            this.btnMaintenance.UseVisualStyleBackColor = false;
            this.btnMaintenance.Click += new System.EventHandler(this.btnMaintenance_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.btnBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackup.FlatAppearance.BorderSize = 0;
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBackup.ForeColor = System.Drawing.Color.White;
            this.btnBackup.Location = new System.Drawing.Point(30, 360);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(400, 100);
            this.btnBackup.TabIndex = 7;
            this.btnBackup.Text = "Yedekleme & Kurtarma\r\n\r\nBackup Ýzleme • Restore Planlama";
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnTroubleshooting
            // 
            this.btnTroubleshooting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnTroubleshooting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTroubleshooting.FlatAppearance.BorderSize = 0;
            this.btnTroubleshooting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTroubleshooting.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnTroubleshooting.ForeColor = System.Drawing.Color.White;
            this.btnTroubleshooting.Location = new System.Drawing.Point(930, 230);
            this.btnTroubleshooting.Name = "btnTroubleshooting";
            this.btnTroubleshooting.Size = new System.Drawing.Size(400, 100);
            this.btnTroubleshooting.TabIndex = 6;
            this.btnTroubleshooting.Text = "Troubleshooting Tools\r\n\r\nLog Viewer • Wait Stats • Hata Analizi";
            this.btnTroubleshooting.UseVisualStyleBackColor = false;
            this.btnTroubleshooting.Click += new System.EventHandler(this.btnTroubleshooting_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Location = new System.Drawing.Point(480, 230);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(400, 100);
            this.btnReports.TabIndex = 5;
            this.btnReports.Text = "Raporlama & Export\r\n\r\nExcel • PDF • Email Alerts";
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnHA
            // 
            this.btnHA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnHA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHA.FlatAppearance.BorderSize = 0;
            this.btnHA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHA.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnHA.ForeColor = System.Drawing.Color.White;
            this.btnHA.Location = new System.Drawing.Point(30, 230);
            this.btnHA.Name = "btnHA";
            this.btnHA.Size = new System.Drawing.Size(400, 100);
            this.btnHA.TabIndex = 4;
            this.btnHA.Text = "High Availability & DR\r\n\r\nAlwaysOn • Replication • Mirroring";
            this.btnHA.UseVisualStyleBackColor = false;
            this.btnHA.Click += new System.EventHandler(this.btnHA_Click);
            // 
            // btnJobs
            // 
            this.btnJobs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnJobs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobs.FlatAppearance.BorderSize = 0;
            this.btnJobs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobs.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnJobs.ForeColor = System.Drawing.Color.White;
            this.btnJobs.Location = new System.Drawing.Point(930, 100);
            this.btnJobs.Name = "btnJobs";
            this.btnJobs.Size = new System.Drawing.Size(400, 100);
            this.btnJobs.TabIndex = 3;
            this.btnJobs.Text = "Job & Agent Monitoring\r\n\r\nÝþ Takibi • Baþarýsýz Ýþler • Zamanlamalar";
            this.btnJobs.UseVisualStyleBackColor = false;
            this.btnJobs.Click += new System.EventHandler(this.btnJobs_Click);
            // 
            // btnSecurity
            // 
            this.btnSecurity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnSecurity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSecurity.FlatAppearance.BorderSize = 0;
            this.btnSecurity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecurity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSecurity.ForeColor = System.Drawing.Color.White;
            this.btnSecurity.Location = new System.Drawing.Point(480, 100);
            this.btnSecurity.Name = "btnSecurity";
            this.btnSecurity.Size = new System.Drawing.Size(400, 100);
            this.btnSecurity.TabIndex = 2;
            this.btnSecurity.Text = "Güvenlik & Yetkilendirme\r\n\r\nKullanýcýlar • Roller • Ýzinler • Audit";
            this.btnSecurity.UseVisualStyleBackColor = false;
            this.btnSecurity.Click += new System.EventHandler(this.btnSecurity_Click);
            // 
            // btnPerformance
            // 
            this.btnPerformance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnPerformance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPerformance.FlatAppearance.BorderSize = 0;
            this.btnPerformance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPerformance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPerformance.ForeColor = System.Drawing.Color.Black;
            this.btnPerformance.Location = new System.Drawing.Point(30, 100);
            this.btnPerformance.Name = "btnPerformance";
            this.btnPerformance.Size = new System.Drawing.Size(400, 100);
            this.btnPerformance.TabIndex = 1;
            this.btnPerformance.Text = "Performans Ýzleme & Analiz\r\n\r\nPahalý Sorgular • Wait Stats • I/O Analizi";
            this.btnPerformance.UseVisualStyleBackColor = false;
            this.btnPerformance.Click += new System.EventHandler(this.btnPerformance_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label3.Location = new System.Drawing.Point(25, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(256, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Yönetim Modülleri - Seçiniz";
            // 
            // Frm_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1400, 760);
            this.Controls.Add(this.panelCategories);
            this.Controls.Add(this.panelQuickStats);
            this.Controls.Add(this.panelServerInfo);
            this.Controls.Add(this.panelTop);
            this.MinimumSize = new System.Drawing.Size(1416, 799);
            this.Name = "Frm_Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL EYES - Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Dashboard_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelServerInfo.ResumeLayout(false);
            this.panelServerInfo.PerformLayout();
            this.panelQuickStats.ResumeLayout(false);
            this.panelCategories.ResumeLayout(false);
            this.panelCategories.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.Button btnChangeConnection;
        private System.Windows.Forms.Button btnRefreshDashboard;
        private System.Windows.Forms.Button btnAdvanced;
        private System.Windows.Forms.Panel panelServerInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.Label lblServerVersion;
        private System.Windows.Forms.Panel panelQuickStats;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDatabaseCount;
        private System.Windows.Forms.Label lblActiveConnections;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTempDBSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelCategories;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPerformance;
        private System.Windows.Forms.Button btnSecurity;
        private System.Windows.Forms.Button btnJobs;
        private System.Windows.Forms.Button btnHA;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnTroubleshooting;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnMaintenance;
        private System.Windows.Forms.Button btnCapacity;
    }
}

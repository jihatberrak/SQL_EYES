namespace SQL_EYES
{
    partial class Frm_Main
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabConnection = new System.Windows.Forms.TabPage();
            this.btnConnect = new System.Windows.Forms.Button();
            this.chkIntegratedSecurity = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabActiveConnections = new System.Windows.Forms.TabPage();
            this.btnRefreshConnections = new System.Windows.Forms.Button();
            this.dgvActiveConnections = new System.Windows.Forms.DataGridView();
            this.tabTempDB = new System.Windows.Forms.TabPage();
            this.btnShrinkTempDB = new System.Windows.Forms.Button();
            this.btnRefreshTempDB = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvTempDBSessions = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvTempDBTables = new System.Windows.Forms.DataGridView();
            this.dgvTempDBFiles = new System.Windows.Forms.DataGridView();
            this.tabBufferPool = new System.Windows.Forms.TabPage();
            this.btnClearBuffer = new System.Windows.Forms.Button();
            this.btnRefreshBuffer = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvBufferByTable = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvBufferByDB = new System.Windows.Forms.DataGridView();
            this.tabDatabaseSizes = new System.Windows.Forms.TabPage();
            this.btnRefreshDBSizes = new System.Windows.Forms.Button();
            this.dgvDatabaseSizes = new System.Windows.Forms.DataGridView();
            this.tabTableSizes = new System.Windows.Forms.TabPage();
            this.cmbDatabases = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRefreshTableSizes = new System.Windows.Forms.Button();
            this.dgvTableSizes = new System.Windows.Forms.DataGridView();
            this.tabIndexMaintenance = new System.Windows.Forms.TabPage();
            this.btnExecuteAllIndexMaintenance = new System.Windows.Forms.Button();
            this.btnExecuteIndexMaintenance = new System.Windows.Forms.Button();
            this.cmbDatabasesForIndex = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numFragmentationThreshold = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAnalyzeIndexes = new System.Windows.Forms.Button();
            this.dgvIndexes = new System.Windows.Forms.DataGridView();
            this.tabConnectedUsers = new System.Windows.Forms.TabPage();
            this.btnRefreshUsers = new System.Windows.Forms.Button();
            this.dgvConnectedUsers = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1.SuspendLayout();
            this.tabConnection.SuspendLayout();
            this.tabActiveConnections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveConnections)).BeginInit();
            this.tabTempDB.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTempDBSessions)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTempDBTables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTempDBFiles)).BeginInit();
            this.tabBufferPool.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBufferByTable)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBufferByDB)).BeginInit();
            this.tabDatabaseSizes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatabaseSizes)).BeginInit();
            this.tabTableSizes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableSizes)).BeginInit();
            this.tabIndexMaintenance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFragmentationThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIndexes)).BeginInit();
            this.tabConnectedUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConnectedUsers)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabConnection);
            this.tabControl1.Controls.Add(this.tabActiveConnections);
            this.tabControl1.Controls.Add(this.tabTempDB);
            this.tabControl1.Controls.Add(this.tabBufferPool);
            this.tabControl1.Controls.Add(this.tabDatabaseSizes);
            this.tabControl1.Controls.Add(this.tabTableSizes);
            this.tabControl1.Controls.Add(this.tabIndexMaintenance);
            this.tabControl1.Controls.Add(this.tabConnectedUsers);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1200, 650);
            this.tabControl1.TabIndex = 0;
            // 
            // tabConnection
            // 
            this.tabConnection.Controls.Add(this.btnConnect);
            this.tabConnection.Controls.Add(this.chkIntegratedSecurity);
            this.tabConnection.Controls.Add(this.txtPassword);
            this.tabConnection.Controls.Add(this.txtUsername);
            this.tabConnection.Controls.Add(this.txtServer);
            this.tabConnection.Controls.Add(this.label3);
            this.tabConnection.Controls.Add(this.label2);
            this.tabConnection.Controls.Add(this.label1);
            this.tabConnection.Location = new System.Drawing.Point(4, 22);
            this.tabConnection.Name = "tabConnection";
            this.tabConnection.Padding = new System.Windows.Forms.Padding(3);
            this.tabConnection.Size = new System.Drawing.Size(1192, 624);
            this.tabConnection.TabIndex = 0;
            this.tabConnection.Text = "Bağlantı";
            this.tabConnection.UseVisualStyleBackColor = true;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(150, 150);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(200, 30);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Bağlan";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // chkIntegratedSecurity
            // 
            this.chkIntegratedSecurity.AutoSize = true;
            this.chkIntegratedSecurity.Location = new System.Drawing.Point(150, 120);
            this.chkIntegratedSecurity.Name = "chkIntegratedSecurity";
            this.chkIntegratedSecurity.Size = new System.Drawing.Size(161, 17);
            this.chkIntegratedSecurity.TabIndex = 6;
            this.chkIntegratedSecurity.Text = "Windows Kimlik Doğrulaması";
            this.chkIntegratedSecurity.UseVisualStyleBackColor = true;
            this.chkIntegratedSecurity.CheckedChanged += new System.EventHandler(this.chkIntegratedSecurity_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(150, 90);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(300, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(150, 60);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(300, 20);
            this.txtUsername.TabIndex = 4;
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(150, 30);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(300, 20);
            this.txtServer.TabIndex = 3;
            this.txtServer.Text = "localhost";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Şifre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kullanıcı Adı:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sunucu:";
            // 
            // tabActiveConnections
            // 
            this.tabActiveConnections.Controls.Add(this.btnRefreshConnections);
            this.tabActiveConnections.Controls.Add(this.dgvActiveConnections);
            this.tabActiveConnections.Location = new System.Drawing.Point(4, 22);
            this.tabActiveConnections.Name = "tabActiveConnections";
            this.tabActiveConnections.Size = new System.Drawing.Size(1192, 624);
            this.tabActiveConnections.TabIndex = 1;
            this.tabActiveConnections.Text = "Aktif Bağlantılar";
            this.tabActiveConnections.UseVisualStyleBackColor = true;
            // 
            // btnRefreshConnections
            // 
            this.btnRefreshConnections.Location = new System.Drawing.Point(10, 10);
            this.btnRefreshConnections.Name = "btnRefreshConnections";
            this.btnRefreshConnections.Size = new System.Drawing.Size(120, 30);
            this.btnRefreshConnections.TabIndex = 1;
            this.btnRefreshConnections.Text = "Yenile";
            this.btnRefreshConnections.UseVisualStyleBackColor = true;
            this.btnRefreshConnections.Click += new System.EventHandler(this.btnRefreshConnections_Click);
            // 
            // dgvActiveConnections
            // 
            this.dgvActiveConnections.AllowUserToAddRows = false;
            this.dgvActiveConnections.AllowUserToDeleteRows = false;
            this.dgvActiveConnections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvActiveConnections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActiveConnections.Location = new System.Drawing.Point(10, 50);
            this.dgvActiveConnections.Name = "dgvActiveConnections";
            this.dgvActiveConnections.ReadOnly = true;
            this.dgvActiveConnections.Size = new System.Drawing.Size(1172, 564);
            this.dgvActiveConnections.TabIndex = 0;
            // 
            // tabTempDB
            // 
            this.tabTempDB.Controls.Add(this.btnShrinkTempDB);
            this.tabTempDB.Controls.Add(this.btnRefreshTempDB);
            this.tabTempDB.Controls.Add(this.groupBox2);
            this.tabTempDB.Controls.Add(this.groupBox1);
            this.tabTempDB.Controls.Add(this.dgvTempDBFiles);
            this.tabTempDB.Location = new System.Drawing.Point(4, 22);
            this.tabTempDB.Name = "tabTempDB";
            this.tabTempDB.Size = new System.Drawing.Size(1192, 624);
            this.tabTempDB.TabIndex = 2;
            this.tabTempDB.Text = "TempDB Kontrol";
            this.tabTempDB.UseVisualStyleBackColor = true;
            // 
            // btnShrinkTempDB
            // 
            this.btnShrinkTempDB.Location = new System.Drawing.Point(140, 10);
            this.btnShrinkTempDB.Name = "btnShrinkTempDB";
            this.btnShrinkTempDB.Size = new System.Drawing.Size(120, 30);
            this.btnShrinkTempDB.TabIndex = 4;
            this.btnShrinkTempDB.Text = "TempDB Küçült";
            this.btnShrinkTempDB.UseVisualStyleBackColor = true;
            this.btnShrinkTempDB.Click += new System.EventHandler(this.btnShrinkTempDB_Click);
            // 
            // btnRefreshTempDB
            // 
            this.btnRefreshTempDB.Location = new System.Drawing.Point(10, 10);
            this.btnRefreshTempDB.Name = "btnRefreshTempDB";
            this.btnRefreshTempDB.Size = new System.Drawing.Size(120, 30);
            this.btnRefreshTempDB.TabIndex = 3;
            this.btnRefreshTempDB.Text = "Yenile";
            this.btnRefreshTempDB.UseVisualStyleBackColor = true;
            this.btnRefreshTempDB.Click += new System.EventHandler(this.btnRefreshTempDB_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvTempDBSessions);
            this.groupBox2.Location = new System.Drawing.Point(10, 410);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1172, 204);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Oturum Bazlı Kullanım";
            // 
            // dgvTempDBSessions
            // 
            this.dgvTempDBSessions.AllowUserToAddRows = false;
            this.dgvTempDBSessions.AllowUserToDeleteRows = false;
            this.dgvTempDBSessions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTempDBSessions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTempDBSessions.Location = new System.Drawing.Point(3, 16);
            this.dgvTempDBSessions.Name = "dgvTempDBSessions";
            this.dgvTempDBSessions.ReadOnly = true;
            this.dgvTempDBSessions.Size = new System.Drawing.Size(1166, 185);
            this.dgvTempDBSessions.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvTempDBTables);
            this.groupBox1.Location = new System.Drawing.Point(10, 220);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1172, 180);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TempDB Tabloları";
            // 
            // dgvTempDBTables
            // 
            this.dgvTempDBTables.AllowUserToAddRows = false;
            this.dgvTempDBTables.AllowUserToDeleteRows = false;
            this.dgvTempDBTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTempDBTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTempDBTables.Location = new System.Drawing.Point(3, 16);
            this.dgvTempDBTables.Name = "dgvTempDBTables";
            this.dgvTempDBTables.ReadOnly = true;
            this.dgvTempDBTables.Size = new System.Drawing.Size(1166, 161);
            this.dgvTempDBTables.TabIndex = 0;
            // 
            // dgvTempDBFiles
            // 
            this.dgvTempDBFiles.AllowUserToAddRows = false;
            this.dgvTempDBFiles.AllowUserToDeleteRows = false;
            this.dgvTempDBFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTempDBFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTempDBFiles.Location = new System.Drawing.Point(10, 50);
            this.dgvTempDBFiles.Name = "dgvTempDBFiles";
            this.dgvTempDBFiles.ReadOnly = true;
            this.dgvTempDBFiles.Size = new System.Drawing.Size(1172, 160);
            this.dgvTempDBFiles.TabIndex = 0;
            // 
            // tabBufferPool
            // 
            this.tabBufferPool.Controls.Add(this.btnClearBuffer);
            this.tabBufferPool.Controls.Add(this.btnRefreshBuffer);
            this.tabBufferPool.Controls.Add(this.groupBox4);
            this.tabBufferPool.Controls.Add(this.groupBox3);
            this.tabBufferPool.Location = new System.Drawing.Point(4, 22);
            this.tabBufferPool.Name = "tabBufferPool";
            this.tabBufferPool.Size = new System.Drawing.Size(1192, 624);
            this.tabBufferPool.TabIndex = 3;
            this.tabBufferPool.Text = "Buffer Pool";
            this.tabBufferPool.UseVisualStyleBackColor = true;
            // 
            // btnClearBuffer
            // 
            this.btnClearBuffer.Location = new System.Drawing.Point(140, 10);
            this.btnClearBuffer.Name = "btnClearBuffer";
            this.btnClearBuffer.Size = new System.Drawing.Size(120, 30);
            this.btnClearBuffer.TabIndex = 3;
            this.btnClearBuffer.Text = "Buffer Temizle";
            this.btnClearBuffer.UseVisualStyleBackColor = true;
            this.btnClearBuffer.Click += new System.EventHandler(this.btnClearBuffer_Click);
            // 
            // btnRefreshBuffer
            // 
            this.btnRefreshBuffer.Location = new System.Drawing.Point(10, 10);
            this.btnRefreshBuffer.Name = "btnRefreshBuffer";
            this.btnRefreshBuffer.Size = new System.Drawing.Size(120, 30);
            this.btnRefreshBuffer.TabIndex = 2;
            this.btnRefreshBuffer.Text = "Yenile";
            this.btnRefreshBuffer.UseVisualStyleBackColor = true;
            this.btnRefreshBuffer.Click += new System.EventHandler(this.btnRefreshBuffer_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.dgvBufferByTable);
            this.groupBox4.Location = new System.Drawing.Point(10, 270);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1172, 344);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tablo Bazlı Buffer Kullanımı";
            // 
            // dgvBufferByTable
            // 
            this.dgvBufferByTable.AllowUserToAddRows = false;
            this.dgvBufferByTable.AllowUserToDeleteRows = false;
            this.dgvBufferByTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBufferByTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBufferByTable.Location = new System.Drawing.Point(3, 16);
            this.dgvBufferByTable.Name = "dgvBufferByTable";
            this.dgvBufferByTable.ReadOnly = true;
            this.dgvBufferByTable.Size = new System.Drawing.Size(1166, 325);
            this.dgvBufferByTable.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvBufferByDB);
            this.groupBox3.Location = new System.Drawing.Point(10, 50);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1172, 210);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Veritabanı Bazlı Buffer Kullanımı";
            // 
            // dgvBufferByDB
            // 
            this.dgvBufferByDB.AllowUserToAddRows = false;
            this.dgvBufferByDB.AllowUserToDeleteRows = false;
            this.dgvBufferByDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBufferByDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBufferByDB.Location = new System.Drawing.Point(3, 16);
            this.dgvBufferByDB.Name = "dgvBufferByDB";
            this.dgvBufferByDB.ReadOnly = true;
            this.dgvBufferByDB.Size = new System.Drawing.Size(1166, 191);
            this.dgvBufferByDB.TabIndex = 0;
            // 
            // tabDatabaseSizes
            // 
            this.tabDatabaseSizes.Controls.Add(this.btnRefreshDBSizes);
            this.tabDatabaseSizes.Controls.Add(this.dgvDatabaseSizes);
            this.tabDatabaseSizes.Location = new System.Drawing.Point(4, 22);
            this.tabDatabaseSizes.Name = "tabDatabaseSizes";
            this.tabDatabaseSizes.Size = new System.Drawing.Size(1192, 624);
            this.tabDatabaseSizes.TabIndex = 4;
            this.tabDatabaseSizes.Text = "Veritabanı Boyutları";
            this.tabDatabaseSizes.UseVisualStyleBackColor = true;
            // 
            // btnRefreshDBSizes
            // 
            this.btnRefreshDBSizes.Location = new System.Drawing.Point(10, 10);
            this.btnRefreshDBSizes.Name = "btnRefreshDBSizes";
            this.btnRefreshDBSizes.Size = new System.Drawing.Size(120, 30);
            this.btnRefreshDBSizes.TabIndex = 1;
            this.btnRefreshDBSizes.Text = "Yenile";
            this.btnRefreshDBSizes.UseVisualStyleBackColor = true;
            this.btnRefreshDBSizes.Click += new System.EventHandler(this.btnRefreshDBSizes_Click);
            // 
            // dgvDatabaseSizes
            // 
            this.dgvDatabaseSizes.AllowUserToAddRows = false;
            this.dgvDatabaseSizes.AllowUserToDeleteRows = false;
            this.dgvDatabaseSizes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDatabaseSizes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatabaseSizes.Location = new System.Drawing.Point(10, 50);
            this.dgvDatabaseSizes.Name = "dgvDatabaseSizes";
            this.dgvDatabaseSizes.ReadOnly = true;
            this.dgvDatabaseSizes.Size = new System.Drawing.Size(1172, 564);
            this.dgvDatabaseSizes.TabIndex = 0;
            // 
            // tabTableSizes
            // 
            this.tabTableSizes.Controls.Add(this.cmbDatabases);
            this.tabTableSizes.Controls.Add(this.label4);
            this.tabTableSizes.Controls.Add(this.btnRefreshTableSizes);
            this.tabTableSizes.Controls.Add(this.dgvTableSizes);
            this.tabTableSizes.Location = new System.Drawing.Point(4, 22);
            this.tabTableSizes.Name = "tabTableSizes";
            this.tabTableSizes.Size = new System.Drawing.Size(1192, 624);
            this.tabTableSizes.TabIndex = 5;
            this.tabTableSizes.Text = "Tablo Boyutları";
            this.tabTableSizes.UseVisualStyleBackColor = true;
            // 
            // cmbDatabases
            // 
            this.cmbDatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDatabases.FormattingEnabled = true;
            this.cmbDatabases.Location = new System.Drawing.Point(90, 15);
            this.cmbDatabases.Name = "cmbDatabases";
            this.cmbDatabases.Size = new System.Drawing.Size(250, 21);
            this.cmbDatabases.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Veritabanı:";
            // 
            // btnRefreshTableSizes
            // 
            this.btnRefreshTableSizes.Location = new System.Drawing.Point(350, 10);
            this.btnRefreshTableSizes.Name = "btnRefreshTableSizes";
            this.btnRefreshTableSizes.Size = new System.Drawing.Size(120, 30);
            this.btnRefreshTableSizes.TabIndex = 1;
            this.btnRefreshTableSizes.Text = "Yenile";
            this.btnRefreshTableSizes.UseVisualStyleBackColor = true;
            this.btnRefreshTableSizes.Click += new System.EventHandler(this.btnRefreshTableSizes_Click);
            // 
            // dgvTableSizes
            // 
            this.dgvTableSizes.AllowUserToAddRows = false;
            this.dgvTableSizes.AllowUserToDeleteRows = false;
            this.dgvTableSizes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTableSizes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableSizes.Location = new System.Drawing.Point(10, 50);
            this.dgvTableSizes.Name = "dgvTableSizes";
            this.dgvTableSizes.ReadOnly = true;
            this.dgvTableSizes.Size = new System.Drawing.Size(1172, 564);
            this.dgvTableSizes.TabIndex = 0;
            // 
            // tabIndexMaintenance
            // 
            this.tabIndexMaintenance.Controls.Add(this.btnExecuteAllIndexMaintenance);
            this.tabIndexMaintenance.Controls.Add(this.btnExecuteIndexMaintenance);
            this.tabIndexMaintenance.Controls.Add(this.cmbDatabasesForIndex);
            this.tabIndexMaintenance.Controls.Add(this.label6);
            this.tabIndexMaintenance.Controls.Add(this.numFragmentationThreshold);
            this.tabIndexMaintenance.Controls.Add(this.label5);
            this.tabIndexMaintenance.Controls.Add(this.btnAnalyzeIndexes);
            this.tabIndexMaintenance.Controls.Add(this.dgvIndexes);
            this.tabIndexMaintenance.Location = new System.Drawing.Point(4, 22);
            this.tabIndexMaintenance.Name = "tabIndexMaintenance";
            this.tabIndexMaintenance.Size = new System.Drawing.Size(1192, 624);
            this.tabIndexMaintenance.TabIndex = 6;
            this.tabIndexMaintenance.Text = "Index Bakımı";
            this.tabIndexMaintenance.UseVisualStyleBackColor = true;
            // 
            // btnExecuteAllIndexMaintenance
            // 
            this.btnExecuteAllIndexMaintenance.Location = new System.Drawing.Point(910, 10);
            this.btnExecuteAllIndexMaintenance.Name = "btnExecuteAllIndexMaintenance";
            this.btnExecuteAllIndexMaintenance.Size = new System.Drawing.Size(150, 30);
            this.btnExecuteAllIndexMaintenance.TabIndex = 7;
            this.btnExecuteAllIndexMaintenance.Text = "Tümüne Bakım Yap";
            this.btnExecuteAllIndexMaintenance.UseVisualStyleBackColor = true;
            this.btnExecuteAllIndexMaintenance.Click += new System.EventHandler(this.btnExecuteAllIndexMaintenance_Click);
            // 
            // btnExecuteIndexMaintenance
            // 
            this.btnExecuteIndexMaintenance.Location = new System.Drawing.Point(720, 10);
            this.btnExecuteIndexMaintenance.Name = "btnExecuteIndexMaintenance";
            this.btnExecuteIndexMaintenance.Size = new System.Drawing.Size(180, 30);
            this.btnExecuteIndexMaintenance.TabIndex = 4;
            this.btnExecuteIndexMaintenance.Text = "Seçili Satırın Bakımını Yap";
            this.btnExecuteIndexMaintenance.UseVisualStyleBackColor = true;
            this.btnExecuteIndexMaintenance.Click += new System.EventHandler(this.btnExecuteIndexMaintenance_Click);
            // 
            // cmbDatabasesForIndex
            // 
            this.cmbDatabasesForIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDatabasesForIndex.FormattingEnabled = true;
            this.cmbDatabasesForIndex.Location = new System.Drawing.Point(330, 15);
            this.cmbDatabasesForIndex.Name = "cmbDatabasesForIndex";
            this.cmbDatabasesForIndex.Size = new System.Drawing.Size(250, 21);
            this.cmbDatabasesForIndex.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(250, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Veritabanı:";
            // 
            // numFragmentationThreshold
            // 
            this.numFragmentationThreshold.Location = new System.Drawing.Point(160, 15);
            this.numFragmentationThreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFragmentationThreshold.Name = "numFragmentationThreshold";
            this.numFragmentationThreshold.Size = new System.Drawing.Size(80, 20);
            this.numFragmentationThreshold.TabIndex = 3;
            this.numFragmentationThreshold.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Parçalanma Eşiği (Min %):";
            // 
            // btnAnalyzeIndexes
            // 
            this.btnAnalyzeIndexes.Location = new System.Drawing.Point(590, 10);
            this.btnAnalyzeIndexes.Name = "btnAnalyzeIndexes";
            this.btnAnalyzeIndexes.Size = new System.Drawing.Size(120, 30);
            this.btnAnalyzeIndexes.TabIndex = 1;
            this.btnAnalyzeIndexes.Text = "Analiz Et";
            this.btnAnalyzeIndexes.UseVisualStyleBackColor = true;
            this.btnAnalyzeIndexes.Click += new System.EventHandler(this.btnAnalyzeIndexes_Click);
            // 
            // dgvIndexes
            // 
            this.dgvIndexes.AllowUserToAddRows = false;
            this.dgvIndexes.AllowUserToDeleteRows = false;
            this.dgvIndexes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIndexes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIndexes.Location = new System.Drawing.Point(10, 50);
            this.dgvIndexes.MultiSelect = false;
            this.dgvIndexes.Name = "dgvIndexes";
            this.dgvIndexes.ReadOnly = true;
            this.dgvIndexes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIndexes.Size = new System.Drawing.Size(1172, 564);
            this.dgvIndexes.TabIndex = 0;
            // 
            // tabConnectedUsers
            // 
            this.tabConnectedUsers.Controls.Add(this.btnRefreshUsers);
            this.tabConnectedUsers.Controls.Add(this.dgvConnectedUsers);
            this.tabConnectedUsers.Location = new System.Drawing.Point(4, 22);
            this.tabConnectedUsers.Name = "tabConnectedUsers";
            this.tabConnectedUsers.Size = new System.Drawing.Size(1192, 624);
            this.tabConnectedUsers.TabIndex = 7;
            this.tabConnectedUsers.Text = "Bağlı Kullanıcılar";
            this.tabConnectedUsers.UseVisualStyleBackColor = true;
            // 
            // btnRefreshUsers
            // 
            this.btnRefreshUsers.Location = new System.Drawing.Point(10, 10);
            this.btnRefreshUsers.Name = "btnRefreshUsers";
            this.btnRefreshUsers.Size = new System.Drawing.Size(120, 30);
            this.btnRefreshUsers.TabIndex = 1;
            this.btnRefreshUsers.Text = "Yenile";
            this.btnRefreshUsers.UseVisualStyleBackColor = true;
            this.btnRefreshUsers.Click += new System.EventHandler(this.btnRefreshUsers_Click);
            // 
            // dgvConnectedUsers
            // 
            this.dgvConnectedUsers.AllowUserToAddRows = false;
            this.dgvConnectedUsers.AllowUserToDeleteRows = false;
            this.dgvConnectedUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvConnectedUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConnectedUsers.Location = new System.Drawing.Point(10, 50);
            this.dgvConnectedUsers.Name = "dgvConnectedUsers";
            this.dgvConnectedUsers.ReadOnly = true;
            this.dgvConnectedUsers.Size = new System.Drawing.Size(1172, 564);
            this.dgvConnectedUsers.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 650);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1200, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(108, 17);
            this.lblStatus.Text = "Bağlantı Bekleniyor";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 672);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL EYES - SQL Server Bakım ve İzleme";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabConnection.ResumeLayout(false);
            this.tabConnection.PerformLayout();
            this.tabActiveConnections.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveConnections)).EndInit();
            this.tabTempDB.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTempDBSessions)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTempDBTables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTempDBFiles)).EndInit();
            this.tabBufferPool.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBufferByTable)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBufferByDB)).EndInit();
            this.tabDatabaseSizes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatabaseSizes)).EndInit();
            this.tabTableSizes.ResumeLayout(false);
            this.tabTableSizes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableSizes)).EndInit();
            this.tabIndexMaintenance.ResumeLayout(false);
            this.tabIndexMaintenance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFragmentationThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIndexes)).EndInit();
            this.tabConnectedUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConnectedUsers)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabConnection;
        private System.Windows.Forms.TabPage tabActiveConnections;
        private System.Windows.Forms.TabPage tabTempDB;
        private System.Windows.Forms.TabPage tabBufferPool;
        private System.Windows.Forms.TabPage tabDatabaseSizes;
        private System.Windows.Forms.TabPage tabTableSizes;
        private System.Windows.Forms.TabPage tabIndexMaintenance;
        private System.Windows.Forms.TabPage tabConnectedUsers;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.CheckBox chkIntegratedSecurity;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvActiveConnections;
        private System.Windows.Forms.Button btnRefreshConnections;
        private System.Windows.Forms.DataGridView dgvTempDBFiles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvTempDBTables;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvTempDBSessions;
        private System.Windows.Forms.Button btnRefreshTempDB;
        private System.Windows.Forms.Button btnShrinkTempDB;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvBufferByDB;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvBufferByTable;
        private System.Windows.Forms.Button btnRefreshBuffer;
        private System.Windows.Forms.Button btnClearBuffer;
        private System.Windows.Forms.DataGridView dgvDatabaseSizes;
        private System.Windows.Forms.Button btnRefreshDBSizes;
        private System.Windows.Forms.DataGridView dgvTableSizes;
        private System.Windows.Forms.Button btnRefreshTableSizes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDatabases;
        private System.Windows.Forms.DataGridView dgvIndexes;
        private System.Windows.Forms.Button btnAnalyzeIndexes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numFragmentationThreshold;
        private System.Windows.Forms.Button btnExecuteIndexMaintenance;
        private System.Windows.Forms.Button btnExecuteAllIndexMaintenance;
        private System.Windows.Forms.ComboBox cmbDatabasesForIndex;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvConnectedUsers;
        private System.Windows.Forms.Button btnRefreshUsers;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}


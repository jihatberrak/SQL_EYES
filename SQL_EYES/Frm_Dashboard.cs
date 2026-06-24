using System;
using System.Drawing;
using System.Windows.Forms;

namespace SQL_EYES
{
    public partial class Frm_Dashboard : Form
    {
        private string connectionString;

        public Frm_Dashboard()
        {
            InitializeComponent();
        }

        private void Frm_Dashboard_Load(object sender, EventArgs e)
        {
            // Dashboard yüklendiðinde baðlantý kontrolü
            if (string.IsNullOrEmpty(SqlHelper.ConnectionString))
            {
                ShowConnectionDialog();
            }
            else
            {
                LoadDashboardData();
            }
        }

        private void ShowConnectionDialog()
        {
            using (var connForm = new Frm_Connection())
            {
                if (connForm.ShowDialog() == DialogResult.OK)
                {
                    connectionString = SqlHelper.ConnectionString;
                    lblConnectionStatus.Text = $"Baðlý: {GetServerName()}";
                    lblConnectionStatus.ForeColor = Color.Green;
                    LoadDashboardData();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private string GetServerName()
        {
            try
            {
                var builder = new System.Data.SqlClient.SqlConnectionStringBuilder(SqlHelper.ConnectionString);
                return builder.DataSource;
            }
            catch
            {
                return "Bilinmeyen Sunucu";
            }
        }

        private void LoadDashboardData()
        {
            try
            {
                LoadServerInfo();
                LoadQuickStats();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dashboard yüklenirken hata: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadServerInfo()
        {
            try
            {
                var dt = SqlHelper.ExecuteQuery(@"
                    SELECT 
                        SERVERPROPERTY('ServerName') AS ServerName,
                        SERVERPROPERTY('ProductVersion') AS Version,
                        SERVERPROPERTY('Edition') AS Edition,
                        SERVERPROPERTY('ProductLevel') AS ProductLevel
                ");

                if (dt != null && dt.Rows.Count > 0)
                {
                    lblServerName.Text = dt.Rows[0]["ServerName"].ToString();
                    lblServerVersion.Text = $"{dt.Rows[0]["Edition"]} - {dt.Rows[0]["Version"]}";
                }
            }
            catch { }
        }

        private void LoadQuickStats()
        {
            try
            {
                // Veritabaný sayýsý
                var dtDB = SqlHelper.ExecuteQuery("SELECT COUNT(*) as DBCount FROM sys.databases WHERE database_id > 4");
                if (dtDB != null && dtDB.Rows.Count > 0)
                {
                    lblDatabaseCount.Text = dtDB.Rows[0]["DBCount"].ToString();
                }

                // Aktif baðlantý sayýsý
                var dtConn = SqlHelper.ExecuteQuery("SELECT COUNT(*) as ConnCount FROM sys.dm_exec_sessions WHERE is_user_process = 1");
                if (dtConn != null && dtConn.Rows.Count > 0)
                {
                    lblActiveConnections.Text = dtConn.Rows[0]["ConnCount"].ToString();
                }

                // TempDB boyutu
                var dtTemp = SqlHelper.ExecuteQuery(@"
                    SELECT SUM(size * 8.0 / 1024) as TempDBSize 
                    FROM tempdb.sys.database_files
                ");
                if (dtTemp != null && dtTemp.Rows.Count > 0)
                {
                    lblTempDBSize.Text = $"{Convert.ToInt32(dtTemp.Rows[0]["TempDBSize"])} MB";
                }
            }
            catch { }
        }

        // Kategori buton click event'leri
        private void btnPerformance_Click(object sender, EventArgs e)
        {
            var perfForm = new Frm_Performance(this);
            perfForm.Show();
            this.Hide();
        }

        private void btnSecurity_Click(object sender, EventArgs e)
        {
            var secForm = new Frm_Security(this);
            secForm.Show();
            this.Hide();
        }

        private void btnJobs_Click(object sender, EventArgs e)
        {
            var jobsForm = new Frm_Jobs(this);
            jobsForm.Show();
            this.Hide();
        }

        private void btnHA_Click(object sender, EventArgs e)
        {
            var haForm = new Frm_HighAvailability(this);
            haForm.Show();
            this.Hide();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            var reportsForm = new Frm_Reports(this);
            reportsForm.Show();
            this.Hide();
        }

        private void btnTroubleshooting_Click(object sender, EventArgs e)
        {
            var troubleForm = new Frm_Troubleshooting(this);
            troubleForm.Show();
            this.Hide();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            var backupForm = new Frm_Backup(this);
            backupForm.Show();
            this.Hide();
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            // Mevcut bakým araçlarýný aç
            var mainForm = new Frm_Main(this);
            mainForm.Show();
            this.Hide();
        }

        private void btnCapacity_Click(object sender, EventArgs e)
        {
            var capacityForm = new Frm_Capacity(this);
            capacityForm.Show();
            this.Hide();
        }

        private void btnAdvanced_Click(object sender, EventArgs e)
        {
            // Geliþmiþ araçlar - Mevcut Frm_Main'i aç
            var mainForm = new Frm_Main(this);
            mainForm.Show();
            this.Hide();
        }

        private void btnChangeConnection_Click(object sender, EventArgs e)
        {
            ShowConnectionDialog();
        }

        private void btnRefreshDashboard_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
            MessageBox.Show("Dashboard güncellendi!", "Bilgi", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

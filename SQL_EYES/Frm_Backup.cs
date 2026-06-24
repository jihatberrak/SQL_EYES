using System;
using System.Data;
using System.Windows.Forms;

namespace SQL_EYES
{
    public partial class Frm_Backup : Form
    {
        private Frm_Dashboard dashboardForm;

        public Frm_Backup()
        {
            InitializeComponent();
        }

        public Frm_Backup(Frm_Dashboard dashboard) : this()
        {
            dashboardForm = dashboard;
        }

        private void Frm_Backup_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SqlHelper.ConnectionString))
            {
                MessageBox.Show("Lütfen önce SQL Server'a baðlanýn!", "Uyarý", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            lblStatus.Text = $"Baðlý: {GetServerName()}";
        }

        private string GetServerName()
        {
            try
            {
                var builder = new System.Data.SqlClient.SqlConnectionStringBuilder(SqlHelper.ConnectionString);
                return builder.DataSource;
            }
            catch { return "Bilinmeyen"; }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (dashboardForm != null && !dashboardForm.IsDisposed)
            {
                dashboardForm.Show();
                dashboardForm.BringToFront();
            }
        }

        private void btnLastBackups_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Son yedekleme bilgileri yükleniyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT 
                    d.name AS [Database Name],
                    d.recovery_model_desc AS [Recovery Model],
                    d.state_desc AS [State],
                    MAX(CASE WHEN b.type = 'D' THEN b.backup_finish_date END) AS [Last Full Backup],
                    MAX(CASE WHEN b.type = 'I' THEN b.backup_finish_date END) AS [Last Differential Backup],
                    MAX(CASE WHEN b.type = 'L' THEN b.backup_finish_date END) AS [Last Log Backup],
                    DATEDIFF(DAY, MAX(CASE WHEN b.type = 'D' THEN b.backup_finish_date END), GETDATE()) AS [Days Since Last Full]
                FROM sys.databases d
                LEFT JOIN msdb.dbo.backupset b ON d.name = b.database_name
                WHERE d.database_id > 4
                GROUP BY d.name, d.recovery_model_desc, d.state_desc
                ORDER BY [Days Since Last Full] DESC, d.name";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - {dt.Rows.Count} veritabaný";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnBackupHistory_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Yedekleme geçmiþi yükleniyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT TOP 100
                    b.database_name AS [Database Name],
                    CASE b.type
                        WHEN 'D' THEN 'Full'
                        WHEN 'I' THEN 'Differential'
                        WHEN 'L' THEN 'Log'
                        ELSE 'Other'
                    END AS [Backup Type],
                    b.backup_start_date AS [Start Time],
                    b.backup_finish_date AS [Finish Time],
                    DATEDIFF(SECOND, b.backup_start_date, b.backup_finish_date) AS [Duration (s)],
                    CAST(b.backup_size / 1024.0 / 1024.0 AS DECIMAL(10,2)) AS [Backup Size (MB)],
                    CAST(b.compressed_backup_size / 1024.0 / 1024.0 AS DECIMAL(10,2)) AS [Compressed Size (MB)],
                    b.user_name AS [User],
                    bmf.physical_device_name AS [Backup Location]
                FROM msdb.dbo.backupset b
                LEFT JOIN msdb.dbo.backupmediafamily bmf ON b.media_set_id = bmf.media_set_id
                ORDER BY b.backup_finish_date DESC";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - Son {dt.Rows.Count} yedekleme";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnMissingBackups_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Yedeklenmeyen veritabanlarý kontrol ediliyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT 
                    d.name AS [Database Name],
                    d.recovery_model_desc AS [Recovery Model],
                    d.state_desc AS [State],
                    CAST((SELECT SUM(size * 8.0 / 1024.0) FROM sys.master_files WHERE database_id = d.database_id AND type = 0) AS DECIMAL(10,2)) AS [Data Size (MB)],
                    CAST((SELECT SUM(size * 8.0 / 1024.0) FROM sys.master_files WHERE database_id = d.database_id AND type = 1) AS DECIMAL(10,2)) AS [Log Size (MB)],
                    d.create_date AS [Created],
                    'NEVER' AS [Last Backup Status]
                FROM sys.databases d
                WHERE d.database_id > 4
                    AND d.name NOT IN (
                        SELECT DISTINCT database_name 
                        FROM msdb.dbo.backupset 
                        WHERE type = 'D' 
                        AND backup_finish_date > DATEADD(DAY, -30, GETDATE())
                    )
                ORDER BY d.name";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - {dt.Rows.Count} yedeklenmeyen veritabaný";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnBackupSize_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Yedekleme boyutlarý analiz ediliyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT 
                    b.database_name AS [Database Name],
                    COUNT(*) AS [Backup Count],
                    CAST(SUM(b.backup_size) / 1024.0 / 1024.0 / 1024.0 AS DECIMAL(10,2)) AS [Total Size (GB)],
                    CAST(AVG(b.backup_size) / 1024.0 / 1024.0 AS DECIMAL(10,2)) AS [Avg Size (MB)],
                    CAST(MAX(b.backup_size) / 1024.0 / 1024.0 AS DECIMAL(10,2)) AS [Max Size (MB)],
                    CASE 
                        WHEN SUM(b.backup_size) > 0 AND SUM(b.compressed_backup_size) > 0 
                        THEN CAST((1 - CAST(SUM(b.compressed_backup_size) AS FLOAT) / SUM(b.backup_size)) * 100 AS DECIMAL(5,2))
                        ELSE 0 
                    END AS [Compression Ratio %],
                    MAX(b.backup_finish_date) AS [Last Backup]
                FROM msdb.dbo.backupset b
                WHERE b.backup_finish_date > DATEADD(DAY, -30, GETDATE())
                GROUP BY b.database_name
                ORDER BY [Total Size (GB)] DESC";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - Son 30 gün yedekleme istatistikleri";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnRestoreHistory_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Restore geçmiþi yükleniyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT TOP 50
                    rh.destination_database_name AS [Database Name],
                    rh.restore_date AS [Restore Date],
                    rh.user_name AS [User],
                    CASE rh.restore_type
                        WHEN 'D' THEN 'Database'
                        WHEN 'F' THEN 'File'
                        WHEN 'G' THEN 'Filegroup'
                        WHEN 'I' THEN 'Differential'
                        WHEN 'L' THEN 'Log'
                        ELSE 'Other'
                    END AS [Restore Type],
                    bmf.physical_device_name AS [Restore From]
                FROM msdb.dbo.restorehistory rh
                LEFT JOIN msdb.dbo.backupset bs ON rh.backup_set_id = bs.backup_set_id
                LEFT JOIN msdb.dbo.backupmediafamily bmf ON bs.media_set_id = bmf.media_set_id
                ORDER BY rh.restore_date DESC";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - {dt.Rows.Count} restore iþlemi";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally { Cursor = Cursors.Default; }
        }

        private void TurkcelestirKolonlari(DataTable dt)
        {
            if (dt == null) return;

            var kolonCeviri = new System.Collections.Generic.Dictionary<string, string>
            {
                { "Database Name", "Veritabaný Adý" },
                { "Recovery Model", "Kurtarma Modeli" },
                { "State", "Durum" },
                { "Last Full Backup", "Son Tam Yedekleme" },
                { "Last Differential Backup", "Son Diferansiyel Yedekleme" },
                { "Last Log Backup", "Son Log Yedekleme" },
                { "Days Since Last Full", "Son Tam Yedeklemeden Beri (Gün)" },
                { "Backup Type", "Yedekleme Tipi" },
                { "Start Time", "Baþlangýç" },
                { "Finish Time", "Bitiþ" },
                { "Duration (s)", "Süre (s)" },
                { "Backup Size (MB)", "Yedek Boyutu (MB)" },
                { "Compressed Size (MB)", "Sýkýþtýrýlmýþ Boyut (MB)" },
                { "User", "Kullanýcý" },
                { "Backup Location", "Yedek Konumu" },
                { "Data Size (MB)", "Veri Boyutu (MB)" },
                { "Log Size (MB)", "Log Boyutu (MB)" },
                { "Created", "Oluþturma Tarihi" },
                { "Last Backup Status", "Son Yedekleme Durumu" },
                { "Backup Count", "Yedekleme Sayýsý" },
                { "Total Size (GB)", "Toplam Boyut (GB)" },
                { "Avg Size (MB)", "Ort. Boyut (MB)" },
                { "Max Size (MB)", "Maks. Boyut (MB)" },
                { "Compression Ratio %", "Sýkýþtýrma Oraný %" },
                { "Last Backup", "Son Yedekleme" },
                { "Restore Date", "Restore Tarihi" },
                { "Restore Type", "Restore Tipi" },
                { "Restore From", "Restore Kaynaðý" }
            };

            foreach (DataColumn column in dt.Columns)
            {
                if (kolonCeviri.ContainsKey(column.ColumnName))
                {
                    column.ColumnName = kolonCeviri[column.ColumnName];
                }
            }
        }
    }
}

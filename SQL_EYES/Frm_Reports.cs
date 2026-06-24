using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SQL_EYES
{
    public partial class Frm_Reports : Form
    {
        private Frm_Dashboard dashboardForm;
        private DataTable currentData;

        public Frm_Reports()
        {
            InitializeComponent();
        }

        public Frm_Reports(Frm_Dashboard dashboard) : this()
        {
            dashboardForm = dashboard;
        }

        private void Frm_Reports_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SqlHelper.ConnectionString))
            {
                MessageBox.Show("Lütfen önce SQL Server'a baðlanýn!", "Uyarý", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            lblStatus.Text = $"Baðlý: {GetServerName()}";
            LoadDatabases();
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

        private void LoadDatabases()
        {
            try
            {
                DataTable dt = SqlHelper.ExecuteQuery("SELECT name FROM sys.databases WHERE database_id > 4 ORDER BY name");
                if (dt != null)
                {
                    cmbDatabase.Items.Clear();
                    cmbDatabase.Items.Add("-- Tüm Veritabanlarý --");
                    foreach (DataRow row in dt.Rows)
                    {
                        cmbDatabase.Items.Add(row["name"].ToString());
                    }
                    if (cmbDatabase.Items.Count > 0)
                        cmbDatabase.SelectedIndex = 0;
                }
            }
            catch { }
        }

        private void btnServerOverview_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Sunucu özet raporu hazýrlanýyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT 
                    'Server Information' AS [Category],
                    CAST(SERVERPROPERTY('ServerName') AS VARCHAR(100)) AS [Property],
                    CAST(SERVERPROPERTY('ProductVersion') AS VARCHAR(100)) AS [Value]
                UNION ALL
                SELECT 'Server Information', 'Edition', CAST(SERVERPROPERTY('Edition') AS VARCHAR(100))
                UNION ALL
                SELECT 'Server Information', 'Product Level', CAST(SERVERPROPERTY('ProductLevel') AS VARCHAR(100))
                UNION ALL
                SELECT 'Database Summary', 'Total Databases', CAST(COUNT(*) AS VARCHAR(100))
                FROM sys.databases
                UNION ALL
                SELECT 'Database Summary', 'User Databases', CAST(COUNT(*) AS VARCHAR(100))
                FROM sys.databases WHERE database_id > 4
                UNION ALL
                SELECT 'Connection Summary', 'Active Connections', CAST(COUNT(*) AS VARCHAR(100))
                FROM sys.dm_exec_sessions WHERE is_user_process = 1
                ORDER BY [Category], [Property]";

                currentData = SqlHelper.ExecuteQuery(query);
                if (currentData != null)
                {
                    TurkcelestirKolonlari(currentData);
                    dgvResults.DataSource = currentData;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Sunucu özet raporu hazýr - {currentData.Rows.Count} kayýt";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnDatabaseReport_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Veritabaný raporu hazýrlanýyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT 
                    d.name AS [Database Name],
                    d.state_desc AS [State],
                    d.recovery_model_desc AS [Recovery Model],
                    d.compatibility_level AS [Compatibility Level],
                    CAST(SUM(CASE WHEN mf.type = 0 THEN mf.size * 8.0 / 1024 ELSE 0 END) AS DECIMAL(10,2)) AS [Data Size (MB)],
                    CAST(SUM(CASE WHEN mf.type = 1 THEN mf.size * 8.0 / 1024 ELSE 0 END) AS DECIMAL(10,2)) AS [Log Size (MB)],
                    d.create_date AS [Created],
                    SUSER_SNAME(d.owner_sid) AS [Owner]
                FROM sys.databases d
                LEFT JOIN sys.master_files mf ON d.database_id = mf.database_id
                WHERE d.database_id > 4
                GROUP BY d.name, d.state_desc, d.recovery_model_desc, d.compatibility_level, d.create_date, d.owner_sid
                ORDER BY d.name";

                currentData = SqlHelper.ExecuteQuery(query);
                if (currentData != null)
                {
                    TurkcelestirKolonlari(currentData);
                    dgvResults.DataSource = currentData;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Veritabaný raporu hazýr - {currentData.Rows.Count} veritabaný";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnBackupReport_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Yedekleme raporu hazýrlanýyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT 
                    d.name AS [Database Name],
                    MAX(CASE WHEN b.type = 'D' THEN b.backup_finish_date END) AS [Last Full Backup],
                    MAX(CASE WHEN b.type = 'I' THEN b.backup_finish_date END) AS [Last Diff Backup],
                    MAX(CASE WHEN b.type = 'L' THEN b.backup_finish_date END) AS [Last Log Backup],
                    DATEDIFF(DAY, MAX(CASE WHEN b.type = 'D' THEN b.backup_finish_date END), GETDATE()) AS [Days Since Full],
                    d.recovery_model_desc AS [Recovery Model]
                FROM sys.databases d
                LEFT JOIN msdb.dbo.backupset b ON d.name = b.database_name
                WHERE d.database_id > 4
                GROUP BY d.name, d.recovery_model_desc
                ORDER BY [Days Since Full] DESC, d.name";

                currentData = SqlHelper.ExecuteQuery(query);
                if (currentData != null)
                {
                    TurkcelestirKolonlari(currentData);
                    dgvResults.DataSource = currentData;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Yedekleme raporu hazýr - {currentData.Rows.Count} veritabaný";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnPerformanceReport_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Performans raporu hazýrlanýyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT TOP 25
                    DB_NAME(qt.dbid) AS [Database],
                    SUBSTRING(qt.TEXT, 1, 100) AS [Query Preview],
                    qs.execution_count AS [Execution Count],
                    CAST(qs.total_worker_time / 1000000.0 AS DECIMAL(10,2)) AS [Total CPU (s)],
                    CAST(qs.total_elapsed_time / 1000000.0 AS DECIMAL(10,2)) AS [Total Duration (s)],
                    CAST(qs.total_logical_reads AS BIGINT) AS [Total Logical Reads],
                    qs.last_execution_time AS [Last Executed]
                FROM sys.dm_exec_query_stats qs
                CROSS APPLY sys.dm_exec_sql_text(qs.sql_handle) qt
                ORDER BY qs.total_worker_time DESC";

                currentData = SqlHelper.ExecuteQuery(query);
                if (currentData != null)
                {
                    TurkcelestirKolonlari(currentData);
                    dgvResults.DataSource = currentData;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Performans raporu hazýr - {currentData.Rows.Count} sorgu";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            if (currentData == null || currentData.Rows.Count == 0)
            {
                MessageBox.Show("Önce bir rapor oluþturun!", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "CSV Dosyasý|*.csv",
                    FileName = $"SQL_EYES_Report_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder sb = new StringBuilder();
                    
                    // Header
                    for (int i = 0; i < currentData.Columns.Count; i++)
                    {
                        sb.Append(currentData.Columns[i].ColumnName);
                        if (i < currentData.Columns.Count - 1)
                            sb.Append(",");
                    }
                    sb.AppendLine();

                    // Rows
                    foreach (DataRow row in currentData.Rows)
                    {
                        for (int i = 0; i < currentData.Columns.Count; i++)
                        {
                            string value = row[i].ToString().Replace(",", ";").Replace("\r", "").Replace("\n", " ");
                            sb.Append($"\"{value}\"");
                            if (i < currentData.Columns.Count - 1)
                                sb.Append(",");
                        }
                        sb.AppendLine();
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show($"Rapor baþarýyla kaydedildi!\n\n{sfd.FileName}", "Baþarýlý", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    lblStatus.Text = "CSV export tamamlandý";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export hatasý: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportHTML_Click(object sender, EventArgs e)
        {
            if (currentData == null || currentData.Rows.Count == 0)
            {
                MessageBox.Show("Önce bir rapor oluþturun!", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "HTML Dosyasý|*.html",
                    FileName = $"SQL_EYES_Report_{DateTime.Now:yyyyMMdd_HHmmss}.html"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("<!DOCTYPE html>");
                    sb.AppendLine("<html><head><meta charset='UTF-8'>");
                    sb.AppendLine("<title>SQL EYES Raporu</title>");
                    sb.AppendLine("<style>");
                    sb.AppendLine("body { font-family: 'Segoe UI', Arial, sans-serif; margin: 20px; }");
                    sb.AppendLine("h1 { color: #2980b9; }");
                    sb.AppendLine("table { border-collapse: collapse; width: 100%; margin-top: 20px; }");
                    sb.AppendLine("th { background-color: #3498db; color: white; padding: 12px; text-align: left; }");
                    sb.AppendLine("td { border: 1px solid #ddd; padding: 10px; }");
                    sb.AppendLine("tr:nth-child(even) { background-color: #f2f2f2; }");
                    sb.AppendLine("tr:hover { background-color: #e8f4f8; }");
                    sb.AppendLine(".footer { margin-top: 20px; color: #7f8c8d; font-size: 12px; }");
                    sb.AppendLine("</style></head><body>");
                    sb.AppendLine($"<h1>SQL EYES Raporu</h1>");
                    sb.AppendLine($"<p><strong>Sunucu:</strong> {GetServerName()}</p>");
                    sb.AppendLine($"<p><strong>Rapor Tarihi:</strong> {DateTime.Now:dd.MM.yyyy HH:mm:ss}</p>");
                    sb.AppendLine("<table><thead><tr>");

                    // Header
                    foreach (DataColumn col in currentData.Columns)
                    {
                        sb.AppendLine($"<th>{col.ColumnName}</th>");
                    }
                    sb.AppendLine("</tr></thead><tbody>");

                    // Rows
                    foreach (DataRow row in currentData.Rows)
                    {
                        sb.AppendLine("<tr>");
                        foreach (var item in row.ItemArray)
                        {
                            string encoded = item.ToString().Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;");
                            sb.AppendLine($"<td>{encoded}</td>");
                        }
                        sb.AppendLine("</tr>");
                    }

                    sb.AppendLine("</tbody></table>");
                    sb.AppendLine($"<div class='footer'>SQL EYES - SQL Server Yönetim Aracý | {currentData.Rows.Count} kayýt</div>");
                    sb.AppendLine("</body></html>");

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show($"Rapor baþarýyla kaydedildi!\n\n{sfd.FileName}", "Baþarýlý", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    lblStatus.Text = "HTML export tamamlandý";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export hatasý: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TurkcelestirKolonlari(DataTable dt)
        {
            if (dt == null) return;

            var kolonCeviri = new System.Collections.Generic.Dictionary<string, string>
            {
                { "Category", "Kategori" },
                { "Property", "Özellik" },
                { "Value", "Deðer" },
                { "Database Name", "Veritabaný Adý" },
                { "State", "Durum" },
                { "Recovery Model", "Kurtarma Modeli" },
                { "Compatibility Level", "Uyumluluk Seviyesi" },
                { "Data Size (MB)", "Veri Boyutu (MB)" },
                { "Log Size (MB)", "Log Boyutu (MB)" },
                { "Created", "Oluþturma Tarihi" },
                { "Owner", "Sahibi" },
                { "Last Full Backup", "Son Tam Yedek" },
                { "Last Diff Backup", "Son Fark Yedek" },
                { "Last Log Backup", "Son Log Yedek" },
                { "Days Since Full", "Son Tam Yedekten Beri (Gün)" },
                { "Database", "Veritabaný" },
                { "Query Preview", "Sorgu Önizleme" },
                { "Execution Count", "Çalýþtýrma Sayýsý" },
                { "Total CPU (s)", "Toplam CPU (s)" },
                { "Total Duration (s)", "Toplam Süre (s)" },
                { "Total Logical Reads", "Toplam Mantýksal Okuma" },
                { "Last Executed", "Son Çalýþtýrma" }
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

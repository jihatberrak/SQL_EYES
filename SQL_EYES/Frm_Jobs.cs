using System;
using System.Data;
using System.Windows.Forms;

namespace SQL_EYES
{
    public partial class Frm_Jobs : Form
    {
        private Frm_Dashboard dashboardForm;

        public Frm_Jobs()
        {
            InitializeComponent();
        }

        public Frm_Jobs(Frm_Dashboard dashboard) : this()
        {
            dashboardForm = dashboard;
        }

        private void Frm_Jobs_Load(object sender, EventArgs e)
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

        private void btnAllJobs_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Tüm job'lar yükleniyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT 
                    j.name AS [Job Name],
                    CASE j.enabled 
                        WHEN 1 THEN 'Enabled' 
                        ELSE 'Disabled' 
                    END AS [Status],
                    SUSER_SNAME(j.owner_sid) AS [Owner],
                    j.date_created AS [Created],
                    j.date_modified AS [Modified],
                    ISNULL(js.next_run_date, 0) AS [Next Run Date],
                    ISNULL(js.next_run_time, 0) AS [Next Run Time],
                    c.name AS [Category]
                FROM msdb.dbo.sysjobs j
                LEFT JOIN msdb.dbo.sysjobschedules js ON j.job_id = js.job_id
                LEFT JOIN msdb.dbo.syscategories c ON j.category_id = c.category_id
                ORDER BY j.name";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - {dt.Rows.Count} job";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnFailedJobs_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Baþarýsýz job'lar yükleniyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT 
                    j.name AS [Job Name],
                    jh.step_name AS [Step Name],
                    jh.run_date AS [Run Date],
                    jh.run_time AS [Run Time],
                    jh.run_duration AS [Duration],
                    jh.message AS [Error Message]
                FROM msdb.dbo.sysjobhistory jh
                INNER JOIN msdb.dbo.sysjobs j ON jh.job_id = j.job_id
                WHERE jh.run_status = 0
                    AND jh.step_id != 0
                ORDER BY jh.run_date DESC, jh.run_time DESC";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - {dt.Rows.Count} baþarýsýz job";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnRunningJobs_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Çalýþan job'lar yükleniyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT 
                    j.name AS [Job Name],
                    ja.start_execution_date AS [Start Time],
                    DATEDIFF(SECOND, ja.start_execution_date, GETDATE()) AS [Running Duration (s)],
                    CASE ja.last_executed_step_id
                        WHEN 0 THEN 'Not started'
                        ELSE CAST(ja.last_executed_step_id AS VARCHAR)
                    END AS [Current Step],
                    ja.next_scheduled_run_date AS [Next Scheduled Run]
                FROM msdb.dbo.sysjobactivity ja
                INNER JOIN msdb.dbo.sysjobs j ON ja.job_id = j.job_id
                WHERE ja.start_execution_date IS NOT NULL
                    AND ja.stop_execution_date IS NULL
                    AND ja.session_id = (SELECT MAX(session_id) FROM msdb.dbo.syssessions)
                ORDER BY ja.start_execution_date DESC";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - {dt.Rows.Count} çalýþan job";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnJobHistory_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Job geçmiþi yükleniyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT TOP 100
                    j.name AS [Job Name],
                    jh.step_name AS [Step Name],
                    CASE jh.run_status
                        WHEN 0 THEN 'Failed'
                        WHEN 1 THEN 'Succeeded'
                        WHEN 2 THEN 'Retry'
                        WHEN 3 THEN 'Canceled'
                        ELSE 'Unknown'
                    END AS [Status],
                    jh.run_date AS [Run Date],
                    jh.run_time AS [Run Time],
                    jh.run_duration AS [Duration],
                    jh.message AS [Message]
                FROM msdb.dbo.sysjobhistory jh
                INNER JOIN msdb.dbo.sysjobs j ON jh.job_id = j.job_id
                WHERE jh.step_id = 0
                ORDER BY jh.run_date DESC, jh.run_time DESC";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - Son {dt.Rows.Count} job çalýþtýrmasý";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnLongRunningJobs_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Uzun süren job'lar yükleniyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT TOP 50
                    j.name AS [Job Name],
                    COUNT(*) AS [Run Count],
                    SUM(jh.run_duration) AS [Total Duration],
                    MAX(jh.run_duration) AS [Max Duration],
                    MIN(jh.run_duration) AS [Min Duration],
                    MAX(jh.run_date) AS [Last Run Date]
                FROM msdb.dbo.sysjobhistory jh
                INNER JOIN msdb.dbo.sysjobs j ON jh.job_id = j.job_id
                WHERE jh.step_id = 0
                    AND jh.run_status = 1
                    AND jh.run_date >= CONVERT(INT, CONVERT(VARCHAR, DATEADD(DAY, -30, GETDATE()), 112))
                GROUP BY j.name
                ORDER BY SUM(jh.run_duration) DESC";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - Son 30 gün istatistikleri";
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
                { "Job Name", "Job Adý" },
                { "Status", "Durum" },
                { "Owner", "Sahibi" },
                { "Created", "Oluþturma Tarihi" },
                { "Modified", "Deðiþtirme Tarihi" },
                { "Next Run Date", "Sonraki Çalýþma Tarihi" },
                { "Next Run Time", "Sonraki Çalýþma Saati" },
                { "Category", "Kategori" },
                { "Step Name", "Adým Adý" },
                { "Run Date", "Çalýþma Tarihi" },
                { "Run Time", "Çalýþma Saati" },
                { "Duration", "Süre" },
                { "Error Message", "Hata Mesajý" },
                { "Message", "Mesaj" },
                { "Start Time", "Baþlama Zamaný" },
                { "Running Duration (s)", "Çalýþma Süresi (s)" },
                { "Current Step", "Þu Anki Adým" },
                { "Next Scheduled Run", "Sonraki Planlanan Çalýþma" },
                { "Run Count", "Çalýþma Sayýsý" },
                { "Total Duration", "Toplam Süre" },
                { "Max Duration", "Maks. Süre" },
                { "Min Duration", "Min. Süre" },
                { "Last Run Date", "Son Çalýþma Tarihi" }
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

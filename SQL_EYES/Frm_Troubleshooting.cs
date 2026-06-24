using System;
using System.Data;
using System.Windows.Forms;

namespace SQL_EYES
{
    public partial class Frm_Troubleshooting : Form
    {
        private Frm_Dashboard dashboardForm;

        public Frm_Troubleshooting()
        {
            InitializeComponent();
        }

        public Frm_Troubleshooting(Frm_Dashboard dashboard) : this()
        {
            dashboardForm = dashboard;
        }

        private void Frm_Troubleshooting_Load(object sender, EventArgs e)
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

        private void btnErrorLog_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "SQL Server hata logu yükleniyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                EXEC xp_readerrorlog 0, 1, NULL, NULL";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - {dt.Rows.Count} log kaydý";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnBlockingChains_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Blocking zincirleri kontrol ediliyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT 
                    sp.spid AS [Blocked Session ID],
                    sp.blocked AS [Blocking Session ID],
                    DB_NAME(sp.dbid) AS [Database],
                    sp.loginame AS [Login],
                    sp.hostname AS [Host],
                    sp.program_name AS [Program],
                    sp.status AS [Status],
                    sp.lastwaittype AS [Wait Type],
                    sp.waittime AS [Wait Time (ms)],
                    SUBSTRING(qt.TEXT, 1, 500) AS [Query Text]
                FROM sys.sysprocesses sp
                CROSS APPLY sys.dm_exec_sql_text(sp.sql_handle) qt
                WHERE sp.blocked <> 0
                ORDER BY sp.blocked";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - {dt.Rows.Count} bloke olan session";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnDeadlocks_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Deadlock bilgileri yükleniyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT 
                    CAST(target_data AS XML).value('(event/@timestamp)[1]', 'DateTime') AS [Timestamp],
                    CAST(target_data AS XML) AS [Deadlock XML]
                FROM sys.dm_xe_session_targets st
                JOIN sys.dm_xe_sessions s ON s.address = st.event_session_address
                WHERE name = 'system_health'
                    AND st.target_name = 'ring_buffer'";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - Deadlock verileri";
                }
                else
                {
                    MessageBox.Show("System Health Extended Event aktif deðil veya deadlock bulunamadý.", 
                        "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}\n\nNot: Bu özellik SQL Server 2008 ve üstü versiyonlarda çalýþýr.", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnServerConfig_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Server konfigürasyonu yükleniyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT 
                    configuration_id AS [Config ID],
                    name AS [Configuration],
                    value AS [Current Value],
                    value_in_use AS [Running Value],
                    minimum AS [Minimum],
                    maximum AS [Maximum],
                    is_dynamic AS [Is Dynamic],
                    is_advanced AS [Is Advanced]
                FROM sys.configurations
                ORDER BY name";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - {dt.Rows.Count} konfigürasyon";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnTraceFlags_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Aktif trace flag'ler kontrol ediliyor...";
                Cursor = Cursors.WaitCursor;

                string query = "DBCC TRACESTATUS(-1) WITH NO_INFOMSGS";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - {dt.Rows.Count} aktif trace flag";
                }
                else
                {
                    MessageBox.Show("Aktif trace flag bulunamadý.", "Bilgi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblStatus.Text = $"Baðlý: {GetServerName()} - Trace flag yok";
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
                { "Blocked Session ID", "Bloke Edilen Session" },
                { "Blocking Session ID", "Bloke Eden Session" },
                { "Database", "Veritabaný" },
                { "Login", "Kullanýcý" },
                { "Host", "Host" },
                { "Program", "Program" },
                { "Status", "Durum" },
                { "Wait Type", "Bekleme Tipi" },
                { "Wait Time (ms)", "Bekleme Süresi (ms)" },
                { "Query Text", "Sorgu Metni" },
                { "Config ID", "Konfig ID" },
                { "Configuration", "Konfigürasyon" },
                { "Current Value", "Þu Anki Deðer" },
                { "Running Value", "Çalýþan Deðer" },
                { "Minimum", "Minimum" },
                { "Maximum", "Maksimum" },
                { "Is Dynamic", "Dinamik mi" },
                { "Is Advanced", "Geliþmiþ mi" }
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

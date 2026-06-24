using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SQL_EYES
{
    public partial class Frm_Performance : Form
    {
        private Frm_Dashboard dashboardForm;

        public Frm_Performance()
        {
            InitializeComponent();
        }

        public Frm_Performance(Frm_Dashboard dashboard) : this()
        {
            dashboardForm = dashboard;
        }

        private void Frm_Performance_Load(object sender, EventArgs e)
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
            catch
            {
                return "Bilinmeyen";
            }
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

        private void btnExpensiveQueries_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "En pahalý sorgular yükleniyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT TOP 50
                    SUBSTRING(qt.TEXT, (qs.statement_start_offset/2)+1,
                        ((CASE qs.statement_end_offset
                            WHEN -1 THEN DATALENGTH(qt.TEXT)
                            ELSE qs.statement_end_offset
                        END - qs.statement_start_offset)/2)+1) AS [Query Text],
                    qs.execution_count AS [Execution Count],
                    qs.total_worker_time/1000000.0 AS [Total CPU Time (s)],
                    qs.total_worker_time/qs.execution_count/1000.0 AS [Avg CPU Time (ms)],
                    qs.total_logical_reads AS [Total Logical Reads],
                    qs.total_logical_reads/qs.execution_count AS [Avg Logical Reads],
                    qs.total_elapsed_time/1000000.0 AS [Total Duration (s)],
                    qs.total_elapsed_time/qs.execution_count/1000.0 AS [Avg Duration (ms)],
                    qs.creation_time AS [Creation Time],
                    qs.last_execution_time AS [Last Execution Time]
                FROM sys.dm_exec_query_stats qs
                CROSS APPLY sys.dm_exec_sql_text(qs.sql_handle) qt
                ORDER BY qs.total_worker_time DESC";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - {dt.Rows.Count} pahalý sorgu listelendi";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnWaitStats_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Wait statistics yükleniyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                WITH Waits AS (
                    SELECT 
                        wait_type,
                        wait_time_ms / 1000.0 AS [Wait Time (s)],
                        (wait_time_ms - signal_wait_time_ms) / 1000.0 AS [Resource Wait (s)],
                        signal_wait_time_ms / 1000.0 AS [Signal Wait (s)],
                        waiting_tasks_count AS [Wait Count],
                        100.0 * wait_time_ms / SUM(wait_time_ms) OVER() AS [Percentage]
                    FROM sys.dm_os_wait_stats
                    WHERE wait_type NOT IN (
                        'CLR_SEMAPHORE', 'LAZYWRITER_SLEEP', 'RESOURCE_QUEUE', 'SLEEP_TASK',
                        'SLEEP_SYSTEMTASK', 'SQLTRACE_BUFFER_FLUSH', 'WAITFOR', 'LOGMGR_QUEUE',
                        'CHECKPOINT_QUEUE', 'REQUEST_FOR_DEADLOCK_SEARCH', 'XE_TIMER_EVENT',
                        'BROKER_TO_FLUSH', 'BROKER_TASK_STOP', 'CLR_MANUAL_EVENT',
                        'CLR_AUTO_EVENT', 'DISPATCHER_QUEUE_SEMAPHORE', 'FT_IFTS_SCHEDULER_IDLE_WAIT',
                        'XE_DISPATCHER_WAIT', 'XE_DISPATCHER_JOIN', 'SQLTRACE_INCREMENTAL_FLUSH_SLEEP'
                    )
                )
                SELECT TOP 25
                    wait_type AS [Wait Type],
                    CAST([Wait Time (s)] AS DECIMAL(12, 2)) AS [Wait Time (s)],
                    CAST([Resource Wait (s)] AS DECIMAL(12, 2)) AS [Resource Wait (s)],
                    CAST([Signal Wait (s)] AS DECIMAL(12, 2)) AS [Signal Wait (s)],
                    [Wait Count],
                    CAST([Percentage] AS DECIMAL(5, 2)) AS [Percentage]
                FROM Waits
                WHERE [Percentage] > 0.01
                ORDER BY [Wait Time (s)] DESC";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - {dt.Rows.Count} wait tipi listelendi";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnIOStats_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "I/O istatistikleri yükleniyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT 
                    DB_NAME(vfs.database_id) AS [Database Name],
                    mf.name AS [File Name],
                    mf.physical_name AS [Physical Path],
                    CAST(vfs.num_of_reads AS DECIMAL(18,0)) AS [Read Count],
                    CAST(vfs.num_of_bytes_read/1024.0/1024.0/1024.0 AS DECIMAL(10,2)) AS [Read (GB)],
                    CAST(vfs.io_stall_read_ms/1000.0 AS DECIMAL(10,2)) AS [Read Stall (s)],
                    CAST(vfs.num_of_writes AS DECIMAL(18,0)) AS [Write Count],
                    CAST(vfs.num_of_bytes_written/1024.0/1024.0/1024.0 AS DECIMAL(10,2)) AS [Written (GB)],
                    CAST(vfs.io_stall_write_ms/1000.0 AS DECIMAL(10,2)) AS [Write Stall (s)],
                    CAST((vfs.io_stall_read_ms + vfs.io_stall_write_ms)/1000.0 AS DECIMAL(10,2)) AS [Total Stall (s)],
                    CASE WHEN vfs.num_of_reads > 0 
                        THEN CAST(vfs.io_stall_read_ms/vfs.num_of_reads AS DECIMAL(10,2))
                        ELSE 0 
                    END AS [Avg Read Latency (ms)],
                    CASE WHEN vfs.num_of_writes > 0 
                        THEN CAST(vfs.io_stall_write_ms/vfs.num_of_writes AS DECIMAL(10,2))
                        ELSE 0 
                    END AS [Avg Write Latency (ms)]
                FROM sys.dm_io_virtual_file_stats(NULL, NULL) vfs
                JOIN sys.master_files mf ON vfs.database_id = mf.database_id 
                    AND vfs.file_id = mf.file_id
                ORDER BY [Total Stall (s)] DESC";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - {dt.Rows.Count} dosya I/O istatistiði";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnMissingIndexes_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Eksik index önerileri yükleniyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT TOP 50
                    DB_NAME(mid.database_id) AS [Database Name],
                    OBJECT_NAME(mid.object_id, mid.database_id) AS [Table Name],
                    CAST(migs.avg_total_user_cost * migs.avg_user_impact * (migs.user_seeks + migs.user_scans) AS BIGINT) AS [Improvement Measure],
                    CAST(migs.avg_total_user_cost AS DECIMAL(10,2)) AS [Avg Query Cost],
                    CAST(migs.avg_user_impact AS DECIMAL(5,2)) AS [Avg Impact %],
                    migs.user_seeks AS [Seeks],
                    migs.user_scans AS [Scans],
                    mid.equality_columns AS [Equality Columns],
                    mid.inequality_columns AS [Inequality Columns],
                    mid.included_columns AS [Included Columns],
                    'CREATE INDEX IX_' + OBJECT_NAME(mid.object_id, mid.database_id) + '_' 
                        + REPLACE(REPLACE(REPLACE(ISNULL(mid.equality_columns,''), ', ', '_'), '[', ''), ']', '') + 
                    ' ON ' + mid.statement + ' (' + ISNULL(mid.equality_columns, '') + 
                    CASE WHEN mid.inequality_columns IS NOT NULL 
                        THEN CASE WHEN mid.equality_columns IS NOT NULL THEN ', ' ELSE '' END + mid.inequality_columns 
                        ELSE '' 
                    END + ')' + 
                    CASE WHEN mid.included_columns IS NOT NULL 
                        THEN ' INCLUDE (' + mid.included_columns + ')' 
                        ELSE '' 
                    END AS [Create Index Script]
                FROM sys.dm_db_missing_index_details mid
                CROSS APPLY sys.dm_db_missing_index_groups mig
                CROSS APPLY sys.dm_db_missing_index_group_stats migs
                WHERE mid.index_handle = mig.index_handle
                    AND mig.index_group_handle = migs.group_handle
                    AND mid.database_id = DB_ID()
                ORDER BY [Improvement Measure] DESC";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - {dt.Rows.Count} eksik index önerisi";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnTopTables_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "En çok okunan/yazýlan tablolar yükleniyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT TOP 50
                    OBJECT_SCHEMA_NAME(s.object_id) AS [Schema],
                    OBJECT_NAME(s.object_id) AS [Table Name],
                    i.name AS [Index Name],
                    s.user_seeks AS [User Seeks],
                    s.user_scans AS [User Scans],
                    s.user_lookups AS [User Lookups],
                    s.user_updates AS [User Updates],
                    s.user_seeks + s.user_scans + s.user_lookups AS [Total Reads],
                    s.last_user_seek AS [Last Seek],
                    s.last_user_scan AS [Last Scan],
                    s.last_user_lookup AS [Last Lookup],
                    s.last_user_update AS [Last Update]
                FROM sys.dm_db_index_usage_stats s
                INNER JOIN sys.indexes i ON s.object_id = i.object_id AND s.index_id = i.index_id
                WHERE OBJECTPROPERTY(s.object_id, 'IsUserTable') = 1
                    AND s.database_id = DB_ID()
                ORDER BY [Total Reads] DESC";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - {dt.Rows.Count} tablo/index istatistiði";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void TurkcelestirKolonlari(DataTable dt)
        {
            if (dt == null) return;

            var kolonCeviri = new System.Collections.Generic.Dictionary<string, string>
            {
                // Expensive Queries
                { "Query Text", "Sorgu Metni" },
                { "Execution Count", "Çalýþtýrma Sayýsý" },
                { "Total CPU Time (s)", "Toplam CPU Zamaný (s)" },
                { "Avg CPU Time (ms)", "Ort. CPU Zamaný (ms)" },
                { "Total Logical Reads", "Toplam Mantýksal Okuma" },
                { "Avg Logical Reads", "Ort. Mantýksal Okuma" },
                { "Total Duration (s)", "Toplam Süre (s)" },
                { "Avg Duration (ms)", "Ort. Süre (ms)" },
                { "Creation Time", "Oluþturma Zamaný" },
                { "Last Execution Time", "Son Çalýþtýrma" },
                
                // Wait Stats
                { "Wait Type", "Bekleme Tipi" },
                { "Wait Time (s)", "Bekleme Süresi (s)" },
                { "Resource Wait (s)", "Kaynak Bekleme (s)" },
                { "Signal Wait (s)", "Sinyal Bekleme (s)" },
                { "Wait Count", "Bekleme Sayýsý" },
                { "Percentage", "Yüzde" },
                
                // I/O Stats
                { "Database Name", "Veritabaný Adý" },
                { "File Name", "Dosya Adý" },
                { "Physical Path", "Fiziksel Yol" },
                { "Read Count", "Okuma Sayýsý" },
                { "Read (GB)", "Okunan (GB)" },
                { "Read Stall (s)", "Okuma Gecikmesi (s)" },
                { "Write Count", "Yazma Sayýsý" },
                { "Written (GB)", "Yazýlan (GB)" },
                { "Write Stall (s)", "Yazma Gecikmesi (s)" },
                { "Total Stall (s)", "Toplam Gecikme (s)" },
                { "Avg Read Latency (ms)", "Ort. Okuma Gecikmesi (ms)" },
                { "Avg Write Latency (ms)", "Ort. Yazma Gecikmesi (ms)" },
                
                // Missing Indexes
                { "Table Name", "Tablo Adý" },
                { "Improvement Measure", "Ýyileþtirme Ölçüsü" },
                { "Avg Query Cost", "Ort. Sorgu Maliyeti" },
                { "Avg Impact %", "Ort. Etki %" },
                { "Seeks", "Arama" },
                { "Scans", "Tarama" },
                { "Equality Columns", "Eþitlik Kolonlarý" },
                { "Inequality Columns", "Eþitsizlik Kolonlarý" },
                { "Included Columns", "Dahil Kolonlar" },
                { "Create Index Script", "Index Oluþturma Script" },
                
                // Top Tables
                { "Schema", "Þema" },
                { "Index Name", "Index Adý" },
                { "User Seeks", "Kullanýcý Aramalarý" },
                { "User Scans", "Kullanýcý Taramalarý" },
                { "User Lookups", "Kullanýcý Lookup'larý" },
                { "User Updates", "Kullanýcý Güncellemeleri" },
                { "Total Reads", "Toplam Okuma" },
                { "Last Seek", "Son Arama" },
                { "Last Scan", "Son Tarama" },
                { "Last Lookup", "Son Lookup" },
                { "Last Update", "Son Güncelleme" }
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

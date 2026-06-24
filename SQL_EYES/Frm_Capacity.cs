using System;
using System.Data;
using System.Windows.Forms;

namespace SQL_EYES
{
    public partial class Frm_Capacity : Form
    {
        private Frm_Dashboard dashboardForm;

        public Frm_Capacity()
        {
            InitializeComponent();
        }

        public Frm_Capacity(Frm_Dashboard dashboard) : this()
        {
            dashboardForm = dashboard;
        }

        private void Frm_Capacity_Load(object sender, EventArgs e)
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

        private void btnDiskSpace_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Disk alaný kullanýmý analiz ediliyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT 
                    DB_NAME(database_id) AS [Database Name],
                    type_desc AS [File Type],
                    name AS [Logical Name],
                    physical_name AS [Physical Path],
                    CAST(size * 8.0 / 1024 AS DECIMAL(10,2)) AS [Current Size (MB)],
                    CAST(size * 8.0 / 1024 / 1024 AS DECIMAL(10,2)) AS [Current Size (GB)],
                    CASE max_size 
                        WHEN -1 THEN 'Unlimited'
                        WHEN 268435456 THEN 'Unlimited'
                        ELSE CAST(CAST(max_size * 8.0 / 1024 / 1024 AS DECIMAL(10,2)) AS VARCHAR) + ' GB'
                    END AS [Max Size],
                    CAST(growth * 8.0 / 1024 AS DECIMAL(10,2)) AS [Growth (MB)],
                    is_percent_growth AS [Is Percent Growth]
                FROM sys.master_files
                WHERE database_id > 4
                ORDER BY DB_NAME(database_id), type_desc";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - {dt.Rows.Count} dosya analiz edildi";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnDatabaseGrowth_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Veritabaný büyüme trendi hesaplanýyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                WITH DatabaseSizes AS (
                    SELECT 
                        database_id,
                        SUM(CAST(size AS BIGINT) * 8 / 1024) AS size_mb
                    FROM sys.master_files
                    GROUP BY database_id
                )
                SELECT 
                    d.name AS [Database Name],
                    CAST(ds.size_mb AS DECIMAL(10,2)) AS [Current Size (MB)],
                    CAST(ds.size_mb / 1024.0 AS DECIMAL(10,2)) AS [Current Size (GB)],
                    d.create_date AS [Created],
                    DATEDIFF(DAY, d.create_date, GETDATE()) AS [Age (Days)],
                    CASE 
                        WHEN DATEDIFF(DAY, d.create_date, GETDATE()) > 0 
                        THEN CAST(ds.size_mb / CAST(DATEDIFF(DAY, d.create_date, GETDATE()) AS FLOAT) AS DECIMAL(10,2))
                        ELSE 0 
                    END AS [Avg Growth (MB/Day)],
                    CASE 
                        WHEN DATEDIFF(DAY, d.create_date, GETDATE()) > 0 
                        THEN CAST((ds.size_mb / CAST(DATEDIFF(DAY, d.create_date, GETDATE()) AS FLOAT)) * 30 AS DECIMAL(10,2))
                        ELSE 0 
                    END AS [Projected Monthly (MB)],
                    CASE 
                        WHEN DATEDIFF(DAY, d.create_date, GETDATE()) > 0 
                        THEN CAST((ds.size_mb / CAST(DATEDIFF(DAY, d.create_date, GETDATE()) AS FLOAT)) * 365 AS DECIMAL(10,2))
                        ELSE 0 
                    END AS [Projected Yearly (MB)]
                FROM sys.databases d
                INNER JOIN DatabaseSizes ds ON d.database_id = ds.database_id
                WHERE d.database_id > 4
                ORDER BY [Avg Growth (MB/Day)] DESC";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - Büyüme trendi hesaplandý";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnTableGrowth_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "En hýzlý büyüyen tablolar analiz ediliyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT TOP 50
                    SCHEMA_NAME(t.schema_id) AS [Schema],
                    t.name AS [Table Name],
                    p.rows AS [Row Count],
                    CAST(SUM(a.total_pages) * 8 / 1024.0 AS DECIMAL(10,2)) AS [Total Space (MB)],
                    CAST(SUM(a.used_pages) * 8 / 1024.0 AS DECIMAL(10,2)) AS [Used Space (MB)],
                    CAST((SUM(a.total_pages) - SUM(a.used_pages)) * 8 / 1024.0 AS DECIMAL(10,2)) AS [Unused Space (MB)],
                    t.create_date AS [Created],
                    t.modify_date AS [Modified]
                FROM sys.tables t
                INNER JOIN sys.indexes i ON t.object_id = i.object_id
                INNER JOIN sys.partitions p ON i.object_id = p.object_id AND i.index_id = p.index_id
                INNER JOIN sys.allocation_units a ON p.partition_id = a.container_id
                WHERE t.is_ms_shipped = 0
                    AND i.object_id > 255
                GROUP BY t.schema_id, t.name, p.rows, t.create_date, t.modify_date
                ORDER BY SUM(a.total_pages) DESC";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - {dt.Rows.Count} tablo analiz edildi";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnIndexSpace_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Index alan kullanýmý analiz ediliyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT TOP 50
                    OBJECT_SCHEMA_NAME(i.object_id) AS [Schema],
                    OBJECT_NAME(i.object_id) AS [Table Name],
                    i.name AS [Index Name],
                    i.type_desc AS [Index Type],
                    CAST(SUM(s.used_page_count) * 8 / 1024.0 AS DECIMAL(10,2)) AS [Used Space (MB)],
                    CAST(SUM(s.reserved_page_count) * 8 / 1024.0 AS DECIMAL(10,2)) AS [Reserved Space (MB)],
                    SUM(p.rows) AS [Row Count],
                    i.fill_factor AS [Fill Factor]
                FROM sys.dm_db_partition_stats s
                INNER JOIN sys.indexes i ON s.object_id = i.object_id AND s.index_id = i.index_id
                INNER JOIN sys.partitions p ON s.object_id = p.object_id AND s.index_id = p.index_id
                WHERE OBJECTPROPERTY(i.object_id, 'IsUserTable') = 1
                    AND i.index_id > 0
                GROUP BY i.object_id, i.name, i.type_desc, i.fill_factor
                ORDER BY SUM(s.used_page_count) DESC";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - {dt.Rows.Count} index analiz edildi";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnResourceUsage_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Kaynak kullanýmý analiz ediliyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT 
                    'Physical Memory (MB)' AS [Resource],
                    CAST(total_physical_memory_kb / 1024.0 AS DECIMAL(10,2)) AS [Total],
                    CAST(available_physical_memory_kb / 1024.0 AS DECIMAL(10,2)) AS [Available],
                    CAST((total_physical_memory_kb - available_physical_memory_kb) / 1024.0 AS DECIMAL(10,2)) AS [Used],
                    CAST(((total_physical_memory_kb - available_physical_memory_kb) * 100.0 / total_physical_memory_kb) AS DECIMAL(5,2)) AS [Usage %]
                FROM sys.dm_os_sys_memory
                UNION ALL
                SELECT 
                    'SQL Server Memory (MB)',
                    CAST(SUM(pages_kb) / 1024.0 AS DECIMAL(10,2)),
                    NULL,
                    CAST(SUM(pages_kb) / 1024.0 AS DECIMAL(10,2)),
                    NULL
                FROM sys.dm_os_memory_clerks
                UNION ALL
                SELECT 
                    'Page Life Expectancy',
                    CAST(cntr_value AS DECIMAL(10,2)),
                    NULL,
                    NULL,
                    NULL
                FROM sys.dm_os_performance_counters
                WHERE counter_name = 'Page life expectancy'
                    AND object_name LIKE '%Buffer Manager%'";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - Kaynak kullanýmý analiz edildi";
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
                // Disk Space
                { "Database Name", "Veritabaný Adý" },
                { "File Type", "Dosya Tipi" },
                { "Logical Name", "Mantýksal Ad" },
                { "Physical Path", "Fiziksel Yol" },
                { "Current Size (MB)", "Þu Anki Boyut (MB)" },
                { "Current Size (GB)", "Þu Anki Boyut (GB)" },
                { "Max Size", "Maksimum Boyut" },
                { "Growth (MB)", "Büyüme (MB)" },
                { "Is Percent Growth", "Yüzde Büyüme mi" },
                
                // Database Growth
                { "Created", "Oluþturma Tarihi" },
                { "Age (Days)", "Yaþ (Gün)" },
                { "Avg Growth (MB/Day)", "Ort. Büyüme (MB/Gün)" },
                { "Projected Monthly (MB)", "Aylýk Tahmin (MB)" },
                { "Projected Yearly (MB)", "Yýllýk Tahmin (MB)" },
                
                // Table Growth
                { "Schema", "Þema" },
                { "Table Name", "Tablo Adý" },
                { "Row Count", "Satýr Sayýsý" },
                { "Total Space (MB)", "Toplam Alan (MB)" },
                { "Used Space (MB)", "Kullanýlan Alan (MB)" },
                { "Unused Space (MB)", "Boþ Alan (MB)" },
                { "Modified", "Deðiþtirilme Tarihi" },
                
                // Index Space
                { "Index Name", "Index Adý" },
                { "Index Type", "Index Tipi" },
                { "Reserved Space (MB)", "Ayrýlan Alan (MB)" },
                { "Fill Factor", "Doluluk Faktörü" },
                
                // Resource Usage
                { "Resource", "Kaynak" },
                { "Total", "Toplam" },
                { "Available", "Kullanýlabilir" },
                { "Used", "Kullanýlan" },
                { "Usage %", "Kullaným %" }
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

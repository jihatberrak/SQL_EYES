using System;
using System.Data;
using System.Windows.Forms;

namespace SQL_EYES
{
    public partial class Frm_HighAvailability : Form
    {
        private Frm_Dashboard dashboardForm;

        public Frm_HighAvailability()
        {
            InitializeComponent();
        }

        public Frm_HighAvailability(Frm_Dashboard dashboard) : this()
        {
            dashboardForm = dashboard;
        }

        private void Frm_HighAvailability_Load(object sender, EventArgs e)
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

        private void btnAlwaysOnStatus_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "AlwaysOn Availability Groups kontrol ediliyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT 
                    ag.name AS [AG Name],
                    ar.replica_server_name AS [Replica Server],
                    ar.availability_mode_desc AS [Availability Mode],
                    ar.failover_mode_desc AS [Failover Mode],
                    ars.role_desc AS [Current Role],
                    ars.operational_state_desc AS [Operational State],
                    ars.connected_state_desc AS [Connected State],
                    ars.synchronization_health_desc AS [Sync Health],
                    ars.last_connect_error_description AS [Last Error]
                FROM sys.availability_groups ag
                INNER JOIN sys.availability_replicas ar ON ag.group_id = ar.group_id
                INNER JOIN sys.dm_hadr_availability_replica_states ars ON ar.replica_id = ars.replica_id
                ORDER BY ag.name, ar.replica_server_name";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null && dt.Rows.Count > 0)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - {dt.Rows.Count} replika";
                }
                else
                {
                    MessageBox.Show("AlwaysOn Availability Groups aktif deðil veya bu özellik desteklenmiyor.\n\n" +
                        "Not: Bu özellik SQL Server 2012+ Enterprise veya Developer Edition'da kullanýlabilir.", 
                        "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblStatus.Text = $"Baðlý: {GetServerName()} - AlwaysOn yok";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}\n\nNot: AlwaysOn Availability Groups SQL Server 2012+ Enterprise/Developer Edition özelliðidir.", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnDatabaseMirroring_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Database Mirroring durumu kontrol ediliyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT 
                    DB_NAME(database_id) AS [Database Name],
                    mirroring_state_desc AS [Mirroring State],
                    mirroring_role_desc AS [Mirroring Role],
                    mirroring_safety_level_desc AS [Safety Level],
                    mirroring_partner_name AS [Partner Server],
                    mirroring_partner_instance AS [Partner Instance],
                    mirroring_witness_name AS [Witness Server],
                    mirroring_witness_state_desc AS [Witness State],
                    mirroring_failover_lsn AS [Failover LSN]
                FROM sys.database_mirroring
                WHERE mirroring_guid IS NOT NULL
                ORDER BY DB_NAME(database_id)";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null && dt.Rows.Count > 0)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - {dt.Rows.Count} mirrored veritabaný";
                }
                else
                {
                    MessageBox.Show("Database Mirroring yapýlandýrýlmýþ veritabaný bulunamadý.\n\n" +
                        "Not: Database Mirroring, SQL Server 2016'dan itibaren deprecated olmuþtur.", 
                        "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblStatus.Text = $"Baðlý: {GetServerName()} - Mirroring yok";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnLogShipping_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Log Shipping durumu kontrol ediliyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT 
                    primary_server AS [Primary Server],
                    primary_database AS [Primary Database],
                    last_backup_file AS [Last Backup File],
                    last_backup_date AS [Last Backup Date],
                    last_backup_date_utc AS [Last Backup UTC],
                    backup_threshold AS [Backup Threshold (min)]
                FROM msdb.dbo.log_shipping_monitor_primary
                ORDER BY primary_database";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null && dt.Rows.Count > 0)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - {dt.Rows.Count} log shipping veritabaný";
                }
                else
                {
                    MessageBox.Show("Log Shipping yapýlandýrýlmýþ veritabaný bulunamadý.", 
                        "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblStatus.Text = $"Baðlý: {GetServerName()} - Log Shipping yok";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnReplicationStatus_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Replication durumu kontrol ediliyor...";
                Cursor = Cursors.WaitCursor;

                // Önce replication yapýlandýrýlmýþ mý kontrol et
                string checkQuery = @"
                SELECT 
                    ISNULL(SERVERPROPERTY('IsDistributor'), 0) AS [Is Distributor],
                    ISNULL(SERVERPROPERTY('IsPublisher'), 0) AS [Is Publisher]";
                
                DataTable dtCheck = SqlHelper.ExecuteQuery(checkQuery);
                bool isConfigured = false;
                
                if (dtCheck != null && dtCheck.Rows.Count > 0)
                {
                    object distValue = dtCheck.Rows[0]["Is Distributor"];
                    object pubValue = dtCheck.Rows[0]["Is Publisher"];
                    
                    int isDistributor = (distValue != null && distValue != DBNull.Value) ? Convert.ToInt32(distValue) : 0;
                    int isPublisher = (pubValue != null && pubValue != DBNull.Value) ? Convert.ToInt32(pubValue) : 0;
                    
                    isConfigured = (isDistributor == 1 || isPublisher == 1);
                }

                if (!isConfigured)
                {
                    // Replication yapýlandýrýlmamýþ - basit bilgi göster
                    string simpleQuery = @"
                    SELECT 
                        'Replication Status' AS [Feature],
                        'Not Configured' AS [Status],
                        ISNULL(CAST(SERVERPROPERTY('IsDistributor') AS VARCHAR), '0') AS [Is Distributor],
                        ISNULL(CAST(SERVERPROPERTY('IsPublisher') AS VARCHAR), '0') AS [Is Publisher],
                        CAST(SERVERPROPERTY('ServerName') AS VARCHAR) AS [Server Name]";
                    
                    DataTable dtSimple = SqlHelper.ExecuteQuery(simpleQuery);
                    if (dtSimple != null)
                    {
                        TurkcelestirKolonlari(dtSimple);
                        dgvResults.DataSource = dtSimple;
                        dgvResults.AutoResizeColumns();
                    }
                    
                    MessageBox.Show("Replication bu sunucuda yapýlandýrýlmamýþ.\n\n" +
                        "Replication'ý yapýlandýrmak için SQL Server Management Studio kullanabilirsiniz.", 
                        "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblStatus.Text = $"Baðlý: {GetServerName()} - Replication yapýlandýrýlmamýþ";
                }
                else
                {
                    // Basit publisher/subscriber bilgisi göster
                    string infoQuery = @"
                    SELECT 
                        d.name AS [Database],
                        CASE 
                            WHEN d.is_published = 1 THEN 'Publisher'
                            WHEN d.is_subscribed = 1 THEN 'Subscriber'
                            WHEN d.is_merge_published = 1 THEN 'Merge Publisher'
                            ELSE 'Not Configured'
                        END AS [Replication Role],
                        d.is_published AS [Is Published],
                        d.is_subscribed AS [Is Subscribed],
                        d.is_merge_published AS [Is Merge Published]
                    FROM sys.databases d
                    WHERE d.is_published = 1 
                        OR d.is_subscribed = 1 
                        OR d.is_merge_published = 1
                    ORDER BY d.name";
                    
                    DataTable dt = SqlHelper.ExecuteQuery(infoQuery);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        TurkcelestirKolonlari(dt);
                        dgvResults.DataSource = dt;
                        dgvResults.AutoResizeColumns();
                        lblStatus.Text = $"Baðlý: {GetServerName()} - {dt.Rows.Count} replicated veritabaný";
                    }
                    else
                    {
                        MessageBox.Show("Replication yapýlandýrýlmýþ ama aktif veritabaný bulunamadý.", 
                            "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblStatus.Text = $"Baðlý: {GetServerName()} - Replication aktif deðil";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}\n\nNot: Replication bilgilerini görüntülemek için yeterli izinlere sahip olmanýz gerekebilir.", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnClusterInfo_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Cluster bilgileri yükleniyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT 
                    NodeName AS [Node Name],
                    status_description AS [Status],
                    is_current_owner AS [Is Current Owner]
                FROM sys.dm_os_cluster_nodes
                ORDER BY NodeName";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null && dt.Rows.Count > 0)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - {dt.Rows.Count} cluster node";
                }
                else
                {
                    // Cluster olmayan sunucu için server bilgileri göster
                    string serverQuery = @"
                    SELECT 
                        SERVERPROPERTY('ComputerNamePhysicalNetBIOS') AS [Computer Name],
                        SERVERPROPERTY('IsClustered') AS [Is Clustered],
                        SERVERPROPERTY('IsHadrEnabled') AS [Is HADR Enabled],
                        SERVERPROPERTY('IsFullTextInstalled') AS [FullText Enabled]";
                    
                    DataTable dtServer = SqlHelper.ExecuteQuery(serverQuery);
                    if (dtServer != null)
                    {
                        TurkcelestirKolonlari(dtServer);
                        dgvResults.DataSource = dtServer;
                        dgvResults.AutoResizeColumns();
                    }
                    
                    MessageBox.Show("Bu SQL Server instance clustered deðil.", 
                        "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblStatus.Text = $"Baðlý: {GetServerName()} - Cluster yok";
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
                // AlwaysOn
                { "AG Name", "AG Adý" },
                { "Replica Server", "Replika Sunucu" },
                { "Availability Mode", "Kullanýlabilirlik Modu" },
                { "Failover Mode", "Failover Modu" },
                { "Current Role", "Þu Anki Rol" },
                { "Operational State", "Operasyonel Durum" },
                { "Connected State", "Baðlantý Durumu" },
                { "Sync Health", "Senkronizasyon Saðlýðý" },
                { "Last Error", "Son Hata" },
                
                // Database Mirroring
                { "Database Name", "Veritabaný Adý" },
                { "Mirroring State", "Mirroring Durumu" },
                { "Mirroring Role", "Mirroring Rolü" },
                { "Safety Level", "Güvenlik Seviyesi" },
                { "Partner Server", "Partner Sunucu" },
                { "Partner Instance", "Partner Instance" },
                { "Witness Server", "Witness Sunucu" },
                { "Witness State", "Witness Durumu" },
                { "Failover LSN", "Failover LSN" },
                
                // Log Shipping
                { "Primary Server", "Birincil Sunucu" },
                { "Primary Database", "Birincil Veritabaný" },
                { "Last Backup File", "Son Yedek Dosyasý" },
                { "Last Backup Date", "Son Yedek Tarihi" },
                { "Last Backup UTC", "Son Yedek (UTC)" },
                { "Backup Threshold (min)", "Yedek Eþiði (dk)" },
                
                // Replication
                { "Database", "Veritabaný" },
                { "Replication Role", "Replikasyon Rolü" },
                { "Is Published", "Yayýmlanmýþ mý" },
                { "Is Subscribed", "Abone mi" },
                { "Is Merge Published", "Merge Yayýmlanmýþ mý" },
                { "Is Distributor", "Distributor mu" },
                { "Is Publisher", "Publisher mý" },
                { "Server Name", "Sunucu Adý" },
                { "Publisher", "Publisher" },
                { "Publication", "Yayýn" },
                { "Article", "Makale" },
                { "Subscriber", "Abone" },
                { "Subscriber DB", "Abone VT" },
                { "Status", "Durum" },
                { "Subscription Type", "Abonelik Tipi" },
                { "Sync Type", "Senkronizasyon Tipi" },
                { "Last Updated", "Son Güncelleme" },
                
                // Cluster
                { "Node Name", "Node Adý" },
                { "Is Current Owner", "Þu Anki Sahip mi" },
                { "Computer Name", "Bilgisayar Adý" },
                { "Is Clustered", "Clustered mý" },
                { "Is HADR Enabled", "HADR Aktif mi" },
                { "FullText Enabled", "FullText Aktif mi" },
                { "Feature", "Özellik" }
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

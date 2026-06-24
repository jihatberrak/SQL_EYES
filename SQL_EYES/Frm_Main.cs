using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_EYES
{
    public partial class Frm_Main : Form
    {
        private Frm_Dashboard dashboardForm;

        public Frm_Main()
        {
            InitializeComponent();
        }

        public Frm_Main(Frm_Dashboard dashboard) : this()
        {
            dashboardForm = dashboard;
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            // Eğer bağlantı varsa direkt tab'ları aç
            if (!string.IsNullOrEmpty(SqlHelper.ConnectionString))
            {
                EnableAllTabs();
                LoadDatabaseList();
                lblStatus.Text = $"Bağlı: {GetServerName()}";
                // Bağlantı tab'ını gizle
                tabControl1.TabPages.Remove(tabConnection);
            }
            else
            {
                chkIntegratedSecurity.Checked = true;
                DisableAllTabsExceptConnection();
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
                return "Bilinmeyen";
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            
            // Dashboard formunu göster
            if (dashboardForm != null && !dashboardForm.IsDisposed)
            {
                dashboardForm.Show();
                dashboardForm.BringToFront();
            }
        }

        private void DisableAllTabsExceptConnection()
        {
            for (int i = 1; i < tabControl1.TabPages.Count; i++)
            {
                tabControl1.TabPages[i].Enabled = false;
            }
        }

        private void EnableAllTabs()
        {
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                tabControl1.TabPages[i].Enabled = true;
            }
        }

        private void chkIntegratedSecurity_CheckedChanged(object sender, EventArgs e)
        {
            txtUsername.Enabled = !chkIntegratedSecurity.Checked;
            txtPassword.Enabled = !chkIntegratedSecurity.Checked;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr;
                if (chkIntegratedSecurity.Checked)
                {
                    connStr = $"Server={txtServer.Text};Database=master;Integrated Security=True;";
                }
                else
                {
                    connStr = $"Server={txtServer.Text};Database=master;User Id={txtUsername.Text};Password={txtPassword.Text};";
                }

                if (SqlHelper.TestConnection(connStr))
                {
                    SqlHelper.ConnectionString = connStr;
                    lblStatus.Text = $"Bağlı: {txtServer.Text}";
                    EnableAllTabs();
                    LoadDatabaseList();
                    MessageBox.Show("Bağlantı başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Bağlantı başarısız! Lütfen bilgileri kontrol edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bağlantı hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDatabaseList()
        {
            try
            {
                DataTable dt = SqlHelper.ExecuteQuery("SELECT name FROM sys.databases WHERE database_id > 4 ORDER BY name");
                if (dt != null)
                {
                    cmbDatabases.Items.Clear();
                    cmbDatabasesForIndex.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        cmbDatabases.Items.Add(row["name"].ToString());
                        cmbDatabasesForIndex.Items.Add(row["name"].ToString());
                    }
                    if (cmbDatabases.Items.Count > 0)
                        cmbDatabases.SelectedIndex = 0;
                    if (cmbDatabasesForIndex.Items.Count > 0)
                        cmbDatabasesForIndex.SelectedIndex = 0;
                }
            }
            catch { }
        }

        private void btnRefreshConnections_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Aktif bağlantılar yükleniyor...";
                DataTable dt = SqlHelper.ExecuteQuery(SqlQueries.ActiveConnections);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvActiveConnections.DataSource = dt;
                    dgvActiveConnections.AutoResizeColumns();
                }
                lblStatus.Text = $"Bağlı: {txtServer.Text} - {dt?.Rows.Count ?? 0} aktif bağlantı";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Bağlı: {txtServer.Text}";
            }
        }

        private void btnRefreshTempDB_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "TempDB bilgileri yükleniyor...";
                
                DataTable dtFiles = SqlHelper.ExecuteQuery(SqlQueries.TempDBInfo);
                if (dtFiles != null)
                {
                    TurkcelestirKolonlari(dtFiles);
                    dgvTempDBFiles.DataSource = dtFiles;
                }

                DataTable dtTables = SqlHelper.ExecuteQuery(SqlQueries.TempDBTables);
                if (dtTables != null)
                {
                    TurkcelestirKolonlari(dtTables);
                    dgvTempDBTables.DataSource = dtTables;
                }

                DataTable dtSessions = SqlHelper.ExecuteQuery(SqlQueries.TempDBSessions);
                if (dtSessions != null)
                {
                    TurkcelestirKolonlari(dtSessions);
                    dgvTempDBSessions.DataSource = dtSessions;
                }

                dgvTempDBFiles.AutoResizeColumns();
                dgvTempDBTables.AutoResizeColumns();
                dgvTempDBSessions.AutoResizeColumns();

                lblStatus.Text = $"Bağlı: {txtServer.Text} - TempDB bilgileri güncellendi";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Bağlı: {txtServer.Text}";
            }
        }

        private void btnShrinkTempDB_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("TempDB küçültme işlemi yapılacak. Devam etmek istiyor musunuz?", 
                    "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    lblStatus.Text = "TempDB küçültülüyor...";
                    SqlHelper.ExecuteNonQuery(SqlQueries.ShrinkTempDB);
                    MessageBox.Show("TempDB küçültme işlemi tamamlandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnRefreshTempDB_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Bağlı: {txtServer.Text}";
            }
        }

        private void btnRefreshBuffer_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Buffer Pool bilgileri yükleniyor...";
                
                DataTable dtByDB = SqlHelper.ExecuteQuery(SqlQueries.BufferPoolByDatabase);
                if (dtByDB != null)
                {
                    TurkcelestirKolonlari(dtByDB);
                    dgvBufferByDB.DataSource = dtByDB;
                    dgvBufferByDB.AutoResizeColumns();
                }

                if (cmbDatabases.SelectedItem != null)
                {
                    string currentDB = SqlHelper.ConnectionString;
                    SqlHelper.ConnectionString = currentDB.Replace("Database=master", $"Database={cmbDatabases.SelectedItem}");
                    
                    DataTable dtByTable = SqlHelper.ExecuteQuery(SqlQueries.BufferPoolByTable);
                    if (dtByTable != null)
                    {
                        TurkcelestirKolonlari(dtByTable);
                        dgvBufferByTable.DataSource = dtByTable;
                        dgvBufferByTable.AutoResizeColumns();
                    }
                    
                    SqlHelper.ConnectionString = currentDB;
                }

                lblStatus.Text = $"Bağlı: {txtServer.Text} - Buffer Pool bilgileri güncellendi";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Bağlı: {txtServer.Text}";
            }
        }

        private void btnClearBuffer_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Buffer temizleme işlemi sistem performansını etkileyebilir. Devam etmek istiyor musunuz?", 
                    "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                
                if (result == DialogResult.Yes)
                {
                    lblStatus.Text = "Buffer temizleniyor...";
                    SqlHelper.ExecuteNonQuery(SqlQueries.ClearBuffer);
                    MessageBox.Show("Buffer temizleme işlemi tamamlandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnRefreshBuffer_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Bağlı: {txtServer.Text}";
            }
        }

        private void btnRefreshDBSizes_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Veritabanı boyutları hesaplanıyor...";
                DataTable dt = SqlHelper.ExecuteQuery(SqlQueries.AllDatabaseSizes);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvDatabaseSizes.DataSource = dt;
                    dgvDatabaseSizes.AutoResizeColumns();
                }
                lblStatus.Text = $"Bağlı: {txtServer.Text} - {dt?.Rows.Count ?? 0} veritabanı";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Bağlı: {txtServer.Text}";
            }
        }

        private void btnRefreshTableSizes_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDatabases.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen bir veritabanı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                lblStatus.Text = "Tablo boyutları hesaplanıyor...";
                
                string currentDB = SqlHelper.ConnectionString;
                SqlHelper.ConnectionString = currentDB.Replace("Database=master", $"Database={cmbDatabases.SelectedItem}");
                
                DataTable dt = SqlHelper.ExecuteQuery(SqlQueries.TableSizes);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvTableSizes.DataSource = dt;
                    dgvTableSizes.AutoResizeColumns();
                }
                
                SqlHelper.ConnectionString = currentDB;
                
                lblStatus.Text = $"Bağlı: {txtServer.Text} - {cmbDatabases.SelectedItem} - {dt?.Rows.Count ?? 0} tablo";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Bağlı: {txtServer.Text}";
            }
        }

        private void btnAnalyzeIndexes_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDatabasesForIndex.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen bir veritabanı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                lblStatus.Text = "Index'ler analiz ediliyor...";
                
                string currentDB = SqlHelper.ConnectionString;
                SqlHelper.ConnectionString = currentDB.Replace("Database=master", $"Database={cmbDatabasesForIndex.SelectedItem}");
                
                string query = SqlQueries.GetIndexMaintenanceScript(true, (int)numFragmentationThreshold.Value);
                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvIndexes.DataSource = dt;
                    dgvIndexes.AutoResizeColumns();
                }
                
                SqlHelper.ConnectionString = currentDB;
                
                lblStatus.Text = $"Bağlı: {txtServer.Text} - {cmbDatabasesForIndex.SelectedItem} - {dt?.Rows.Count ?? 0} parçalı index";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Bağlı: {txtServer.Text}";
            }
        }

        private void btnExecuteIndexMaintenance_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvIndexes.Rows.Count == 0)
                {
                    MessageBox.Show("Önce index analizi yapmalısınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dgvIndexes.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Lütfen bakım yapacak index'i seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show("Seçili index için bakım işlemi yapılacak. Devam etmek istiyor musunuz?", 
                    "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    lblStatus.Text = "Index bakımı yapılıyor...";
                    
                    string currentDB = SqlHelper.ConnectionString;
                    SqlHelper.ConnectionString = currentDB.Replace("Database=master", $"Database={cmbDatabasesForIndex.SelectedItem}");
                    
                    DataGridViewRow selectedRow = dgvIndexes.SelectedRows[0];
                    string columnName = "Önerilen İşlem";
                    
                    // İngilizce kolon adıyla da dene
                    if (!dgvIndexes.Columns.Contains(columnName))
                        columnName = "Recommended Action";
                    
                    if (selectedRow.Cells[columnName].Value != null && 
                        !string.IsNullOrEmpty(selectedRow.Cells[columnName].Value.ToString()))
                    {
                        string command = selectedRow.Cells[columnName].Value.ToString();
                        SqlHelper.ExecuteNonQuery(command);
                        
                        MessageBox.Show("Index bakım işlemi tamamlandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Seçili index için önerilen işlem bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                    SqlHelper.ConnectionString = currentDB;
                    lblStatus.Text = $"Bağlı: {txtServer.Text}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Bağlı: {txtServer.Text}";
            }
        }

        private void btnExecuteAllIndexMaintenance_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvIndexes.Rows.Count == 0)
                {
                    MessageBox.Show("Önce index analizi yapmalısınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show("TÜM index'ler için bakım işlemi yapılacak. Bu işlem uzun sürebilir. Devam etmek istiyor musunuz?", 
                    "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    lblStatus.Text = "Tüm index bakımı yapılıyor...";
                    
                    string currentDB = SqlHelper.ConnectionString;
                    SqlHelper.ConnectionString = currentDB.Replace("Database=master", $"Database={cmbDatabasesForIndex.SelectedItem}");
                    
                    int executedCount = 0;
                    string columnName = dgvIndexes.Columns.Contains("Önerilen İşlem") ? "Önerilen İşlem" : "Recommended Action";
                    
                    foreach (DataGridViewRow row in dgvIndexes.Rows)
                    {
                        if (row.Cells[columnName].Value != null && 
                            !string.IsNullOrEmpty(row.Cells[columnName].Value.ToString()))
                        {
                            string command = row.Cells[columnName].Value.ToString();
                            SqlHelper.ExecuteNonQuery(command);
                            executedCount++;
                            lblStatus.Text = $"Index bakımı yapılıyor... ({executedCount}/{dgvIndexes.Rows.Count})";
                            Application.DoEvents();
                        }
                    }
                    
                    SqlHelper.ConnectionString = currentDB;
                    
                    MessageBox.Show($"{executedCount} index bakım işlemi tamamlandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblStatus.Text = $"Bağlı: {txtServer.Text}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Bağlı: {txtServer.Text}";
            }
        }

        private void btnRefreshUsers_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Bağlı kullanıcılar yükleniyor...";
                DataTable dt = SqlHelper.ExecuteQuery(SqlQueries.ConnectedUsers);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvConnectedUsers.DataSource = dt;
                    dgvConnectedUsers.AutoResizeColumns();
                }
                lblStatus.Text = $"Bağlı: {txtServer.Text} - {dt?.Rows.Count ?? 0} kullanıcı grubu";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Bağlı: {txtServer.Text}";
            }
        }

        private void TurkcelestirKolonlari(DataTable dt)
        {
            if (dt == null) return;

            var kolonCeviri = new Dictionary<string, string>
            {
                // Aktif Bağlantılar
                { "Session ID", "Oturum ID" },
                { "Login Name", "Kullanıcı Adı" },
                { "Host Name", "Host Adı" },
                { "Program Name", "Program Adı" },
                { "Status", "Durum" },
                { "Database", "Veritabanı" },
                { "Command", "Komut" },
                { "CPU Time", "CPU Zamanı" },
                { "Total Elapsed Time", "Toplam Geçen Süre" },
                { "Logical Reads", "Mantıksal Okuma" },
                { "Reads", "Okuma" },
                { "Writes", "Yazma" },
                { "Blocking Session", "Bloke Eden Oturum" },
                { "Query Text", "Sorgu Metni" },
                
                // TempDB
                { "File Name", "Dosya Adı" },
                { "Physical Path", "Fiziksel Yol" },
                { "Size (MB)", "Boyut (MB)" },
                { "Free Space (MB)", "Boş Alan (MB)" },
                { "Used Space (MB)", "Kullanılan Alan (MB)" },
                { "Temporary Table Name", "Geçici Tablo Adı" },
                { "Row Count", "Satır Sayısı" },
                { "Used Space (KB)", "Kullanılan Alan (KB)" },
                { "Reserved Space (KB)", "Ayrılan Alan (KB)" },
                { "Database ID", "Veritabanı ID" },
                { "Total User Objects (MB)", "Toplam Kullanıcı Nesneleri (MB)" },
                { "Net User Objects (MB)", "Net Kullanıcı Nesneleri (MB)" },
                { "Total Internal Objects (MB)", "Toplam İç Nesneler (MB)" },
                { "Net Internal Objects (MB)", "Net İç Nesneler (MB)" },
                { "Total Allocation (MB)", "Toplam Ayrılan (MB)" },
                { "Net Allocation (MB)", "Net Ayrılan (MB)" },
                
                // Buffer Pool
                { "Database Name", "Veritabanı Adı" },
                { "Pages in Buffer", "Bellekteki Sayfa" },
                { "Buffer Size (MB)", "Bellek Boyutu (MB)" },
                { "Object Name", "Nesne Adı" },
                { "Object Type", "Nesne Tipi" },
                { "Index Name", "Index Adı" },
                { "Index Type", "Index Tipi" },
                { "Cached Pages Count", "Önbelleğe Alınan Sayfa" },
                { "Cached Pages (MB)", "Önbelleğe Alınan (MB)" },
                
                // Veritabanı Boyutları
                { "State", "Durum" },
                { "Recovery Model", "Kurtarma Modeli" },
                { "Total Size (MB)", "Toplam Boyut (MB)" },
                { "Data Size (MB)", "Data Boyutu (MB)" },
                { "Data Used (MB)", "Kullanılan Data (MB)" },
                { "Log Size (MB)", "Log Boyutu (MB)" },
                { "Log Used (MB)", "Kullanılan Log (MB)" },
                
                // Tablo Boyutları
                { "Table Name", "Tablo Adı" },
                { "Schema Name", "Şema Adı" },
                { "Total Space (MB)", "Toplam Alan (MB)" },
                { "Unused Space (MB)", "Boş Alan (MB)" },
                
                // Index Bakımı
                { "Table", "Tablo" },
                { "Schema", "Şema" },
                { "Fragmentation %", "Parçalanma %" },
                { "Recommended Action", "Önerilen İşlem" },
                
                // Bağlı Kullanıcılar
                { "Session Count", "Oturum Sayısı" }
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



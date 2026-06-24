using System;
using System.Data;
using System.Windows.Forms;

namespace SQL_EYES
{
    public partial class Frm_Security : Form
    {
        private Frm_Dashboard dashboardForm;

        public Frm_Security()
        {
            InitializeComponent();
        }

        public Frm_Security(Frm_Dashboard dashboard) : this()
        {
            dashboardForm = dashboard;
        }

        private void Frm_Security_Load(object sender, EventArgs e)
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

        private void btnServerLogins_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Server login'leri yükleniyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT 
                    sp.name AS [Login Name],
                    sp.type_desc AS [Login Type],
                    sp.create_date AS [Created],
                    sp.modify_date AS [Modified],
                    CASE WHEN sp.is_disabled = 1 THEN 'Yes' ELSE 'No' END AS [Disabled],
                    sp.default_database_name AS [Default Database],
                    sp.default_language_name AS [Default Language]
                FROM sys.server_principals sp
                WHERE sp.type IN ('S', 'U', 'G')
                ORDER BY sp.name";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - {dt.Rows.Count} login";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnDatabaseUsers_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Veritabaný kullanýcýlarý yükleniyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT 
                    DB_NAME() AS [Database],
                    dp.name AS [User Name],
                    dp.type_desc AS [User Type],
                    dp.create_date AS [Created],
                    dp.modify_date AS [Modified],
                    ISNULL(USER_NAME(dp.owning_principal_id), '') AS [Schema Owner]
                FROM sys.database_principals dp
                WHERE dp.type IN ('S', 'U', 'G')
                    AND dp.name NOT IN ('dbo', 'guest', 'INFORMATION_SCHEMA', 'sys')
                ORDER BY dp.name";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - {dt.Rows.Count} kullanýcý";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnServerRoles_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Server rolleri yükleniyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT 
                    r.name AS [Role Name],
                    ISNULL(m.name, '') AS [Member Name],
                    m.type_desc AS [Member Type]
                FROM sys.server_role_members rm
                RIGHT JOIN sys.server_principals r ON rm.role_principal_id = r.principal_id
                LEFT JOIN sys.server_principals m ON rm.member_principal_id = m.principal_id
                WHERE r.type = 'R'
                ORDER BY r.name, m.name";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - Server rolleri";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnDatabaseRoles_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Veritabaný rolleri yükleniyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT 
                    r.name AS [Role Name],
                    ISNULL(m.name, '') AS [Member Name],
                    m.type_desc AS [Member Type]
                FROM sys.database_role_members rm
                RIGHT JOIN sys.database_principals r ON rm.role_principal_id = r.principal_id
                LEFT JOIN sys.database_principals m ON rm.member_principal_id = m.principal_id
                WHERE r.type = 'R'
                ORDER BY r.name, m.name";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - Veritabaný rolleri";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Baðlý: {GetServerName()}";
            }
            finally { Cursor = Cursors.Default; }
        }

        private void btnPermissions_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Ýzinler yükleniyor...";
                Cursor = Cursors.WaitCursor;

                string query = @"
                SELECT 
                    pr.name AS [Principal Name],
                    pr.type_desc AS [Principal Type],
                    pe.state_desc AS [Permission State],
                    pe.permission_name AS [Permission],
                    SCHEMA_NAME(o.schema_id) + '.' + o.name AS [Object],
                    o.type_desc AS [Object Type]
                FROM sys.database_permissions pe
                INNER JOIN sys.database_principals pr ON pe.grantee_principal_id = pr.principal_id
                LEFT JOIN sys.objects o ON pe.major_id = o.object_id
                WHERE pr.name NOT IN ('public', 'dbo', 'guest', 'INFORMATION_SCHEMA', 'sys')
                ORDER BY pr.name, pe.permission_name";

                DataTable dt = SqlHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    TurkcelestirKolonlari(dt);
                    dgvResults.DataSource = dt;
                    dgvResults.AutoResizeColumns();
                    lblStatus.Text = $"Baðlý: {GetServerName()} - {dt.Rows.Count} izin";
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
                { "Login Name", "Login Adý" },
                { "Login Type", "Login Tipi" },
                { "Created", "Oluþturma Tarihi" },
                { "Modified", "Deðiþtirme Tarihi" },
                { "Disabled", "Devre Dýþý" },
                { "Default Database", "Varsayýlan Veritabaný" },
                { "Default Language", "Varsayýlan Dil" },
                { "Database", "Veritabaný" },
                { "User Name", "Kullanýcý Adý" },
                { "User Type", "Kullanýcý Tipi" },
                { "Schema Owner", "Þema Sahibi" },
                { "Role Name", "Rol Adý" },
                { "Member Name", "Üye Adý" },
                { "Member Type", "Üye Tipi" },
                { "Principal Name", "Asýl Adý" },
                { "Principal Type", "Asýl Tipi" },
                { "Permission State", "Ýzin Durumu" },
                { "Permission", "Ýzin" },
                { "Object", "Nesne" },
                { "Object Type", "Nesne Tipi" }
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

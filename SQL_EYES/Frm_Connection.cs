using System;
using System.Windows.Forms;

namespace SQL_EYES
{
    public partial class Frm_Connection : Form
    {
        public Frm_Connection()
        {
            InitializeComponent();
        }

        private void Frm_Connection_Load(object sender, EventArgs e)
        {
            chkIntegratedSecurity.Checked = true;
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
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Baðlantý baþarýsýz! Lütfen bilgileri kontrol edin.", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Baðlantý hatasý: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

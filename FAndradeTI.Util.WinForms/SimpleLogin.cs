using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FAndradeTI.Util.WinForms
{
    public partial class SimpleLogin : Form
    {
        private string login;
        private string pwd;

        public SimpleLogin(string text, string emailFrom)
        {
            InitializeComponent();

            this.Text = text;
            txtUser.Text = emailFrom;
            this.DialogResult = DialogResult.Cancel;
        }

        public string Login { get => login; set => login = value; }
        public string Pwd { get => pwd; set => pwd = value; }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPwd.Text))
            {
                MessageBox.Show("Please inform your password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            login = txtUser.Text;
            pwd = txtPwd.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

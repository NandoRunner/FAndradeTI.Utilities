using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FAndradeTI.Util.WinForms
{
    public partial class FrmFolderInOut : FAndradeTI.Util.WinForms.FrmBase
    {
        private readonly int myWidth;
        private readonly int txtWidth;

        public FrmFolderInOut()
        {
            InitializeComponent();

            this.myWidth = this.Width;
            this.txtWidth = txtInput.Width;
        }

        private void btnFolderSearchInput_Click(object sender, EventArgs e)
        {
            txtInput.Text = btnFolderOpenInput.OpenFolder = btnFolderSearchInput.SearchFolder;
            TsInfo.Text = "Search input!";
        }

        private void btnFolderSearchOutput_Click(object sender, EventArgs e)
        {
            txtOutput.Text = btnFolderOpenOutput.OpenFolder = btnFolderSearchOutput.SearchFolder;
            TsInfo.Text = "Search output!";
        }

        private void btnFolderOpenInput_Click(object sender, EventArgs e)
        {
            TsInfo.Text = "Open input!";
        }

        private void btnFolderOpenOutput_Click(object sender, EventArgs e)
        {
            TsInfo.Text = "Open output!";
        }

        private void FrmFolderInOut_Resize(object sender, EventArgs e)
        {
            txtInput.Width = txtOutput.Width = this.txtWidth + this.Width - this.myWidth;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmFolderInOut_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;  
using System.Collections.Generic;  
using System.Text;  
using System.Drawing;  
using System.Data;  
using System.Windows.Forms;  
using System.Drawing.Drawing2D;  
  
  
namespace FAndradeTI.Util.WinForms
{
    public class ButtonClose : System.Windows.Forms.Button
    {
        public string SearchFolder { get; set;  }
        
        public int borderWidth = 2;
        public Color borderColor = Color.Transparent;


        public ButtonClose()
        {
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Image = global::FAndradeTI.Util.WinForms.Properties.Resources.close_32;
            this.UseVisualStyleBackColor = true;
            this.Name = "btnClose";
            this.Size = new System.Drawing.Size(40, 40);
            this.UseVisualStyleBackColor = false;
            this.Click += new System.EventHandler(this.BtnClose_Click);
            this.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Text = string.Empty;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja mesmo sair?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }



    }
}
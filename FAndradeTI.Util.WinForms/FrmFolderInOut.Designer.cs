using System.Drawing;

namespace FAndradeTI.Util.WinForms
{
    partial class FrmFolderInOut
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFolderInOut));
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFolderOpenOutput = new FAndradeTI.Util.WinForms.ButtonFolderOpen();
            this.btnFolderOpenInput = new FAndradeTI.Util.WinForms.ButtonFolderOpen();
            this.btnFolderSearchOutput = new FAndradeTI.Util.WinForms.ButtonFolderSearch();
            this.btnFolderSearchInput = new FAndradeTI.Util.WinForms.ButtonFolderSearch();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new FAndradeTI.Util.WinForms.ButtonClose();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(83, 13);
            this.txtInput.Margin = new System.Windows.Forms.Padding(32, 14, 32, 14);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(594, 24);
            this.txtInput.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(32, 0, 32, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input:";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnFolderOpenOutput);
            this.panel1.Controls.Add(this.btnFolderOpenInput);
            this.panel1.Controls.Add(this.btnFolderSearchOutput);
            this.panel1.Controls.Add(this.btnFolderSearchInput);
            this.panel1.Controls.Add(this.txtOutput);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtInput);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(32, 14, 32, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(774, 96);
            this.panel1.TabIndex = 1;
            // 
            // btnFolderOpenOutput
            // 
            this.btnFolderOpenOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFolderOpenOutput.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFolderOpenOutput.BorderColor = System.Drawing.Color.Transparent;
            this.btnFolderOpenOutput.BorderWidth = 2;
            this.btnFolderOpenOutput.ButtonShape = FAndradeTI.Util.WinForms.ButtonFolderOpen.ButtonsShapes.Rect;
            this.btnFolderOpenOutput.ButtonText = "";
            this.btnFolderOpenOutput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFolderOpenOutput.EndColor = System.Drawing.Color.MidnightBlue;
            this.btnFolderOpenOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFolderOpenOutput.GradientAngle = 90;
            this.btnFolderOpenOutput.Image = ((System.Drawing.Image)(resources.GetObject("btnFolderOpenOutput.Image")));
            this.btnFolderOpenOutput.Location = new System.Drawing.Point(729, 52);
            this.btnFolderOpenOutput.MouseClickColor1 = System.Drawing.Color.Yellow;
            this.btnFolderOpenOutput.MouseClickColor2 = System.Drawing.Color.Red;
            this.btnFolderOpenOutput.MouseHoverColor1 = System.Drawing.Color.Turquoise;
            this.btnFolderOpenOutput.MouseHoverColor2 = System.Drawing.Color.DarkSlateGray;
            this.btnFolderOpenOutput.Name = "btnFolderOpenOutput";
            this.btnFolderOpenOutput.OpenFolder = null;
            this.btnFolderOpenOutput.ShowButtontext = false;
            this.btnFolderOpenOutput.Size = new System.Drawing.Size(32, 28);
            this.btnFolderOpenOutput.StartColor = System.Drawing.Color.DodgerBlue;
            this.btnFolderOpenOutput.TabIndex = 7;
            this.btnFolderOpenOutput.TextLocation_X = 9;
            this.btnFolderOpenOutput.TextLocation_Y = 14;
            this.btnFolderOpenOutput.Transparent1 = 250;
            this.btnFolderOpenOutput.Transparent2 = 250;
            this.btnFolderOpenOutput.UseVisualStyleBackColor = false;
            this.btnFolderOpenOutput.Click += new System.EventHandler(this.btnFolderOpenOutput_Click);
            // 
            // btnFolderOpenInput
            // 
            this.btnFolderOpenInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFolderOpenInput.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFolderOpenInput.BorderColor = System.Drawing.Color.Transparent;
            this.btnFolderOpenInput.BorderWidth = 2;
            this.btnFolderOpenInput.ButtonShape = FAndradeTI.Util.WinForms.ButtonFolderOpen.ButtonsShapes.Rect;
            this.btnFolderOpenInput.ButtonText = "";
            this.btnFolderOpenInput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFolderOpenInput.EndColor = System.Drawing.Color.MidnightBlue;
            this.btnFolderOpenInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFolderOpenInput.GradientAngle = 90;
            this.btnFolderOpenInput.Image = ((System.Drawing.Image)(resources.GetObject("btnFolderOpenInput.Image")));
            this.btnFolderOpenInput.Location = new System.Drawing.Point(729, 11);
            this.btnFolderOpenInput.MouseClickColor1 = System.Drawing.Color.Yellow;
            this.btnFolderOpenInput.MouseClickColor2 = System.Drawing.Color.Red;
            this.btnFolderOpenInput.MouseHoverColor1 = System.Drawing.Color.Turquoise;
            this.btnFolderOpenInput.MouseHoverColor2 = System.Drawing.Color.DarkSlateGray;
            this.btnFolderOpenInput.Name = "btnFolderOpenInput";
            this.btnFolderOpenInput.OpenFolder = null;
            this.btnFolderOpenInput.ShowButtontext = false;
            this.btnFolderOpenInput.Size = new System.Drawing.Size(32, 28);
            this.btnFolderOpenInput.StartColor = System.Drawing.Color.DodgerBlue;
            this.btnFolderOpenInput.TabIndex = 6;
            this.btnFolderOpenInput.TextLocation_X = 9;
            this.btnFolderOpenInput.TextLocation_Y = 14;
            this.btnFolderOpenInput.Transparent1 = 250;
            this.btnFolderOpenInput.Transparent2 = 250;
            this.btnFolderOpenInput.UseVisualStyleBackColor = false;
            this.btnFolderOpenInput.Click += new System.EventHandler(this.btnFolderOpenInput_Click);
            // 
            // btnFolderSearchOutput
            // 
            this.btnFolderSearchOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFolderSearchOutput.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFolderSearchOutput.BorderColor = System.Drawing.Color.Transparent;
            this.btnFolderSearchOutput.BorderWidth = 2;
            this.btnFolderSearchOutput.ButtonShape = FAndradeTI.Util.WinForms.ButtonFolderSearch.ButtonsShapes.Rect;
            this.btnFolderSearchOutput.ButtonText = "";
            this.btnFolderSearchOutput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFolderSearchOutput.EndColor = System.Drawing.Color.MidnightBlue;
            this.btnFolderSearchOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFolderSearchOutput.GradientAngle = 90;
            this.btnFolderSearchOutput.Image = ((System.Drawing.Image)(resources.GetObject("btnFolderSearchOutput.Image")));
            this.btnFolderSearchOutput.Location = new System.Drawing.Point(682, 52);
            this.btnFolderSearchOutput.Margin = new System.Windows.Forms.Padding(32, 14, 32, 14);
            this.btnFolderSearchOutput.MouseClickColor1 = System.Drawing.Color.Yellow;
            this.btnFolderSearchOutput.MouseClickColor2 = System.Drawing.Color.Red;
            this.btnFolderSearchOutput.MouseHoverColor1 = System.Drawing.Color.Turquoise;
            this.btnFolderSearchOutput.MouseHoverColor2 = System.Drawing.Color.DarkSlateGray;
            this.btnFolderSearchOutput.Name = "btnFolderSearchOutput";
            this.btnFolderSearchOutput.SearchFolder = null;
            this.btnFolderSearchOutput.ShowButtontext = false;
            this.btnFolderSearchOutput.Size = new System.Drawing.Size(32, 28);
            this.btnFolderSearchOutput.StartColor = System.Drawing.Color.DodgerBlue;
            this.btnFolderSearchOutput.TabIndex = 5;
            this.btnFolderSearchOutput.TextLocation_X = 9;
            this.btnFolderSearchOutput.TextLocation_Y = 14;
            this.btnFolderSearchOutput.Transparent1 = 250;
            this.btnFolderSearchOutput.Transparent2 = 250;
            this.btnFolderSearchOutput.UseVisualStyleBackColor = false;
            this.btnFolderSearchOutput.Click += new System.EventHandler(this.btnFolderSearchOutput_Click);
            // 
            // btnFolderSearchInput
            // 
            this.btnFolderSearchInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFolderSearchInput.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFolderSearchInput.BorderColor = System.Drawing.Color.Transparent;
            this.btnFolderSearchInput.BorderWidth = 2;
            this.btnFolderSearchInput.ButtonShape = FAndradeTI.Util.WinForms.ButtonFolderSearch.ButtonsShapes.Rect;
            this.btnFolderSearchInput.ButtonText = "";
            this.btnFolderSearchInput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFolderSearchInput.EndColor = System.Drawing.Color.MidnightBlue;
            this.btnFolderSearchInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFolderSearchInput.GradientAngle = 90;
            this.btnFolderSearchInput.Image = ((System.Drawing.Image)(resources.GetObject("btnFolderSearchInput.Image")));
            this.btnFolderSearchInput.Location = new System.Drawing.Point(682, 11);
            this.btnFolderSearchInput.Margin = new System.Windows.Forms.Padding(32, 14, 32, 14);
            this.btnFolderSearchInput.MouseClickColor1 = System.Drawing.Color.Yellow;
            this.btnFolderSearchInput.MouseClickColor2 = System.Drawing.Color.Red;
            this.btnFolderSearchInput.MouseHoverColor1 = System.Drawing.Color.Turquoise;
            this.btnFolderSearchInput.MouseHoverColor2 = System.Drawing.Color.DarkSlateGray;
            this.btnFolderSearchInput.Name = "btnFolderSearchInput";
            this.btnFolderSearchInput.SearchFolder = null;
            this.btnFolderSearchInput.ShowButtontext = false;
            this.btnFolderSearchInput.Size = new System.Drawing.Size(32, 28);
            this.btnFolderSearchInput.StartColor = System.Drawing.Color.DodgerBlue;
            this.btnFolderSearchInput.TabIndex = 4;
            this.btnFolderSearchInput.TextLocation_X = 9;
            this.btnFolderSearchInput.TextLocation_Y = 14;
            this.btnFolderSearchInput.Transparent1 = 250;
            this.btnFolderSearchInput.Transparent2 = 250;
            this.btnFolderSearchInput.UseVisualStyleBackColor = false;
            this.btnFolderSearchInput.Click += new System.EventHandler(this.btnFolderSearchInput_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(83, 53);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(32, 14, 32, 14);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(594, 24);
            this.txtOutput.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(32, 0, 32, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Output:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(5, 101);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(774, 76);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(722, 17);
            this.btnClose.Name = "btnClose";
            this.btnClose.SearchFolder = null;
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(5, 177);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(774, 362);
            this.panel3.TabIndex = 3;
            // 
            // FrmFolderInOut
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(43, 24, 43, 24);
            this.Name = "FrmFolderInOut";
            this.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.Text = "FrmFolderInOut";
            this.Load += new System.EventHandler(this.FrmFolderInOut_Load);
            this.Resize += new System.EventHandler(this.FrmFolderInOut_Resize);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label label2;
        private ButtonFolderSearch btnFolderSearchOutput;
        private ButtonFolderSearch btnFolderSearchInput;
        private ButtonFolderOpen btnFolderOpenOutput;
        private ButtonFolderOpen btnFolderOpenInput;

        public void SetPanelBackgroundColor(Color c)
        {
            this.panel1.BackColor = c;
        }

        private System.Windows.Forms.Panel panel2;
        private ButtonClose btnClose;
        private System.Windows.Forms.Panel panel3;
    }
}

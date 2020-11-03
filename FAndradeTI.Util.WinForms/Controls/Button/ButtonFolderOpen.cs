using System;  
using System.Collections.Generic;  
using System.Text;  
using System.Drawing;  
using System.Data;  
using System.Windows.Forms;  
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace FAndradeTI.Util.WinForms
{
    public class ButtonFolderOpen: System.Windows.Forms.Button
    {
        public string OpenFolder { get; set;  }
        
        Color clr1, clr2;
        private Color color1 = Color.DodgerBlue;
        private Color color2 = Color.MidnightBlue;
        private Color m_hovercolor1 = Color.Turquoise;
        private Color m_hovercolor2 = Color.DarkSlateGray;
        private int color1Transparent = 250;
        private int color2Transparent = 250;
        private Color clickcolor1 = Color.Yellow;
        private Color clickcolor2 = Color.Red;
        private int angle = 90;
        private int textX = 100;
        private int textY = 25;
        private String text = "";
        public Color buttonborder_1 = Color.FromArgb(220, 220, 220);
        public Color buttonborder_2 = Color.FromArgb(150, 150, 150);
        public Boolean showButtonText = false;
        public int borderWidth = 2;
        public Color borderColor = Color.Transparent;

        public enum ButtonsShapes
        {
            Rect,
            RoundRect,
            Circle
        }

        ButtonsShapes buttonShape;

        public ButtonsShapes ButtonShape
        {
            get { return buttonShape; }
            set
            {
                buttonShape = value; Invalidate();
            }
        }

        public String ButtonText
        {
            get { return text; }
            set { text = value; Invalidate(); }
        }

        public int BorderWidth
        {
            get { return borderWidth; }
            set { borderWidth = value; Invalidate(); }
        }


        void SetBorderColor(Color bdrColor)
        {
            int red = bdrColor.R - 40;
            int green = bdrColor.G - 40;
            int blue = bdrColor.B - 40;
            if (red < 0)
                red = 0;
            if (green < 0)
                green = 0;
            if (blue < 0)
                blue = 0;

            buttonborder_1 = Color.FromArgb(red, green, blue);
            buttonborder_2 = bdrColor;
        }


        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                if (borderColor == Color.Transparent)
                {
                    buttonborder_1 = Color.FromArgb(220, 220, 220);
                    buttonborder_2 = Color.FromArgb(150, 150, 150);
                }
                else
                {
                    SetBorderColor(borderColor);
                }

            }
        }

        public Color StartColor
        {
            get { return color1; }
            set { color1 = value; Invalidate(); }
        }
        public Color EndColor
        {
            get { return color2; }
            set { color2 = value; Invalidate(); }
        }
        public Color MouseHoverColor1
        {
            get { return m_hovercolor1; }
            set { m_hovercolor1 = value; Invalidate(); }
        }
        public Color MouseHoverColor2
        {
            get { return m_hovercolor2; }
            set { m_hovercolor2 = value; Invalidate(); }
        }
        public Color MouseClickColor1
        {
            get { return clickcolor1; }
            set { clickcolor1 = value; Invalidate(); }
        }
        public Color MouseClickColor2
        {
            get { return clickcolor2; }
            set { clickcolor2 = value; Invalidate(); }
        }

        public int Transparent1
        {
            get { return color1Transparent; }
            set
            {
                color1Transparent = value;
                if (color1Transparent > 255)
                {
                    color1Transparent = 255;
                    Invalidate();
                }
                else
                    Invalidate();
            }
        }

        public int Transparent2
        {
            get { return color2Transparent; }
            set
            {
                color2Transparent = value;
                if (color2Transparent > 255)
                {
                    color2Transparent = 255;
                    Invalidate();
                }
                else
                    Invalidate();
            }
        }

        public int GradientAngle
        {
            get { return angle; }
            set { angle = value; Invalidate(); }
        }

        public int TextLocation_X
        {
            get { return textX; }
            set { textX = value; Invalidate(); }
        }
        public int TextLocation_Y
        {
            get { return textY; }
            set { textY = value; Invalidate(); }
        }

        public Boolean ShowButtontext
        {
            get { return showButtonText; }
            set { showButtonText = value; Invalidate(); }
        }

        public ButtonFolderOpen()
        {
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Image = global::FAndradeTI.Util.WinForms.Properties.Resources.folder_open_16;
            this.UseVisualStyleBackColor = true;
            this.Name = "btnFolderOpen";
            this.Size = new System.Drawing.Size(32, 32);
            this.UseVisualStyleBackColor = false;
            this.Click += new System.EventHandler(this.BtnOpen_Click);
            this.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.text = string.Empty;
        }


        //method mouse enter  
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            clr1 = color1;
            clr2 = color2;
            color1 = m_hovercolor1;
            color2 = m_hovercolor2;
        }
        //method mouse leave  
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            color1 = clr1;
            color2 = clr2;
            SetBorderColor(borderColor);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            color1 = clickcolor1;
            color2 = clickcolor2;

            int red = borderColor.R - 40;
            int green = borderColor.G - 40;
            int blue = borderColor.B - 40;
            if (red < 0)
                red = 0;
            if (green < 0)
                green = 0;
            if (blue < 0)
                blue = 0;

            buttonborder_2 = Color.FromArgb(red, green, blue);
            buttonborder_1 = borderColor;
            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            OnMouseLeave(mevent);
            color1 = clr1;
            color2 = clr2;
            SetBorderColor(borderColor);
            this.Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            color1 = clr1;
            color2 = clr2;
            this.Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            textX = (int)((this.Width / 3) - 1);
            textY = (int)((this.Height / 3) + 5);
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                var proc = new ProcessStartInfo
                {
                    FileName = "explorer.exe",
                    Arguments = this.OpenFolder
                };
                Process.Start(proc);
            }
            catch
            {
                throw;
            }
        }



    }
}
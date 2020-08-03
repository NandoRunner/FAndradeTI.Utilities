using System;
using System.Windows.Forms;

namespace FAndradeTI.Util.WinForms
{
    public static class StatusStripControl
    {
        public static string FormName = "FrmMain";

        public static string StatusStripName = "statusStrip1";

        public static string ProgressBarName = "tsProgressBar";

        public static string LabelName = "tsInfo";

        public static void InitProgressBar(int maxValue)
        {
            
            Application.OpenForms[FormName].BeginInvoke((Action)(() => ((ToolStripProgressBar)((StatusStrip)Application.OpenForms[FormName].Controls[StatusStripName]).Items[ProgressBarName]).Maximum = maxValue));

            Application.OpenForms[FormName].BeginInvoke((Action)(() => ((ToolStripProgressBar)((StatusStrip)Application.OpenForms[FormName].Controls[StatusStripName]).Items[ProgressBarName]).Value = 0));
        }

        public static void InitStatusStrip(string labelText, int maxValue)
        {
            try
            {
                UpdateLabel(labelText);

                InitProgressBar(maxValue);
            }
            catch
            {
                throw;
            }
        }

        public static void UpdateProgressBar()
        {
            UpdateProgressBar(1);
        }

        public static void UpdateProgressBar(int value)
        {
            if (((ToolStripProgressBar)((StatusStrip)Application.OpenForms[FormName].Controls[StatusStripName]).Items[ProgressBarName]).Maximum < ((ToolStripProgressBar)((StatusStrip)Application.OpenForms[FormName].Controls[StatusStripName]).Items[ProgressBarName]).Value + value)
            {
                Application.OpenForms[FormName].BeginInvoke((Action)(() => ((ToolStripProgressBar)((StatusStrip)Application.OpenForms[FormName].Controls[StatusStripName]).Items[ProgressBarName]).Value = ((ToolStripProgressBar)((StatusStrip)Application.OpenForms[FormName].Controls[StatusStripName]).Items[ProgressBarName]).Maximum));
                return;
            }

            Application.OpenForms[FormName].BeginInvoke((Action)(() => ((ToolStripProgressBar)((StatusStrip)Application.OpenForms[FormName].Controls[StatusStripName]).Items[ProgressBarName]).Value += value));
        }

        public static void UpdateLabel(string labelText)
        {
            try
            {
                Application.OpenForms[FormName].BeginInvoke((Action)(() => ((ToolStripStatusLabel)((StatusStrip)Application.OpenForms[FormName].Controls[StatusStripName]).Items[LabelName]).Text = labelText));
            }
            catch
            {
                throw;
            }
        }
    }
}

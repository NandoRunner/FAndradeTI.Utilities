using System;
using System.Windows.Forms;

namespace FAndradeTI.Util.WinForms
{
    public static class TabPageControl
    {
        public static string FormName = "FrmMain";

        public static string TabControlName = "tabMain";

        public static string TabPageName;

        public static void SetProgressBarValue(string name, int value)
        {
            ((ProgressBar)GetTabPage().Controls[name]).Value = value;
        }

        public static void SetLabelText(string name, string text)
        {
            ((Label)GetTabPage().Controls[name]).SafeInvoke(c => c.Text = text);
        }

        public static void SetTextBoxText(string name, string text)
        {
            ((TextBox)GetTabPage().Controls[name]).Text = text;
        }

        private static TabPage GetTabPage()
        {
            return (TabPage)Application.OpenForms[FormName].Controls[TabControlName].Controls[TabPageName];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace FAndradeTI.Util.WinForms
{
    public static class FormControl
    {
        public static string FormName = "FrmMain";
        public static string LabelName = "lblInfo";
        public static string TextBoxName { get; set; }
        public static string ListBoxName { get; set; }

        public static void ClearListBox()
        {
            try
            {
                ((ListBox)Application.OpenForms[FormName].Controls[ListBoxName]).Items.Clear();
            }
            catch
            {
                throw;
            }
        }

        public static void UpdateListBox(string item)
        {
            try
            {
                ((ListBox)Application.OpenForms[FormName].Controls[ListBoxName]).Items.Add(item);
                ((ListBox)Application.OpenForms[FormName].Controls[ListBoxName]).Refresh();
            }
            catch
            {
                throw;
            }
        }

        public static void UpdateListBox(List<string> list)
        {
            try
            {
                ((ListBox)Application.OpenForms[FormName].Controls[ListBoxName]).DataSource = list;
                ((ListBox)Application.OpenForms[FormName].Controls[ListBoxName]).Refresh();
            }
            catch
            {
                throw;
            }
        }

        public static void UpdateLabel(string text)
        {
            UpdateLabel(FormName, text, LabelName);
        }
        
        public static void UpdateLabel(string formName, string text)
        {
            UpdateLabel(formName, text, LabelName);
        }

        public static void UpdateLabel(string formName, string text, string name)
        {
            try
            {
                ((Label)Application.OpenForms[formName].Controls[name]).Text = text;
                ((Label)Application.OpenForms[formName].Controls[name]).Refresh();
            }
            catch
            {
                throw;
            }
        }

        public static void UpdateTextBox(string text)
        {
            UpdateTextBox(FormName, text, TextBoxName);
        }

        public static void UpdateTextBox(string formName, string text)
        {
            UpdateTextBox(formName, text, LabelName);
        }

        public static void UpdateTextBox(string formName, string text, string name)
        {
            try
            {
                ((TextBox)Application.OpenForms[formName].Controls[name]).Text = text;
                ((TextBox)Application.OpenForms[formName].Controls[name]).Refresh();
            }
            catch
            {
                throw;
            }
        }

        public static List<string> CreateListMonth()
        {
            var ret = new List<string>();

            for (int i = 1; i <= 12; i++)
                ret.Add(i.ToString("00", CultureInfo.CurrentCulture));

            return ret;
        }

        public static List<string> CreateListYear()
        {
            return CreateListYear(2017, DateTime.Now.Year);
        }

        public static List<string> CreateListYear(int minYear, int maxYear)
        {
            var ret = new List<string>();

            for (int i = minYear; i <= maxYear; i++)
                ret.Add(i.ToString("0000", CultureInfo.CurrentCulture));

            return ret;
        }
    }
}

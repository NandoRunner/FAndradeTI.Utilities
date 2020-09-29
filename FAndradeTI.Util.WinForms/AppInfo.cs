using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FAndradeTI.Util.WinForms
{
    public static class AppInfo
    {
        public static string GetFullTitle()
        {
            return $"{Assembly.GetCallingAssembly().GetCustomAttribute<AssemblyTitleAttribute>().Title}{new String(' ', 10)}v{Application.ProductVersion}{new String(' ', 10)}{Application.CompanyName}";
        }

        public static string GetTitle()
        {
            return $"{Assembly.GetCallingAssembly().GetCustomAttribute<AssemblyTitleAttribute>().Title}{new String(' ', 10)}v{Application.ProductVersion}";

        }
    }
}

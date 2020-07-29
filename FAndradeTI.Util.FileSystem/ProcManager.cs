using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAndradeTI.Util.FileSystem
{
    public static class ProcManager
    {
        public static void KillExcelFileProcess()
        {
            KillFileProcess("EXCEL");
        }

        public static void KillFileProcess(string name)
        {
            var processes = from p in Process.GetProcessesByName(name)
                            select p;

            foreach (var process in processes)
            {
                if (string.IsNullOrEmpty(process.MainWindowTitle))
                    process.Kill();
            }
        }

        public static void RunGitBash(string path)
        {
            Run(@"C:\Program Files\Git\usr\bin\bash.exe", path, " --login -i ");
        }

        public static void RunVSCode(string path)
        {
            Run("code.exe", path);
        }

        public static void RunExplorer(string path)
        {
            Run("explorer.exe", path);
        }

        private static void Run(string command, string args)
        {
            Run(command, null, args);
        }

        private static void Run(string command, string path = null, string args = null)
        {
            var proc = new ProcessStartInfo
            {
                FileName = command,
                Arguments = args,
                WorkingDirectory = path
            };
            Process.Start(proc);
        }

    }
}

using System;
using System.Diagnostics;
using System.Linq;

namespace FAndradeTI.Util.FileSystem
{
    public static class ProcManager
    {
        public static string Message { get; private set; }

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

        public static void RunExplorer(string path)
        {
            Run("explorer.exe", path);
        }

        public static bool RunGitBash(string path)
        {
            var ret = false;
            try
            {
                Run("bash.exe", path, " --login -i ");
                ret = true;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return ret;
        }

        public static void RunGitClone(string path, string args)
        {
            Run("git.exe", path, $" clone {args}");
        }
        public static bool RunVSCode(string path)
        {
            var ret = false;
            try
            {
                Run("code.exe", path);
                ret = true;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return ret;
        }
        private static void Run(string command, string args)
        {
            try
            {
                Run(command, null, args);
            }
            catch
            {
                throw;
            }
        }

        private static void Run(string command, string path = null, string args = null)
        {
            try
            {
                var proc = new ProcessStartInfo
                {
                    FileName = command,
                    Arguments = args,
                    WorkingDirectory = path
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

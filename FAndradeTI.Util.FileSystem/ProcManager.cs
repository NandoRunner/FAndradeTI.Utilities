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

        public static bool RunGitBash(string workingDir)
        {
            var ret = false;
            try
            {
                Run("bash.exe", " --login -i ", workingDir);
                ret = true;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return ret;
        }

        public static bool RunGitClone(string workingDir, string args)
        {
            var ret = false;
            try
            {
                Run("git.exe", $" clone {args}", workingDir);
                ret = true;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return ret;

        }
        public static bool RunVisualStudio(string command)
        {
            var ret = false;
            try
            {
                Run(command, null, null);
                ret = true;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return ret;
        }

        public static bool RunVSCode(string path)
        {
            var ret = false;
            try
            {
                Run("code", path);
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
                Run(command, args, null);
            }
            catch
            {
                throw;
            }
        }
        private static void Run(string command, string args, string workingDir)
        {
            try
            {
                var proc = new ProcessStartInfo
                {
                    FileName = command,
                    WorkingDirectory = workingDir,
                    Arguments = args,
                    WindowStyle = ProcessWindowStyle.Maximized
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

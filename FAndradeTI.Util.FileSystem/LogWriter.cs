using System;
using System.IO;


namespace FAndradeTI.Util.FileSystem
{
    public class LogWriter
    {
        private readonly string m_exePath = string.Empty;
        private readonly string fileName = string.Empty;

        public LogWriter(string path, string name)
        {
            m_exePath = path;
            fileName = name;
        }
        public void LogWrite(string logMessage)
        {
            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + fileName))
                {
                    Log(logMessage, w);
                }
            }
            catch
            {
                throw;
            }
        }

        public static void Log(string logMessage, TextWriter txtWriter)
        {
            if (txtWriter == null) return;

            try
            {
                txtWriter.WriteLine("{0} {1}   : {2}", DateTime.Now.ToShortDateString(),
                    DateTime.Now.ToShortTimeString(), logMessage);
            }
            catch
            {
                throw;
            }
        }
    }
}
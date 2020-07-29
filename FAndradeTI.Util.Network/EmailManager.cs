using System;
using System.Globalization;
using System.Net;
using System.Net.Mail;

namespace FAndradeTI.Util.Network
{
    public class EmailManager
    {
        private readonly string from;
        private readonly string host;
        private readonly string port;
        private readonly string pwd;

        public static string LastErrorMethod { get; set; }

        public static string LastErrorMessage { get; set; }

        public EmailManager(string from, string host, string port, string pwd)
        {
            this.from = from;
            this.host = host;
            this.port = port;
            this.pwd = pwd;
        }

        public bool Send(string subject, string body, string to)
        {
            try
            {
                using (SmtpClient client = new SmtpClient(host, int.Parse(port, CultureInfo.CurrentCulture))
                {
                    Credentials = new NetworkCredential(from, pwd),
                    EnableSsl = true
                })
                {
                    client.Send(from, to, subject, body);
                }
                return true;
            }
            catch (SmtpException ex)
            {
                LastErrorMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
                LastErrorMessage = ex.Message;
                Console.WriteLine(ex.Message);
                return false;
            }

        }
    }
}

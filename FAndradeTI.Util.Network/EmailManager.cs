using System;
using System.Net;
using System.Net.Mail;

namespace FAndradeTI.Util.Network
{
    public class EmailManager
    {
        private readonly string _fromEmail;
        private readonly string _fromName;
        private readonly string _host;
        private readonly int _port;
        private readonly string _pwd;
        private string _attach; 

        public static string LastErrorMethod { get; set; }

        public static string LastErrorMessage { get; set; }
        public string Attach { get => _attach; set => _attach = value; }

        public EmailManager(string fromEmail, string fromName, string host, int port, string pwd)
        {
            _fromEmail = fromEmail;
            _fromName = fromName;
            _host = host;
            _port = port;
            _pwd = pwd;
        }

        public bool Send(string subject, string body, string toEmail, string toName)
        {
            try
            {
                var smtpClient = new SmtpClient(_host)
                {
                    Port = _port,
                    Credentials = new NetworkCredential(_fromEmail, _pwd),
                    EnableSsl = true
                };
                
                var msg = new MailMessage();

                var a = new Attachment(_attach);
                msg.Attachments.Add(a);

                var f = new MailAddress(_fromEmail, _fromName);
                msg.From = f;

                var t = new MailAddress(toEmail, toName);
                msg.To.Add(t);

                msg.Subject = subject;
                msg.Body = body;

                smtpClient.Send(msg);
                return true;
            }
            catch (Exception ex)
            {
                LastErrorMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
                LastErrorMessage = ex.Message;
                Console.WriteLine(ex.Message);
                return false;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAndradeTI.Util.Network
{
    public class GmailManager : EmailManager
    {
        public GmailManager(string fromEmail, string fromName, string pwd) : base(fromEmail, fromName, "smtp.gmail.com", 587, pwd) {}

    }
}

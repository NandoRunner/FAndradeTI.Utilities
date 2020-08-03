using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAndradeTI.Util.Firebase
{
    public static class DataUtil
    {

        public static DateTime TimestampToDateTime(object date)
        {
            return ((Timestamp)date).ToDateTime();
        }
    }
}

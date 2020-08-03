using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAndradeTI.Util.Firebase
{
    public class QueryData
    {
        public QueryData(string whereName, object whereValue)
        {
            this.whereName = whereName;
            this.whereValue = whereValue;
            this.whereValue2 = null;
        }

        public QueryData(string whereName, object whereValue, object whereValue2)
        {
            this.whereName = whereName;
            this.whereValue = whereValue;
            this.whereValue2 = whereValue2;
        }

        public string whereName { get; set; }

        public object whereValue { get; set; }

        public object whereValue2 { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;

namespace FAndradeTI.Util
{
    public static class StringExtension
    {
        private static readonly CultureInfo Ci = CultureInfo.CurrentCulture;

        public static string FirstToUpper(string str)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;

            var firstPart = str.Substring(0, 1).ToUpper(Ci);
            var secondPart = str.Substring(1).ToLower(Ci);
            return firstPart + secondPart;

        }

        public static string LeftZeros(int number)
        {
            return LeftZeros(number, 1);
        }

        public static string LeftZeros(int number, int numZeros)
        {
            return number.ToString("D" + numZeros.ToString(Ci), Ci);
        }

        public static string FormatCurrency(object number)
        {
            return string.Format(Ci, "{0:###,###.00}", number);
        }

        public static string FormatDate(string date)
        {
            return FormatDate("/", date);
        }

        public static string FormatDate(string separator, string date)
        {
            if (string.IsNullOrEmpty(date)) return string.Empty;

            var ret = date.Substring(4, 2) + separator + date.Substring(6, 2) + separator + date.Substring(0, 4);
            return ret;
        }

        public static string JoinItems(List<string> list)
        {
            return JoinItems("\n", list);
        }

        public static string JoinItems(string separator, List<string> list)
        {
            return string.Join(separator, list);
        }
    }
}

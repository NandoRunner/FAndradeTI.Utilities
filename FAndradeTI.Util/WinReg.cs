using System;
using System.Globalization;
using Microsoft.Win32;

namespace FAndradeTI.Util
{
    public static class WinReg
    {
        private static string subKey;
        private static string baseRegistryKey;

        public static string SubKey { get => subKey; set => subKey = value; }
        public static string BaseRegistryKey { get => baseRegistryKey; set => baseRegistryKey = value; }

        public static string Read(string KeyName)
        {
            return Read(KeyName, true);
        }

        public static string Read(string KeyName, bool ToUpper)
        {
            if (string.IsNullOrEmpty(KeyName)) return string.Empty;

            try
            {
                RegistryKey rk = Registry.CurrentUser;
                RegistryKey sk1 = rk.OpenSubKey(SubKey);

                if (sk1 == null)
                {
                    return null;
                }
                else
                {
                    return (string)sk1.GetValue(ToUpper ? KeyName.ToUpper(CultureInfo.CurrentCulture) : KeyName);
                }

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }

        public static bool Write(string KeyName, object Value)
        {
            return Write(KeyName, Value, true);
        }

        public static bool Write(string KeyName, object Value, bool ToUpper)
        {
            if (string.IsNullOrEmpty(KeyName)) return false;

            try
            {
                RegistryKey rk = Registry.CurrentUser;
                RegistryKey sk1 = rk.CreateSubKey(SubKey);

                sk1.SetValue(ToUpper ? KeyName.ToUpper(CultureInfo.CurrentCulture) : KeyName, Value);

                return true;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}

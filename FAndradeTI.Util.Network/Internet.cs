using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;

namespace FAndradeTI.Util.Network
{
    public static class Internet
    {
        public static string LastErrorMethod { get; set; }

        public static string LastErrorMessage { get; set; }

        public static bool ConnectionExists()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com"))
                    return true;
            }
            catch  (WebException ex)
            {
                LastErrorMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
                LastErrorMessage = ex.Message;
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static bool HostExists(string host)
        {
            Ping pinger = new Ping();

            try
            {
                PingReply reply = pinger.Send(host);
                return reply.Status == IPStatus.Success;
            }
            catch (PingException ex)
            {
                LastErrorMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
                LastErrorMessage = ex.Message;
                Console.WriteLine(ex.Message); 
                return false;
            }
            finally
            {
                pinger.Dispose();
            }

        }

        public static IPAddress ParseSingleIPv4Address(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input string must not be null", input);
            }

            var addressBytesSplit = input.Trim().Split('.').ToList();
            if (addressBytesSplit.Count != 4)
            {
                throw new ArgumentException("Input string was not in valid IPV4 format \"a.b.c.d\"", input);
            }

            var addressBytes = new byte[4];
            foreach (var i in Enumerable.Range(0, addressBytesSplit.Count))
            {
                if (!int.TryParse(addressBytesSplit[i], out var parsedInt))
                {
                    throw new FormatException($"Unable to parse integer from {addressBytesSplit[i]}");
                }

                if (0 > parsedInt || parsedInt > 255)
                {
                    throw new ArgumentOutOfRangeException($"{parsedInt} not within required IP address range [0,255]");
                }
                addressBytes[i] = (byte)parsedInt;
            }
            return new IPAddress(addressBytes);
        }
    }
}

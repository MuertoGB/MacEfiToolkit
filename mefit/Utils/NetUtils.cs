// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// NetUtils.cs
// Released under the GNU GLP v3.0

using System.Net;
using System.Net.NetworkInformation;

namespace Mac_EFI_Toolkit.Utils
{
    class NetUtils
    {
        /// <summary>
        /// Checks if a website is available by making a HEAD request to its URL.
        /// </summary>
        /// <param name="strUrl">The URL of the website to check.</param>
        /// <returns>True if the website is available, false otherwise.</returns>
        internal static bool _boolIsWebsiteAvailable(string strUrl)
        {
            try
            {
                WebRequest req;
                req = WebRequest.Create(strUrl);
                req.Timeout = 5000;
                req.Method = "HEAD";
                using (var res = req.GetResponse())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Checks if a network connection is available by attempting to send a ping request to a known IP address.
        /// </summary>
        /// <returns>True if a network connection is available, false otherwise.</returns>
        internal static bool _boolIsNetworkAvailable()
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                return false;
            }
            try
            {
                using (var ping = new Ping())
                {
                    var result = ping.Send("8.8.8.8", 1000);
                    return (result.Status == IPStatus.Success);
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
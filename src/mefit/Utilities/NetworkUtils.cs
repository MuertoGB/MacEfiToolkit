// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// NetworkUtils.cs
// Released under the GNU GLP v3.0

using System;
using System.Net;
using System.Net.NetworkInformation;

namespace Mac_EFI_Toolkit.Utilities
{
    public static class NetworkUtils
    {
        /// <summary>
        /// Checks if a website is available by making a HEAD request to its URL.
        /// </summary>
        /// <param name="url">The URL of the website to check.</param>
        /// <returns>True if the website is available, false otherwise.</returns>
        public static bool IsWebsiteAvailable(string url)
        {
            WebRequest webRequest;

            try
            {
                webRequest = WebRequest.Create(url);
                webRequest.Timeout = 5000;
                webRequest.Method = "HEAD";

                using (WebResponse webResponse = webRequest.GetResponse())
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(IsWebsiteAvailable), e.GetType(), e.Message);
                return false;
            }
        }

        /// <summary>
        /// Checks if a network connection is available by attempting to send a ping request to a known IP address.
        /// </summary>
        /// <returns>True if a network connection is available, false otherwise.</returns>
        public static bool IsNetworkAvailable()
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
                return false;

            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = ping.Send("8.8.8.8", 1000);
                    return (reply.Status == IPStatus.Success);
                }
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(IsNetworkAvailable), e.GetType(), e.Message);
                return false;
            }
        }
    }
}
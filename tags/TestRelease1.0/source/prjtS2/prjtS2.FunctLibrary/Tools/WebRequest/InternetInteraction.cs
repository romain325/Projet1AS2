using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;

namespace prjtS2.FunctLibrary.Tools.WebRequest
{
    /// <summary>
    /// Check For Different Internet Interactions
    /// </summary>
    public static class InternetInteraction
    {
        /// <summary>
        /// Check if Network is up by pinging Google and awaiting an answer
        /// </summary>
        /// <returns>return if we had a response</returns>
        public static bool NetworkStatus()
        {
            try
            {
                Ping myPing = new Ping();
                byte[] buffer = new byte[32];
                PingReply reply = myPing.Send("google.com", 1000, buffer, new PingOptions());
                return (reply.Status == IPStatus.Success);
            }
            catch
            {
                return false;
            }
            
        }

        /// <summary>
        /// !!!!!! NOT SECURE AT ALL !!!!!!!
        /// !Take care in real application, don't check any MetaData so can be a lil program that you don't want to have on your Computer!
        /// just check Head Content-Type (MIME) <-- not secure but better than anything
        /// You can check for Magic Numbers / Key Signature but we aren't doing security yet so it's not important in this case
        /// </summary>
        /// <param name="url">url of the image</param>
        /// <returns>If links ends up by jpg or png</returns>
        public static bool CheckLinkIsJpgOrPng(string url)
        {
            var request = (HttpWebRequest)HttpWebRequest.Create(url);
            var response = request.GetResponse();
            var re = response.ContentType;

            return re == "image/png" || re == "image/jpeg" || re == "image/gif";
        }
    }
}

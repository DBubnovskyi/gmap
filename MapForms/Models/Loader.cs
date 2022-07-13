using System.Net;

namespace MapProcassor.Models
{
    public class Loader
    {
        private readonly static string _userAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
        public static string LoadJson(string url)
        {
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.UserAgent] = _userAgent;
                return client.DownloadString(url);
            }
        }
    }
}

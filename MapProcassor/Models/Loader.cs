using System.Net;

namespace MapProcassor.Models
{
    public class Loader
    {
        private readonly static string _userAgent = 
            $"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 " +
            $"(KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36";

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

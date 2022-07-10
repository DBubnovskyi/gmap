using System.Net;

namespace MapForms.Models.Data.SetUawardata
{
    public class UawardataDataProcessor
    {
        public UawardataDataProcessor()
        {
            Load();
        }

        private static readonly string hostUrl = "https://www.uawardata.com/";
        private static readonly string areas = "areas/";
        private static readonly string areaslist = $"{areas}areaslist.json";

        void Load()
        {
            using (var client = new WebClient())
            {
                string areaslistResponce = client.DownloadString($"{hostUrl}{areaslist}");
                var dateList = DateList.FromJson(areaslistResponce);
                string batleResponce = client.DownloadString($"{hostUrl}{areas}{dateList[0].Date}.geojson");
            }
        }
    }
}

using GMap.NET;
using MapForms.Models.SetUawardata.Data;
using System.Collections.Generic;
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
        private static readonly string shapes = "shapes/";
        private static readonly string areaslist = $"{areas}areaslist.json";
        private static readonly string line240222 = $"{shapes}desputed.json";

        public List<List<PointLatLng>> UkraineOutline { get; set; } = new List<List<PointLatLng>>();
        public List<List<PointLatLng>> Line240222 { get; set; } = new List<List<PointLatLng>>();
        public List<List<PointLatLng>> ActualLine { get; set; } = new List<List<PointLatLng>>();

        void Load()
        {
            using (var client = new WebClient())
            {
                string areaslistResponce = client.DownloadString($"{hostUrl}{areaslist}");
                var dateList = DateList.FromJson(areaslistResponce);
                string actualLineUrl = $"{hostUrl}{areas}{dateList[0].Date}.geojson";
                string batleResponce = client.DownloadString(actualLineUrl);
                ActualLine = ParseActualLine(batleResponce);
                string line240222LineUrl = $"{hostUrl}{line240222}";
                string line240222Responce = client.DownloadString(line240222LineUrl);
                Line240222 = ParseLine240222(line240222Responce);
            }
        }

        public static List<List<PointLatLng>> ParseActualLine(string json)
        {
            var root = DataSet<FeatureV2>.FromJson(json);
            List<List<PointLatLng>> tmp = new List<List<PointLatLng>>();
            foreach (var f in root.Features)
            {
                foreach (var c1 in f.Geometry.Coordinates)
                {
                    List<PointLatLng> list = new List<PointLatLng>();
                    foreach (var c2 in c1)
                    {
                        foreach (var c3 in c2)
                        {
                            list.Add(new PointLatLng(c3[1], c3[0]));
                        }
                    }
                    tmp.Add(list);
                }
            }
            return tmp;
        }

        public static List<List<PointLatLng>> ParseLine240222(string json)
        {
            var root = DataSet<FeatureV1>.FromJson(json);
            List<List<PointLatLng>> tmp = new List<List<PointLatLng>>();
            foreach (var f in root.Features)
            {
                List<PointLatLng> list = new List<PointLatLng>();
                foreach (var c1 in f.Geometry.Coordinates)
                {
                    foreach (var c2 in c1)
                    {
                        list.Add(new PointLatLng(c2[1], c2[0]));
                    }
                }
                tmp.Add(list);
            }
            return tmp;
        }
    }
}

using GMap.NET;
using MapForms.Models.SetUawardata.Data;
using System;
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
                try{
                    string areaslistResponce = client.DownloadString($"{hostUrl}{areaslist}");
                    var dateList = DateList.FromJson(areaslistResponce);
                    string actualLineUrl = $"{hostUrl}{areas}{dateList[0].Date}.geojson";
                    string batleResponce = client.DownloadString(actualLineUrl);
                    ActualLine = ParseLine<FeatureV2>(batleResponce);
                    string line240222LineUrl = $"{hostUrl}{line240222}";
                    string line240222Responce = client.DownloadString(line240222LineUrl);
                    Line240222 = ParseLine<FeatureV1>(line240222Responce);
                }
                catch (Exception) { };
            }
        }

        public static List<List<PointLatLng>> ParseLine<T>(string json) =>
            ToPointsList(DataSet<T>.FromJson(json));

        public static Data ToData<T>(string json)
        {
            var dataSet = DataSet<T>.FromJson(json);
            if(dataSet?.Features != null)
            {
                return new Data()
                {
                    Points = ToPointsList(dataSet),
                    Label = dataSet.Label,
                    Mode = dataSet.Mode,
                    LineColor = dataSet.LineColor,
                    TextColor = dataSet.TextColor,
                    Background = dataSet.Background,
                    Transparency = dataSet.Transparency
                };
            }
            return null;
        }

        public static List<List<PointLatLng>> ToPointsList<T>(DataSet<T> dataSet)
        {
            List<List<PointLatLng>> tmp = new List<List<PointLatLng>>();
            if (typeof(T) == typeof(FeatureV1))
            {
                foreach (var f in dataSet.Features as List<FeatureV1>)
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
            }
            else if (typeof(T) == typeof(FeatureV2))
            {
                foreach (var f in dataSet.Features as List<FeatureV2>)
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
            }
            return tmp;
        }
    }
}

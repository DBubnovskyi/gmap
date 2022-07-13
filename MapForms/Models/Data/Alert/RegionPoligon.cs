using GMap.NET;
using MapForms.Models.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MapProcassor.Models.Alert
{
    public class RegionPoligon
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("geometries")]
        public List<Geometry> Geometries { get; set; }

        public static RegionPoligon FromJson(string json) => 
            JsonConvert.DeserializeObject<RegionPoligon>(json, Converter.Settings);

        public List<List<PointLatLng>> ToPoligons()
        {
            List<List<PointLatLng>> tmp = new List<List<PointLatLng>>();
            foreach (var g in this.Geometries)
            {
                foreach (var c1 in g.Coordinates)
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
    }

    public partial class Geometry
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public List<List<List<List<double>>>> Coordinates { get; set; }
    }
}
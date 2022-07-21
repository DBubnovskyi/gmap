using GMap.NET;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapForms.Models.Data.SetOpenstreetmap
{
    public class OpenstreetmapProvider
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("geometries")]
        public List<Geometry> Geometries { get; set; }

        public static OpenstreetmapProvider FromJson(string json) => 
            JsonConvert.DeserializeObject<OpenstreetmapProvider>(json, Converter.Settings);

        public static List<List<PointLatLng>> ParseLine(string json)
        {
            var root = OpenstreetmapProvider.FromJson(json);
            List<List<PointLatLng>> tmp = new List<List<PointLatLng>>();
            foreach (var f in root.Geometries)
            {
                foreach (var c1 in f.Coordinates)
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

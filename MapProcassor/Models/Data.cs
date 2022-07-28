using System.Collections.Generic;
using Newtonsoft.Json;

namespace MapProcassor.Models
{
    public partial class Data : DataInfo
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("geometries")]
        public List<Geometry> Geometries { get; set; }
    }

    public partial class Geometry
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public List<List<List<List<double>>>> Coordinates { get; set; }
    }

    public partial class Temperatures
    {
        public static Temperatures FromJson(string json) => JsonConvert.DeserializeObject<Temperatures>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Temperatures self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}

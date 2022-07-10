using Newtonsoft.Json;
using System.Collections.Generic;

namespace MapForms.Models.SetUawardata.Data
{
    public class FeatureV1
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("geometry")]
        public Geometry<List<List<List<double>>>> Geometry { get; set; }

        [JsonProperty("properties")]
        public Properties Properties { get; set; }
    }
}

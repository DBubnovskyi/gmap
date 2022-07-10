using Newtonsoft.Json;

namespace MapForms.Models.SetUawardata.Data
{
    public class Crs
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("properties")]
        public CrsProperties Properties { get; set; }
    }
}

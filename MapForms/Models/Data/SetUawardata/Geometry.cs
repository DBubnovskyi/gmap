using Newtonsoft.Json;

namespace MapForms.Models.SetUawardata.Data
{
    public class Geometry<T>
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public T Coordinates { get; set; }
    }
}

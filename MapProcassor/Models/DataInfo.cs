using Newtonsoft.Json;

namespace MapProcassor.Models
{
    public class DataInfo
    {
        public enum SetType
        {
            None, Poligon, Route, Markers,
        }

        [JsonProperty("transparency")]
        public short Transparency { get; set; } = 200;

        [JsonProperty("line color")]
        public string LineColor { get; set; }

        [JsonProperty("background")]
        public string Background { get; set; }

        [JsonProperty("text color")]
        public string TextColor { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("mode")]
        public SetType Mode { get; set; }
    }
}

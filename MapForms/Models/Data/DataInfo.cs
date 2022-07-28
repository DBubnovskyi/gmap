using Newtonsoft.Json;
using static MapForms.Models.Data.Data;

namespace MapForms.Models.Data
{
    public class DataInfo
    {
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

        [JsonProperty("visible zoom")]
        public int VisibleAtZoom { get; set; }
    }
}

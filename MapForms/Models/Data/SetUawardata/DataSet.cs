using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using MapForms.Models.Data;

namespace MapForms.Models.SetUawardata.Data
{
    public class DataSet<T>
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("crs")]
        public Crs Crs { get; set; }

        [JsonProperty("features")]
        public List<T> Features { get; set; }


        public static DataSet<T> FromJson(string json) => JsonConvert.DeserializeObject<DataSet<T>>(json, Converter.Settings);
    }

    public static partial class Serialize
    {
        public static string ToJson(this DataSet<List<List<List<double>>>> self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public static partial class Serialize
    {
        public static string ToJson(this DataSet<List<List<List<List<double>>>>> self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}

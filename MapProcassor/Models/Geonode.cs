using Newtonsoft.Json;
using System.Collections.Generic;

namespace MapProcassor.Models
{
    public class Geonode
    {
        [JsonProperty("place_id")]
        public long PlaceId { get; set; }

        [JsonProperty("licence")]
        public string Licence { get; set; }

        [JsonProperty("osm_type")]
        public string OsmType { get; set; }

        [JsonProperty("osm_id")]
        public long OsmId { get; set; }

        [JsonProperty("boundingbox")]
        public List<string> Boundingbox { get; set; }

        private string _latStr = string.Empty;
        [JsonProperty("lat")]
        public string LatStr
        {
            get => _latStr;
            set
            {
                _latStr = value;
                Lat = double.Parse(_latStr, System.Globalization.CultureInfo.InvariantCulture);
            }
        }
        public double Lat { get; set; }

        private string _lonStr = string.Empty;
        [JsonProperty("lon")]
        public string LonStr
        {
            get => _lonStr;
            set
            {
                _lonStr = value;
                Lon = double.Parse(_lonStr, System.Globalization.CultureInfo.InvariantCulture);
            }
        }
        public double Lon { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("place_rank")]
        public long PlaceRank { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("importance")]
        public double Importance { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        public static List<Geonode> FromJson(string json) 
            => JsonConvert.DeserializeObject<List<Geonode>>(json, Converter.Settings);

        public string ToMapDataString()
        {
            var poins = new List<List<List<List<double>>>>
            {
                new List<List<List<double>>>
                {
                    new List<List<double>>
                    {
                        new List<double>
                        {
                            Lon,
                            Lat
                        }
                    }
                }
            };
            var data = new Data()
            {
                Label = DisplayName,
                Mode = DataInfo.SetType.Markers,
                TextColor = "#444444",
                Transparency = 150,
                Type = "GeometryCollection",
                Geometries = new List<Geometry>()
                {
                    new Geometry()
                    {
                        Type = "MultiLocation",
                        Coordinates = poins
                    }
                }
            };

            return JsonConvert.SerializeObject(data, Converter.Settings);
        }
    }
}

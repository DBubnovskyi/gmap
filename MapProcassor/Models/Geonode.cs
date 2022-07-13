using MapForms.Models.Data;
using Newtonsoft.Json;
using System;
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

        [JsonProperty("lat")]
        public string Lat { get; set; }

        [JsonProperty("lon")]
        public string Lon { get; set; }

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
    }
}

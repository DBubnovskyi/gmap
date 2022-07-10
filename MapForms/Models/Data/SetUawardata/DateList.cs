using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MapForms.Models.Data.SetUawardata
{
    public class DateList
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("loaded")]
        public bool Loaded { get; set; }

        public static List<DateList> FromJson(string json) 
            => JsonConvert.DeserializeObject<List<DateList>>(json, Converter.Settings);
    }

}

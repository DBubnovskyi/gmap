using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace MapForms.Models.Data
{
    public static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            Error = (sender, error) => error.ErrorContext.Handled = true,
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}

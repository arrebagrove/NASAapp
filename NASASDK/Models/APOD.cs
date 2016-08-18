using Newtonsoft.Json;
using System;

namespace NASASDK.Models
{
    public class PictureOfDay
    {
        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "explanation")]
        public string Explanation { get; set; }

        [JsonProperty(PropertyName = "hdurl")]
        public string HdUrl { get; set; }

        [JsonProperty(PropertyName = "media_type")]
        public string MediaType { get; set; }

        [JsonProperty(PropertyName = "service_version")]
        public string ServiceVersion { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "copyright")]
        public string Copyright { get; set; }
    }
}

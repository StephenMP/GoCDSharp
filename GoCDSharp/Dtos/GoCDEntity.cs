using Newtonsoft.Json;

namespace GoCDSharp.Dtos
{
    public abstract class GoCDEntity
    {
        [JsonIgnore]
        public string ETag { get; set; }

        [JsonIgnore]
        [JsonProperty("_links")]
        public GoCDLinks Links { get; set; }

        [JsonIgnore]
        [JsonProperty("origin")]
        public GoCDOrigin Origin { get; set; }
    }
}
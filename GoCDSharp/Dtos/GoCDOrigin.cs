using Newtonsoft.Json;

namespace GoCDSharp.Dtos
{
    public class GoCDOrigin : GoCDEntity
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
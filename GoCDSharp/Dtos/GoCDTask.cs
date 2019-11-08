using Newtonsoft.Json;

namespace GoCDSharp.Dtos
{
    public class GoCDTask : GoCDEntity
    {
        [JsonProperty("attributes")]
        public GoCDTaskAttributes Attributes { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
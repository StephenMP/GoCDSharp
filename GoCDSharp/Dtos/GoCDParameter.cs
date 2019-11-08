using Newtonsoft.Json;

namespace GoCDSharp.Dtos
{
    public class GoCDParameter : GoCDEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
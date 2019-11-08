using Newtonsoft.Json;

namespace GoCDSharp.Dtos
{
    public class GoCDMaterial : GoCDEntity
    {
        [JsonProperty("attributes")]
        public GoCDMaterialAttributes Attributes { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
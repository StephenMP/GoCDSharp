using Newtonsoft.Json;

namespace GoCDSharp.Dtos
{
    public class GoCDEnvironmentConfig : GoCDEntity
    {
        [JsonProperty("_embedded")]
        public Embedded Embedded { get; set; }
    }
}
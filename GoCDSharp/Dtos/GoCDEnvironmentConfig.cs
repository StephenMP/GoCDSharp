using Newtonsoft.Json;

namespace GoCDSharp.Dtos
{
    public class GoCDEnvironmentConfig : GoCDEntity
    {
        [JsonProperty("_embedded")]
        public GoCDEmbedded Embedded { get; set; }
    }
}
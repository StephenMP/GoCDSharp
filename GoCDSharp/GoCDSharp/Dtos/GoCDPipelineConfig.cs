using Newtonsoft.Json;

namespace GoCDSharp.Dtos
{
    public class GoCDPipelineConfig : GoCDEntity
    {
        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("pipeline")]
        public GoCDPipeline Pipeline { get; set; }
    }
}
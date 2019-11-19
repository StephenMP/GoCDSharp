using Newtonsoft.Json;
using System.Collections.Generic;

namespace GoCDSharp.Dtos
{
    public class GoCDPipelineGroup
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("pipelines")]
        public List<GoCDPipeline> Pipelines { get; set; }
    }
}
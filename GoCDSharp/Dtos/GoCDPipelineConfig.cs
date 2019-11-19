using Newtonsoft.Json;
using System.Collections.Generic;

namespace GoCDSharp.Dtos
{
    public class GoCDPipelineConfig : GoCDEntity
    {
        [JsonProperty("environment_variables")]
        public List<GoCDEnvironmentVariable> EnvironmentVariables { get; set; }

        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("label_template")]
        public string LabelTemplate { get; set; }

        [JsonProperty("lock_behavior")]
        public string LockBehavior { get; set; }

        [JsonProperty("materials")]
        public List<GoCDMaterial> Materials { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parameters")]
        public List<GoCDParameter> Parameters { get; set; }

        [JsonProperty("stages")]
        public List<GoCDStage> Stages { get; set; }

        [JsonProperty("template")]
        public string Template { get; set; }

        [JsonProperty("timer")]
        public GoCDTimer Timer { get; set; }
    }
}
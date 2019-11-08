using Newtonsoft.Json;
using System.Collections.Generic;

namespace GoCDSharp.Dtos
{
    public class GoCDPipeline : GoCDEntity
    {
        public GoCDPipeline()
        {
            this.Parameters = new List<GoCDParameter>();
            this.EnvironmentVariables = new List<EnvironmentVariable>();
            this.Materials = new List<GoCDMaterial>();
            this.Stages = new List<GoCDStage>();
        }

        [JsonProperty("environment_variables")]
        public List<EnvironmentVariable> EnvironmentVariables { get; set; }

        [JsonProperty("label_template")]
        public string LabelTemplate { get; set; }

        [JsonProperty("lock_behavior")]
        public string LockBehavior { get; set; }

        [JsonProperty("materials")]
        public List<GoCDMaterial> Materials { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("origin")]
        public GoCDOrigin Origin { get; set; }

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
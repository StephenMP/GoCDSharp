using Newtonsoft.Json;
using System.Collections.Generic;

namespace GoCDSharp.Dtos
{
    public class EnvironmentVariable
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("secure")]
        public bool Secure { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class GoCDEnvironment : GoCDEntity
    {
        public GoCDEnvironment()
        {
            this.Agents = new List<GoCDAgent>();
            this.EnvironmentVariables = new List<EnvironmentVariable>();
            this.Pipelines = new List<GoCDPipeline>();
        }

        [JsonProperty("agents")]
        public List<GoCDAgent> Agents { get; set; }

        [JsonProperty("environment_variables")]
        public List<EnvironmentVariable> EnvironmentVariables { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("pipelines")]
        public List<GoCDPipeline> Pipelines { get; set; }
    }
}
using Newtonsoft.Json;
using GoCDSharp.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace GoCDSharp.Requests
{
    public class GoCDUpdateEnvironmentPipelineRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class GoCDUpdateEnvironmentRequest : GoCDEntity
    {
        public GoCDUpdateEnvironmentRequest(GoCDEnvironment env)
        {
            this.ETag = env.ETag;
            this.Pipelines = new List<GoCDUpdateEnvironmentPipelineRequest>(env.Pipelines.Select(p => new GoCDUpdateEnvironmentPipelineRequest { Name = p.Name }));
            this.Agents = new List<string>();
            this.EnvironmentVariables = new List<GoCDEnvironmentVariable>();
        }

        [JsonProperty("agents")]
        public List<string> Agents { get; set; }

        [JsonProperty("environment_variables")]
        public List<GoCDEnvironmentVariable> EnvironmentVariables { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("pipelines")]
        public List<GoCDUpdateEnvironmentPipelineRequest> Pipelines { get; set; }
    }
}
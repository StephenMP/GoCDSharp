using Newtonsoft.Json;
using System.Collections.Generic;

namespace GoCDSharp.Dtos
{
    public class GoCDUpdateEnvironmentRequestDto
    {
        public GoCDUpdateEnvironmentRequestDto()
        {
            this.Pipelines = new List<UpdateEnvironmentPipelineRequestDto>();
            this.Agents = new List<string>();
            this.EnvironmentVariables = new List<EnvironmentVariable>();
        }

        [JsonProperty("agents")]
        public List<string> Agents { get; set; }

        [JsonProperty("environment_variables")]
        public List<EnvironmentVariable> EnvironmentVariables { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("pipelines")]
        public List<UpdateEnvironmentPipelineRequestDto> Pipelines { get; set; }
    }

    public class UpdateEnvironmentPipelineRequestDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
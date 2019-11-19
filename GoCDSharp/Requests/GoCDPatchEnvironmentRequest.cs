using Newtonsoft.Json;
using System.Collections.Generic;

namespace GoCDSharp.Requests
{
    public class GoCDEnvironmentVariablesPatchRequest
    {
        public GoCDEnvironmentVariablesPatchRequest()
        {
            this.Add = new List<GoCDEnvironmentVariablesPatchRequestAdd>();
            this.Remove = new List<string>();
        }

        [JsonProperty("add")]
        public List<GoCDEnvironmentVariablesPatchRequestAdd> Add { get; set; }

        [JsonProperty("remove")]
        public List<string> Remove { get; set; }
    }

    public class GoCDEnvironmentVariablesPatchRequestAdd
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class GoCDPatchEnvironmentRequest
    {
        public GoCDPatchEnvironmentRequest()
        {
            this.Pipelines = new GoCDPatchRequest();
            this.Agents = new GoCDPatchRequest();
            this.EnvironmentVariables = new GoCDEnvironmentVariablesPatchRequest();
        }

        [JsonProperty("agents")]
        public GoCDPatchRequest Agents { get; set; }

        [JsonProperty("environment_variables")]
        public GoCDEnvironmentVariablesPatchRequest EnvironmentVariables { get; set; }

        [JsonProperty("pipelines")]
        public GoCDPatchRequest Pipelines { get; set; }
    }

    public class GoCDPatchRequest
    {
        public GoCDPatchRequest()
        {
            this.Add = new List<string>();
            this.Remove = new List<string>();
        }

        [JsonProperty("add")]
        public List<string> Add { get; set; }

        [JsonProperty("remove")]
        public List<string> Remove { get; set; }
    }
}
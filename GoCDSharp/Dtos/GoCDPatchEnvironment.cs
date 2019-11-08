using Newtonsoft.Json;
using System.Collections.Generic;

namespace GoCDSharp.Dtos
{
    public class Add
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class EnvironmentVariablesPatch
    {
        public EnvironmentVariablesPatch()
        {
            this.Add = new List<Add>();
            this.Remove = new List<string>();
        }

        [JsonProperty("add")]
        public List<Add> Add { get; set; }

        [JsonProperty("remove")]
        public List<string> Remove { get; set; }
    }

    public class GoCDPatchEnvironment
    {
        public GoCDPatchEnvironment()
        {
            this.Pipelines = new Patch();
            this.Agents = new Patch();
            this.EnvironmentVariables = new EnvironmentVariablesPatch();
        }

        [JsonProperty("agents")]
        public Patch Agents { get; set; }

        [JsonProperty("environment_variables")]
        public EnvironmentVariablesPatch EnvironmentVariables { get; set; }

        [JsonProperty("pipelines")]
        public Patch Pipelines { get; set; }
    }

    public class Patch
    {
        public Patch()
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
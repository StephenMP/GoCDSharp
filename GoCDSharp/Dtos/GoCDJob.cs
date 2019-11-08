using Newtonsoft.Json;
using System.Collections.Generic;

namespace GoCDSharp.Dtos
{
    public class GoCDJob : GoCDEntity
    {
        [JsonProperty("environment_variables")]
        public List<EnvironmentVariable> EnvironmentVariables { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("resources")]
        public List<string> Resources { get; set; }

        [JsonProperty("run_instance_count")]
        public object RunInstanceCount { get; set; }

        [JsonProperty("tasks")]
        public List<GoCDTask> Tasks { get; set; }

        [JsonProperty("timeout")]
        public long Timeout { get; set; }
    }
}
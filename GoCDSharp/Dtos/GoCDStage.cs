using Newtonsoft.Json;
using System.Collections.Generic;

namespace GoCDSharp.Dtos
{
    public class GoCDStage : GoCDEntity
    {
        public GoCDStage()
        {
            this.EnvironmentVariables = new List<GoCDEnvironmentVariable>();
            this.Jobs = new List<GoCDJob>();
        }

        [JsonProperty("approval")]
        public GoCDApproval Approval { get; set; }

        [JsonProperty("clean_working_directory")]
        public bool CleanWorkingDirectory { get; set; }

        [JsonProperty("environment_variables")]
        public List<GoCDEnvironmentVariable> EnvironmentVariables { get; set; }

        [JsonProperty("fetch_materials")]
        public bool FetchMaterials { get; set; }

        [JsonProperty("jobs")]
        public List<GoCDJob> Jobs { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("never_cleanup_artifacts")]
        public bool NeverCleanupArtifacts { get; set; }
    }
}
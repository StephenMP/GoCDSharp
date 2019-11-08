using Newtonsoft.Json;
using System.Collections.Generic;

namespace GoCDSharp.Dtos
{
    public class Embedded : GoCDEntity
    {
        public Embedded()
        {
            this.Agents = new List<GoCDAgent>();
            this.Environments = new List<GoCDEnvironment>();
            this.Templates = new List<GoCDTemplate>();
        }

        [JsonProperty("agents")]
        public List<GoCDAgent> Agents { get; set; }

        [JsonProperty("environments")]
        public List<GoCDEnvironment> Environments { get; set; }

        [JsonProperty("templates")]
        public List<GoCDTemplate> Templates { get; set; }
    }

    public class GoCDAgent : GoCDEntity
    {
        public GoCDAgent()
        {
            this.Environments = new List<string>();
            this.Resources = new List<string>();
        }

        [JsonProperty("agent_config_state")]
        public string AgentConfigState { get; set; }

        [JsonProperty("agent_state")]
        public string AgentState { get; set; }

        [JsonProperty("build_state")]
        public string BuildState { get; set; }

        [JsonProperty("environments")]
        public List<string> Environments { get; set; }

        [JsonProperty("free_space")]
        public long FreeSpace { get; set; }

        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }

        [JsonProperty("operating_system")]
        public string OperatingSystem { get; set; }

        [JsonProperty("resources")]
        public List<string> Resources { get; set; }

        [JsonProperty("sandbox")]
        public string Sandbox { get; set; }

        [JsonProperty("uuid")]
        public string Uuid { get; set; }
    }

    public class GoCDAgents : GoCDEntity
    {
        [JsonProperty("_embedded")]
        public Embedded Embedded { get; set; }
    }
}
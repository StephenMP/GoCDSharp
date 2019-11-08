using Newtonsoft.Json;

namespace GoCDSharp.Dtos
{
    public class GoCDMaterialAttributes : GoCDEntity
    {
        [JsonProperty("auto_update")]
        public bool AutoUpdate { get; set; }

        [JsonProperty("branch")]
        public string Branch { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("filter")]
        public object Filter { get; set; }

        [JsonProperty("invert_filter")]
        public bool InvertFilter { get; set; }

        [JsonProperty("name")]
        public object Name { get; set; }

        [JsonProperty("pipeline")]
        public string Pipeline { get; set; }

        [JsonProperty("shallow_clone")]
        public bool ShallowClone { get; set; }

        [JsonProperty("stage")]
        public string Stage { get; set; }

        [JsonProperty("submodule_folder")]
        public object SubmoduleFolder { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GoCDSharp.Dtos
{
    public class GoCDTemplate : GoCDEntity
    {
        public GoCDTemplate()
        {
            this.Stages = new List<GoCDStage>();
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("stages")]
        public List<GoCDStage> Stages { get; set; }
    }

    public class GoCDTemplateConfigTemplate : GoCDEntity
    {
        public GoCDTemplateConfigTemplate()
        {
            this.Embedded = new GoCDEmbedded();
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("_embedded")]
        public GoCDEmbedded Embedded { get; set; }
    }

    public class GoCDTemplateConfig : GoCDEntity
    {
        public GoCDTemplateConfig()
        {
            this.Embedded = new GoCDEmbedded();
        }

        [JsonProperty("_embedded")]
        public GoCDEmbedded Embedded { get; set; }
    }

    public partial class GoCDEmbedded
    {
        [JsonProperty("templates")]
        public List<GoCDTemplateConfigTemplate> Templates { get; set; }

        [JsonProperty("pipelines")]
        public List<GoCDPipeline> Pipelines { get; set; }
    }
}
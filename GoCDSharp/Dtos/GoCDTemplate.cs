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

    public class TemplateConfig
    {
        public TemplateConfig()
        {
            this.Embedded = new Embedded();
        }

        [JsonProperty("_embedded")]
        public Embedded Embedded { get; set; }
    }
}
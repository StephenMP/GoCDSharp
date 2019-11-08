using Newtonsoft.Json;

namespace GoCDSharp.Dtos
{
    public class GoCDTimer : GoCDEntity
    {
        [JsonProperty("only_on_changes")]
        public bool OnlyOnChanges { get; set; }

        [JsonProperty("spec")]
        public string Spec { get; set; }
    }
}
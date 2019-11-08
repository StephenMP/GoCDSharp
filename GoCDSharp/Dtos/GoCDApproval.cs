using Newtonsoft.Json;

namespace GoCDSharp.Dtos
{
    public class GoCDApproval : GoCDEntity
    {
        [JsonProperty("authorization")]
        public GoCDAuthorization Authorization { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
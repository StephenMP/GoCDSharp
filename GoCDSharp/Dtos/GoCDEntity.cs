using Newtonsoft.Json;

namespace GoCDSharp.Dtos
{
    public abstract class GoCDEntity
    {
        [JsonIgnore]
        public string ETag { get; set; }
    }
}
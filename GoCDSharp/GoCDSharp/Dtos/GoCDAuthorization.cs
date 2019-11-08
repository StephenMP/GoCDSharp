using Newtonsoft.Json;
using System.Collections.Generic;

namespace GoCDSharp.Dtos
{
    public class GoCDAuthorization : GoCDEntity
    {
        public GoCDAuthorization()
        {
            this.Roles = new List<string>();
            this.Users = new List<string>();
        }

        [JsonProperty("roles")]
        public List<string> Roles { get; set; }

        [JsonProperty("users")]
        public List<string> Users { get; set; }
    }
}
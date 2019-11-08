using Newtonsoft.Json;
using System.Collections.Generic;

namespace GoCDSharp.Dtos
{
    public class GoCDTaskAttributes : GoCDEntity
    {
        public GoCDTaskAttributes()
        {
            this.RunIf = new List<string>();
            this.Arguments = new List<string>();
        }

        [JsonProperty("arguments")]
        public List<string> Arguments { get; set; }

        [JsonProperty("command")]
        public string Command { get; set; }

        [JsonProperty("on_cancel")]
        public GoCDTask OnCancel { get; set; }

        [JsonProperty("run_if")]
        public List<string> RunIf { get; set; }

        [JsonProperty("working_directory")]
        public string WorkingDirectory { get; set; }
    }
}
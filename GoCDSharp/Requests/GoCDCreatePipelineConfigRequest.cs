using Newtonsoft.Json;
using GoCDSharp.Dtos;

namespace GoCDSharp.Requests
{
    public class GoCDCreatePipelineConfigRequest
    {
        public GoCDCreatePipelineConfigRequest() { }
        public GoCDCreatePipelineConfigRequest(string group, GoCDPipeline pipeline)
        {
            this.Group = group;
            this.Pipeline = pipeline;
        }

        public GoCDCreatePipelineConfigRequest(GoCDPipelineConfig pipelineConfig)
        {
            this.Group = pipelineConfig.Group;
            this.Pipeline = new GoCDPipeline
            {
                EnvironmentVariables = pipelineConfig.EnvironmentVariables,
                LabelTemplate = pipelineConfig.LabelTemplate,
                LockBehavior = pipelineConfig.LockBehavior,
                Materials = pipelineConfig.Materials,
                Name = pipelineConfig.Name,
                Parameters = pipelineConfig.Parameters,
                Stages = pipelineConfig.Stages,
                Template = pipelineConfig.Template,
                Timer = pipelineConfig.Timer
            };
        }

        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("pipeline")]
        public GoCDPipeline Pipeline { get; set; }
    }
}

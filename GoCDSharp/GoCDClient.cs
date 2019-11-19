using GoCDSharp.Endpoints;
using System;

namespace GoCDSharp
{
    public interface IGoCDClient
    {
        IGoCDAgentsEndpoint Agents { get; }
        IGoCDEnvironmentConfigEndpoint EnvironmentConfig { get; }
        IGoCDPipelineConfigEndpoint PipelineConfig { get; }
        IGoCDPipelineGroupsEndpoint PipelineGroups { get; }
        IGoCDPipelinesEndpoint Pipelines { get; }
        IGoCDTemplateConfigEndpoint TemplateConfig { get; }
    }

    public class GoCDClient : IGoCDClient
    {
        public GoCDClient(Uri apiBaseUri)
        {
            var apiBaseUriString = apiBaseUri.ToString();
            if (apiBaseUriString.ToLowerInvariant().Contains("/go/api"))
            {
                apiBaseUri = new Uri(apiBaseUriString.TrimEnd('/').Replace("/go/api", ""));
            }

            this.Agents = new GoCDAgentsEndpoint(apiBaseUri);
            this.EnvironmentConfig = new GoCDEnvironmentConfigEndpoint(apiBaseUri);
            this.PipelineConfig = new GoCDPipelineConfigEndpoint(apiBaseUri);
            this.PipelineGroups = new GoCDPipelineGroupsEndpoint(apiBaseUri);
            this.Pipelines = new GoCDPipelinesEndpoint(apiBaseUri);
            this.TemplateConfig = new GoCDTemplateConfigEndpoint(apiBaseUri);
        }

        public GoCDClient(string apiBaseUri) : this(new Uri(apiBaseUri))
        {
        }

        public IGoCDAgentsEndpoint Agents { get; set; }

        public IGoCDEnvironmentConfigEndpoint EnvironmentConfig { get; set; }

        public IGoCDPipelineConfigEndpoint PipelineConfig { get; set; }

        public IGoCDPipelineGroupsEndpoint PipelineGroups { get; set; }

        public IGoCDPipelinesEndpoint Pipelines { get; set; }

        public IGoCDTemplateConfigEndpoint TemplateConfig { get; set; }
    }
}
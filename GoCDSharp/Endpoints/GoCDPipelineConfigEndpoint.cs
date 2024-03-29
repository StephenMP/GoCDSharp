﻿using Flurl.Http;
using GoCDSharp.Dtos;
using GoCDSharp.Requests;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GoCDSharp.Endpoints
{
    public interface IGoCDPipelineConfigEndpoint
    {
        Task<GoCDPipelineConfig> CreateAsync(GoCDCreatePipelineConfigRequest createPipelineConfigRequest);
        Task<GoCDPipelineConfig> CreateAsync(GoCDPipelineConfig pipelineConfig);
        Task<GoCDPipelineConfig> CreateAsync(string group, GoCDPipeline pipeline);

        Task DeleteAsync(string pipelineName);

        Task<GoCDPipelineConfig> EditAsync(GoCDPipelineConfig pipeline);

        Task<GoCDPipelineConfig> GetAsync(string pipelineName);
    }

    public class GoCDPipelineConfigEndpoint : GoCDEndpoint, IGoCDPipelineConfigEndpoint
    {
        public GoCDPipelineConfigEndpoint(Uri apiBaseUri) : base(apiBaseUri, "admin/pipelines", 10)
        {
        }

        public async Task<GoCDPipelineConfig> CreateAsync(GoCDCreatePipelineConfigRequest createPipelineConfigRequest)
        {
            return await this.BeginRequest()
                             .PostJsonAsync(createPipelineConfigRequest)
                             .ReceiveJson<GoCDPipelineConfig>()
                             .ConfigureAwait(false);
        }

        public async Task<GoCDPipelineConfig> CreateAsync(string group, GoCDPipeline pipeline)
        {
            return await this.CreateAsync(new GoCDCreatePipelineConfigRequest(group, pipeline));
        }

        public async Task<GoCDPipelineConfig> CreateAsync(GoCDPipelineConfig pipelineConfig)
        {
            return await this.CreateAsync(new GoCDCreatePipelineConfigRequest(pipelineConfig));
        }

        public async Task DeleteAsync(string pipelineName)
        {
            await this.BeginRequest()
                      .AppendPathSegment(pipelineName)
                      .DeleteAsync()
                      .ConfigureAwait(false);
        }

        public async Task<GoCDPipelineConfig> EditAsync(GoCDPipelineConfig pipelineConfig)
        {
            return await this.BeginRequest()
                             .WithHeader("If-Match", pipelineConfig.ETag)
                             .AppendPathSegment(pipelineConfig.Name)
                             .PutJsonAsync(pipelineConfig)
                             .ReceiveJson<GoCDPipelineConfig>()
                             .ConfigureAwait(false);
        }

        public async Task<GoCDPipelineConfig> GetAsync(string name)
        {
            var request = this.BeginRequest()
                              .AppendPathSegment(name);

            using (var response = await request.GetAsync().ConfigureAwait(false))
            {
                var eTag = response.Headers.GetValues("ETag").FirstOrDefault();
                var rawContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var content = JsonConvert.DeserializeObject<GoCDPipelineConfig>(rawContent);
                content.ETag = eTag;

                return content;
            }
        }
    }
}
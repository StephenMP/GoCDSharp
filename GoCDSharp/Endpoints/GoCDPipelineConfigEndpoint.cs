using Flurl.Http;
using GoCDSharp.Dtos;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GoCDSharp.Endpoints
{
    public interface IGoCDPipelineConfigEndpoint
    {
        Task<GoCDPipeline> CreateAsync(GoCDPipelineConfig pipelineDto);

        Task DeleteAsync(string pipelineName);

        Task<GoCDPipeline> GetAsync(string pipelineName);

        Task<string> UpdateAsync(GoCDPipeline pipeline);
    }

    public class GoCDPipelineConfigEndpoint : GoCDEndpoint, IGoCDPipelineConfigEndpoint
    {
        public GoCDPipelineConfigEndpoint(Uri apiBaseUri) : base(apiBaseUri, "admin/pipelines")
        {
        }

        public async Task<GoCDPipeline> CreateAsync(GoCDPipelineConfig pipelineDto)
        {
            return await this.Endpoint
                             .ToString()
                             .WithHeader("Accept", this.GetAcceptHeader(10))
                             .AllowHttpStatus("422")
                             .PostJsonAsync(pipelineDto)
                             .ReceiveJson<GoCDPipeline>()
                             .ConfigureAwait(false);
        }

        public async Task DeleteAsync(string pipelineName)
        {
            await this.Endpoint
                      .ToString()
                      .WithHeader("Accept", this.GetAcceptHeader(10))
                      .DeleteAsync()
                      .ConfigureAwait(false);
        }

        public async Task<GoCDPipeline> GetAsync(string name)
        {
            var request = this.Endpoint
                              .ToString()
                              .WithHeader("Accept", GetAcceptHeader(10))
                              .AppendPathSegment(name);

            using (var response = await request.GetAsync().ConfigureAwait(false))
            {
                var eTag = response.Headers.GetValues("ETag").FirstOrDefault();
                var rawContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var content = JsonConvert.DeserializeObject<GoCDPipeline>(rawContent);
                content.ETag = eTag;

                return content;
            }
        }

        public async Task<string> UpdateAsync(GoCDPipeline pipelineDto)
        {
            return await this.Endpoint
                             .ToString()
                             .WithHeader("Accept", this.GetAcceptHeader(10))
                             .WithHeader("If-Match", pipelineDto.ETag)
                             .AppendPathSegment(pipelineDto.Name)
                             .PutJsonAsync(pipelineDto)
                             .ReceiveString()
                             .ConfigureAwait(false);
        }
    }
}
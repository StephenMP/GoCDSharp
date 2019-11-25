using Flurl.Http;
using GoCDSharp.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoCDSharp.Endpoints
{
    public interface IGoCDPipelineGroupsEndpoint
    {
        Task<IEnumerable<GoCDPipelineGroup>> GetAllAsync();
    }

    public class GoCDPipelineGroupsEndpoint : GoCDEndpoint, IGoCDPipelineGroupsEndpoint
    {
        public GoCDPipelineGroupsEndpoint(Uri apiBaseUri) : base(apiBaseUri, "config/pipeline_groups", 0)
        {
        }

        public async Task<IEnumerable<GoCDPipelineGroup>> GetAllAsync()
        {
            return await this.Endpoint
                             .ToString()
                             .GetJsonAsync<List<GoCDPipelineGroup>>()
                             .ConfigureAwait(false);
        }
    }
}
using Flurl.Http;
using GoCDSharp.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoCDSharp.Endpoints
{
    public interface IGoCDPipelineGroupsEndpoint
    {
        Task<IEnumerable<GoCDPipelineGroups>> GetAllAsync();
    }

    public class GoCDPipelineGroupsEndpoint : GoCDEndpoint, IGoCDPipelineGroupsEndpoint
    {
        public GoCDPipelineGroupsEndpoint(Uri apiBaseUri) : base(apiBaseUri, "config/pipeline_groups")
        {
        }

        public async Task<IEnumerable<GoCDPipelineGroups>> GetAllAsync()
        {
            return await this.Endpoint
                             .ToString()
                             .GetJsonAsync<List<GoCDPipelineGroups>>()
                             .ConfigureAwait(false);
        }
    }
}
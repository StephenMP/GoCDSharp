using Flurl.Http;
using GoCDSharp.Dtos;
using System;
using System.Threading.Tasks;

namespace GoCDSharp.Endpoints
{
    public interface IGoCDAgentsEndpoint
    {
        Task<GoCDAgents> GetAllAsync();
    }

    public class GoCDAgentsEndpoint : GoCDEndpoint, IGoCDAgentsEndpoint
    {
        public GoCDAgentsEndpoint(Uri apiBaseUri) : base(apiBaseUri, "agents")
        {
        }

        public async Task<GoCDAgents> GetAllAsync()
        {
            return await this.Endpoint
                             .ToString()
                             .WithHeader("Accept", this.GetAcceptHeader(6))
                             .GetJsonAsync<GoCDAgents>()
                             .ConfigureAwait(false);
        }
    }
}
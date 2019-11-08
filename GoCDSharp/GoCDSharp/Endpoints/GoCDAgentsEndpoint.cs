using Flurl.Http;
using GoCDSharp.Dtos;
using System;
using System.Threading.Tasks;

namespace GoCDSharp.Endpoints
{
    public interface IGoCDAgentsClient
    {
        Task<GoCDAgents> GetAllAsync();
    }

    public class GoCDAgentsClient : GoCDEndpoint, IGoCDAgentsClient
    {
        public GoCDAgentsClient(Uri apiBaseUri) : base(apiBaseUri, "agents")
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
using Flurl.Http;
using GoCDSharp.Dtos;
using System;
using System.Threading.Tasks;

namespace GoCDSharp.Endpoints
{
    public interface IGoCDAgentsEndpoint
    {
        Task<GoCdAgents> GetAllAsync();
    }

    public class GoCDAgentsEndpoint : GoCDEndpoint, IGoCDAgentsEndpoint
    {
        public GoCDAgentsEndpoint(Uri apiBaseUri) : base(apiBaseUri, "agents", 6)
        {
        }

        public async Task<GoCdAgents> GetAllAsync()
        {
            return await this.BeginRequest()
                             .GetJsonAsync<GoCdAgents>()
                             .ConfigureAwait(false);
        }
    }
}
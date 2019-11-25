using Flurl.Http;
using System;
using System.Threading.Tasks;

namespace GoCDSharp.Endpoints
{
    public interface IGoCDPipelinesEndpoint
    {
        Task PauseAsync(string name, string reason);

        Task UnpauseAsync(string name);
    }

    public class GoCDPipelinesEndpoint : GoCDEndpoint, IGoCDPipelinesEndpoint
    {
        public GoCDPipelinesEndpoint(Uri apiBaseUri) : base(apiBaseUri, "pipelines", 1)
        {
        }

        public async Task PauseAsync(string name, string reason)
        {
            var pauseCause = new { pause_cause = reason };
            await this.BeginRequest()
                      .AppendPathSegments(name, "pause")
                      .PostJsonAsync(pauseCause)
                      .ConfigureAwait(false);
        }

        public async Task UnpauseAsync(string name)
        {
            await this.BeginRequest()
                      .WithHeader("X-GoCD-Confirm", "true")
                      .AppendPathSegments(name, "unpause")
                      .PostStringAsync(string.Empty)
                      .ConfigureAwait(false);
        }
    }
}
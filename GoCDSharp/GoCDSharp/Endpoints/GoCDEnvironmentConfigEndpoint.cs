using Flurl.Http;
using GoCDSharp.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoCDSharp.Endpoints
{
    public interface IGoCDEnvironmentConfigEndpoint
    {
        Task<GoCDEnvironment> CreateAsync(GoCDEnvironment environmentDto);

        Task DeleteAsync(string name);

        Task<IEnumerable<GoCDEnvironment>> GetAllAsync();

        Task<GoCDEnvironment> GetAsync(string name);

        Task UpdateAsync(string environmentName, GoCDPatchEnvironment patch);
    }

    public class GoCDEnvironmentConfigEndpoint : GoCDEndpoint, IGoCDEnvironmentConfigEndpoint
    {
        public GoCDEnvironmentConfigEndpoint(Uri apiBaseUri) : base(apiBaseUri, "admin/environments")
        {
        }

        public async Task<GoCDEnvironment> CreateAsync(GoCDEnvironment environmentDto)
        {
            return await this.Endpoint
                             .ToString()
                             .WithHeader("Accept", this.GetAcceptHeader(3))
                             .PostJsonAsync(environmentDto)
                             .ReceiveJson<GoCDEnvironment>()
                             .ConfigureAwait(false);
        }

        public async Task DeleteAsync(string name)
        {
            await this.Endpoint
                      .ToString()
                      .WithHeader("Accept", this.GetAcceptHeader(3))
                      .AppendPathSegment(name)
                      .DeleteAsync()
                      .ConfigureAwait(false);
        }

        public async Task<IEnumerable<GoCDEnvironment>> GetAllAsync()
        {
            var request = this.Endpoint
                              .ToString()
                              .WithHeader("Accept", this.GetAcceptHeader(3));

            using (var response = await request.GetAsync().ConfigureAwait(false))
            {
                var eTag = response.Headers.GetValues("ETag").FirstOrDefault();
                var rawContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var content = JsonConvert.DeserializeObject<GoCDEnvironmentConfig>(rawContent);

                foreach (var envrionment in content.Embedded.Environments)
                {
                    envrionment.ETag = eTag;
                }

                return content.Embedded.Environments;
            }
        }

        public async Task<GoCDEnvironment> GetAsync(string name)
        {
            var request = this.Endpoint
                              .ToString()
                              .WithHeader("Accept", this.GetAcceptHeader(3))
                              .AppendPathSegment(name);

            using (var response = await request.GetAsync().ConfigureAwait(false))
            {
                var eTag = response.Headers.GetValues("ETag").FirstOrDefault();
                var rawContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var content = JsonConvert.DeserializeObject<GoCDEnvironment>(rawContent);
                content.ETag = eTag;

                return content;
            }
        }

        public async Task UpdateAsync(string name, GoCDPatchEnvironment patchDto)
        {
            await this.Endpoint
                      .ToString()
                      .WithHeader("Accept", this.GetAcceptHeader(2))
                      .AppendPathSegment(name)
                      .PatchJsonAsync(patchDto)
                      .ConfigureAwait(false);
        }
    }
}
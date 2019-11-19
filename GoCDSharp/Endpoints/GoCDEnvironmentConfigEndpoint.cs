using Flurl.Http;
using Newtonsoft.Json;
using GoCDSharp.Dtos;
using GoCDSharp.Requests;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GoCDSharp.Endpoints
{
    public interface IGoCDEnvironmentConfigEndpoint
    {
        Task<GoCDEnvironment> CreateAsync(GoCDEnvironment environmentDto);

        Task DeleteAsync(string name);

        Task<GoCDEnvironmentConfig> GetAllAsync();

        Task<GoCDEnvironment> GetAsync(string name);

        Task PatchAsync(string environmentName, GoCDPatchEnvironmentRequest patch);

        Task UpdateAsync(string environmentName, string eTag, GoCDUpdateEnvironmentRequest updateRequest);
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

        public async Task<GoCDEnvironmentConfig> GetAllAsync()
        {
            var request = this.Endpoint
                              .ToString()
                              .WithHeader("Accept", this.GetAcceptHeader(3));

            using (var response = await request.GetAsync().ConfigureAwait(false))
            {
                var eTag = response.Headers.GetValues("ETag").FirstOrDefault();
                var rawContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var content = JsonConvert.DeserializeObject<GoCDEnvironmentConfig>(rawContent);

                content.ETag = eTag;
                foreach (var envrionment in content.Embedded.Environments)
                {
                    envrionment.ETag = eTag;
                }

                return content;
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

        public async Task PatchAsync(string name, GoCDPatchEnvironmentRequest patchDto)
        {
            await this.Endpoint
                      .ToString()
                      .WithHeader("Accept", this.GetAcceptHeader(3))
                      .AppendPathSegment(name)
                      .PatchJsonAsync(patchDto)
                      .ConfigureAwait(false);
        }

        public async Task UpdateAsync(string name, string eTag, GoCDUpdateEnvironmentRequest updateRequest)
        {
            await this.Endpoint
                      .ToString()
                      .WithHeader("Accept", this.GetAcceptHeader(3))
                      .WithHeader("If-Match", eTag)
                      .AppendPathSegment(name)
                      .PutJsonAsync(updateRequest)
                      .ConfigureAwait(false);
        }
    }
}
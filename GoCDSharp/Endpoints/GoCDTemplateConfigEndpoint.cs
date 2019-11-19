using Flurl.Http;
using Newtonsoft.Json;
using GoCDSharp.Dtos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GoCDSharp.Endpoints
{
    public interface IGoCDTemplateConfigEndpoint
    {
        Task<GoCDTemplate> CreateAsync(GoCDTemplate template);

        Task DeleteAsync(string templateName);

        Task<GoCDTemplateConfig> GetAllAsync();

        Task<GoCDTemplate> GetAsync(string name);

        Task UpdateAsync(GoCDTemplate template, string name = null);
    }

    public class GoCDTemplateConfigEndpoint : GoCDEndpoint, IGoCDTemplateConfigEndpoint
    {
        public GoCDTemplateConfigEndpoint(Uri apiBaseUri) : base(apiBaseUri, "admin/templates")
        {
        }

        public async Task<GoCDTemplate> CreateAsync(GoCDTemplate template)
        {
            return await this.Endpoint
                             .ToString()
                             .WithHeader("Accept", this.GetAcceptHeader(5))
                             .PostJsonAsync(template)
                             .ReceiveJson<GoCDTemplate>()
                             .ConfigureAwait(false);
        }

        public async Task DeleteAsync(string name)
        {
            await this.Endpoint
                      .ToString()
                      .WithHeader("Accept", this.GetAcceptHeader(5))
                      .AppendPathSegment(name)
                      .DeleteAsync()
                      .ConfigureAwait(false);
        }

        public async Task<GoCDTemplateConfig> GetAllAsync()
        {
            return await this.Endpoint
                             .ToString()
                             .WithHeader("Accept", this.GetAcceptHeader(5))
                             .GetJsonAsync<GoCDTemplateConfig>()
                             .ConfigureAwait(false);
        }

        public async Task<GoCDTemplate> GetAsync(string name)
        {
            var request = this.Endpoint
                              .ToString()
                              .WithHeader("Accept", this.GetAcceptHeader(5))
                              .AppendPathSegment(name);

            using (var result = await request.GetAsync().ConfigureAwait(false))
            {
                var eTag = result.Headers.GetValues("ETag").FirstOrDefault();
                var rawContent = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                var content = JsonConvert.DeserializeObject<GoCDTemplate>(rawContent);
                content.ETag = eTag;

                return content;
            }
        }

        public async Task UpdateAsync(GoCDTemplate template, string name = null)
        {
            await this.Endpoint
                      .ToString()
                      .WithHeader("Accept", this.GetAcceptHeader(5))
                      .WithHeader("If-Match", template.ETag)
                      .AppendPathSegment(name ?? template.Name)
                      .PutJsonAsync(template)
                      .ConfigureAwait(false);
        }
    }
}
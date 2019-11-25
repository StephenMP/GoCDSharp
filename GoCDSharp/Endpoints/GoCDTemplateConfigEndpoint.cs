using Flurl.Http;
using GoCDSharp.Dtos;
using Newtonsoft.Json;
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
        public GoCDTemplateConfigEndpoint(Uri apiBaseUri) : base(apiBaseUri, "admin/templates", 5)
        {
        }

        public async Task<GoCDTemplate> CreateAsync(GoCDTemplate template)
        {
            return await this.BeginRequest()
                             .PostJsonAsync(template)
                             .ReceiveJson<GoCDTemplate>()
                             .ConfigureAwait(false);
        }

        public async Task DeleteAsync(string name)
        {
            await this.BeginRequest()
                      .AppendPathSegment(name)
                      .DeleteAsync()
                      .ConfigureAwait(false);
        }

        public async Task<GoCDTemplateConfig> GetAllAsync()
        {
            return await this.BeginRequest()
                             .GetJsonAsync<GoCDTemplateConfig>()
                             .ConfigureAwait(false);
        }

        public async Task<GoCDTemplate> GetAsync(string name)
        {
            var request = this.BeginRequest()
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
            await this.BeginRequest()
                      .WithHeader("If-Match", template.ETag)
                      .AppendPathSegment(name ?? template.Name)
                      .PutJsonAsync(template)
                      .ConfigureAwait(false);
        }
    }
}
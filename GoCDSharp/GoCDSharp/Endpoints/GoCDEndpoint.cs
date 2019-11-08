using System;

namespace GoCDSharp.Endpoints
{
    public abstract class GoCDEndpoint
    {
        public GoCDEndpoint(Uri apiBaseUri, string endpoint)
        {
            this.Endpoint = new Uri(apiBaseUri, endpoint);
        }

        public Uri Endpoint { get; }

        public string GetAcceptHeader(int version)
        {
            return $"application/vnd.go.cd.v{version}+json";
        }
    }
}
using Flurl.Http;
using System;

namespace GoCDSharp.Endpoints
{
    public abstract class GoCDEndpoint
    {
        public GoCDEndpoint(Uri apiBaseUri, string endpoint, int endpointVersion)
        {
            this.Endpoint = new Uri(apiBaseUri, $"/go/api/{endpoint}");
            this.EndpointVersion = endpointVersion;
        }

        public Uri Endpoint { get; }
        public int EndpointVersion { get; }

        public IFlurlRequest BeginRequest(int? endpointVersion = null)
        {
            return this.Endpoint
                       .ToString()
                       .WithHeader("Accept", this.GetAcceptHeader(endpointVersion ?? this.EndpointVersion));

        }

        public string GetAcceptHeader(int version)
        {
            return $"application/vnd.go.cd.v{version}+json";
        }
    }
}
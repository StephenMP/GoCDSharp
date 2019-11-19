using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Globalization;

namespace GoCDSharp.Dtos
{
    public partial class GoCDEmbedded : GoCDEntity
    {
        [JsonProperty("environments")]
        public List<GoCDEnvironment> Environments { get; set; }
    }

    public partial class GoCDEnvironment : GoCDEntity
    {
        [JsonProperty("environment_variables")]
        public List<GoCDEnvironmentVariable> EnvironmentVariables { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("pipelines")]
        public List<GoCDPipeline> Pipelines { get; set; }
    }

    public partial class GoCdEnvironmentsLinks : GoCDEntity
    {
        [JsonProperty("doc")]
        public GoCDDoc Doc { get; set; }

        [JsonProperty("self")]
        public GoCDDoc Self { get; set; }
    }

    public partial class GoCDEnvironmentVariable : GoCDEntity
    {
        [JsonProperty("encrypted_value", NullValueHandling = NullValueHandling.Ignore)]
        public string EncryptedValue { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("secure")]
        public bool Secure { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
    }

    public partial class GoCDLinks : GoCDEntity
    {
        [JsonProperty("doc")]
        public GoCDDoc Doc { get; set; }

        [JsonProperty("find")]
        public GoCDDoc Find { get; set; }

        [JsonProperty("self")]
        public GoCDDoc Self { get; set; }
    }

    internal static class GoCDEnvironmentConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace GoCDSharp.Dtos
{
    public partial struct FreeSpace
    {
        public long? Integer;
        public string String;

        public static implicit operator FreeSpace(long Integer) => new FreeSpace { Integer = Integer };

        public static implicit operator FreeSpace(string String) => new FreeSpace { String = String };
    }

    public partial class GoCDAgent : GoCDEntity
    {
        [JsonProperty("agent_config_state")]
        public string AgentConfigState { get; set; }

        [JsonProperty("agent_state")]
        public string AgentState { get; set; }

        [JsonProperty("build_state")]
        public string BuildState { get; set; }

        [JsonProperty("environments")]
        public List<GoCDEnvironment> Environments { get; set; }

        [JsonProperty("free_space")]
        public FreeSpace FreeSpace { get; set; }

        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }

        [JsonProperty("operating_system")]
        public string OperatingSystem { get; set; }

        [JsonProperty("resources")]
        public List<object> Resources { get; set; }

        [JsonProperty("sandbox")]
        public string Sandbox { get; set; }

        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }
    }

    public partial class GoCDAgentLinks : GoCDEntity
    {
        [JsonProperty("doc")]
        public GoCDDoc Doc { get; set; }

        [JsonProperty("find")]
        public GoCDDoc Find { get; set; }

        [JsonProperty("self")]
        public GoCDDoc Self { get; set; }
    }

    public partial class GoCdAgents : GoCDEntity
    {
        [JsonProperty("_embedded")]
        public GoCDEmbedded Embedded { get; set; }
    }

    public partial class GoCdAgentsLinks : GoCDEntity
    {
        [JsonProperty("doc")]
        public GoCDDoc Doc { get; set; }

        [JsonProperty("self")]
        public GoCDDoc Self { get; set; }
    }

    public partial class GoCDDoc : GoCDEntity
    {
        [JsonProperty("href")]
        public Uri Href { get; set; }
    }

    public partial class GoCDEmbedded : GoCDEntity
    {
        public GoCDEmbedded()
        {
            this.Agents = new List<GoCDAgent>();
        }

        [JsonProperty("agents")]
        public List<GoCDAgent> Agents { get; set; }
    }

    public partial class Origin : GoCDEntity
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    internal static class GoCDAgentsConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                GoCDAgentsFreeSpaceConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class GoCDAgentsFreeSpaceConverter : JsonConverter
    {
        public static readonly GoCDAgentsFreeSpaceConverter Singleton = new GoCDAgentsFreeSpaceConverter();

        public override bool CanConvert(Type t) => t == typeof(FreeSpace) || t == typeof(FreeSpace?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return new FreeSpace { Integer = integerValue };

                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new FreeSpace { String = stringValue };
            }
            throw new Exception("Cannot unmarshal type FreeSpace");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (FreeSpace)untypedValue;
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value);
                return;
            }
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            throw new Exception("Cannot marshal type FreeSpace");
        }
    }
}
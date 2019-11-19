using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using GoCDSharp.Constants;
using System;
using System.Collections.Generic;

namespace GoCDSharp.Dtos
{
    public class GoCDJob : GoCDEntity
    {
        [JsonProperty("environment_variables")]
        public List<GoCDEnvironmentVariable> EnvironmentVariables { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("resources")]
        public List<string> Resources { get; set; }

        [JsonProperty("run_instance_count")]
        [JsonConverter(typeof(GoCDRunInstanceCountDataConverter))]
        public GoCDJobRunInstanceCount RunInstanceCount { get; set; }

        [JsonProperty("tasks")]
        public List<GoCDTask> Tasks { get; set; }

        [JsonProperty("timeout")]
        public int? Timeout { get; set; }
    }

    public class GoCDJobRunInstanceCount
    {
        public bool All { get; set; }
        public int Count { get; set; }
    }

    internal class GoCDRunInstanceCountDataConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(int) || objectType == typeof(string));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Type == JTokenType.Integer)
            {
                return GoCDJobRunInstanceCountConstants.RunOnInstances(token.Value<int>());
            }

            if (token.Type == JTokenType.String)
            {
                if (token.Value<string>().ToString().Equals("all", StringComparison.OrdinalIgnoreCase))
                {
                    return GoCDJobRunInstanceCountConstants.RunOnAllAgents;
                }
            }

            return GoCDJobRunInstanceCountConstants.RunOnOneInstance;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var instance = value as GoCDJobRunInstanceCount;
            if (instance == null)
            {
                serializer.Serialize(writer, null);
            }
            else if (instance.All)
            {
                serializer.Serialize(writer, "all");
            }
            else
            {
                serializer.Serialize(writer, instance.Count);
            }
        }
    }
}
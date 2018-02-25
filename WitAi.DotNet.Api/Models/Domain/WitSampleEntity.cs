using Newtonsoft.Json;
using System.ComponentModel;

namespace WitAi.DotNet.Api.Models.Domain
{
    public class WitSampleEntity
    {
        [JsonProperty("entity")]
        public string Entity { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [DefaultValue(null)]
        [JsonProperty("start", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? Start { get; set; }

        [DefaultValue(null)]
        [JsonProperty("end", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? End { get; set; }

        public WitSampleEntity() { }

        public WitSampleEntity(string entity, string value)
        {
            Entity = entity;
            Value = value;
        }

        public WitSampleEntity(string entity, string value, int start, int end)
        {
            Entity = entity;
            Value = value;
            Start = start;
            End = end;
        }
    }
}
using Newtonsoft.Json;

namespace WitAi.DotNet.Api.Models.Domain
{
    public class WitNormalizedValue
    {
        [JsonProperty("value")]
        public object Value { get; set; }

        [JsonProperty("unit")]
        public string Second { get; set; }
    }
}
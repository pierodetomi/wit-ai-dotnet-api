using Newtonsoft.Json;

namespace WitAi.DotNet.Api.Models.Domain
{
    public class WitRangeValue
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("grain")]
        public string Grain { get; set; }
    }
}
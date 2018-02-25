using Newtonsoft.Json;
using System.Collections.Generic;

namespace WitAi.DotNet.Api.Models.Domain
{
    public class WitParsedEntityValue
    {
        public string EntityValueJson { get; set; }

        [JsonProperty("confidence")]
        public decimal Confidence { get; set; }

        [JsonProperty("suggested")]
        public bool? IsSuggested { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("start")]
        public int? Start { get; set; }

        [JsonProperty("end")]
        public int? End { get; set; }

        [JsonProperty("body")]
        public int? Body { get; set; }
    }
}
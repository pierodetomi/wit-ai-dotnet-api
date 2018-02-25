using Newtonsoft.Json;
using System.Collections.Generic;

namespace WitAi.DotNet.Api.Models.Domain
{
    public class WitEntityValue
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("expressions")]
        public List<string> Expressions { get; set; }
    }
}
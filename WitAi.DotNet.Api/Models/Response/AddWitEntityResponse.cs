using Newtonsoft.Json;
using System.Collections.Generic;

namespace WitAi.DotNet.Api.Models.Response
{
    public class AddWitEntityResponse : BaseWitResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("doc")]
        public string Doc { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("lookups")]
        public List<string> Lookups { get; set; }

        [JsonProperty("builtin")]
        public bool Builtin { get; set; }
    }
}
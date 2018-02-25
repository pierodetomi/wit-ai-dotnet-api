using Newtonsoft.Json;
using System.Collections.Generic;
using WitAi.DotNet.Api.Models.Domain;

namespace WitAi.DotNet.Api.Models.Response
{
    public class GetWitEntityResponse : BaseWitResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("doc")]
        public string Description { get; set; }

        [JsonProperty("lookups")]
        public List<string> Lookups { get; set; }

        [JsonProperty("lang")]
        public string LanguageCode { get; set; }

        [JsonProperty("builtin")]
        public bool IsBuiltIn { get; set; }

        [JsonProperty("values")]
        public List<WitEntityValue> Values { get; set; }
    }
}
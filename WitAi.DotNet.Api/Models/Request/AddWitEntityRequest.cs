using Newtonsoft.Json;

namespace WitAi.DotNet.Api.Models.Request
{
    public class AddWitEntityRequest : BaseWitRequest
    {
        [JsonProperty("id")]
        public string EntityName { get; set; }

        [JsonProperty("doc", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Description { get; set; }

        public AddWitEntityRequest() { }

        public AddWitEntityRequest(string accessToken) : base(accessToken) { }
    }
}
using Newtonsoft.Json;

namespace WitAi.DotNet.Api.Models.Request
{
    public class CreateWitAppRequest : BaseWitRequest
    {
        [JsonProperty("name")]
        public string AppName { get; set; }

        [JsonProperty("desc", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string AppDescription { get; set; }

        [JsonProperty("lang")]
        public string LanguageCode { get; set; }

        [JsonProperty("private")]
        public bool IsPrivate { get; set; }

        public CreateWitAppRequest() { }

        public CreateWitAppRequest(string accessToken) : base(accessToken) { }
    }
}
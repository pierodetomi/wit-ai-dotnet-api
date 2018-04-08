using Newtonsoft.Json;

namespace WitAi.DotNet.Api.Models.Request
{
    public class UpdateWitAppRequest : BaseWitRequest
    {
        public string AppId { get; set; }

        [JsonProperty("name")]
        public string AppName { get; set; }

        [JsonProperty("desc", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string AppDescription { get; set; }

        [JsonProperty("lang", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LanguageCode { get; set; }

        [JsonProperty("private", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsPrivate { get; set; }

        [JsonProperty("timezone", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Timezone { get; set; }

        public UpdateWitAppRequest() { }

        public UpdateWitAppRequest(string accessToken, string appId, string appName) : base(accessToken)
        {
            AppId = appId;
            AppName = appName;
        }
    }
}
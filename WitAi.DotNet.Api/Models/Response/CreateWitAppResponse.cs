using Newtonsoft.Json;

namespace WitAi.DotNet.Api.Models.Response
{
    public class CreateWitAppResponse : BaseWitResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("app_id")]
        public string AppId { get; set; }
    }
}
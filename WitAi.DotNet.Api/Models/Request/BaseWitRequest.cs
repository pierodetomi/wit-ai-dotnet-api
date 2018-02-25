using Newtonsoft.Json;

namespace WitAi.DotNet.Api.Models.Request
{
    public class BaseWitRequest
    {
        [JsonIgnore]
        public string AccessToken { get; set; }

        public BaseWitRequest() { }

        public BaseWitRequest(string accessToken)
        {
            AccessToken = accessToken;
        }
    }
}
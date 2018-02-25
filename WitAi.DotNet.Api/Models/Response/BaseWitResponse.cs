using Newtonsoft.Json;

namespace WitAi.DotNet.Api.Models.Response
{
    public class BaseWitResponse
    {
        [JsonProperty("success")]
        public bool IsSuccessful { get; set; }

        public string ErrorMessage { get; set; }
    }
}
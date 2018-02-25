using Newtonsoft.Json;

namespace WitAi.DotNet.Api.Models.Request
{
    public class ParseWitMessageRequest : BaseWitRequest
    {
        [JsonProperty("q")]
        public string Message { get; set; }

        [JsonProperty("msg_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string MessageId { get; set; }

        [JsonProperty("thread_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ThreadId { get; set; }

        [JsonProperty("n", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? MaxResults { get; set; }

        [JsonProperty("verbose", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? Verbose { get; set; }

        public ParseWitMessageRequest() { }

        public ParseWitMessageRequest(string accessToken) : base(accessToken) { }
    }
}
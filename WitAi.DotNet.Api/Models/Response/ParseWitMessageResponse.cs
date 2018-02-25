using Newtonsoft.Json;
using System.Collections.Generic;

namespace WitAi.DotNet.Api.Models.Response
{
    public class ParseWitMessageResponse : BaseWitResponse
    {
        [JsonProperty("msg_id")]
        public string MessageId { get; set; }

        [JsonProperty("_text")]
        public string Text { get; set; }

        [JsonProperty("entities")]
        public Dictionary<string, List<object>> Entities { get; set; }
    }
}
using Newtonsoft.Json;
using System.Collections.Generic;
using WitAi.DotNet.Api.Models.Domain;

namespace WitAi.DotNet.Api.Models.Response
{
    public class ParseWitMessageResponse : BaseWitResponse
    {
        [JsonProperty("msg_id")]
        public string MessageId { get; set; }

        [JsonProperty("_text")]
        public string Text { get; set; }

        [JsonProperty("entities")]
        public Dictionary<string, List<WitParsedEntity>> Entities { get; set; }
    }
}
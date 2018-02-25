using Newtonsoft.Json;
using System.Collections.Generic;

namespace WitAi.DotNet.Api.Models.Domain
{
    public class WitTrainingSample
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("entities")]
        public List<WitSampleEntity> Entities { get; set; }
    }
}
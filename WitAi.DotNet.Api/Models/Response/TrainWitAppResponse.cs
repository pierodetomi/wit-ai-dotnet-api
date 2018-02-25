using Newtonsoft.Json;

namespace WitAi.DotNet.Api.Models.Response
{
    public class TrainWitAppResponse : BaseWitResponse
    {
        [JsonProperty("sent")]
        public bool IsTrained { get; set; }

        [JsonProperty("n")]
        public int SamplesSentCount { get; set; }
    }
}
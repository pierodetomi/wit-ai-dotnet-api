using System.Collections.Generic;
using WitAi.DotNet.Api.Models.Domain;

namespace WitAi.DotNet.Api.Models.Request
{
    public class TrainWitAppRequest : BaseWitRequest
    {
        public List<WitTrainingSample> Samples { get; set; }

        public TrainWitAppRequest() { }

        public TrainWitAppRequest(string accessToken) : base(accessToken) { }
    }
}
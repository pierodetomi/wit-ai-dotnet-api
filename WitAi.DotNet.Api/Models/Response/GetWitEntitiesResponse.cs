using System.Collections.Generic;

namespace WitAi.DotNet.Api.Models.Response
{
    public class GetWitEntitiesResponse : BaseWitResponse
    {
        public List<string> Entities { get; set; }
    }
}
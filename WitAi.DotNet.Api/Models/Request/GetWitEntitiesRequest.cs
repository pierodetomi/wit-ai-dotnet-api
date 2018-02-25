namespace WitAi.DotNet.Api.Models.Request
{
    public class GetWitEntitiesRequest : BaseWitRequest
    {
        public GetWitEntitiesRequest() { }

        public GetWitEntitiesRequest(string accessToken) : base(accessToken) { }
    }
}
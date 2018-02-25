namespace WitAi.DotNet.Api.Models.Request
{
    public class GetWitEntityRequest : BaseWitRequest
    {
        public string EntityNameOrId { get; set; }

        public GetWitEntityRequest() { }

        public GetWitEntityRequest(string accessToken) : base(accessToken) { }
    }
}
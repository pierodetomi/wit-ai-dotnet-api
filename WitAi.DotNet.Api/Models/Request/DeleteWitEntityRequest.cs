namespace WitAi.DotNet.Api.Models.Request
{
    public class DeleteWitEntityRequest : BaseWitRequest
    {
        public string EntityNameOrId { get; set; }

        public DeleteWitEntityRequest() { }

        public DeleteWitEntityRequest(string accessToken) : base(accessToken) { }
    }
}
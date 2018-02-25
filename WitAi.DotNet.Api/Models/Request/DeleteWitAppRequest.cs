namespace WitAi.DotNet.Api.Models.Request
{
    public class DeleteWitAppRequest : BaseWitRequest
    {
        public string AppId { get; set; }

        public DeleteWitAppRequest() { }

        public DeleteWitAppRequest(string accessToken) : base(accessToken) { }
    }
}
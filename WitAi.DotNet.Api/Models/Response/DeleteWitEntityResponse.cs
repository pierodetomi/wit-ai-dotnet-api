using Newtonsoft.Json;

namespace WitAi.DotNet.Api.Models.Response
{
    public class DeleteWitEntityResponse : BaseWitResponse
    {
        [JsonProperty("deleted")]
        public string DeletedEntityNameOrId { get; set; }
    }
}
using System.Collections.Generic;
using WitAi.DotNet.Api.Models.Domain;

namespace WitAi.DotNet.Api.Models.Response
{
    public class ParseWitMessageResponse : BaseWitResponse
    {
        public string MessageId { get; set; }

        public string Text { get; set; }

        public List<WitParsedEntity> Entities { get; set; }

        public ParseWitMessageResponse()
        {
            Entities = new List<WitParsedEntity> { };
        }
    }
}
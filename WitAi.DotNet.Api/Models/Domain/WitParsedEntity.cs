using System.Collections.Generic;

namespace WitAi.DotNet.Api.Models.Domain
{
    public class WitParsedEntity
    {
        public string EntityName { get; set; }

        public List<WitParsedEntityValue> Values { get; set; }

        public WitParsedEntity()
        {
            Values = new List<WitParsedEntityValue> { };
        }
    }
}
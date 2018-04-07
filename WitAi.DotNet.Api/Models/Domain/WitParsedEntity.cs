using Newtonsoft.Json;
using System.Collections.Generic;

namespace WitAi.DotNet.Api.Models.Domain
{
    public class WitParsedEntity
    {
        /// <summary>
        /// A value that indicates the level of confidence for this entity match.
        /// </summary>
        [JsonProperty("confidence")]
        public decimal Confidence { get; set; }

        /// <summary>
        /// <code>true</code> if this value is the suggested match.
        /// </summary>
        [JsonProperty("suggested")]
        public bool? IsSuggested { get; set; }

        /// <summary>
        /// In case of Type == "value", this property contains the value detected for the entity.
        /// </summary>
        [JsonProperty("value")]
        public object Value { get; set; }

        /// <summary>
        /// If present, indicates the unit of measure of the value.
        /// </summary>
        [JsonProperty("unit")]
        public string Unit { get; set; }

        /// <summary>
        /// In case of entities of type <code>wit$quantity</code>, this can indicate the product described by the quantity (e.g.: "3 cups of sugar" => product = "sugar").
        /// </summary>
        [JsonProperty("product")]
        public string Product { get; set; }

        /// <summary>
        /// If present, describes the value in the normalized form of value and unit.
        /// </summary>
        [JsonProperty("normalized")]
        public WitNormalizedValue NormalizedValue { get; set; }

        /// <summary>
        /// If present, indicates the level of detail of the value.
        /// </summary>
        [JsonProperty("grain")]
        public string Grain { get; set; }

        /// <summary>
        /// The type of entity detected (e.g.: "value", "interval").
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The character index at which the entity starts.
        /// </summary>
        [JsonProperty("start")]
        public int? Start { get; set; }

        /// <summary>
        /// The character index at which the entity ends.
        /// </summary>
        [JsonProperty("end")]
        public int? End { get; set; }

        [JsonProperty("body")]
        public int? Body { get; set; }

        /// <summary>
        /// This will have a value in case of Type == "interval".
        /// </summary>
        [JsonProperty("from")]
        public WitRangeValue From { get; set; }

        /// <summary>
        /// This will have a value in case of Type == "interval".
        /// </summary>
        [JsonProperty("to")]
        public WitRangeValue To { get; set; }

        /// <summary>
        /// This will have a value in case of Type == "interval".
        /// </summary>
        [JsonProperty("values")]
        public List<WitParsedEntity> Values { get; set; }

        /// <summary>
        /// In case of composite entities, this list will contain "child" entities.
        /// </summary>
        [JsonProperty("entities")]
        public Dictionary<string, List<WitParsedEntity>> Entities { get; set; }
    }
}
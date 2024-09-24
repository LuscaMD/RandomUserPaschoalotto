using System.Text.Json.Serialization;

namespace RandomUserGeneratorPaschoalotto.Domain.Entities
{
    public class Id
    {
        [JsonPropertyName("nameId")]
        public string? NameId { get; set; }

        [JsonPropertyName("valueId")]
        public string? ValueId { get; set; }
    }
}

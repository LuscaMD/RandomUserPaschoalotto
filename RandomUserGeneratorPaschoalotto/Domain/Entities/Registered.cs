using System.Text.Json.Serialization;

namespace RandomUserGeneratorPaschoalotto.Domain.Entities
{
    public class Registered
    {
        [JsonPropertyName("dateRegistered")]
        public string? DateRegistered { get; set; }

        [JsonPropertyName("ageRegistered")]
        public int AgeRegistered { get; set; }
    }
}

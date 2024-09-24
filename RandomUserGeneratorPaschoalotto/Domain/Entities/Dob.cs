using System.Text.Json.Serialization;

namespace RandomUserGeneratorPaschoalotto.Domain.Entities
{
    public class Dob
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }
    }
}

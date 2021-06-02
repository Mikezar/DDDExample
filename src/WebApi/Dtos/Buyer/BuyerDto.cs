using System.Text.Json.Serialization;

namespace WebApi.Dtos.Buyer
{
    public class BuyerDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}

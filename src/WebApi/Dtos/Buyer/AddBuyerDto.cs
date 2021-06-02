using System.Text.Json.Serialization;

namespace WebApi.Dtos.Buyer
{
    public class AddBuyerDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}

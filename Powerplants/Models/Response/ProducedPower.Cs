using System.Text.Json.Serialization;

namespace Powerplants.Models.Response
{
    public class ProducedPower
    {
        public string Name { get; set; }
        [JsonPropertyName("p")]
        public decimal Power { get; set; }
    }
}

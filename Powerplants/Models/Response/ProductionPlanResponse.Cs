using System.Text.Json.Serialization;

namespace Powerplants.Models.Response
{
    public class ProductionPlanResponse
    {
        public string Name { get; set; }
        [JsonPropertyName("P")]
        public decimal Power { get; set; }
    }
}

using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Powerplants.Models
{
    public class Fuel
    {
        public Fuel()
        {
        }

        public Fuel(decimal gasEuroPerMWh, decimal kerosineEuroPerMWh, decimal co2EuroPerTon, decimal wind)
        {
            GasEuroPerMWh = gasEuroPerMWh;
            KerosineEuroPerMWh = kerosineEuroPerMWh;
            Co2EuroPerTon = co2EuroPerTon;
            WindPercentage = wind;
        }

        [JsonPropertyName("gas(euro/MWh)")]
        public decimal GasEuroPerMWh { get; set; }

        [JsonPropertyName("kerosine(euro/MWh)")]
        public decimal KerosineEuroPerMWh { get; set; }

        [JsonPropertyName("co2(euro/ton)")]
        public decimal Co2EuroPerTon { get; set; }

        [JsonPropertyName("wind(%)")]
        public decimal WindPercentage { get; set; }
    }
}

using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Powerplants.Models
{
    public class Fuel
    {
        public Fuel(decimal gasEuroPerMWh, decimal kerosineEuroPerMWh, decimal co2EuroPerTon, decimal wind)
        {
            GasEuroPerMWh = gasEuroPerMWh;
            KerosineEuroPerMWh = kerosineEuroPerMWh;
            Co2EuroPerTon = co2EuroPerTon;
            Wind = wind;
        }

        [JsonPropertyName("gas(euro/MWh)")]
        [Required]
        [Min(0)]
        public decimal GasEuroPerMWh { get; set; }

        [JsonPropertyName("kerosine(euro/MWh)")]
        [Required]
        [Min(0)]
        public decimal KerosineEuroPerMWh { get; set; }

        [JsonPropertyName("co2(euro/ton)")]
        [Required]
        [Min(0)]
        public decimal Co2EuroPerTon { get; set; }

        [JsonPropertyName("wind(%)")]
        [Required]
        [Min(0)]
        public decimal Wind { get; set; }
    }
}

namespace Powerplants.Models
{
    public class PowerPlant
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Efficiency { get; set; }
        public decimal Pmin { get; set; }
        public decimal Pmax { get; set; }
        public decimal CostPer1Mwh { get; set; }
    }
}

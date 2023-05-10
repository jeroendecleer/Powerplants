using Powerplants.Models;
using Powerplants.Models.Response;

namespace Powerplants.Services
{
    public class ProductionPlanCalculator : IProductionPlanCalculator
    {
        private readonly ILogger<ProductionPlanCalculator> _logger;

        public ProductionPlanCalculator(ILogger<ProductionPlanCalculator> logger)
        {
            _logger = logger;
        }

        public List<ProducedPower> CalculateProductionPlan(Payload payload)
        {
            _logger.LogInformation("Calculating production plan");
            calculateCostPer1MWh(payload.Fuels, payload.PowerPlants);
            payload.PowerPlants = payload.PowerPlants.OrderBy(p => p.CostPer1Mwh).ToList();

            return calculatePowerPerPowerplant(payload);
        }

        private List<ProducedPower> calculatePowerPerPowerplant(Payload payload)
        {
            List<ProducedPower> producedPowers = new List<ProducedPower>();
            var neededLoad = payload.Load;

            payload.PowerPlants.ForEach(powerplant =>
            {
                if (powerplant.Pmax <= neededLoad && neededLoad > 0)
                {
                    producedPowers.Add(new ProducedPower
                    {
                        Name = powerplant.Name,
                        Power = powerplant.Pmax
                    });
                    neededLoad -= powerplant.Pmax;
                }
                else if (powerplant.Pmax > neededLoad && neededLoad > 0)
                {
                    producedPowers.Add(new ProducedPower
                    {
                        Name = powerplant.Name,
                        Power = neededLoad
                    });
                    neededLoad -= neededLoad;
                }
                else
                {
                    producedPowers.Add(new ProducedPower
                    {
                        Name = powerplant.Name,
                        Power = 0
                    });
                }
            });

            return producedPowers;
        }


        private void calculateCostPer1MWh(Fuel fuels, List<PowerPlant> powerplants)
        {
            powerplants.Where(p => p.Type == PowerPlantType.GASFIRED.ToString().ToLower()).ToList().ForEach(gasFiredPowerplant => gasFiredPowerplant.CostPer1Mwh = 1 / gasFiredPowerplant.Efficiency * fuels.GasEuroPerMWh);
            powerplants.Where(t => t.Type == PowerPlantType.TURBOJET.ToString().ToLower()).ToList().ForEach(turbojetPowerplant => turbojetPowerplant.CostPer1Mwh = 1 / turbojetPowerplant.Efficiency * fuels.KerosineEuroPerMWh);
            powerplants.Where(x => x.Type == PowerPlantType.WINDTURBINE.ToString().ToLower()).ToList().ForEach(windTurbinePowerplant  => windTurbinePowerplant.CostPer1Mwh = 0);
            powerplants.Where(x => x.Type == PowerPlantType.WINDTURBINE.ToString().ToLower()).ToList().ForEach(windTurbinePowerplant => windTurbinePowerplant.Pmax = windTurbinePowerplant.Pmax * fuels.WindPercentage / 100);
        }
    }
}

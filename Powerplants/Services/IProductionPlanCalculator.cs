using Powerplants.Models;
using Powerplants.Models.Response;

namespace Powerplants.Services
{
    public interface IProductionPlanCalculator
    {
        List<ProducedPower> CalculateProductionPlan(Payload payload);
    }
}

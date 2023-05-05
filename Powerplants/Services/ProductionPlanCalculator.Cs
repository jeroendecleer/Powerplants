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

        public List<ProductionPlanResponse> CalculateProductionPlan(Payload payload)
        {
            _logger.LogInformation("Calculating production plan");

            return new List<ProductionPlanResponse>
            {
                new ProductionPlanResponse
                {
                    Name = "test",
                    Power = 5
                },
                new ProductionPlanResponse
                {
                    Name = "test",
                    Power = 4
                },
            };
        }
    }
}

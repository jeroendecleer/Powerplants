using Microsoft.AspNetCore.Mvc;
using Powerplants.Models;
using Powerplants.Services;

namespace Powerplants.Controllers
{
    [Route("productionplan")]
    [ApiController]
    public class ProductionPlanController : ControllerBase
    {
        private readonly ILogger<ProductionPlanController> _logger;
        private readonly IProductionPlanCalculator _productionPlanCalculator;
        public ProductionPlanController(ILogger<ProductionPlanController> logger, IProductionPlanCalculator productionPlanCalculator)
        {
            _logger = logger;
            _productionPlanCalculator = productionPlanCalculator;
        }

        [HttpPost]
        public IActionResult CreateProductionPlan([FromBody] Payload payload)
        {
            _logger.LogInformation("Start creation of production plan");

            var response = _productionPlanCalculator.CalculateProductionPlan(payload);
            return Ok(response);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Powerplants.Models;

namespace Powerplants.Controllers
{
    [Route("productionplan")]
    [ApiController]
    public class ProductionPlanController : ControllerBase
    {
        private readonly ILogger<ProductionPlanController> _logger;
        public ProductionPlanController(ILogger<ProductionPlanController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult CreateProductionPlan([FromBody] Payload payload)
        {
            _logger.LogInformation("Start creation of production plan");

            var response = new
            {
                message = "Production plan created successfully",
                payload = payload
            };

            return Ok(response);
        }
    }
}
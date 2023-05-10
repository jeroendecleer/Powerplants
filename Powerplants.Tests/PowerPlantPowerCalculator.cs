using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Powerplants.Controllers;
using Powerplants.Models;
using Powerplants.Models.Response;
using Powerplants.Services;

namespace Powerplants.Tests
{
    public class Tests
    {
        private ILogger<ProductionPlanCalculator> _logger;
        private ProductionPlanCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            var loggerMock = new Mock<ILogger<ProductionPlanCalculator>>();
            _logger = loggerMock.Object;
            _calculator = new ProductionPlanCalculator(_logger);
        }

        [Test]
        public void CalculateProductionPlan_ReturnsProducedPowerList()
        {
            // Arrange
            var payload = new Payload
            {
                Load = 480,
                Fuels = new Fuel
                {
                    GasEuroPerMWh = 13.4M,
                    KerosineEuroPerMWh = 50.8M,
                    Co2EuroPerTon = 20M,
                    WindPercentage = 60M
                },
                PowerPlants = new List<PowerPlant>
                {
                    new PowerPlant
                    {
                        Name = "gasfiredbig1",
                        Type = "gasfired",
                        Efficiency = 0.53M,
                        Pmin = 100,
                        Pmax = 460
                    },
                    new PowerPlant
                    {
                        Name = "gasfiredbig2",
                        Type = "gasfired",
                        Efficiency = 0.53M,
                        Pmin = 100,
                        Pmax = 460
                    },
                    new PowerPlant
                    {
                        Name = "gasfiredsomewhatsmaller",
                        Type = "gasfired",
                        Efficiency = 0.37M,
                        Pmin = 40,
                        Pmax = 210
                    },
                    new PowerPlant
                    {
                        Name = "tj1",
                        Type = "turbojet",
                        Efficiency = 0.3M,
                        Pmin = 0,
                        Pmax = 16
                    },
                    new PowerPlant
                    {
                        Name = "windpark1",
                        Type = "windturbine",
                        Efficiency = 1M,
                        Pmin = 0,
                        Pmax = 150
                    },
                    new PowerPlant
                    {
                        Name = "windpark2",
                        Type = "windturbine",
                        Efficiency = 1M,
                        Pmin = 0,
                        Pmax = 36
                    }
                }
            };

            var loggerMock = new Mock<ILogger<ProductionPlanController>>();
            var controller = new ProductionPlanController(loggerMock.Object, _calculator);

            // Act
            var producedPower = controller.CreateProductionPlan(payload) as OkObjectResult;

            // Assert
            Assert.NotNull(producedPower);
            Assert.That(producedPower.StatusCode, Is.EqualTo(200));
            var productionPlans = producedPower.Value as List<ProducedPower>;
            Assert.That(payload.Load, Is.EqualTo(productionPlans.Sum(p => p.Power)));

        }
    }
}
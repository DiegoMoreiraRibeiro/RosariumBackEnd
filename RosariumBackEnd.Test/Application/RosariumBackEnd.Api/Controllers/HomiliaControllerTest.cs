using Microsoft.AspNetCore.Mvc;
using Moq;
using RosariumBackEnd.Api.Controllers;
using RosariumBackEnd.Entities.Entities;
using RosariumBackEnd.Service.Interfaces;
using Xunit.Abstractions;

namespace RosariumBackEnd.Test.Application.RosariumBackEnd.Api.Controllers
{
    public class HomiliaControllerTest
    {
        private readonly Mock<IEvangelhoService> mockEvangelhoService;
        private readonly IQueryable<Evangelho> mockIQueryableEvangelho;
        private readonly ITestOutputHelper output;

        public HomiliaControllerTest(ITestOutputHelper output)
        {
            this.output = output;

            // Arrange
            mockEvangelhoService = new Mock<IEvangelhoService>();
            mockIQueryableEvangelho = new List<Evangelho>
            {
                new Evangelho
                {
                    Id = 2,
                    Referencia = "Referencia",
                    Texto = "Texto",
                    Titulo = "Titulo",
                }
            }.AsQueryable();
        }

        [Fact]
        public async Task GetAllEvangelhosAsync_Returns_OkResult_With_Evangelhos()
        {
            // Arrange
            mockEvangelhoService.Setup(service => service.GetAllEvangelhosAsync())
                .ReturnsAsync(mockIQueryableEvangelho);
            output.WriteLine("Setup mock IEvangelhoService");

            var controller = new HomiliaController(mockEvangelhoService.Object);
            output.WriteLine("HomiliaController instance created");

            // Act
            var result = await controller.GetAllEvangelhosAsync();
            output.WriteLine("Controller method GetAllEvangelhosAsync called");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            output.WriteLine("Result is OkObjectResult");

            var evangelhos = Assert.IsAssignableFrom<IEnumerable<Evangelho>>(okResult.Value);
            output.WriteLine("Retrieved evangelhos from OkObjectResult");

            Assert.NotEmpty(evangelhos);
            output.WriteLine("Evangelhos collection is not empty");
        }
    }
}

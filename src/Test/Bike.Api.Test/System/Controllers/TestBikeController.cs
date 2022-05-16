using Bike.Api.Application.Abstract;
using Bike.Api.Test.MockData;
using Bike.Api.WebApi.Controllers;
using Bike.Common.Models;
using Bike.Common.Models.ResponseModels;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Bike.Api.Test.System.Controllers
{
    public class TestBikeController
    {
        private readonly Mock<IBikeService> _bikeService;
        private readonly BikeController _bikeController;

        private readonly BikeModels bikes;

        public TestBikeController()
        {
            _bikeService = new Mock<IBikeService>();
            _bikeController = new BikeController(_bikeService.Object);

            bikes = BikeMockData.GetBikes();
        }

        [Theory]
        [InlineData("amsterdam")]
        public async Task GetBikesAsync_ActionExecutes_ShouldReturn200StatusWithCity(string city)
        {
            // Arrange
            _bikeService.Setup(x => x.GetStolenBikesCountByCity(city)).ReturnsAsync(new BikeTheftModel { City = city, TotalStolen = bikes.Bikes.Count });

            // Act
            var result = (OkObjectResult)await _bikeController.Get(city);

            // Assert
            result.StatusCode.Should().Be(200);

            result.Value.Should().BeOfType<ApiResponseDto>();
            
            var apiResponse = (ApiResponseDto)result.Value;

            _ = apiResponse.StatusCode.Should().Be(200);

            apiResponse.Result.Should().BeOfType<BikeTheftModel>();

            var response = (BikeTheftModel)apiResponse.Result;

            _ = response.City.Should().Be(city);
            _ = response.TotalStolen.Should().Be(bikes.Bikes.Count);
        }        
    }
}

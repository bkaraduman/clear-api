using Bike.Api.Application.Abstract;
using Bike.Api.Application.Concrete;
using Bike.Common;
using Bike.Common.Infrastructure.Exceptions;
using FluentAssertions;
using Moq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Bike.Api.Test.System.Services
{
    public class TestBikeService
    {
        private readonly IHttpClientFactory _mockFactory;

        public TestBikeService()
        {
            _mockFactory = new Mock<IHttpClientFactory>().Object;
        }
        
        [Fact]
        public async Task GetBikesAsync_CityIsExceptional_ShouldReturnValidationException()
        {
            // Arrange
            string city = BikeConstants.ExceptionalCities[0];

            var bikeService = new BikeService(_mockFactory);

            // Act
            Func<Task> act = () => bikeService.GetStolenBikesCountByCity(city);

            // Assert
            await act.Should().ThrowAsync<ValidationException>();            
        }

        [Fact]
        public async Task GetBikesAsync_CityIsRequired_ShouldReturnValidationException()
        {
            // Arrange
            var bikeService = new BikeService(_mockFactory);

            // Act
            Func<Task> act = () => bikeService.GetStolenBikesCountByCity(null);

            // Assert
            await act.Should().ThrowAsync<ValidationException>();
        }
    }
}

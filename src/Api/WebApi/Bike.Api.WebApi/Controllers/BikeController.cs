using Bike.Api.Application.Abstract;
using Bike.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bike.Api.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BikeController : ControllerBase
    {
        private readonly IBikeService _bikeService;

        public BikeController(IBikeService bikeService)
        {
            _bikeService = bikeService;
        }

        [HttpGet]
        [Route("stolen-count/{city}")]
        public async Task<IActionResult> Get(string city)
        {
            var result = await _bikeService.GetStolenBikesCountByCity(city);

            return Ok(new ApiResponseDto
            {
                Result = result
            });
        }
    }
}
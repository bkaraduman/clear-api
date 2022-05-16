using Bike.Api.Application.Abstract;
using Bike.Common;
using Bike.Common.Infrastructure;
using Bike.Common.Infrastructure.Exceptions;
using Bike.Common.Models.ResponseModels;

namespace Bike.Api.Application.Concrete
{
    public class BikeService : IBikeService
    {
        private readonly HttpClient _httpClient;

        public BikeService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("bike-api");
        }

        public async Task<BikeTheftModel> GetStolenBikesCountByCity(string city)
        {
            BikeModels data = new();

            if (string.IsNullOrEmpty(city))
                throw new ValidationException("City is required");

            if (BikeConstants.ExceptionalCities.Contains(city))
                throw new ValidationException("This city is not supported");

            city = city.ToLowerInvariant();

            for (int i = 1; i < int.MaxValue; i++)
            {
                string result = await _httpClient.GetStringAsync($"api/v3/search?page={i}&per_page=25&location={city}&distance=20&stolenness=proximity");

                BikeModels bikes = result.Deserialize<BikeModels>();

                if (bikes.Bikes.Count <= 0)
                    break;

                data.Bikes.AddRange(bikes.Bikes);
            }

            return new BikeTheftModel
            {
                City = city,
                TotalStolen = data.Bikes.Where(x => x.Stolen).Count()
            };
        }
    }
}

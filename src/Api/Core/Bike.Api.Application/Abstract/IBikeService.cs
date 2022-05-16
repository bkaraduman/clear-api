using Bike.Common.Models.ResponseModels;

namespace Bike.Api.Application.Abstract
{
    public interface IBikeService
    {
        Task<BikeTheftModel> GetStolenBikesCountByCity(string city);
    }
}

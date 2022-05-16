using Newtonsoft.Json;

namespace Bike.Common.Models.ResponseModels
{
    public class BikeModels
    {
        public BikeModels()
        {
            Bikes = new List<BikeDetailModels>();
        }

        [JsonProperty("bikes")]
        public List<BikeDetailModels> Bikes { get; set; }
    }
}

using System.Text.Json;

namespace Bike.Common.Infrastructure
{
    public static class JsonExtensions
    {
        public static T Deserialize<T>(this string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,

            };
            return JsonSerializer.Deserialize<T>(json, options);
        }

       

    }
}

using System.Text.Json.Serialization;

namespace WeatherApp_Console.Models
{
    public class ForecastDay
    {
        [JsonPropertyName("date")]
        public DateOnly date { get; set; }
        [JsonPropertyName("date_epoch")]
        public int date_epoch { get; set; }
        [JsonPropertyName("day")]
        public Day day { get; set; }
        [JsonPropertyName("astro")]
        public Astro astro { get; set; }
        [JsonPropertyName("air_quality")]
        public AirQuality? air_quality { get; set; }
        [JsonPropertyName("hour")]
        public Hour[] hour { get; set; }
    }
}

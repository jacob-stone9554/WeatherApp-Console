using System.Text.Json.Serialization;

namespace WeatherApp_Console.Models
{
    class Forecast
    {
        [JsonPropertyName("forecastday")]
        public ForecastDay[] forecastDay { get; set; }
    }
}

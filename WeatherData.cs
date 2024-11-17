using System.Text.Json.Serialization;

namespace WeatherApp_Console
{
    /// <summary>
    ///     WeatherData will hold the information retrieved from the API.
    ///     
    ///     There are subsequent categories (like current, location) that I
    ///         am breaking out into their own objects
    /// </summary>
    class WeatherData
    {
        [JsonPropertyName("location")]
        public Location location {  get; set; }

        [JsonPropertyName("current")]
        public Current current { get; set; }
    }
}

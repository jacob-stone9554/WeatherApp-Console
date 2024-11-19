namespace WeatherApp_Console.Models
{
    class ForecastDay
    {
        public DateOnly date { get; set; }
        public int date_epoch { get; set; }
        public Day day { get; set; }
        public Astro astro { get; set; }
        public AirQuality air_quality { get; set; }
        public Hour hour { get; set; }
    }
}

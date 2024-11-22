namespace WeatherApp_Console.Models
{
    public class Hour
    {
        public int time_epoch {  get; set; }
        public string time {  get; set; }
        public decimal temp_c {  get; set; }
        public decimal temp_f { get; set; }
        public string conditionText { get; set; }
        public string conditionIcon { get; set; }
        public int conditionCode { get; set; }
        public decimal wind_mph { get; set; }
        public decimal wind_kph { get; set; }
        public int wind_degree { get; set; }
        public string wind_dir { get; set; }
        public decimal pressure_mb { get; set; }
        public decimal pressure_in { get; set; }
        public decimal precip_mm {  get; set; }
        public decimal precim_in { get; set; }
        public decimal snow_cm { get; set; }
        public int humidity { get; set; }
        public int cloud {  get; set; }
        public decimal feelslike_c { get; set; }
        public decimal feelslike_f { get; set; }
        public decimal windchill_c { get; set; }
        public decimal windchill_f { get; set; }
        public decimal heatindex_c { get; set; }
        public decimal heatindex_f { get;set; }
        public decimal dewpoint_c { get; set; }
        public decimal dewpoint_f { get; set ; }
        public int will_it_rain { get; set; }
        public int will_it_snow { get; set; }
        public int is_day { get; set; }
        public decimal vis_km { get; set; }
        public decimal vis_miles { get; set; }
        public int chance_of_rain { get; set; }
        public int chance_of_snow { get; set; }
        public decimal gust_mph { get; set; }
        public decimal gust_kph { get; set; }
        public decimal uv {  get; set; }
        public decimal short_rad { get; set; }
        public decimal diff_rad { get; set; }
        public AirQuality air_quality { get; set; }

    }
}

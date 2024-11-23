using Newtonsoft.Json;

namespace WeatherApp_Console.Models
{
    public class Day
    {
        public decimal maxtemp_c {  get; set; }
        public decimal maxtemp_f { get; set; }
        public decimal mintemp_c { get; set; }
        public decimal mintemp_f { get; set;}
        public decimal avgtemp_c { get; set; }
        public decimal avgtemp_f { get;set; }
        public decimal maxwind_mph { get; set; }
        public decimal maxwind_kph { get; set; }
        public decimal totalprecip_mm { get; set; }
        public decimal totalprecip_in { get; set; }
        public decimal totalsnow_in { get; set; }
        public decimal avgvis_km { get; set; }
        public decimal avgvis_miles { get; set; }
        public int avghumidity { get; set; }
        [JsonProperty("condition")]
        public Condition condition { get; set; }
        public decimal uv {  get; set; }
        public int daily_will_it_rain { get; set; } // 1 = yes, 2 = no --> will it rain or not
        public int daily_will_it_snow { get; set; } // 1 = yes, 2 = no --> will it rain or not
        public int daily_chance_of_rain { get; set; }
        public int daily_chance_of_snow { get; set; }
    }
}

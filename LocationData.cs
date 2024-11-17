namespace WeatherApp_Console
{
    class Location
    {
        public string? name;
        public string? region;
        public string? timezone;
        public decimal latitude;
        public decimal longitude;
        public ulong localtime_epoch;
        public DateTime localtime; 
    }
}
//switch this to string if there are issues pulling data from the json
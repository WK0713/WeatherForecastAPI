namespace WeatherForecastAPI.Model
{
    public class OneCallApiResponse
    {
        public double lat { get; set; } //Latitude of the location, decimal (−90; 90)
        public double lon { get; set; } //Longitude of the location, decimal (-180; 180)
        public string timezone { get; set; } //Timezone name for the requested location
        public int timezone_offset { get; set; } //Shift in seconds from UTC
        public List<DailyForecast> daily { get; set; } //Daily forecast weather data API response
    }
}

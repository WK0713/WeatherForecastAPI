namespace WeatherForecastAPI.Model
{
    public class DailyForecast
    {
        public int dt { get; set; } //Time of the forecasted data, Unix, UTC
        public int sunrise { get; set; } //Sunrise time, Unix, UTC. For polar areas in midnight sun and polar night periods this parameter is not returned in the response
        public int sunset { get; set; } //Sunset time, Unix, UTC. For polar areas in midnight sun and polar night periods this parameter is not returned in the response
        public int moonrise { get; set; } //The time of when the moon rises for this day, Unix, UTC
        public int moonset { get; set; } //The time of when the moon sets for this day, Unix, UTC
        public double moon_phase { get; set; } //Moon phase. 0 and 1 are 'new moon', 0.25 is 'first quarter moon', 0.5 is 'full moon' and 0.75 is 'last quarter moon'. The periods in between are called 'waxing crescent', 'waxing gibous', 'waning gibous', and 'waning crescent', respectively.
        public string summary { get; set; } //Human-readable description of the weather conditions for the day
        public int pressure { get; set; } //Atmospheric pressure on the sea level, hPa
        public int humidity { get; set; } //Humidity, %
        public double dew_point { get; set; } //Atmospheric temperature (varying according to pressure and humidity) below which water droplets begin to condense and dew can form. Units – default: kelvin, metric: Celsius, imperial: Fahrenheit.
        public double wind_speed { get; set; } //Wind speed. Units – default: metre/sec, metric: metre/sec, imperial: miles/hour.
        public int wind_deg { get; set; } //(where available) Wind gust. Units – default: metre/sec, metric: metre/sec, imperial: miles/hour.
        public double wind_gust { get; set; } //Wind direction, degrees (meteorological)
        public int clouds { get; set; } //Cloudiness, %
        public double pop { get; set; } //Probability of precipitation. The values of the parameter vary between 0 and 1, where 0 is equal to 0%, 1 is equal to 100%
        public double rain { get; set; } //Precipitation volume, mm. Please note that only mm as units of measurement are available for this parameter
        public double? snow { get; set; } //(where available) Snow volume, mm. Please note that only mm as units of measurement are available for this parameter
        public double uvi { get; set; } //The maximum value of UV index for the day

        public DailyTemperature temp { get; set; } //Units – default: kelvin, metric: Celsius, imperial: Fahrenheit
        public DailyFeelsLike feels_like { get; set; } //This accounts for the human perception of weather. Units – default: kelvin, metric: Celsius, imperial: Fahrenheit.
        public List<Weather> weather { get; set; }
    }
}

namespace WeatherForecastAPI.Model
{
    public class DailyTemperature
    {
        public double day { get; set; } //day temperature
        public double min { get; set; } //min daily temperature
        public double max { get; set; } //max daily temperature
        public double night { get; set; } //night temperature
        public double eve { get; set; } //evening temperature
        public double morn { get; set; } //morning temperature
    }
}

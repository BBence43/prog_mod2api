namespace ProgMod2_API
{
    public static class Extensions
    {
        public static WeatherForecastDto AsDto(this WeatherForecast item)
        {
            return new WeatherForecastDto(item.Id, item.Date, item.TemperatureC, item.Summary);
        }
    }
}

namespace ProgMod2_API.Repositories
{
    public interface IWeatherForecastRepository
    {

        IEnumerable<WeatherForecast> GetWeatherForecasts();

        void CreateWeatherForecast(WeatherForecastDto weatherForecast);
    }
}

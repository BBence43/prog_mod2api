namespace ProgMod2_API.Repositories
{
    public interface IWeatherForecastRepository
    {

        Task<IEnumerable<WeatherForecast>> Get();

        Task CreateWeatherAsync(WeatherForecast item);
    }
}

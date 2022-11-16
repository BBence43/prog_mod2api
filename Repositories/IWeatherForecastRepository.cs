namespace ProgMod2_API.Repositories
{
    public interface IWeatherForecastRepository
    {
        

        Task CreateWeatherAsync(WeatherForecast item);
    }
}

namespace ProgMod2_API.Repositories
{
    public class InMemWeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly List<WeatherForecast> forecasts = new ();

        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await Task.FromResult(forecasts);
        }

       

        public async Task CreateWeatherAsync(WeatherForecast item)
        {
            forecasts.Add(item);
            await Task.CompletedTask;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ProgMod2_API.Repositories;

namespace ProgMod2_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastPostController : ControllerBase
    {
      
        public List<WeatherForecast> weatherForecasts = new List<WeatherForecast>();

        private readonly IWeatherForecastRepository repository;

        private int id = 0;

        private readonly ILogger<WeatherForecastPostController> _logger;

        public WeatherForecastPostController(IWeatherForecastRepository repository, ILogger<WeatherForecastPostController> logger)
        {
            this.repository = repository;
            _logger = logger;
        }
       
        [HttpPost]
        public async Task<ActionResult<WeatherForecastDto>> CreateWeatherAsync(WeatherForecastDto weatherForecast)
        {
            WeatherForecast item = new()
            {
                Id = id++,
                Date = weatherForecast.Date,
                TemperatureC = weatherForecast.TemperatureC,
                Summary = weatherForecast.Summary,
            };

            await repository.CreateWeatherAsync(item);

            return NoContent();
            
        }
    }
}
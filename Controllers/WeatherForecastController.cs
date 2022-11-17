using Microsoft.AspNetCore.Mvc;
using ProgMod2_API.Repositories;

namespace ProgMod2_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IWeatherForecastRepository repository;


        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IWeatherForecastRepository repository, ILogger<WeatherForecastController> logger)
        {
            this.repository = repository;
            _logger = logger;
        }
       

      

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return repository.GetWeatherForecasts();
        }

        [HttpPost]
        public IActionResult CreateWeatherAsync(WeatherForecastDto weatherForecast)
        {

            repository.CreateWeatherForecast(weatherForecast);

            return Ok();
            
        }
    }
}
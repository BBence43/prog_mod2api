using Microsoft.AspNetCore.Mvc;
using ProgMod2_API.Repositories;

namespace ProgMod2_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
      
        public List<WeatherForecast> weatherForecasts = new List<WeatherForecast>();
        private readonly IWeatherForecastRepository repository;

        private int id = 0;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {

            string multilineTextInput = "";
            using (StreamReader sr = new StreamReader("Data/weather.txt"))
            {
                multilineTextInput = sr.ReadToEnd();

                string[] lines = multilineTextInput.Split(
           new[] { Environment.NewLine },
           StringSplitOptions.None);

                foreach (var line in lines)
                {
                    string[] words = line.Split(';');

                    weatherForecasts.Add(
                            new WeatherForecast(
                                id++,
                                words[0],
                                int.Parse(words[1]),
                                words[3]
                                )
                            );
                }
            }
            return weatherForecasts;
        }

        [HttpPost]
        public async Task<ActionResult<WeatherForecastDto>> CreateWeatherAsync(WeatherForecastDto weatherForecast)
        {
            WeatherForecast item = new()
            {
                Id =id++,
                Date = weatherForecast.Date,
                TemperatureC = weatherForecast.TemperatureC,
                Summary = weatherForecast.Summary,
            };

            await repository.CreateWeatherAsync(item);

            return CreatedAtAction(nameof(Get), new { id = item.Id }, item.AsDto());
        }
    }
}
using System.ComponentModel.DataAnnotations;

namespace ProgMod2_API
{
    public record WeatherForecastDto(int Id, string Date, int TemperatureC, string Summary);
    public record CreateWeatherForecastDto([Required] string Date, int TemperatureC , string Summary);
    public record UpdateWeatherForecastDto([Required] string Date, int TemperatureC, string Summary );

}

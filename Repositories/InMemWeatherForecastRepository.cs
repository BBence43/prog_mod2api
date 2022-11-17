using System.IO;

namespace ProgMod2_API.Repositories;

public class InMemWeatherForecastRepository : IWeatherForecastRepository
{
    private readonly List<WeatherForecast> forecasts = new ();
    
    public InMemWeatherForecastRepository()
    {
        string multilineTextInput = "";
        using var sr = new StreamReader("Data/weather.txt");
        multilineTextInput = sr.ReadToEnd();

        string[] lines = multilineTextInput.Split(
                    new[] { Environment.NewLine },
                    StringSplitOptions.None);

        foreach (var line in lines)
        {
            string[] words = line.Split(';');

            forecasts.Add(
                    new WeatherForecast(
                        forecasts.Count,
                        words[0],
                        int.Parse(words[1]),
                        words[3]
                        )
                    );
        }
    }

    public IEnumerable<WeatherForecast> GetWeatherForecasts()
    {
        return forecasts;
    }

    

    public void CreateWeatherForecast(WeatherForecastDto weatherForecast)
    {
        var item = new WeatherForecast()
        {
            Id = forecasts.Count,
            Date = weatherForecast.Date,
            TemperatureC = weatherForecast.TemperatureC,
            Summary = weatherForecast.Summary,
        };

        forecasts.Add(item);
        using (StreamWriter sw = File.AppendText(@"Data/weather.txt"))
        {
            sw.WriteLine();
            sw.WriteLine(item.Date + ";" + item.TemperatureC + ";" + ((item.TemperatureC * 1.8) + 32) + ";" + item.Summary);
        }

    }
}


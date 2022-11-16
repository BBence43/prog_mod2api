namespace ProgMod2_API
{
    public class WeatherForecast
    {
        public int Id { get; set; }
        public string Date { get; set; }

        public int TemperatureC { get; set; }


        public string Summary { get; set; }
        
        public WeatherForecast(int id, string date, int temperatureC, string summary)
        {
            Id = id;
            Date = date;
            TemperatureC = temperatureC;
            Summary = summary;
        }

        public WeatherForecast()
        {

        }
    }
}
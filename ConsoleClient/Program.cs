using ConsoleClient;

Console.WriteLine("Fetching weather data from Weather Api using OpenApi.\n");
using (var httpClient = new HttpClient())
{
    var swaggerClient = new swaggerClient("http://localhost:5128/", httpClient);
    var weatherForecasts = await swaggerClient.GetWeatherForecastAsync();

    foreach (var weatherForecast in weatherForecasts)
    {
        Console.WriteLine($"Date: {weatherForecast.Date}, " +
                          $"Summary: {weatherForecast.Summary}, " +
                          $"TemperatureF: {weatherForecast.TemperatureF}, " +
                          $"TemperatureC: {weatherForecast.TemperatureC}.");
    }
}

Console.ReadKey();

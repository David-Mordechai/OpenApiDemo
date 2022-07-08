using Infrastructure.Configurations;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureServices((_, services) =>
    {
        services.AddHttpClient();
        services.AddSingleton(new Settings {WeatherForecastApiBaseUri = "http://localhost:5128/"});
        services.AddTransient<IWeatherForecastService, WeatherForecastService>();
    })
    .UseConsoleLifetime()
    .Build();

using var serviceScope = host.Services.CreateScope();
var services = serviceScope.ServiceProvider;
var weatherForecastService = services.GetRequiredService<IWeatherForecastService>();

foreach (var weatherForecast in await weatherForecastService.GetWeatherForecastAsync())
    Console.WriteLine(weatherForecast);

Console.ReadKey();
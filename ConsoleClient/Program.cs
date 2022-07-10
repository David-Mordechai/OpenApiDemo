using Core.Services;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureServices((_, services) => services.AddInfrastructureLayer())
    .UseConsoleLifetime()
    .Build();

using var serviceScope = host.Services.CreateScope();
var services = serviceScope.ServiceProvider;
var weatherForecastService = services.GetRequiredService<IWeatherForecastService>();

foreach (var weatherForecast in await weatherForecastService.GetWeatherForecastAsync())
    Console.WriteLine(weatherForecast);

Console.ReadKey();
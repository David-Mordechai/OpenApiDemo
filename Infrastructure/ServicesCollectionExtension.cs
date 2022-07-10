using Core.Services;
using Infrastructure.Configurations;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServicesCollectionExtension
{
    public static void AddInfrastructureLayer(this IServiceCollection services)
    {
        services.AddHttpClient();
        var settings = new Settings { WeatherForecastApiBaseUri = "http://localhost:5128/" };
        services.AddSingleton(settings);
        services.AddTransient<IWeatherForecastService, WeatherForecastService>();
    }
}
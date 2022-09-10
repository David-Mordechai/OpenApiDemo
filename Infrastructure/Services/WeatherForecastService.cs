using Core.Dtos;
using Core.Services;
using Infrastructure.Configurations;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services;

internal class WeatherForecastService : IWeatherForecastService
{
    private readonly ILogger<WeatherForecastService> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _apiBaseUrl;

    public WeatherForecastService(ILogger<WeatherForecastService> logger, 
        IHttpClientFactory httpClientFactory, Settings settings)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
        _apiBaseUrl = settings.WeatherForecastApiBaseUri;
    }

    public async Task<List<WeatherForecastDto>> GetWeatherForecastAsync()
    {
        try
        {
            using var httpClient = _httpClientFactory.CreateClient();
            var weatherForecastApi = new WeatherForecastApi(_apiBaseUrl, httpClient);
            var weatherForecasts = await weatherForecastApi.GetWeatherForecastAsync();

            return weatherForecasts
                .Select(weatherForecast =>
                    new WeatherForecastDto
                    {
                        Date = weatherForecast.Date,
                        Summary = weatherForecast.Summary,
                        TemperatureC = weatherForecast.TemperatureC,
                        TemperatureF = weatherForecast.TemperatureF
                    })
                .ToList();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error message: {ErrorMessage}", e.Message);
            return new List<WeatherForecastDto>();
        }
    }
}
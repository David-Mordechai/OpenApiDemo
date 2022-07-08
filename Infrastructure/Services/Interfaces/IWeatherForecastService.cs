using Infrastructure.Dtos;

namespace Infrastructure.Services.Interfaces;

public interface IWeatherForecastService
{
    Task<List<WeatherForecastDto>> GetWeatherForecastAsync();
}
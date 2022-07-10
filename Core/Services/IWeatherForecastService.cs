using Core.Dtos;

namespace Core.Services;

public interface IWeatherForecastService
{
    Task<List<WeatherForecastDto>> GetWeatherForecastAsync();
}
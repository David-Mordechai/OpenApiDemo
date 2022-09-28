namespace Core.Dtos;

public class WeatherForecastDto
{
    public DateTimeOffset Date { get; init; }

    public int TemperatureC { get; init; }

    public int TemperatureF { get; init; }

    public string Summary { get; init; } = string.Empty;

    public override string ToString()
    {
        return $"Date: {Date}, Summary: {Summary}, TemperatureF: {TemperatureF}, TemperatureC: {TemperatureC}.";
    }
}
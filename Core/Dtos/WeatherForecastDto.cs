namespace Core.Dtos;

public class WeatherForecastDto
{
    public DateTimeOffset Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF { get; set; }

    public string Summary { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"Date: {Date}, Summary: {Summary}, TemperatureF: {TemperatureF}, TemperatureC: {TemperatureC}.";
    }
}
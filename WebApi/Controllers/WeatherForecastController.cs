using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();
    }
    
    [HttpGet("{id:int}")]
    public async Task<string> Get(int id)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.CancelAfter(3000);
        var token = cancellationTokenSource.Token;

        try
        {
            await Task.Delay(4000, token);
            _logger.LogInformation("Task 1 ended");
        
            await Task.Delay(4000, token);
            _logger.LogInformation("Task 2 ended");
        }
        catch (Exception e)
        {
            var error = e switch
            {
                TaskCanceledException => "Task Canceled Exception",
                OperationCanceledException => "Operation Canceled Exception",
                _ => "Unknown Exception"
            };
            _logger.LogError("{Error}", error);
            return error;
        }
        
        return $"Id: {id}";
    }
}
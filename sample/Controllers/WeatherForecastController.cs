using dependency_injection_dotnet_webapi_sample.Services;
using Microsoft.AspNetCore.Mvc;

namespace dependency_injection_dotnet_webapi_sample.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IService _service;
    private readonly IService2 _service2;

    public WeatherForecastController(
        ILogger<WeatherForecastController> logger,
        IService service,
        IService2 service2)
    {
        _logger = logger;
        _service = service;
        _service2 = service2;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("GetMessage")]
    public string GetMessage(string state1, string state2)
    {
        // var singleton = HttpContext.RequestServices.GetService<ISingletonService>();
        // var scoped = HttpContext.RequestServices.GetService<IScopedService>();
        // var transient = HttpContext.RequestServices.GetService<ITransientService>();

        var service1Message = this._service.PrintAllMessageFromService1(state1);
        var service2Message = this._service2.PrintAllMessageFromService2(state2);

        return string.Concat(
            "1-call \n", service1Message, "\n\n\n",
            "2-call \n", service2Message);
    }
}

using FluentValidation;
using FluentValidationSample.Validation;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationSample.Controllers
{
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        string[] summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        List<WeatherForecast> forecast = new();
        public HomeController()
        {
            forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
                .ToList();
        }
        [HttpGet]
        public object Index()
        {
            return forecast;
        }
        [HttpPost]
        public object Index1([FromBody] WeatherForecast weatherForecast)
        {
            forecast.Add(weatherForecast);
            return forecast;
        }
    }
}

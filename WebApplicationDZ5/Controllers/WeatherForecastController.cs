using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApplicationDZ5.Controllers
{
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


        //https://localhost:5001/WeatherForecast/1488.1337228/false/20A732F8-B0F9-4A0D-B808-1F43563107BB
        [HttpGet]
        [Route("{number:double}/{forif:bool}/{id:guid}")]
        public string Get(double number, bool forif , Guid id)
        {
            if (forif==true)
            {
                return $"Your guid :{id}, number :{number}";
            }
            return $" FORIF NOT TRUE BUT YOUR NUMBRER(doubble) IS {number} , and GUID :{id}";

        }
        //https://localhost:5001/WeatherForecast/forecast/6/03-31-2021%2010%3A10%20pm/100.5/55555.44/123456789101112
        [HttpGet]
        [Route("forecast/{i:int}/{date:datetime}/{fortemp:decimal}/{a:float}/{b:long}")]
        public IEnumerable<WeatherForecast> GetForecast(int i, DateTime date, decimal fortemp, float a , long b)
        {
            var rng = new Random();


            return Enumerable.Range(1, i).Select(index => new WeatherForecast
            {
               
                A = a,
                B = b,
                Date = date.AddDays(index),
                TemperatureC = fortemp,
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}

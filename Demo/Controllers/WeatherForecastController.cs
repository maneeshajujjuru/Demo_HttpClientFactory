using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IHttpClientFactory _httpClientFactory;

        //private MyGitHubClient _httpClient;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }
        //public WeatherForecastController(ILogger<WeatherForecastController> logger, MyGitHubClient httpClient)
        //{
        //    _logger = logger;
        //    _httpClient = httpClient;
        //}


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = string.Empty;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);

                var client = _httpClientFactory.CreateClient("googleApi");

                result = await client.GetStringAsync("http://www.google.com");
                //return Ok(result);
            }
            return Ok(result);
        }

        //[HttpGet]
        //    public async Task<ActionResult> Get()
        //    {
        //        var client = _httpClientFactory.CreateClient("GitHubClient");
        //        var result = await client.GetStringAsync("/");
        //        return Ok(result);
        //    }
        //}
        //[HttpGet]
        //public async Task<ActionResult> Get()
        //{
        //    var client = await _httpClient.Client.GetStringAsync("/");
        //    return Ok(client);
        //}
    }
}

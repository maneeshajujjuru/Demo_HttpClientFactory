using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_HttpClientFactory.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        //The IHttpClientFactory allows us to ask for and receive a HttpClient instance.
        private readonly IHttpClientFactory _httpClientFactory;

        public ValuesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetStringAsync("http://www.google.com");
            return Ok(result);
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var client = _httpClientFactory.CreateClient("googleApi");
            var result = await client.GetStringAsync("http://www.google.com");
            return Ok(result);
        }
    }
}

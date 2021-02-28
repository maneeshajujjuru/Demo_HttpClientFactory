using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_HttpClientFactory.Controllers
{
    public class ActivityController
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ActivityController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("Activity/Random")]
        public async Task<Board> GetRandomActivity()
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetStringAsync("http://www.boredapi.com/api/activity/");

            return JsonConvert.DeserializeObject<Board>(response);
        }
    }

    //[Route("Activity")]
    //public class ActivityController
    //{
    //    private readonly IHttpClientFactory _httpClientFactory;

    //    public ActivityController(IHttpClientFactory httpClientFactory)
    //    {
    //        _httpClientFactory = httpClientFactory;
    //    }

    //    [HttpGet]
    //    [Route("Random")]
    //    public async Task<Board> GetRandomActivity()
    //    {
    //        var client = _httpClientFactory.CreateClient("boardApi");

    //        var response = await client.GetStringAsync("activity");

    //        return JsonConvert.DeserializeObject<Board>(response);
    //    }
    //}
    public class ActivityController
    {
        private readonly IBoardApiClient _boardApiClient;

        public ActivityController(IBoardApiClient boardApiClient)
        {
            _boardApiClient = boardApiClient;
        }

        [HttpGet]
        [Route("Activity/Random")]
        public async Task<Board> GetRandomActivity()
        {
            return await _boardApiClient.GetRandomActivity();
        }
    }
}
    }

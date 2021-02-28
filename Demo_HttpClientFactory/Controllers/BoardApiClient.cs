using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Demo_HttpClientFactory.Controllers
{
    public class BoardApiClient : IBoardApiClient
    {
        private readonly HttpClient _client;

        public BoardApiClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("http://www.boredapi.com/api/");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = httpClient;
        }

        public async Task<Board> GetRandomActivity()
        {
            var response = await _client.GetStringAsync("activity");

            return JsonConvert.DeserializeObject<Board>(response);
        }
    }
}

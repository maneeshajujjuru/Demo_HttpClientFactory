using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Demo
{
    public class MyGitHubClient
    {
        #region Constructor

        public MyGitHubClient(HttpClient client)
        {
            client.BaseAddress = new Uri("http://api.github.com/");
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            Client = client;
        }

        #endregion Constructor
        public HttpClient Client { get; set; }
    }
}

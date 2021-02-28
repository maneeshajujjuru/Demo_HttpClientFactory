using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_HttpClientFactory.Controllers
{
    public interface IBoardApiClient
    {
        Task<Board> GetRandomActivity();
    }
}

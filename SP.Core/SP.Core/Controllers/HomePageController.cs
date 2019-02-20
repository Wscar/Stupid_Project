using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sp.Service;
namespace SP.Core.Controllers
{
    [Route("api/home")]
    [ApiController]
    public class HomePageController : ControllerBase
    {
        private readonly IHomePageService homePageService;
        public HomePageController(IHomePageService _homePageService)
        {
            homePageService = _homePageService;
        }
        [HttpGet]
        [Route("areas")]
        public async Task<IActionResult> GetHomePageArea()
        {
            var result = await homePageService.GetHomePageAreaAndForumsAsync();
            return Ok(result);
        }
    }
}
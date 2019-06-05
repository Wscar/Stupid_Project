using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YMB.MVC.Client.Models;
using IdentityModel;
using System.Net.Http;

namespace YMB.MVC.Client.Controllers
{   [Authorize]
    public class HomeController : Controller
    {
        private IHttpClientFactory clientFactory;
        public HomeController(IHttpClientFactory _clientFactory)
        {
            clientFactory = _clientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var client = clientFactory.CreateClient();
                
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

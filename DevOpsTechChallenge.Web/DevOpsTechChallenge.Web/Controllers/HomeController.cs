using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DevOpsTechChallenge.Web.Models;
using DevOpsTechChallenge.Services.ChallengeThree;
using Microsoft.Extensions.Configuration;

namespace DevOpsTechChallenge.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IChallengeThreeService _challengeThreeService;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IChallengeThreeService challengeThreeService, IConfiguration configuration)
        {
            _logger = logger;
            _challengeThreeService = challengeThreeService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View(new HomeModel());
        }

        public IActionResult ChallengeTwo(string dataKey)
        {
            var model = new HomeModel
            {
                ResultTwo = "Testing 123"
            };
            return View("Index", model);
        }

        public IActionResult ChallengeThree(string key, string json)
        {
            var model = new HomeModel
            {
                ResultThree = _challengeThreeService.GetResult(key, json, _configuration["APIUrl"] + "/challengethree")
            };
            return View("Index",model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

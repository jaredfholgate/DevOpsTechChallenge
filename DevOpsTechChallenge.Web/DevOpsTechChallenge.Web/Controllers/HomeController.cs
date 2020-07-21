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
        private readonly IChallengeOneService _challengeOneService;
        private readonly IChallengeTwoService _challengeTwoService;
        private readonly IChallengeThreeService _challengeThreeService;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IChallengeOneService challengeOneService, IChallengeTwoService challengeTwoService, IChallengeThreeService challengeThreeService, IConfiguration configuration)
        {
            _logger = logger;
            _challengeOneService = challengeOneService;
            _challengeTwoService = challengeTwoService;
            _challengeThreeService = challengeThreeService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View(new HomeModel() 
            { 
                COneTestValue = _challengeOneService.GetTest(_configuration["APIUrl"] + "/challengeone")
            });
        }

        public IActionResult ChallengeOne(HomeModel model)
        {
            _challengeOneService.SetTest(_configuration["APIUrl"] + "/challengeone", model.COneTestValue);
            model.COneTestValue = _challengeOneService.GetTest(_configuration["APIUrl"] + "/challengeone");
            ModelState.Clear();
            return View("Index", model);
        }

        public IActionResult ChallengeTwo(HomeModel model)
        {
            model.CTwoResult = _challengeTwoService.Get(model.CTwoVMName, model.CTwoDataKey, _configuration["APIUrl"] + "/challengetwo");
            ModelState.Clear();
            return View("Index", model);
        }

        public IActionResult ChallengeThree(HomeModel model)
        {
            model.CThreeResult = _challengeThreeService.GetResult(model.CThreeKey, model.CThreeJson, _configuration["APIUrl"] + "/challengethree");
            ModelState.Clear();
            return View("Index", model);
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

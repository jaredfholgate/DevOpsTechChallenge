using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DevOpsTechChallenge.ChallengeThree;
using DevOpsTechChallenge.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DevOpsTechChallenge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChallengeOneController : ControllerBase
    {
 
        private readonly ILogger<ChallengeThreeController> _logger;
        private readonly ITestRepository _testRepository;

        public ChallengeOneController(ILogger<ChallengeThreeController> logger, ITestRepository testRepository)
        {
            _logger = logger;
            _testRepository = testRepository;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            try
            {
                return  _testRepository.GetTest();
            }
            catch
            {
                return NotFound();
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody]string testValue)
        {
            try
            {
                _testRepository.SetTest(testValue);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}

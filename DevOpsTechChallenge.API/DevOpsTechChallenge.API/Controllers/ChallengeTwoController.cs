using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DevOpsTechChallenge.ChallengeThree;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DevOpsTechChallenge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChallengeTwoController : ControllerBase
    {
 
        private readonly ILogger<ChallengeThreeController> _logger;
        private readonly IParser _parser;

        public ChallengeTwoController(ILogger<ChallengeThreeController> logger, IParser parser)
        {
            _logger = logger;
            _parser = parser;
        }

        [HttpGet]
        public ActionResult<string> Get(string key, string json)
        {
            try
            {
                return _parser.Parse(key, json);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}

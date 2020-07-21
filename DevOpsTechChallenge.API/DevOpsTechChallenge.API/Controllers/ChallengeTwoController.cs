using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DevOpsTechChallenge.ChallengeThree;
using DevOpsTechChallenge.ChallengeTwo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DevOpsTechChallenge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChallengeTwoController : ControllerBase
    {
 
        private readonly ILogger<ChallengeThreeController> _logger;
        private readonly IVMQuery _vMQuery;

        public ChallengeTwoController(ILogger<ChallengeThreeController> logger, IVMQuery vMQuery)
        {
            _logger = logger;
            _vMQuery = vMQuery;
        }

        [HttpGet]
        public ActionResult<string> Get(string vmName, string filter)
        {
            try
            {
                return _vMQuery.Get(vmName, filter);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}

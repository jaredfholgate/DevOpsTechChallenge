using System;
using System.Net;
using System.Net.Http;

namespace DevOpsTechChallenge.Services.ChallengeThree
{
    public class ChallengeTwoService : IChallengeTwoService
    {

        public string Get(string vmName, string filter, string apiUrl)
        {
            var result = string.Empty;
            using (var client = new HttpClient())
            {
                var response = client.GetAsync($"{apiUrl}?vmName={vmName}&filter={filter}").Result;
                result = response.Content.ReadAsStringAsync().Result;
            }

            return result;
        }
    }
}

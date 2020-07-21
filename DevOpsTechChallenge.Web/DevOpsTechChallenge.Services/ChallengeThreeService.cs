using System;
using System.Net;
using System.Net.Http;

namespace DevOpsTechChallenge.Services.ChallengeThree
{
    public class ChallengeThreeService : IChallengeThreeService
    {

        public string GetResult(string key, string json, string apiUrl)
        {
            var result = string.Empty;
            using (var client = new HttpClient())
            {
                var response = client.GetAsync($"{apiUrl}?key={key}&json={json}").Result;
                result = response.Content.ReadAsStringAsync().Result;
            }

            return result;
        }
    }
}

using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace DevOpsTechChallenge.Services.ChallengeThree
{
    public class ChallengeOneService : IChallengeOneService
    {

        public string GetTest(string apiUrl)
        {
            var result = string.Empty;
            using (var client = new HttpClient())
            {
                var response = client.GetAsync($"{apiUrl}").Result;
                if(response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    result = "Boom!";
                }
            }

            return result;
        }

        public void SetTest(string apiUrl, string testValue)
        {
            using (var client = new HttpClient())
            {
                var response = client.PostAsync($"{apiUrl}", new StringContent(testValue, Encoding.UTF8, "application/json")).Result;
            }
        }
    }
}

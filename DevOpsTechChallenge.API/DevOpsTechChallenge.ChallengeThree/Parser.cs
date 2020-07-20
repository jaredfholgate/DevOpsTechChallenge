using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data;

namespace DevOpsTechChallenge.ChallengeThree
{
    public class Parser : IParser
    {
        public string Parse(string key, string json)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Key must contain a value.");
            }
            if (string.IsNullOrWhiteSpace(json))
            {
                throw new ArgumentException("Json must contain a value.");
            }
            var parsedJson = JObject.Parse(json);
            try
            {
                return parsedJson.SelectToken(key.Replace("/", ".")).Value<string>();
            }
            catch
            {
                throw new Exception("The Key not valid for this Object.");
            }
        }
    }
}

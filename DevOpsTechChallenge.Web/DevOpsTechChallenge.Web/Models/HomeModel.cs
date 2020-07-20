using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevOpsTechChallenge.Web.Models
{
    public class HomeModel
    {
        public HomeModel()
        {
            Key = "a/b/c";
            Json = "{ \"a\" : { \"b\" : { \"c\" : \"d\" } } }";
        }

        public string Key { get; set; }

        public string Json { get; set; }

        public string ResultThree { get; set; }
        
        public string DataKey { get; set; }
        
        public string ResultTwo { get; set; }

    }
}

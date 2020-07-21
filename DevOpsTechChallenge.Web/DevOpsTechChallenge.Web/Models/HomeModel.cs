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
            CTwoVMName = "example-machine";
            CTwoDataKey = "compute/name";
            CThreeKey = "a/b/c";
            CThreeJson = "{ \"a\" : { \"b\" : { \"c\" : \"d\" } } }";
        }

        public string COneTestValue { get; set; }

        public string CTwoVMName { get; set; }

        public string CTwoDataKey { get; set; }

        public string CTwoResult { get; set; }

        public string CThreeKey { get; set; }

        public string CThreeJson { get; set; }

        public string CThreeResult { get; set; }
    }
}

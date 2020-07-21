using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevOpsTechChallenge.ChallengeTwo.IntnTests
{
    [TestClass]
    public class VMQueryTests
    {
        private const string ClientId = "";
        private const string ClientSecret = "";
        private const string TenantId = "";

        [Ignore]
        [TestMethod]
        public void CanConnectToVMAndGetInfo()
        {
            var result = new VMQuery().Get("example-machine", null, ClientId, ClientSecret, TenantId);
            Assert.IsTrue(result.Contains("\"name\": \"example-machine\""));
        }

        [Ignore]
        [TestMethod]
        public void CanFilterResultToName()
        {
            var result = new VMQuery().Get("example-machine", "compute/name", ClientId, ClientSecret, TenantId);
            Assert.AreEqual("example-machine", result);
        }
    }
}

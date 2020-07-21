using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevOpsTechChallenge.ChallengeTwo.IntnTests
{
    [TestClass]
    public class VMQueryTests
    {
        [Ignore]
        [TestMethod]
        public void CanConnectToVMAndGetInfo()
        {
            var result = new VMQuery().Get("example-machine", null);
            Assert.IsTrue(result.Contains("\"name\": \"example-machine\""));
        }

        [Ignore]
        [TestMethod]
        public void CanFilterResultToName()
        {
            var result = new VMQuery().Get("example-machine", "compute/name");
            Assert.AreEqual("example-machine", result);
        }
    }
}

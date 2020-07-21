using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevOpsTechChallenge.ChallengeTwo.IntnTests
{
    [TestClass]
    public class VMQueryTests
    {
        [TestMethod]
        public void CanConnectToVMAndGetInfo()
        {
            var result = new VMQuery().Get("example-machine", null);
            Assert.IsTrue(result.Contains("\"name\": \"example-machine\""));
        }

        [TestMethod]
        public void CanFilterResultToName()
        {
            var result = new VMQuery().Get("example-machine", "compute/name");
            Assert.AreEqual("example-machine", result);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevOpsTechChallenge.ChallengeThree.UnitTests
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void CanAcceptAKeyAndReturnAValue()
        {
            var parser = new Parser();
            var result = parser.Parse("a/b/c");
            Assert.AreEqual("d", result);
        }
    }
}

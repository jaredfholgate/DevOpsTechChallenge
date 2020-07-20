using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevOpsTechChallenge.ChallengeThree.UnitTests
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void CanAcceptAKeyAndObjectAndReturnAValue()
        {
            var parser = new Parser();
            var result = parser.Parse("a/b/c", "{ \"a\" : { \"b\" : { \"c\" : \"d\" } } }");
            Assert.AreEqual("d", result);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

        [TestMethod]
        public void CanAcceptADifferent3LevelKeyAndObjectAndReturnAValue()
        {
            var parser = new Parser();
            var result = parser.Parse("x/y/z", "{ \"x\" : { \"y\" : { \"z\" : \"a\" } } }");
            Assert.AreEqual("a", result);
        }

        [TestMethod]
        public void CanAcceptA4LevelKeyAndObjectAndReturnAValue()
        {
            var parser = new Parser();
            var result = parser.Parse("c/d/e/f", "{ \"c\" : { \"d\" : { \"e\" : {\"f\" : \"g\" } } } }");
            Assert.AreEqual("g", result);
        }

        [TestMethod]
        public void CanHandleMissingKey()
        {
            var parser = new Parser();
            Assert.ThrowsException<ArgumentException>(() => parser.Parse(null, "{ \"c\" : { \"d\" : { \"e\" : {\"f\" : \"g\" } } } }"), "Key must contain a value.");
            Assert.ThrowsException<ArgumentException>(() => parser.Parse(string.Empty, "{ \"c\" : { \"d\" : { \"e\" : {\"f\" : \"g\" } } } }"), "Key must contain a value.");
        }


        [TestMethod]
        public void CanHandleMissingObject()
        {
            var parser = new Parser();
            Assert.ThrowsException<ArgumentException>(() => parser.Parse("c/d/e/f", null), "Json must contain a value.");
            Assert.ThrowsException<ArgumentException>(() => parser.Parse("c/d/e/f", string.Empty), "Json must contain a value.");
        }
    }
}

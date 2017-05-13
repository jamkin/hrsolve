using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankSolutions.HackerRankInAString
{
    [TestClass]
    public class HackerRankInASring_Test
    {
        [TestMethod]
        public void EmptyStringTest()
        {
            string str = string.Empty;
            Assert.AreEqual("NO", HackerRankInAString.Solve(str));
        }

        [TestMethod]
        public void  NotEmptyButTooSmallTest()
        {
            string str = "alkdj";
            Assert.AreEqual("NO", HackerRankInAString.Solve(str));
        }

        [TestMethod]
        public void SameSizeButDifferentCharactersTest()
        {
            string str = "habkerrark";
            Assert.AreEqual("NO", HackerRankInAString.Solve(str));
        }

        [TestMethod]
        public void LongerAndDoesntContainTest()
        {
            string str = "habkerrarkakdh";
            Assert.AreEqual("NO", HackerRankInAString.Solve(str));
        }

        [TestMethod]
        public void ExactMatchTest()
        {
            string str = HackerRankInAString.Target;
            Assert.AreEqual("YES", HackerRankInAString.Solve(str));
        }

        [TestMethod]
        public void IsSubstringTest()
        {
            string str = $"xx{HackerRankInAString.Target}x";
            Assert.AreEqual("YES", HackerRankInAString.Solve(str));
        }

        [TestMethod]
        public void CharactersInBetweenTest()
        {
            string str = "hxaxckerranxk";
            Assert.AreEqual("YES", HackerRankInAString.Solve(str));
        }
    }
}

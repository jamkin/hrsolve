using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankSolutions.BirthdayCakeCandles
{
    [TestClass]
    public class BirthdayCakeCandles_Test
    {
       [TestMethod]
        public void EmptyInput()
        {
            int[] heights = { };
            Assert.AreEqual(0, BirthdayCakeCandles.CandlesToBlow(heights));
        }

        [TestMethod]
        public void OneCandle()
        {
            int[] heights = { 56 };
            Assert.AreEqual(1, BirthdayCakeCandles.CandlesToBlow(heights));
        }

        [TestMethod]
        public void TwoCandlesSecondTallerThanFirst()
        {
            int[] heights = { 1, 2 };
            Assert.AreEqual(1, BirthdayCakeCandles.CandlesToBlow(heights));
        }

        [TestMethod]
        public void TwoCandlesFirstTallerThanSecond()
        {
            int[] heights = { 2, 1 };
            Assert.AreEqual(1, BirthdayCakeCandles.CandlesToBlow(heights));
        }

        [TestMethod]
        public void TwoOfSameHeight()
        {
            int[] heights = { 1, 1 };
            Assert.AreEqual(2, BirthdayCakeCandles.CandlesToBlow(heights));
        }

        [TestMethod]
        public void ThreeCandlesOneSmallerHeight()
        {
            int[] heights = { 1, 2, 2 };
            Assert.AreEqual(2, BirthdayCakeCandles.CandlesToBlow(heights));
        }

        [TestMethod]
        public void SampleInput_0()
        {
            int[] heights = { 3, 2, 1, 3 };
            Assert.AreEqual(2, BirthdayCakeCandles.CandlesToBlow(heights));
        }
    }
}

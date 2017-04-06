using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankSolutions.BreakingTheRecords
{
    [TestClass]
    public class BreakingTheRecords_Test
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyInputThrowsProperException()
        {
            int lows, highs;
            int[] empty = { };
            BreakingTheRecords.BrokenRecordFrequencies(empty, out lows, out highs);
        }

        [TestMethod]
        public void NoRecordsBrokenIfOneGame()
        {
            int lows, highs;
            int[] one = { 12 };
            BreakingTheRecords.BrokenRecordFrequencies(one, out lows, out highs);
            Assert.AreEqual(0, lows);
            Assert.AreEqual(0, highs);
        }

        [TestMethod]
        public void TwoDifferentScores()
        {
            int lows, highs;
            int[] scores = { 1, 2 };
            BreakingTheRecords.BrokenRecordFrequencies(scores, out lows, out highs);
            Assert.AreEqual(0, lows);
            Assert.AreEqual(1, highs);
            lows = highs = default(int);
            scores = new int[] { 2, 1 };
            BreakingTheRecords.BrokenRecordFrequencies(scores, out lows, out highs);
            Assert.AreEqual(1, lows);
            Assert.AreEqual(0, highs);
        }

        [TestMethod]
        public void TwoEqualScores()
        {
            int lows, highs;
            int[] scores = { 5, 5 };
            BreakingTheRecords.BrokenRecordFrequencies(scores, out lows, out highs);
            Assert.AreEqual(0, lows);
            Assert.AreEqual(0, highs);
        }

        [TestMethod]
        public void ThreeAscendingScores()
        {
            int lows, highs;
            int[] scores = { 1, 2, 3 };
            BreakingTheRecords.BrokenRecordFrequencies(scores, out lows, out highs);
            Assert.AreEqual(0, lows);
            Assert.AreEqual(2, highs);
        }

        [TestMethod]
        public void ThreeDescendingScores()
        {
            int lows, highs;
            int[] scores = { 3, 2, 1 };
            BreakingTheRecords.BrokenRecordFrequencies(scores, out lows, out highs);
            Assert.AreEqual(2, lows);
            Assert.AreEqual(0, highs);
        }

        [TestMethod]
        public void UpDownUp()
        {
            int lows, highs;
            int[] scores = { 1, 2, 1, 2 };
            BreakingTheRecords.BrokenRecordFrequencies(scores, out lows, out highs);
            Assert.AreEqual(0, lows);
            Assert.AreEqual(1, highs);
        }

        [TestMethod]
        public void DownUpDown()
        {
            int lows, highs;
            int[] scores = { 2, 1, 2, 1 };
            BreakingTheRecords.BrokenRecordFrequencies(scores, out lows, out highs);
            Assert.AreEqual(1, lows);
            Assert.AreEqual(0, highs);
        }

        [TestMethod]
        public void IncreasingAmplitude()
        {
            int lows, highs;
            int[] scores = { 1, 0, 2, -1, 3, -2 };
            BreakingTheRecords.BrokenRecordFrequencies(scores, out lows, out highs);
            Assert.AreEqual(3, lows);
            Assert.AreEqual(2, highs);
        }

        [TestMethod]
        public void SampleInput()
        {
            int lows, highs;
            int[] scores = { 10, 5, 20, 20, 4, 5, 2, 25, 1 };
            BreakingTheRecords.BrokenRecordFrequencies(scores, out lows, out highs);
            Assert.AreEqual(4, lows);
            Assert.AreEqual(2, highs);
        }
    }
}

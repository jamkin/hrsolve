using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace HackerRankSolutions.ClimbingTheLeaderboard
{
    [TestClass]
    public class ClimbingTheLeaderboard_Test
    {
        [TestMethod]
        public void BaseCaseEmpty()
        {
            int[] scores = { };
            int[] alice = { };
            var expected = new List<int> { };
            var ranks = ClimbingTheLeaderboard.HistoricalRanks(scores, alice).ToList();
            CollectionAssert.AreEqual(expected, ranks);
        }

        [TestMethod]
        public void OneScoreAliceLess()
        {
            int[] scores = { 2 };
            int[] alice = { 1 };
            var expected = new List<int> { 2 };
            var ranks = ClimbingTheLeaderboard.HistoricalRanks(scores, alice).ToList();
            CollectionAssert.AreEqual(expected, ranks);
        }

        [TestMethod]
        public void OneScoreAliceEqual()
        {
            int[] scores = { 2 };
            int[] alice = { 2 };
            var expected = new List<int> { 1 };
            var ranks = ClimbingTheLeaderboard.HistoricalRanks(scores, alice).ToList();
            CollectionAssert.AreEqual(expected, ranks);
        }

        [TestMethod]
        public void OneScoreAliceGreater()
        {
            int[] scores = { 2 };
            int[] alice = { 3 };
            var expected = new List<int> { 1 };
            var ranks = ClimbingTheLeaderboard.HistoricalRanks(scores, alice).ToList();
            CollectionAssert.AreEqual(expected, ranks);
        }

        [TestMethod]
        public void TwoAscendingScoresAliceAlwaysLess()
        {
            int[] scores = { 2, 3 };
            int[] alice = { 1, 1 };
            var expected = new List<int> { 3, 3 };
            var ranks = ClimbingTheLeaderboard.HistoricalRanks(scores, alice).ToList();
            CollectionAssert.AreEqual(expected, ranks);
            alice = new int[] { 1, 1 };
            ranks = ClimbingTheLeaderboard.HistoricalRanks(scores, alice).ToList();
            CollectionAssert.AreEqual(expected, ranks);
        }

        [TestMethod]
        public void TwoAscendingScoresAliceBehindCatchesUpToSecond()
        {
            int[] scores = { 3, 2 };
            int[] alice = { 1, 2 };
            var expected = new List<int> { 3, 2 };
            var ranks = ClimbingTheLeaderboard.HistoricalRanks(scores, alice).ToList();
            CollectionAssert.AreEqual(expected, ranks);
        }

        [TestMethod]
        public void TwoAscendingScoresAliceBehindCatchesBetweenSecondAndFirst()
        {
            int[] scores = { 4, 2 };
            int[] alice = { 1, 3 };
            var expected = new List<int> { 3, 2 };
            var ranks = ClimbingTheLeaderboard.HistoricalRanks(scores, alice).ToList();
            CollectionAssert.AreEqual(expected, ranks);
        }

        [TestMethod]
        public void TwoAscendingScoresAliceBehindCatchesUpToFirst()
        {
            int[] scores = { 3, 2 };
            int[] alice = { 1, 3 };
            var expected = new List<int> { 3, 1 };
            var ranks = ClimbingTheLeaderboard.HistoricalRanks(scores, alice).ToList();
            CollectionAssert.AreEqual(expected, ranks);
        }

        [TestMethod]
        public void TwoAscendingScoresAliceBehindSurpassesFirst()
        {
            int[] scores = { 3, 2 };
            int[] alice = { 1, 4 };
            var expected = new List<int> { 3, 1 };
            var ranks = ClimbingTheLeaderboard.HistoricalRanks(scores, alice).ToList();
            CollectionAssert.AreEqual(expected, ranks);
        }

        [TestMethod]
        public void TwoAscendingScoresAliceTiedForSecondStaysTied()
        {
            int[] scores = { 3, 2 };
            int[] alice = { 2, 2 };
            var expected = new List<int> { 2, 2 };
            var ranks = ClimbingTheLeaderboard.HistoricalRanks(scores, alice).ToList();
            CollectionAssert.AreEqual(expected, ranks);
        }

        [TestMethod]
        public void TwoAscendingScoresAliceTiedForSecondGetsBetween()
        {
            int[] scores = { 4, 2 };
            int[] alice = { 2, 3 };
            var expected = new List<int> { 2, 2 };
            var ranks = ClimbingTheLeaderboard.HistoricalRanks(scores, alice).ToList();
            CollectionAssert.AreEqual(expected, ranks);
        }

        [TestMethod]
        public void TwoAscendingScoresAliceTiedForSecondCatchesUpToFirst()
        {
            int[] scores = { 3, 2 };
            int[] alice = { 2, 3 };
            var expected = new List<int> { 2, 1 };
            var ranks = ClimbingTheLeaderboard.HistoricalRanks(scores, alice).ToList();
            CollectionAssert.AreEqual(expected, ranks);
        }

        [TestMethod]
        public void TwoAscendingScoresAliceTiedForSecondThenSurpassesFirst()
        {
            int[] scores = { 3, 2 };
            int[] alice = { 2, 4 };
            var expected = new List<int> { 2, 1 };
            var ranks = ClimbingTheLeaderboard.HistoricalRanks(scores, alice).ToList();
            CollectionAssert.AreEqual(expected, ranks);
        }

        [TestMethod]
        public void TwoAscendingScoresAliceBetweenNeverCatchesFirst()
        {
            int[] scores = { 4, 2 };
            int[] alice = { 3, 3 };
            var expected = new List<int> { 2, 2 };
            var ranks = ClimbingTheLeaderboard.HistoricalRanks(scores, alice).ToList();
            CollectionAssert.AreEqual(expected, ranks);
        }

        [TestMethod]
        public void TwoAscendingScoresAliceBetweenCatchesFirst()
        {
            int[] scores = { 4, 2 };
            int[] alice = { 3, 4 };
            var expected = new List<int> { 2, 1 };
            var ranks = ClimbingTheLeaderboard.HistoricalRanks(scores, alice).ToList();
            CollectionAssert.AreEqual(expected, ranks);
        }

        [TestMethod]
        public void TwoAscendingScoresAliceBetweenSurpassesFirst()
        {
            int[] scores = { 4, 2 };
            int[] alice = { 3, 5 };
            var expected = new List<int> { 2, 1 };
            var ranks = ClimbingTheLeaderboard.HistoricalRanks(scores, alice).ToList();
            CollectionAssert.AreEqual(expected, ranks);
        }

        [TestMethod]
        public void TwoEqualScoresAliceBehindNeverCatches()
        {
            int[] scores = { 2, 2 };
            int[] alice = { 1, 1 };
            var expected = new List<int> { 2, 2 };
            var ranks = ClimbingTheLeaderboard.HistoricalRanks(scores, alice).ToList();
            CollectionAssert.AreEqual(expected, ranks);
        }

        [TestMethod]
        public void TwoEqualScoresAliceBehindCatchesUp()
        {
            int[] scores = { 2, 2 };
            int[] alice = { 1, 2 };
            var expected = new List<int> { 2, 1 };
            var ranks = ClimbingTheLeaderboard.HistoricalRanks(scores, alice).ToList();
            CollectionAssert.AreEqual(expected, ranks);
        }

        [TestMethod]
        public void TwoEqualScoresAliceBehindSurpasses()
        {
            int[] scores = { 2, 2 };
            int[] alice = { 1, 3 };
            var expected = new List<int> { 2, 1 };
            var ranks = ClimbingTheLeaderboard.HistoricalRanks(scores, alice).ToList();
            CollectionAssert.AreEqual(expected, ranks);
        }

        [TestMethod]
        public void TwoEqualScoresAliceSameThroughout()
        {
            int[] scores = { 2, 2 };
            int[] alice = { 2, 2 };
            var expected = new List<int> { 1, 1 };
            var ranks = ClimbingTheLeaderboard.HistoricalRanks(scores, alice).ToList();
            CollectionAssert.AreEqual(expected, ranks);
        }

        [TestMethod]
        public void TwoEqualScoresAliceSameThenGreater()
        {
            int[] scores = { 2, 2 };
            int[] alice = { 2, 3 };
            var expected = new List<int> { 1, 1 };
            var ranks = ClimbingTheLeaderboard.HistoricalRanks(scores, alice).ToList();
            CollectionAssert.AreEqual(expected, ranks);
        }

        [TestMethod]
        public void SampleInput()
        {
            int[] scores = { 100, 100, 50, 40, 40, 20, 10 };
            int[] alice = { 5, 25, 50, 120 };
            var expected = new List<int> { 6, 4, 2, 1 };
            var ranks = ClimbingTheLeaderboard.HistoricalRanks(scores, alice).ToList();
            CollectionAssert.AreEqual(expected, ranks);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace HackerRankSolutions.MinimumAbsoluteDifference
{
    [TestClass]
    public class MinimumAbsoluteDifference_Test
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ArrayTooSmall()
        {
            int[] arr = { 8 };
            MinimumAbsoluteDifference.Solve(arr);
        }

        [TestMethod]
        public void TwoElements_Postitive()
        {
            int[] arr = { 5, 1 };
            Assert.AreEqual(4, MinimumAbsoluteDifference.Solve(arr));
        }

        [TestMethod]
        public void TwoElements_OneNegative()
        {
            int[] arr = { 5, -1 };
            Assert.AreEqual(6, MinimumAbsoluteDifference.Solve(arr));
        }

        [TestMethod]
        public void ThreeElementsEqualDifference()
        {
            int[] arr = { 3, 3, 3 };
            Assert.AreEqual(0, MinimumAbsoluteDifference.Solve(arr));
        }

        [TestMethod]
        public void ThreeElementsTwoDifferences()
        {
            int[] arr = { 3, 2, 3 };
            Assert.AreEqual(0, MinimumAbsoluteDifference.Solve(arr));
        }

        [TestMethod]
        public void ThreeElementsThreeDifferences()
        {
            int[] arr = { 3, 2, 9 };
            Assert.AreEqual(1, MinimumAbsoluteDifference.Solve(arr));
        }

        [TestMethod]
        public void CompareAgainstBruteForce()
        {
            for(int t = 0; t < 1000; ++t)
            {
                int[] arr = GenerateValidArray();
                Assert.AreEqual(BruteForce(arr), MinimumAbsoluteDifference.Solve(arr));
            }
        }

        private static int[] GenerateValidArray()
        {
            Random r = new Random();
            int n = r.Next(2, 500);
            int[] arr = new int[n];
            for(int i = 0; i < n; ++i)
            {
                arr[i] = r.Next();
            }
            return arr;
        }

        private static int BruteForce(int[] arr)
        {
            var range = arr.Select((val, index) => new { val, index });
            return
                (
                from x in range
                from y in range
                where x.index < y.index
                select Math.Abs(x.val - y.val)
                ).Min();

        }

    }
}

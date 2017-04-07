using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace HackerRankSolutions.BirthdayChocolate
{
    [TestClass]
    public class BirthdayChocolate_Test
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TooManyMonthsThrowsProperException()
        {
            int m = 2;
            int d = 5;
            int[] chocs = { 4 };
            BirthdayChocolate.PossibleChocolateBreaks(m, d, chocs);
        }

        [TestMethod]
        public void EmptyChocolatesMeansZeroPossibilities()
        {
            int m = 0;
            int d = 5;
            int[] chocs = { };
            int result = BirthdayChocolate.PossibleChocolateBreaks(m, d, chocs);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void SingleChocolateEqualToSum()
        {
            int m = 1;
            int d = 74;
            int[] chocs = { 74 };
            int result = BirthdayChocolate.PossibleChocolateBreaks(m, d, chocs);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void SingleChocolateNotEqualToSum()
        {
            int m = 1;
            int d = 73;
            int[] chocs = { 74 };
            int result = BirthdayChocolate.PossibleChocolateBreaks(m, d, chocs);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Alternating()
        {
            int m = 2;
            int d = 3;
            int[] chocs = { 1, 2, 1, 2, 1 };
            int result = BirthdayChocolate.PossibleChocolateBreaks(m, d, chocs);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void SampleInput_0()
        {
            int m = 2;
            int d = 3;
            int[] chocs = { 1, 2, 1, 3, 2 };
            int result = BirthdayChocolate.PossibleChocolateBreaks(m, d, chocs);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void SampleInput_1()
        {
            int m = 2;
            int d = 3;
            int[] chocs = { 1, 1, 1, 1, 1, 1 };
            int result = BirthdayChocolate.PossibleChocolateBreaks(m, d, chocs);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestCase_2()
        {
            int m = 1;
            int d = 4;
            int[] chocs = { 4 };
            int result = BirthdayChocolate.PossibleChocolateBreaks(m, d, chocs);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CompareAgainstAlternativeMethod()
        {
            Random r = new Random();
            for(int t = 0; t < 10000; ++t)
            {
                int len = r.Next(1, 20);

                int[] chocs = Enumerable.Repeat(1, len).Select(i => r.Next(1, 10)).ToArray();
                int m = r.Next(1, len + 1);
                int d = r.Next(2, len * 2);
                Assert.AreEqual
                (
                    AltMethod(m, d, chocs),
                    BirthdayChocolate.PossibleChocolateBreaks(m, d, chocs), 
                    $"d = {d}, m = {m}, chocs = {string.Join(" ", chocs)}"
                );
            }
        }

        /// <summary>
        /// O(n^2) solution to same problem
        /// </summary>
        private static int AltMethod(int m, int d, int[] chocs)
        {
            return Enumerable.Range(0, chocs.Length - m + 1)
                .Select(start => chocs.Skip(start).Take(m))
                .Count(interval => interval.Sum() == d);

        }
    }
}

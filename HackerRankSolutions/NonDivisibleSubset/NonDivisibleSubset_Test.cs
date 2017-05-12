using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace HackerRankSolutions.NonDivisibleSubset
{
    [TestClass]
    public class NonDivisibleSubset_Test
    {
        [TestMethod]
        public void EmptyInput()
        {
            int k = 1;
            int[] empty = { };
            Assert.AreEqual(0, NonDivisibleSubset.GetMaxSize(empty, k));
        }

        [TestMethod]
        public void OneElementInput()
        {
            int k = 1;
            int[] single = { 172 };
            Assert.AreEqual(1, NonDivisibleSubset.GetMaxSize(single, k));
        }

        [TestMethod]
        public void TwoElementsSumDividesK()
        {
            int k = 2;
            int[] pair = { 6, 4 };
            Assert.AreEqual(1, NonDivisibleSubset.GetMaxSize(pair, k));
        }

        [TestMethod]
        public void TwoElementsSumDoesntDivideK()
        {
            int k = 2;
            int[] pair = { 2, 3 };
            Assert.AreEqual(2, NonDivisibleSubset.GetMaxSize(pair, k));
        }

        [TestMethod]
        public void ThreeElementsEveryPairsSumDividesK()
        {
            int k = 2;
            int[] triplet = { 3, 17, 1 };
            Assert.AreEqual(1, NonDivisibleSubset.GetMaxSize(triplet, k));
        }

        [TestMethod]
        public void ThreeElementsOnePairsSumDivideK()
        {
            int k = 2;
            int[] triplet = { 3, 17, 2 };  // T = { 1, 1, 0 }
            Assert.AreEqual(2, NonDivisibleSubset.GetMaxSize(triplet, k));
        }

        [TestMethod]
        public void ThreeElementsNoPairsSumDivideK()
        {
            int k = 8;
            int[] triplet = { 3, 17, 1 };
            Assert.AreEqual(3, NonDivisibleSubset.GetMaxSize(triplet, k));
        }

        [TestMethod]
        public void FourElementsEveryPairsSumDividesK()
        {
            int k = 4;
            int[] quadruplet = { 4, 20, 888, 12 };
            Assert.AreEqual(1, NonDivisibleSubset.GetMaxSize(quadruplet, k));
        }

        [TestMethod]
        public void FourElementsOnePairsSumDividesK()
        {
            int k = 4;
            int[] quadruplet = { 81, 2, 6, 1 };
            Assert.AreEqual(3, NonDivisibleSubset.GetMaxSize(quadruplet, k));
        }

        [TestMethod]
        public void FourElementsTwoPairsSumDividesK()
        {
            int k = 4;
            int[] quadruplet = { 81, 2, 6, 10 };
            Assert.AreEqual(2, NonDivisibleSubset.GetMaxSize(quadruplet, k));
        }

        [TestMethod]
        public void FourElementsNoPairsSumDividesK()
        {
            int k = 4;
            int[] quadruplet = { 1, 5, 9, 2 };
            Assert.AreEqual(4, NonDivisibleSubset.GetMaxSize(quadruplet, k));
        }

        [TestMethod]
        public void MiscInput_0()
        {
            int k = 10;
            int[] arr = { 16, 1, 4, 10, 6, 19 };
            // can shrink to { 16, 1, 10, 6 }
            Assert.AreEqual(4, NonDivisibleSubset.GetMaxSize(arr, k));
        }

        [TestMethod]
        public void MiscInput_1()
        {
            int k = 3;
            int[] arr = { 1, 7, 3, 11, 6, 8, 10, 9, 5 };
            Assert.AreEqual(4, NonDivisibleSubset.GetMaxSize(arr, k));
        }

        [TestMethod]
        public void MiscInput_2()
        {
            int k = 5;
            int[] arr = { 7, 6, 8, 4, 3, 1 };
            Assert.AreEqual(4, NonDivisibleSubset.GetMaxSize(arr, k));
        }

        [TestMethod]
        [Ignore]
        public void OrderDoesntMatter()
        {
            Random r = new Random();
            for(int t = 0; t < 1000; ++t)
            {
                int[] arr = GenerateRandomInput();
                int k = r.Next(1, 10);
                int first = NonDivisibleSubset.GetMaxSize(arr, k);
                Array.Reverse(arr);
                int second = NonDivisibleSubset.GetMaxSize(arr, k);
                Assert.AreEqual(first, second);
            }
        }

        [TestMethod]
        [Ignore]
        public void CompareAgainstBruteForce()
        {
            Random r = new Random();
            for(int t = 0; t < 500; ++t)
            {
                int[] arr = GenerateRandomInput();
                int k = r.Next(1, 100);
                int brute = BruteForce(arr, k);
                int better = NonDivisibleSubset.GetMaxSize(arr, k);
                Assert.AreEqual(brute, better, $"Passed {t} test cases before failing on arr={string.Join(",", arr)}, k={k}");
            }
        }

        private static int[] GenerateRandomInput()
        {
            Random r = new Random();
            int len = r.Next(1, 20);
            List<int> vals = new List<int>();
            for(int i = 0; i < len; ++i)
                vals.Add(r.Next(1, 12));
            return vals.Distinct().ToArray();
        }

        private static int BruteForce(int[] arr, int k)
        {
            IEnumerable<int>[] subcollections = arr.AllSubcollections().ToArray();

            return arr.AllSubcollections()
                .Where(subcollection =>
                {
                    int[] subarr = subcollection.ToArray();
                    IEnumerable<int> range = Enumerable.Range(0, subarr.Length);
                    return
                       (from i in range
                        from j in range
                        where i < j
                        select (subarr[i] + subarr[j])
                        )
                        .All(sum => sum % k != 0);
                }
                ).Max(s => s.Count());
        }
    }
}

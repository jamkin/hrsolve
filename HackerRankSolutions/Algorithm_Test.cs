using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace HackerRankSolutions
{
    /// <summary>
    /// Test class for our all-encompasing utility class for common algorithms that
    /// .NET does not have a built-in method for running.
    /// </summary>
    [TestClass]
    public class Algorithm_Test
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CombinationsOfSize_InvalidInput()
        {
            int[] arr = { 56, 8 };
            arr.CombinationsOfSize(-1);
        }

        [TestMethod]
        public void CombinationsOfSize_EmptyInput()
        {
            int[] arr = { };
            var result = arr.CombinationsOfSize(0);
            Assert.IsFalse(result.Any());
            result = arr.CombinationsOfSize(1);
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void CombinationsOfSize_OneElement()
        {
            int[] arr = { 1 };
            var result = arr.CombinationsOfSize(1);
            Assert.AreEqual(1, result.Single().Single());
            result = arr.CombinationsOfSize(2);
            CollectionAssert.AreEqual(new List<int>() { 1, 1 }, result.Single().ToList());
        }

        [TestMethod]
        public void CombinationsOfSize_TwoElements()
        {
            int[] arr = { 1, 2 };
            var result = arr.CombinationsOfSize(1);
            ExecuteNestedCollectionsEqual(result, new List<List<int>>() { new List<int>() { 1 }, new List<int>() { 2 } });
            result = arr.CombinationsOfSize(2);
            ExecuteNestedCollectionsEqual(result, new List<List<int>>() { new List<int>() { 1, 1 }, new List<int>() { 1, 2 }, new List<int>() { 2, 2 }, new List<int>() { 2, 1 } });
        }

        [TestMethod]
        public void CombinationsOfSize_ThreeElementsSizeThree()
        {
            int[] arr = { 1, 2, 3 };
            var result = arr.CombinationsOfSize(3);
            ExecuteNestedCollectionsEqual
            (
                new List<List<int>>()
                {
                    new List<int>() { 1, 1, 1 }, 
                    new List<int>() { 1, 2, 1 },
                    new List<int>() { 1, 1, 2 },
                    new List<int>() { 1, 2, 2 },
                    new List<int>() { 1, 3, 2 },
                    new List<int>() { 1, 2, 3 },
                    new List<int>() { 1, 3, 3 },
                    new List<int>() { 1, 1, 3 },
                    new List<int>() { 1, 3, 1 },

                    new List<int>() { 2, 1, 1 },
                    new List<int>() { 2, 1, 2 },
                    new List<int>() { 2, 2, 2 },
                    new List<int>() { 2, 2, 1 },
                    new List<int>() { 2, 1, 3 },
                    new List<int>() { 2, 3, 1 },
                    new List<int>() { 2, 3, 3 },
                    new List<int>() { 2, 2, 3 },
                    new List<int>() { 2, 3, 2 },

                    new List<int>() { 3, 1, 1 },
                    new List<int>() { 3, 1, 2 },
                    new List<int>() { 3, 2, 1 },
                    new List<int>() { 3, 2, 2 },
                    new List<int>() { 3, 1, 3 },
                    new List<int>() { 3, 3, 1 },
                    new List<int>() { 3, 3, 3 },
                    new List<int>() { 3, 2, 3 },
                    new List<int>() { 3, 3, 2 },
                },
                result
            );
        }

        [TestMethod]
        public void CombinationsOfSize_CorrectResultSize()
        {
            int[] input = { 1, 1 };
            for(int i = 0; i <= 10; ++i)
            {
                int expectedSize = i == 0 ? 0 : (int)Math.Pow(input.Length, i);
                int actualSize = input.CombinationsOfSize(i).Count();
                Assert.AreEqual(expectedSize, actualSize);
            }
        }

        private static void ExecuteNestedCollectionsEqual(IEnumerable<IEnumerable<int>> first, IEnumerable<IEnumerable<int>> second)
        {
            string[] s1 = first.Select(c => string.Join(",", c)).ToArray(),
                     s2 = second.Select(c => string.Join(",", c)).ToArray();
            Array.Sort(s1);
            Array.Sort(s2);
            CollectionAssert.AreEqual(s1, s2);
        }

        private static IEnumerable<int> GenerateRandomCollection(int maxSize = int.MaxValue, int valMin = int.MinValue, int valMax = int.MaxValue)
        {
            Random r = new Random();
            for(int i = 0; i <= maxSize; ++i)
                yield return r.Next(valMin, valMax);
        }
    }
}

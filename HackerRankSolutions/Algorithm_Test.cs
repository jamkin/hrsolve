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

        [TestMethod]
        public void AllSubcollections_EmptyCollection()
        {
            List<int> arr = new List<int>() { };
            var expected = new List<List<int>>() { new List<int>() { } };
            var actual = arr.AllSubcollections();
            ExecuteNestedCollectionsEqual(expected, actual);
        }

        [TestMethod]
        public void AllSubcollections_SingleElementCollection()
        {
            List<int> arr = new List<int>() { 1 };
            var expected = new List<List<int>>() { new List<int>() { }, new List<int>() { 1 } };
            var actual = arr.AllSubcollections();
            ExecuteNestedCollectionsEqual(expected, actual);
        }

        [TestMethod]
        public void AllSubcollections_TwoElementCollection()
        {
            List<int> arr = new List<int>() { 1, 2 };
            var expected = new List<List<int>>() { new List<int>() { }, new List<int>() { 1 }, new List<int>() { 2 }, new List<int>() { 1, 2 } };
            var actual = arr.AllSubcollections();
            ExecuteNestedCollectionsEqual(expected, actual);
        }

        [TestMethod]
        public void AllSubcollections_ThreeElementCollection()
        {
            List<int> arr = new List<int>() { 1, 2, 3 };
            var expected = new List<List<int>>()
            {
                new List<int>() { },
                new List<int>() { 1 },
                new List<int>() { 2 },
                new List<int>() { 3 },
                new List<int>() { 1, 2 },
                new List<int>() { 1, 3 },
                new List<int>() { 2, 3 },
                new List<int>() { 1, 2, 3 }
            };
            var actual = arr.AllSubcollections();
            ExecuteNestedCollectionsEqual(expected, actual);
        }

        [TestMethod]
        public void SumToN_Test()
        {
            int[] arr;
            int n;
            IEnumerable<Tuple<int, int>> result;

            // base case
            arr = new int[] { };
            for(n = 0; n < 10; ++n)
            {
                result = arr.PairsSumToN(n);
                Assert.IsFalse(result.Any());
            }

            // 1 element, isn't equal n
            arr = new int[] { 1 };
            n = 2;
            result = arr.PairsSumToN(n);
            Assert.IsFalse(result.Any());

            // 1 element, is equal n
            n = 1;
            result = arr.PairsSumToN(n);
            Assert.IsFalse(result.Any());

            // 2 elements, don't sum to n
            n = 5;
            List<int[]> pairs = new List<int[]>()
            {
                new int[] { 0, 0 },
                new int[] { 0, 1 }, 
                new int[] { 1, 1 },
                new int[] { 1, 2 },
                new int[] { 1, 3 },
                new int[] { 3, 1 },
                new int[] { 1, 5 },
                new int[] { 3, 3 },
                new int[] { 3, -1 },
                new int[] { 3, -8 },
                new int[] { 6, -2 },
                new int[] { 7, -1 }
            };
            foreach(var pair in pairs)
            {
                arr = pair;
                result = arr.PairsSumToN(n);
                Assert.IsFalse(result.Any());
            }

            Tuple<int, int> tuple;

            // 2 elements, sum to n
            n = 5;
            pairs = new List<int[]>()
            {
                new int[] { 0, 5 },
                new int[] { 2, 3 },
                new int[] { 6, -1 },
                new int[] { 1, 4 }
            };
            foreach(var pair in pairs)
            {
                result = pair.PairsSumToN(n);
                tuple = result.Single();
                TupleEqualityIgnoreOrder(Tuple.Create(pair[0], pair[1]), tuple);
            }

            // 3 elements, 0 pairs sum to n

            List<int[]> triplets = new List<int[]>()
            {
                new int[] { 1, 1, 1 },
                new int[] { 1, 2, 2 },
                new int[] { 0, 1, 9 }
            };
            foreach(var triplet in triplets)
            {
                result = triplet.PairsSumToN(n);
                Assert.IsFalse(result.Any());
            }

            // 3 elements, 1 pair sums to n

            arr = new int[] { 1, 2, 4 };
            result = arr.PairsSumToN(n);
            tuple = result.Single();
            TupleEqualityIgnoreOrder(tuple, Tuple.Create(1, 4));

            arr = new int[] { 5, 0, 4 };
            result = arr.PairsSumToN(n);
            tuple = result.Single();
            TupleEqualityIgnoreOrder(tuple, Tuple.Create(0, 5));


            arr = new int[] { 3, 2, 9 };
            result = arr.PairsSumToN(n);
            tuple = result.Single();
            TupleEqualityIgnoreOrder(tuple, Tuple.Create(3, 2));

            // 3 elements, 2 pairs sum to n

            arr = new int[] { 2, 3, 2 };
            result = arr.PairsSumToN(n);
            Assert.AreEqual(2, result.Count());
            foreach(var pair in result)
                TupleEqualityIgnoreOrder(pair, Tuple.Create(2, 3));

            arr = new int[] { -1, -1, 6 };
            result = arr.PairsSumToN(n);
            Assert.AreEqual(2, result.Count());
            foreach(var pair in result)
                TupleEqualityIgnoreOrder(pair, Tuple.Create(-1, 6));

            // 3 elements, all 3 pairs sum to n
            n = 10;
            arr = new int[] { 5, 5, 5 };
            result = arr.PairsSumToN(n);
            Assert.AreEqual(3, result.Count());
            foreach(var pair in result)
                TupleEqualityIgnoreOrder(pair, Tuple.Create(5, 5));

            // 4 elements, 2 pairs sum to n
            arr = new int[] { 1, 2, 8, 9 };
            var expected = new List<int[]>() { new int[] { 1, 9 }, new int[] { 2, 8 } };
            result = arr.PairsSumToN(n);
            var actual = result.Select(t => new int[] { t.Item1, t.Item2 });
            ExecuteNestedCollectionsEqual(actual, expected);

            // 4 elements, 3 pairs sum to n
            arr = new int[] { 5, 5, 5, 2 };
            result = arr.PairsSumToN(n);
            Assert.AreEqual(3, result.Count());
            foreach (var pair in result)
                TupleEqualityIgnoreOrder(pair, Tuple.Create(5, 5));

            // Misc. large 
            arr = new int[] { 10, 4, 4, 7, 3, 2, 1, 10, 5, 8, 6, 1, 9, 1, 8, 9, 3, 9, 3, 9 };
            n = 8; 
            expected = new List<int[]>() { new int[] { 4, 4 }, new int[] { 1, 7 }, new int[] { 1, 7 }, new int[] { 1, 7 }, new int[] { 2, 6 }, new int[] { 5, 3 }, new int[] { 5, 3 }, new int[] { 5, 3 } };
            actual = arr.PairsSumToN(n).Select(t => new int[] { t.Item1, t.Item2 });
            ExecuteNestedCollectionsEqual(actual, expected);
        }

        [TestMethod]
        public void OneFromEachTest()
        {
            int[][] input = { };
            var actual = input.OneFromEach();
            var expected = new int[][] { };
            ExecuteNestedCollectionsEqual(actual, expected);

            input = new int[][] { new int[] { } };
            actual = input.OneFromEach();
            ExecuteNestedCollectionsEqual(actual, expected);

            input = new int[][] { new int[] { }, new int[] { } };
            actual = input.OneFromEach();
            ExecuteNestedCollectionsEqual(actual, expected);

            input = new int[][] { new int[] { 1 }, new int[] { } };
            actual = input.OneFromEach();
            expected = new int[][] { new int[] { 1 } };
            ExecuteNestedCollectionsEqual(actual, expected);

            input = new int[][] { new int[] { 1, 2 }, new int[] { } };
            actual = input.OneFromEach();
            expected = new int[][] { new int[] { 1 }, new int[] { 2 } };
            ExecuteNestedCollectionsEqual(actual, expected);

            input = new int[][] { new int[] { 1, 2 }, new int[] { 3 } };
            actual = input.OneFromEach();
            expected = new int[][] { new int[] { 1, 3 }, new int[] { 2, 3 } };
            ExecuteNestedCollectionsEqual(actual, expected);

            input = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } };
            actual = input.OneFromEach();
            expected = new int[][] { new int[] { 1, 3 }, new int[] { 1, 4 }, new int[] { 2, 3 }, new int[] { 2, 4 } };
            ExecuteNestedCollectionsEqual(actual, expected);

            input = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4, 5 } };
            actual = input.OneFromEach();
            expected = new int[][] { new int[] { 1, 3 }, new int[] { 1, 4 }, new int[] { 1, 5 }, new int[] { 2, 3 }, new int[] { 2, 4 }, new int[] { 2, 5 } };
            ExecuteNestedCollectionsEqual(actual, expected);

            input = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4, 5 }, new int[] { 6 } };
            actual = input.OneFromEach();
            expected = new int[][] { new int[] { 1, 3, 6 }, new int[] { 1, 4, 6 }, new int[] { 1, 5, 6 }, new int[] { 2, 3, 6 }, new int[] { 2, 4, 6 }, new int[] { 2, 5, 6 } };
            ExecuteNestedCollectionsEqual(actual, expected);
        }

        private static bool TupleEqualityIgnoreOrder<IEquatable>(Tuple<IEquatable, IEquatable> t1, Tuple<IEquatable, IEquatable> t2)
        {
            return t1.Item1.Equals(t2.Item1) && t1.Item2.Equals(t2.Item2)
                || t1.Item1.Equals(t2.Item2) && t2.Item2.Equals(t1.Item1);
        }

        private static void ExecuteNestedCollectionsEqual(IEnumerable<IEnumerable<int>> first, IEnumerable<IEnumerable<int>> second)
        {
            string[] s1 = first.Select(c => string.Join(",", c.OrderBy(x => x))).ToArray(),
                     s2 = second.Select(c => string.Join(",", c.OrderBy(x => x))).ToArray();
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

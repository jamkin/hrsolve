using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace HackerRankSolutions.PickingNumbers
{
    [TestClass]
    public class PickingNumbers_Test
    {
        [TestMethod]
        public void SampleInput_0()
        {
            int[] arr = { 4, 6, 5, 3, 3, 1 };
            Assert.AreEqual(3, PickingNumbers.Solve(arr));
        }

        [TestMethod]
        public void SampleInput_1()
        {
            int[] arr = { 1, 2, 2, 3, 1, 2 };
            Assert.AreEqual(5, PickingNumbers.Solve(arr));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ArrayTooShort_0()
        {
            int[] arr = { };
            PickingNumbers.Solve(arr);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ArrayTooShort_1()
        {
            int[] arr = { 5 };
            PickingNumbers.Solve(arr);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ARrayTooLong()
        {
            int[] arr = Enumerable.Repeat(5, 101).ToArray();
            PickingNumbers.Solve(arr);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ElementTooSmall()
        {
            int[] arr = { 4, 0, 3 };
            PickingNumbers.Solve(arr);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ElementTooLarge()
        {
            int[] arr = { 4, 100, 3 };
            PickingNumbers.Solve(arr);
        }

        [TestMethod]
        public void InputOrderDoesntMatter()
        {
            for(int t = 0; t < 100; ++t)
            {
                int[] forward = GenerateRandomInput();
                int[] backward = GenerateRandomInput();
                Assert.AreEqual(PickingNumbers.Solve(forward), PickingNumbers.Solve(backward));
            }
        }

        [TestMethod]
        public void MiscTest_0()
        {
            int[] arr = { 1, 1 };
            Assert.AreEqual(2, PickingNumbers.Solve(arr));
        }

        [TestMethod]
        public void MiscTest_1()
        {
            int[] arr = { 1, 2 };
            Assert.AreEqual(2, PickingNumbers.Solve(arr));
        }

        [TestMethod]
        public void MiscTest_2()
        {
            int[] arr = { 1, 3 };
            Assert.AreEqual(1, PickingNumbers.Solve(arr));
        }

        [TestMethod]
        public void MiscTest_3()
        {
            int[] arr = { 1, 1, 1 };
            Assert.AreEqual(3, PickingNumbers.Solve(arr));
        }

        [TestMethod]
        public void MiscTest_4()
        {
            int[] arr = { 1, 1, 2 };
            Assert.AreEqual(3, PickingNumbers.Solve(arr));
        }

        [TestMethod]
        public void MiscTest_5()
        {
            int[] arr = { 1, 2, 2 };
            Assert.AreEqual(3, PickingNumbers.Solve(arr));
        }

        [TestMethod]
        public void MiscTest_6()
        {
            int[] arr = { 1, 2, 4 };
            Assert.AreEqual(2, PickingNumbers.Solve(arr));
        }

        [TestMethod]
        public void MiscTest_7()
        {
            int[] arr = { 1, 3, 4 };
            Assert.AreEqual(2, PickingNumbers.Solve(arr));
        }

        [TestMethod]
        public void MiscTest_8()
        {
            int[] arr = { 1, 3, 4 };
            Assert.AreEqual(2, PickingNumbers.Solve(arr));
        }

        [TestMethod]
        public void MiscTest_9()
        {
            int[] arr = { 1, 3, 5 };
            Assert.AreEqual(1, PickingNumbers.Solve(arr));
        }

        [TestMethod]
        public void MiscTest_10()
        {
            int[] arr = { 1, 3, 4, 10, 1, 3, 10, 9, 67, 5 };
            Assert.AreEqual(3, PickingNumbers.Solve(arr));
        }

        [TestMethod]
        public void MiscTest_11()
        {
            int[] arr = { 1, 3, 4, 10, 1, 3, 10, 9, 67, 5, 4 };
            Assert.AreEqual(4, PickingNumbers.Solve(arr));
        }

        [TestMethod]
        public void CompareAgainstBruteForce()
        {
            for(int t = 0; t < 500; ++t)
            {
                int[] arr = GenerateRandomInput();
                Assert.AreEqual(PickingNumbers.Solve(arr), AltSolve(arr), $"Failed for array {string.Join(",", arr)}");
            }
        }

        /// <summary>
        /// Helper method for generating a random array that statisfieds the problem's constraints
        /// </summary>
        private static int[] GenerateRandomInput()
        {
            Random r = new Random();
            int[] arr = new int[r.Next() % 11 + 2];
            for(int i = 0; i < arr.Length; ++i)
            {
                arr[i] = r.Next() % 15 + 1;
            }
            return arr;
        }

        /// <summary>
        /// Alternative, brute force solution
        /// </summary>
        private static int AltSolve(int[] arr)
        {
            Array.Sort(arr);
            return AllSubarrays(arr)
                .Where(a => (a[a.Length - 1] - a[0]) <= 1)
                .Max(a => a.Length);
        }
  
        /// <summary>
        /// Helper method for yielding all contiguous subarrays
        /// </summary>
        private static IEnumerable<int[]> AllSubarrays(int[] arr)
        {
            for(int size = 1; size <= arr.Length; ++size)
                for(int i = 0, j = size - 1; j < arr.Length; ++i, ++j)
                    yield return arr.Skip(i).Take(size).ToArray();
        }
    }
}

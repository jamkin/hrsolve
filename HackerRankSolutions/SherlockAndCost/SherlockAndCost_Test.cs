using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankSolutions.SherlockAndCost
{
    [TestClass]
    public class SherlockAndCost_Test
    {
        [TestMethod]
        public void TwoOfSameElement()
        {
            int[] b = { 3, 3 };
            Assert.AreEqual(2, SherlockAndCost.Solve(b));
        }

        [TestMethod]
        public void TwoDifferentElementsAscending()
        {
            int[] b = { 8, 2 };
            Assert.AreEqual(7, SherlockAndCost.Solve(b));
        }

        [TestMethod]
        public void TwoDifferentElementsDescending()
        {
            int[] b = { 8, 2 };
            Assert.AreEqual(7, SherlockAndCost.Solve(b));
        }

        [TestMethod]
        public void ThreeDifferentElementsAscending()
        {
            int[] b = { 4, 8, 9 };
            Assert.AreEqual(14, SherlockAndCost.Solve(b));
        }

        [TestMethod]
        public void ThreeDifferentElementsDescending()
        {
            int[] b = { 9, 8, 4 };
            Assert.AreEqual(14, SherlockAndCost.Solve(b));
        }

        [TestMethod]
        public void ThreeDifferentElementsLargestInMiddle()
        {
            int[] b = { 8, 9, 4 };
            Assert.AreEqual(16, SherlockAndCost.Solve(b));
        }

        [TestMethod]
        public void ThreeDifferentElementsSmallestInMiddle()
        {
            int[] b = { 8, 4, 9 };
            Assert.AreEqual(15, SherlockAndCost.Solve(b));
        }

        [TestMethod]
        public void ThreeOfSameElement()
        {
            int[] b = { 100, 100, 100 };
            Assert.AreEqual(198, SherlockAndCost.Solve(b));
        }

        [TestMethod]
        public void SampleInput()
        {
            int[] b = { 10, 1, 10, 1, 10 };
            Assert.AreEqual(36, SherlockAndCost.Solve(b));
        }

        [TestMethod]
        public void SampleInputRearranged()
        {
            int[] b = { 10, 1, 1, 10 };
            Assert.AreEqual(18, SherlockAndCost.Solve(b));
        }

        [TestMethod]
        public void TestMethod_0_Line_0()
        {
            int[] b = { 75, 26, 45, 72, 81, 47, 29, 97, 2, 75, 25, 82, 84, 17, 56, 32, 2, 28, 37, 57, 39, 18 };
            Assert.AreEqual(1121, SherlockAndCost.Solve(b));
        }

        [TestMethod]
        public void TestMethod_0_Line_1()
        {
            int[] b = { 79, 6, 40, 68, 68, 16, 40, 63, 93, 49, 91 };
            Assert.AreEqual(642, SherlockAndCost.Solve(b));
        }

        [TestMethod]
        public void TestMethod_0_Line_2()
        {
            int[] b = { 55, 68, 31, 80, 57, 18, 34, 28, 76, 55 };
            Assert.AreEqual(508, SherlockAndCost.Solve(b));
        }

        [TestMethod]
        public void TestMethod_0_Line_3()
        {
            int[] b = { 80, 22, 45, 11, 67, 67, 74, 91, 4, 35, 34, 65, 80, 21, 95, 1, 52, 25, 31, 2, 53 };
            Assert.AreEqual(1107, SherlockAndCost.Solve(b));
        }

        [TestMethod]
        public void TestMethod_0_Line_4()
        {
            int[] b = { 22, 89, 99, 7, 66, 32, 2, 68, 33, 75, 92, 84, 10, 94, 28, 54, 12, 9, 80, 43, 21, 51, 92, 20, 97, 7, 25, 67, 17, 38, 100, 86, 4, 83, 20, 6, 81, 58, 59, 53, 2, 54, 62, 25, 35, 79, 64, 27, 49, 32, 95, 100, 20, 58, 39, 92, 30, 67, 89, 58, 81, 100, 66, 73, 29, 75, 81, 70, 55, 18, 28, 7, 35, 98, 52, 30, 11, 69, 48, 84, 54, 13, 14, 15, 86, 34, 82, 92, 26, 8, 53, 62, 57, 50, 31, 61 };
            Assert.AreEqual(5563, SherlockAndCost.Solve(b));
        }
    }
}

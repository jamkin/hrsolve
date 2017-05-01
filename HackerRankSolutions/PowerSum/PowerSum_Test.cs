using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace HackerRankSolutions.PowerSum
{
    [TestClass]
    public class PowerSum_Test
    {
        [TestMethod]
        public void SampleInput_0()
        {
            int X = 10, N = 2;
            Assert.AreEqual(1, PowerSum.Solve(X, N));
        }

        [TestMethod]
        public void TestCase_1()
        {
            int X = 100, N = 2;
            Assert.AreEqual(3, PowerSum.Solve(X, N));
        }

        [TestMethod]
        public void TestCase_2()
        {
            int X = 100, N = 3;
            Assert.AreEqual(1, PowerSum.Solve(X, N));
        }

        [TestMethod]
        public void BaseCase()
        {
            int X = 1, N = 2;
            Assert.AreEqual(1, PowerSum.Solve(X, N));
        }

        [TestMethod]
        public void MistTest_0()
        {
            int X = 1, N = 3;
            Assert.AreEqual(1, PowerSum.Solve(X, N));
        }

        [TestMethod]
        public void MistTest_1()
        {
            int X = 2, N = 2;
            Assert.AreEqual(0, PowerSum.Solve(X, N));
        }

        [TestMethod]
        public void MistTest_2()
        {
            int X = 2, N = 3;
            Assert.AreEqual(0, PowerSum.Solve(X, N));
        }

        [TestMethod]
        public void MistTest_3()
        {
            int X = 2, N = 4;
            Assert.AreEqual(0, PowerSum.Solve(X, N));
        }

        [TestMethod]
        public void MistTest_4()
        {
            int X = 3, N = 2;
            Assert.AreEqual(0, PowerSum.Solve(X, N));
        }

        [TestMethod]
        public void MistTest_5()
        {
            int X = 2, N = 5;
            Assert.AreEqual(0, PowerSum.Solve(X, N));
        }

        [TestMethod]
        public void MistTest_6()
        {
            int X = 5, N = 2;
            Assert.AreEqual(1, PowerSum.Solve(X, N));
        }

        [TestMethod]
        public void MistTest_7()
        {
            int X = 9, N = 3;
            Assert.AreEqual(1, PowerSum.Solve(X, N));
        }

        /// <summary>
        /// Helper method for generating random input that satisfies the problem constraints
        /// </summary>
        private static void GenerateRandomInput(out int X, out int N)
        {
            Random r = new Random();
            X = r.Next() % 1000 + 1;
            N = r.Next() % 9 + 2;
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace HackerRankSolutions.QueensAttackII
{
    [TestClass]
    public class QueensAttackII_Test
    {
        [TestMethod]
        public void Sample_Testcase_0()
        {
            int n = 4;
            Tuple<int, int> queen = Tuple.Create(4, 4);
            var obstacles = new Tuple<int, int>[] { };

            int actual = QueensAttackII.Solve(n, queen, obstacles);

            Assert.AreEqual(9, actual);
        }

        [TestMethod]
        public void Sample_Testcase_1()
        {
            int n = 5;
            Tuple<int, int> queen = Tuple.Create(4, 3);
            var obstacles = new Tuple<int, int>[]
            {
                Tuple.Create(5, 5),
                Tuple.Create(4, 2),
                Tuple.Create(2, 3)
            };

            int actual = QueensAttackII.Solve(n, queen, obstacles);

            Assert.AreEqual(10, actual);
        }

        [TestMethod]
        public void SingleSpaceNoOstacles()
        {
            int n = 1;
            Tuple<int, int> queen = Tuple.Create(1, 1);
            var obstacles = new Tuple<int, int>[] { };

            int actual = QueensAttackII.Solve(n, queen, obstacles);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void FourSpacesZeroObstacles()
        {
            int n = 2;
            Tuple<int, int> queen = Tuple.Create(2, 2);
            var obstacles = new Tuple<int, int>[] { };

            int actual = QueensAttackII.Solve(n, queen, obstacles);

            Assert.AreEqual(3, actual);
        }

        [TestMethod]
        public void FourSpacesOneObstacle()
        {
            int n = 2;
            Tuple<int, int> queen = Tuple.Create(2, 2);
            var obstacles = new Tuple<int, int>[]
            {
                Tuple.Create(1, 1)
            };

            int actual = QueensAttackII.Solve(n, queen, obstacles);

            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        public void FourSpacesTwoObstacles()
        {
            int n = 2;
            Tuple<int, int> queen = Tuple.Create(2, 2);
            var obstacles = new Tuple<int, int>[]
            {
                Tuple.Create(1, 1),
                Tuple.Create(1, 2)
            };

            int actual = QueensAttackII.Solve(n, queen, obstacles);

            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void FourSpacesThreeObstacles()
        {
            int n = 2;
            Tuple<int, int> queen = Tuple.Create(2, 2);
            var obstacles = new Tuple<int, int>[]
            {
                Tuple.Create(1, 1),
                Tuple.Create(1, 2),
                Tuple.Create(2, 1)
            };

            int actual = QueensAttackII.Solve(n, queen, obstacles);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void TwentyFiveSpacesZeroObstacles()
        {
            int n = 5;
            Tuple<int, int> queen = Tuple.Create(3, 3);
            var obstacles = new Tuple<int, int>[] { };

            int actual = QueensAttackII.Solve(n, queen, obstacles);

            Assert.AreEqual(16, actual);
        }

        [TestMethod]
        public void TwentyFiveSpacesOneEdgeObstacle()
        {
            int n = 5;
            Tuple<int, int> queen = Tuple.Create(3, 3);
            var obstacles = new Tuple<int, int>[]
            {
                Tuple.Create(3, 5)
            };

            int actual = QueensAttackII.Solve(n, queen, obstacles);

            Assert.AreEqual(15, actual);
        }

        [TestMethod]
        public void TwentyFiveSpacesOneAdjacentObstacle()
        {
            int n = 5;
            Tuple<int, int> queen = Tuple.Create(3, 3);
            var obstacles = new Tuple<int, int>[]
            {
                Tuple.Create(3, 4)
            };

            int actual = QueensAttackII.Solve(n, queen, obstacles);

            Assert.AreEqual(14, actual);
        }

        [TestMethod]
        public void TwentyFiveSpacesOneNonobstacle()
        {
            int n = 5;
            Tuple<int, int> queen = Tuple.Create(3, 3);
            var obstacles = new Tuple<int, int>[]
            {
                Tuple.Create(1, 4)
            };

            int actual = QueensAttackII.Solve(n, queen, obstacles);

            Assert.AreEqual(16, actual);
        }
    }
}

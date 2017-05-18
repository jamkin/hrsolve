using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankSolutions.WeekOfCode32.CircularWalk
{
    [TestClass]
    public class CircularWalk_Test
    {
        [TestMethod]
        public void SampleInput()
        {
            int n = 9;
            int s = 0;
            int t = 2;
            int R0 = 1;
            int g = 3;
            int seed = 4;
            int p = 7;
            Assert.AreEqual(2, CircularWalk.Solve(n, s, t, R0, g, seed, p));
        }

        [TestMethod]
        public void SampleInput_ChangeEndToBeginning()
        {
            int n = 9;
            int s = 0;
            int t = 0;
            int R0 = 1;
            int g = 3;
            int seed = 4;
            int p = 7;
            Assert.AreEqual(0, CircularWalk.Solve(n, s, t, R0, g, seed, p));
        }

        [TestMethod]
        public void SampleInput_ChangeToFirstMoveReach()
        {
            int n = 9;
            int s = 0;
            int t = 8;
            int R0 = 1;
            int g = 3;
            int seed = 4;
            int p = 7;
            Assert.AreEqual(1, CircularWalk.Solve(n, s, t, R0, g, seed, p));
        }

        [TestMethod]
        public void DoesntErrorOut()
        {
            Random r = new Random();
            for(int k = 0; k < 1000; ++k)
            {
                int n = r.Next(1, (int)10e7 + 1);
                int s = r.Next(1, n);
                int t = r.Next(0, n);
                int p = r.Next(1, n + 1);
                int R0 = r.Next(0, p);
                int g = r.Next(0, p);
                int seed = r.Next(0, p);
                int result = CircularWalk.Solve(n, s, t, R0, g, seed, p);
                Assert.IsTrue(result >= -1 && result < p);
            }
        }
    }
}

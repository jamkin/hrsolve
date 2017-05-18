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
            long n = 9;
            long s = 0;
            long t = 2;
            long R0 = 1;
            long g = 3;
            long seed = 4;
            long p = 7;
            Assert.AreEqual(2L, CircularWalk.Solve(n, s, t, R0, g, seed, p));
        }

        [TestMethod]
        public void SampleInput_ChangeEndToBeginning()
        {
            long n = 9;
            long s = 0;
            long t = 0;
            long R0 = 1;
            long g = 3;
            long seed = 4;
            long p = 7;
            Assert.AreEqual(0L, CircularWalk.Solve(n, s, t, R0, g, seed, p));
        }

        [TestMethod]
        public void SampleInput_ChangeToFirstMoveReach()
        {
            long n = 9;
            long s = 0;
            long t = 8;
            long R0 = 1;
            long g = 3;
            long seed = 4;
            long p = 7;
            Assert.AreEqual(1L, CircularWalk.Solve(n, s, t, R0, g, seed, p));
        }

        [TestMethod]
        public void DoesntErrorOut()
        {
            Random r = new Random();
            for(long k = 0; k < 10000; ++k)
            {
                int n = r.Next(1, 100 + 1);
                int s = r.Next(0, n);
                int t = r.Next(0, n);
                int p = r.Next(1, n + 1);
                int R0 = r.Next(0, p);
                int g = r.Next(0, p);
                int seed = r.Next(0, p);
                long result = CircularWalk.Solve((long)n, (long)s, (long)t, (long)R0, (long)g, (long)seed, (long)p);
            }
        }
    }
}

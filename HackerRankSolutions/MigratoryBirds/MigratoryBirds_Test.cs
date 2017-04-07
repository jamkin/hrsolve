using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankSolutions.MigratoryBirds
{
    [TestClass]
    public class MigratoryBirds_Test
    {
        [TestMethod]
        public void OneBird()
        {
            for(int i = 1; i < 6; ++i)
            {
                Assert.AreEqual(i, MigratoryBirds.MostCommonBird(new int[] { i }));
            }
        }

        [TestMethod]
        public void TwoDifferentBirds()
        {
            int[] birds = { 1, 2 };
            Assert.AreEqual(1, MigratoryBirds.MostCommonBird(birds));
        }

        [TestMethod]
        public void TwoSameOneDifferent()
        {
            int[] birds = { 1, 2, 2 };
            Assert.AreEqual(2, MigratoryBirds.MostCommonBird(birds));
        }

        [TestMethod]
        public void TwoGroupsOfTwoSame()
        {
            int[] birds = { 1, 1, 2, 2 };
            Assert.AreEqual(1, MigratoryBirds.MostCommonBird(birds));
        }

        [TestMethod]
        public void SampleInput()
        {
            int[] birds = { 1, 4, 4, 4, 5, 3 };
            Assert.AreEqual(4, MigratoryBirds.MostCommonBird(birds));
        }

        [TestMethod]
        public void ConsistentWithAlternativeImplementation()
        {
            Random r = new Random();
            for(int t = 0; t < 1000; ++t)
            {
                int[] birds = new int[r.Next(1, 100)];
                for(int i = 0; i < birds.Length; ++i)
                {
                    birds[i] = r.Next(1, 6);
                }
                Assert.AreEqual(AltMethod(birds), MigratoryBirds.MostCommonBird(birds));
            }
        }

        private static int AltMethod(int[] birds)
        {
            int[] counts = new int[5];
            int max = 0;
            for(int i = 0; i < birds.Length; ++i)
            {
                int j = birds[i] - 1;
                ++counts[j];
                if(counts[j] > max)
                {
                    max = counts[j];
                }
            };
            int b = -1;
            for(int i = 0; i < counts.Length; ++i)
            {
                if(counts[i] == max)
                {
                    b = i + 1;
                    break;
                }
            }
            return b;
        }
    }
}

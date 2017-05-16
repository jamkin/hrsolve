using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankSolutions.WeekOfCode32.FightTheMonsters
{
    [TestClass]
    public class FightTheMonsters_Test
    {
        [TestMethod]
        public void NoMonsters()
        {
            int[] h = { };
            int hit = 8;
            int t = 6;
            Assert.AreEqual(0, FightTheMonsters.KillCount(h, hit, t));
        }

        [TestMethod]
        public void OneMonsterNotEnoughTime()
        {
            int[] h = { 6 };
            int hit = 2;
            int t = 0;
            Assert.AreEqual(0, FightTheMonsters.KillCount(h, hit, t));
            t = 1;
            Assert.AreEqual(0, FightTheMonsters.KillCount(h, hit, t));
            t = 2;
            Assert.AreEqual(0, FightTheMonsters.KillCount(h, hit, t));
        }

        [TestMethod]
        public void OneMonsterJustEnoughTime()
        {
            int[] h = { 6 };
            int hit = 2;
            int t = 3;
            Assert.AreEqual(1, FightTheMonsters.KillCount(h, hit, t));
        }

        [TestMethod]
        public void OneMonsterMoreThanEnoughTime()
        {
            int[] h = { 6 };
            int hit = 2;
            int t = 4;
            Assert.AreEqual(1, FightTheMonsters.KillCount(h, hit, t));
        }

        [TestMethod]
        public void TwoMonstersNotEnoughTimeForEither()
        {
            int[] h = { 2, 3 };
            int hit = 1;
            int t = 1;
            Assert.AreEqual(0, FightTheMonsters.KillCount(h, hit, t));
        }

        [TestMethod]
        public void TwoMonstersEnoughTimeToHitSmallerOnly()
        {
            int[] h = { 2, 3 };
            int hit = 1;
            int t = 2;
            Assert.AreEqual(1, FightTheMonsters.KillCount(h, hit, t));
            t = 3;
            Assert.AreEqual(1, FightTheMonsters.KillCount(h, hit, t));
            t = 4;
            Assert.AreEqual(1, FightTheMonsters.KillCount(h, hit, t));
        }

        [TestMethod]
        public void TwoMonstersEnoughTimeForBoth()
        {
            int[] h = { 2, 3 };
            int hit = 1;
            int t = 5;
            Assert.AreEqual(2, FightTheMonsters.KillCount(h, hit, t));
        }

        [TestMethod]
        public void ThreeMonstersEnoughTimeForTwo()
        {
            int[] h = { 2, 3, 1 };
            int hit = 2;
            int t = 2;
            Assert.AreEqual(2, FightTheMonsters.KillCount(h, hit, t));
        }

        [TestMethod]
        public void ThreeMonstersEnoughTimeForAll()
        {
            int[] h = { 2, 3, 1 };
            int hit = 2;
            int t = 4;
            Assert.AreEqual(3, FightTheMonsters.KillCount(h, hit, t));
        }

        [TestMethod]
        public void SampleInput()
        {
            int[] h = { 16, 19, 7, 11, 23, 8, 16 };
            int hit = 8;
            int t = 6;
            Assert.AreEqual(4, FightTheMonsters.KillCount(h, hit, t));
        }
    }
}

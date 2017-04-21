using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace HackerRankSolutions.CountingValleys
{
    [TestClass]
    public class CountingValleys_Test
    {
        [TestMethod]
        public void SampleInput()
        {
            char[] input = { 'U', 'D', 'D', 'D', 'U', 'D', 'U', 'U' };
            Assert.AreEqual(1, CountingValleys.Solve(input));
        }

        [TestMethod]
        public void ZeroSteps()
        {
            char[] input = { };
            Assert.AreEqual(0, CountingValleys.Solve(input));
        }

        [TestMethod]
        public void OneStepUp()
        {
            char[] input = { 'U' };
            Assert.AreEqual(0, CountingValleys.Solve(input));
        }

        [TestMethod]
        public void OneStepDown()
        {
            char[] input = { 'D' };
            Assert.AreEqual(0, CountingValleys.Solve(input));
        }

        [TestMethod]
        public void TwoStepsUp()
        {
            char[] input = { 'U', 'U' };
            Assert.AreEqual(0, CountingValleys.Solve(input));
        }

        [TestMethod]
        public void TwoStepsDown()
        {
            char[] input = { 'U', 'U' };
            Assert.AreEqual(0, CountingValleys.Solve(input));
        }

        [TestMethod]
        public void ManyStepsUp()
        {
            char[] input = Enumerable.Repeat('U', 50).ToArray();
            Assert.AreEqual(0, CountingValleys.Solve(input));
        }

        [TestMethod]
        public void ManyStepsDown()
        {
            char[] input = Enumerable.Repeat('D', 50).ToArray();
            Assert.AreEqual(0, CountingValleys.Solve(input));
        }

        [TestMethod]
        public void OneUpOneDown()
        {
            char[] input = { 'U', 'D' };
            Assert.AreEqual(0, CountingValleys.Solve(input));
        }

        [TestMethod]
        public void OneDownOneUp()
        {
            char[] input = { 'D', 'U' };
            Assert.AreEqual(1, CountingValleys.Solve(input));
        }

        [TestMethod]
        public void UpUpDown()
        {
            char[] input = { 'U', 'U', 'D' };
            Assert.AreEqual(0, CountingValleys.Solve(input));
        }

        [TestMethod]
        public void DownDownUp()
        {
            char[] input = { 'D', 'D', 'U' };
            Assert.AreEqual(0, CountingValleys.Solve(input));
        }

        [TestMethod]
        public void DownDownUpUp()
        {
            char[] input = { 'D', 'D', 'U', 'U' };
            Assert.AreEqual(1, CountingValleys.Solve(input));
        }

        [TestMethod]
        public void DownUpUp()
        {
            char[] input = { 'D', 'U', 'U' };
            Assert.AreEqual(1, CountingValleys.Solve(input));
        }

        [TestMethod]
        public void DownUpAndAway()
        {
            char[] input = new char[] { 'D' }.Concat(Enumerable.Repeat('U', 100)).ToArray();
            Assert.AreEqual(1, CountingValleys.Solve(input));
        }

        [TestMethod]
        public void UpDownAndAWay()
        {
            char[] input = new char[] { 'U' }.Concat(Enumerable.Repeat('D', 100)).ToArray();
            Assert.AreEqual(0, CountingValleys.Solve(input));
        }

        [TestMethod]
        public void DownUpDownUp()
        {
            char[] input = { 'D', 'U', 'D', 'U' };
            Assert.AreEqual(2, CountingValleys.Solve(input));
        }

        [TestMethod]
        public void DownUpRepeatALot()
        {
            int alot = 30;
            char[] input = Enumerable.Repeat(new char[] { 'D', 'U' }, alot)
                .SelectMany(pair => pair)
                .ToArray();
            Assert.AreEqual(alot, CountingValleys.Solve(input));
        }

        [TestMethod]
        public void UpDownRepeatALot()
        {
            char[] input = Enumerable.Repeat(new char[] { 'U', 'D' }, 58)
                .SelectMany(pair => pair)
                .ToArray();
            Assert.AreEqual(0, CountingValleys.Solve(input));
        }

        [TestMethod]
        public void DownALotAndUpSame()
        {
            int alot = 20;
            char[] downs = Enumerable.Repeat('D', alot).ToArray();
            char[] ups = Enumerable.Repeat('U', alot).ToArray();
            char[] input = downs.Concat(ups).ToArray();
            Assert.AreEqual(1, CountingValleys.Solve(input));
        }

        [TestMethod]
        public void MiscTestMethod_0()
        {
            char[] input = { 'U', 'U', 'D', 'D', 'D', 'U' };
            Assert.AreEqual(1, CountingValleys.Solve(input));
        }

        [TestMethod]
        public void MiscTestMethod_1()
        {
            char[] input = { 'D', 'U', 'U', 'D', 'D', 'U' };
            Assert.AreEqual(2, CountingValleys.Solve(input));
        }

        [TestMethod]
        public void MiscTestMethod_2()
        {
            char[] input = { 'D', 'U', 'U', 'D', 'D', 'U' };
            Assert.AreEqual(2, CountingValleys.Solve(input));
        }
    }
}

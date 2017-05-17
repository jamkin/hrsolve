using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankSolutions.WeightedUniformStrings
{
    [TestClass]
    public class WeightedUniformStrings_Test
    {
        [TestMethod]
        public void EmptyString()
        {
            string s = string.Empty;
            WeightedUniformStrings wus = new WeightedUniformStrings(s);
            Assert.IsFalse(wus.HasUniformWeight(0));
            Assert.IsFalse(wus.HasUniformWeight(1));
            Assert.IsFalse(wus.HasUniformWeight(int.MaxValue));
        }

        [TestMethod]
        public void SingleLetterString()
        {
            string s = "a";
            WeightedUniformStrings wus = new WeightedUniformStrings(s);
            Assert.IsFalse(wus.HasUniformWeight(0));
            Assert.IsTrue(wus.HasUniformWeight(1));
            Assert.IsFalse(wus.HasUniformWeight(2));
            Assert.IsFalse(wus.HasUniformWeight(int.MaxValue));
        }

        [TestMethod]
        public void TwoOfSameLettersString()
        {
            string s = "bb";
            WeightedUniformStrings wus = new WeightedUniformStrings(s);
            Assert.IsFalse(wus.HasUniformWeight(0));
            Assert.IsFalse(wus.HasUniformWeight(1));
            Assert.IsTrue(wus.HasUniformWeight(2));
            Assert.IsFalse(wus.HasUniformWeight(3));
            Assert.IsTrue(wus.HasUniformWeight(4));
            Assert.IsFalse(wus.HasUniformWeight(5));
        }

        [TestMethod]
        public void TwoDifferentLettersString()
        {
            string s = "ab";
            WeightedUniformStrings wus = new WeightedUniformStrings(s);
            Assert.IsFalse(wus.HasUniformWeight(0));
            Assert.IsTrue(wus.HasUniformWeight(1));
            Assert.IsTrue(wus.HasUniformWeight(2));
            Assert.IsFalse(wus.HasUniformWeight(3));
        }

        [TestMethod]
        public void SandwichTest()
        {
            string s = "aba";
            WeightedUniformStrings wus = new WeightedUniformStrings(s);
            Assert.IsFalse(wus.HasUniformWeight(0));
            Assert.IsTrue(wus.HasUniformWeight(1));
            Assert.IsTrue(wus.HasUniformWeight(2));
            Assert.IsFalse(wus.HasUniformWeight(3));
        }

        [TestMethod]
        public void TwoOfSameFollowedByOther()
        {
            string s = "aab";
            WeightedUniformStrings wus = new WeightedUniformStrings(s);
            Assert.IsFalse(wus.HasUniformWeight(0));
            Assert.IsTrue(wus.HasUniformWeight(1));
            Assert.IsTrue(wus.HasUniformWeight(2));
            Assert.IsFalse(wus.HasUniformWeight(3));
            Assert.IsFalse(wus.HasUniformWeight(4));
        }

        [TestMethod]
        public void TwoOfSameFollowedByOtherFollowedByFirst()
        {
            string s = "aaba";
            WeightedUniformStrings wus = new WeightedUniformStrings(s);
            Assert.IsFalse(wus.HasUniformWeight(0));
            Assert.IsTrue(wus.HasUniformWeight(1));
            Assert.IsTrue(wus.HasUniformWeight(2));
            Assert.IsFalse(wus.HasUniformWeight(3));
            Assert.IsFalse(wus.HasUniformWeight(4));
        }

        [TestMethod]
        public void ThreeDifferent()
        {
            string s = "abc";
            WeightedUniformStrings wus = new WeightedUniformStrings(s);
            Assert.IsFalse(wus.HasUniformWeight(0));
            Assert.IsTrue(wus.HasUniformWeight(1));
            Assert.IsTrue(wus.HasUniformWeight(2));
            Assert.IsTrue(wus.HasUniformWeight(3));
            Assert.IsFalse(wus.HasUniformWeight(4));
        }

        [TestMethod]
        public void SampleInput()
        {
            string s = "abccddde";
            WeightedUniformStrings wus = new WeightedUniformStrings(s);
            Assert.IsTrue(wus.HasUniformWeight(1));
            Assert.IsTrue(wus.HasUniformWeight(3));
            Assert.IsTrue(wus.HasUniformWeight(12));
            Assert.IsTrue(wus.HasUniformWeight(5));
            Assert.IsFalse(wus.HasUniformWeight(9));
            Assert.IsFalse(wus.HasUniformWeight(10));
        }
    }
}

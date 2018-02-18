using System;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankSolutions.SeparateTheNumbers
{
    [TestClass]
    public class SeparateTheNumbers_Test
    {
        [TestMethod]
        public void SampeInput1Test()
        {
            string input = "1234";
            string result;
            Assert.IsTrue(SeparateTheNumbers.Solve(input, out result));
            Assert.AreEqual("1", result);
        }

        [TestMethod]
        public void SampleInput2Test()
        {
            string input = "91011";
            string result;
            Assert.IsTrue(SeparateTheNumbers.Solve(input, out result));
            Assert.AreEqual("9", result);
        }

        [TestMethod]
        public void SampleInput3Test()
        {
            string input = "99100";
            string result;
            Assert.IsTrue(SeparateTheNumbers.Solve(input, out result));
            Assert.AreEqual("99", result);
        }

        [TestMethod]
        public void SampleInput4Test()
        {
            string input = "101103";
            string result;
            Assert.IsFalse(SeparateTheNumbers.Solve(input, out result));
        }

        [TestMethod]
        public void SampleInput5Test()
        {
            string input = "010203";
            string result;
            Assert.IsFalse(SeparateTheNumbers.Solve(input, out result));
        }

        [TestMethod]
        public void SampleInput6Test()
        {
            string input = "13";
            string result;
            Assert.IsFalse(SeparateTheNumbers.Solve(input, out result));
        }

        [TestMethod]
        public void SampleInput7Test()
        {
            string input = "1";
            string result;
            Assert.IsFalse(SeparateTheNumbers.Solve(input, out result));
        }

        [TestMethod]
        public void MyTest1()
        {
            string input = "12";
            string result;
            Assert.IsTrue(SeparateTheNumbers.Solve(input, out result));
            Assert.AreEqual("1", result);
        }

        [TestMethod]
        public void MyTest2()
        {
            string input = "102";
            string result;
            Assert.IsFalse(SeparateTheNumbers.Solve(input, out result));
        }

        [TestMethod]
        public void MyTest3()
        {
            string input = "34567891011121314";
            string result;
            Assert.IsTrue(SeparateTheNumbers.Solve(input, out result));
            Assert.AreEqual("3", result);
        }

        [TestMethod]
        public void MyTest4()
        {
            string input = "345678911121314";
            string result;
            Assert.IsFalse(SeparateTheNumbers.Solve(input, out result));
        }

        [TestMethod]
        public void MyTest5()
        {
            string input = "910";
            string result;
            Assert.IsTrue(SeparateTheNumbers.Solve(input, out result));
            Assert.AreEqual("9", result);
        }

        [TestMethod]
        public void MyTest6()
        {
            string input = "10021003";
            string result;
            Assert.IsTrue(SeparateTheNumbers.Solve(input, out result));
            Assert.AreEqual("1002", result);
        }

        [TestMethod]
        public void MyTest7()
        {
            string input = "0012";
            string result;
            Assert.IsFalse(SeparateTheNumbers.Solve(input, out result));
        }

        [TestMethod]
        public void MyTest8()
        {
            string input = "102";
            string result;
            Assert.IsFalse(SeparateTheNumbers.Solve(input, out result));
        }

        [TestMethod]
        public void MyTest9()
        {
            string input = "13014";
            string result;
            Assert.IsFalse(SeparateTheNumbers.Solve(input, out result));
        }

        [TestMethod]
        public void MyTest10()
        {
            string input = "139140";
            string result;
            Assert.IsTrue(SeparateTheNumbers.Solve(input, out result));
            Assert.AreEqual("139", result);
        }

        [TestMethod]
        public void MyTest11()
        {
            string input = string.Join("", Enumerable.Range(18, 100).Select(i => i.ToString()));
            string result;
            Assert.IsTrue(SeparateTheNumbers.Solve(input, out result));
            Assert.AreEqual("18", result);
        }

        [TestMethod]
        public void MyTest12()
        {
            string input = "109";
            string result;
            Assert.IsFalse(SeparateTheNumbers.Solve(input, out result));
        }

        [TestMethod]
        public void TestCase3Line1()
        {
            string input = "1234567891011121314151617181920";
            string result;
            Assert.IsTrue(SeparateTheNumbers.Solve(input, out result));
            Assert.AreEqual("1", result);
        }

        [TestMethod]
        public void TestCase3Line2()
        {
            string input = "5678910111213141516171819202122";
            string result;
            Assert.IsTrue(SeparateTheNumbers.Solve(input, out result));
            Assert.AreEqual("5", result);
        }

        [TestMethod]
        public void TestCase3Line3()
        {
            string input = "9101112131415161718192021222324";
            string result;
            Assert.IsTrue(SeparateTheNumbers.Solve(input, out result));
            Assert.AreEqual("9", result);
        }

        [TestMethod]
        public void TestCase3Line4()
        {
            string input = "979899100101102103104105106107";
            string result;
            Assert.IsTrue(SeparateTheNumbers.Solve(input, out result));
            Assert.AreEqual("97", result);
        }

        [TestMethod]
        public void TestCase3Line5()
        {
            string input = "998999100010011002100310041005";
            string result;
            Assert.IsTrue(SeparateTheNumbers.Solve(input, out result));
            Assert.AreEqual("998", result);
        }

        [TestMethod]
        public void TestCase3Line6()
        {
            string input = "1234567891011120314151617181920";
            string result;
            Assert.IsFalse(SeparateTheNumbers.Solve(input, out result));
        }
    }
}

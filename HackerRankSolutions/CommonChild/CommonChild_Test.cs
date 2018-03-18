using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankSolutions.CommonChild
{
    [TestClass]
    public class CommonChild_Test
    {
        #region tests

        [TestMethod]
        public void SampleTest0()
        {
            ExecuteTest(first: "HARRY", second: "SALLY", expected: 2);
        }

        [TestMethod]
        public void SampleTest1()
        {
            ExecuteTest(first: "AA", second: "BB", expected: 0);
        }

        [TestMethod]
        public void SampleTest2()
        {
            ExecuteTest(first: "SHINCHAN", second: "NOHARAAA", expected: 3);
        }

        [TestMethod]
        public void SampleTest3()
        {
            ExecuteTest(first: "ABCDEF", second: "FBDAMN", expected: 2);
        }

        [TestMethod]
        public void MyTest0()
        {
            ExecuteTest(first: "", second: "", expected: 0);
        }

        [TestMethod]
        public void MyTest1()
        {
            ExecuteTest(first: "", second: "A", expected: 0);
        }

        [TestMethod]
        public void MyTest2()
        {
            ExecuteTest(first: "A", second: "A", expected: 1);
        }

        [TestMethod]
        public void MyTest3()
        {
            ExecuteTest(first: "A", second: "B", expected: 0);
        }

        [TestMethod]
        public void MyTest4()
        {
            ExecuteTest(first: "A", second: "AB", expected: 1);
        }

        [TestMethod]
        public void MyTest5()
        {
            ExecuteTest(first: "A", second: "BA", expected: 1);
        }
        [TestMethod]
        public void MyTest6()
        {
            ExecuteTest(first: "AB", second: "BA", expected: 1);
        }

        [TestMethod]
        public void MyTest7()
        {
            ExecuteTest(first: "AB", second: "AB", expected: 2);
        }

        [TestMethod]
        public void MyTest8()
        {
            ExecuteTest(first: "AC", second: "ABC", expected: 2);
        }

        [TestMethod]
        public void MyTest9()
        {
            ExecuteTest(first: "AC", second: "ABCD", expected: 2);
        }

        [TestMethod]
        public void MyTest10()
        {
            ExecuteTest(first: "ACE", second: "ABCDEE", expected: 3);
        }

        [TestMethod]
        public void MyTest11()
        {
            ExecuteTest(first: "ACEF", second: "ABCDEE", expected: 3);
        }

        [TestMethod]
        public void MyTest12()
        {
            ExecuteTest(first: "ACEJJKLMNPST", second: "ABCDEEGHHHIPQRRS", expected: 5);
        }

        [TestMethod]
        public void MyTest13()
        {
            ExecuteTest(first: "ACEF", second: "BCDEEA", expected: 2);
        }

        [TestMethod]
        public void MyTest14()
        {
            ExecuteTest(first: "WYZXY", second: "YOOX", expected: 2);
        }

        [TestMethod]
        public void MyTest15()
        {
            ExecuteTest(first: "XXXXXXYXXX", second: "XYXXXXXXXX", expected: 9);
        }

        [TestMethod]
        public void MyTest16()
        {
            ExecuteTest(first: "ATXTXY", second: "XXXXXXXXXX", expected: 2);
        }

        [TestMethod]
        public void MyTest17()
        {
            ExecuteTest(first: "CYAT", second: "CATY", expected: 3);
        }

        [TestMethod]
        public void TestCase1()
        {
            ExecuteTest
            (
                first: "WEWOUCUIDGCGTRMEZEPXZFEJWISRSBBSYXAYDFEJJDLEBVHHKS",
                second: "FDAGCXGKCTKWNECHMRXZWMLRYUCOCZHJRRJBOAJOQJZZVUYXIC",
                expected: 15
            );
        }

        #endregion

        #region helpers

        private static void ExecuteTest(string first, string second, int expected)
        {
            int actual = CommonChild.Solve(first, second);
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}

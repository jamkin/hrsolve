using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Reflection;
using System.IO;

namespace HackerRankSolutions.Candies
{
    [TestClass]
    public class CandiesTest
    {
        [TestMethod]
        public void SampleInput()
        {
            Assert.AreEqual((ulong)4, Candies.ByRating(new int[] { 1, 2, 2 }));
        }

        [TestMethod]
        public void NoStudents()
        {
            Assert.AreEqual((ulong)0, Candies.ByRating(new int[] { }));
        }

        [TestMethod]
        public void OneStudent()
        {
            for (int i = 0; i < 10; ++i)
            {
                Assert.AreEqual((ulong)1, Candies.ByRating(new int[] { i }));
            }
        }

        [TestMethod]
        public void TwoStudentsSameScore()
        {
            for (int i = 0; i < 10; ++i)
            {
                Assert.AreEqual((ulong)2, Candies.ByRating(new int[] { i, i }));
            }
        }

        [TestMethod]
        public void TwoStudentsDifferentScores()
        {
            for(int i = 0; i < 10; ++i)
            {
                Assert.AreEqual((ulong)3, Candies.ByRating(new int[] { i, i + 1 }));
                Assert.AreEqual((ulong)3, Candies.ByRating(new int[] { i + 1, i }));
            }
        }

        [TestMethod]
        public void ThreeStudents_0()
        {
            Assert.AreEqual((ulong)3, Candies.ByRating(new int[] { 1, 1, 1 }));
        }

        [TestMethod]
        public void ThreeStudents_1()
        {
            Assert.AreEqual((ulong)4, Candies.ByRating(new int[] { 1, 1, 2 }));
        }

        [TestMethod]
        public void ThreeStudents_2()
        {
            Assert.AreEqual((ulong)6, Candies.ByRating(new int[] { 1, 2, 3 }));
        }

        [TestMethod]
        public void ThreeStudents_3()
        {
            Assert.AreEqual((ulong)6, Candies.ByRating(new int[] { 1, 2, 4 }));
        }

        [TestMethod]
        public void FourStudents_0()
        {
            Assert.AreEqual((ulong)10, Candies.ByRating(new int[] { 1, 2, 3, 4 }));
        }

        [TestMethod]
        public void FourStudents_1()
        {
            Assert.AreEqual((ulong)5, Candies.ByRating(new int[] { 1, 1, 1, 2 }));
        }

        [TestMethod]
        public void FourStudents_2()
        {
            Assert.AreEqual((ulong)5, Candies.ByRating(new int[] { 1, 1, 2, 2 }));
        }

        [TestMethod]
        public void FourStudents_3()
        {
            Assert.AreEqual((ulong)6, Candies.ByRating(new int[] { 1, 2, 2, 3 }));
        }

        [TestMethod]
        public void FourStudents_4()
        {
            Assert.AreEqual((ulong)7, Candies.ByRating(new int[] { 1, 2, 3, 3 }));
        }

        [TestMethod]
        public void FourStudents_5()
        {
            Assert.AreEqual((ulong)7, Candies.ByRating(new int[] { 1, 2, 3, 2 }));
        }

        [TestMethod]
        public void FourStudents_6()
        {
            Assert.AreEqual((ulong)7, Candies.ByRating(new int[] { 1, 2, 3, 1 }));
        }

        [TestMethod]
        public void FourStudents_7()
        {
            Assert.AreEqual((ulong)5, Candies.ByRating(new int[] { 1, 2, 1, 1 }));
        }

        [TestMethod]
        public void FourStudents_8()
        {
            Assert.AreEqual((ulong)5, Candies.ByRating(new int[] { 2, 2, 2, 1 }));
        }

        [TestMethod]
        public void FourStudents_9()
        {
            Assert.AreEqual((ulong)5, Candies.ByRating(new int[] { 2, 2, 1, 1 }));
        }

        [TestMethod]
        public void AscendersEqualSum()
        {
            for(int i = 1; i < 20; ++i)
            {
                int[] ratings = Enumerable.Range(1, i).ToArray();
                Assert.AreEqual((ulong)(ratings.Length * (ratings.Length + 1) / 2), Candies.ByRating(ratings));
            }
        }

        [TestMethod]
        public void TranslationDoesntMatter()
        {
            for(int i = 0; i < 50; ++i)
            {
                int[] students = GenerateRandomArray();
                for(int j = 1; j <= 10; ++j)
                {
                    int[] translated = students.Select(s => s + j).ToArray();
                    Assert.AreEqual((ulong)Candies.ByRating(students), Candies.ByRating(translated));
                }
            }
        }

        [TestMethod]
        public void TestCase_2()
        {
            int[] students = ReadInput("TestCase_2_Input.txt");
            ulong actual = Candies.ByRating(students);
            Assert.AreEqual((ulong)33556, actual);
        }

        [TestMethod]
        public void TestCase_11()
        {
            int[] students = ReadInput("TestCase_11_Input.txt");
            ulong actual = Candies.ByRating(students);
            Assert.AreEqual((ulong)5000050000, actual);
        }

        private static int[] ReadInput(string testFileName)
        {
            string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Candies", "TestCaseInput", testFileName);
            return File.ReadAllLines(filePath).Select(line => int.Parse(line)).ToArray();
        }

        private static int[] GenerateRandomArray()
        {
            Random r = new Random();
            int len = r.Next() % 100;
            int[] arr = new int[len];
            for(int i = 0; i < len; ++i)
                arr[i] = r.Next() % 50;
            return arr;
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.IO;

namespace HackerRankSolutions.GamingArray
{
    [TestClass]
    public class GamingArray_Test
    {
        [TestMethod]
        public void SampleInput_0_Line0()
        {
            int[] board = { 5, 2, 6, 3, 4 };
            Assert.AreEqual("ANDY", GamingArray.WhoWins(board));
        }

        [TestMethod]
        public void SampleInput_0_Line1()
        {
            int[] board = { 3, 1 };
            Assert.AreEqual("BOB", GamingArray.WhoWins(board));
        }

        [TestMethod]
        public void EmptyBoard()
        {
            int[] board = { };
            Assert.AreEqual("ANDY", GamingArray.WhoWins(board));
        }

        [TestMethod]
        public void SingleElement()
        {
            int[] board = { 1 };
            Assert.AreEqual("BOB", GamingArray.WhoWins(board));
        }

        [TestMethod]
        public void TwoOfSameElement()
        {
            int[] board = { 2, 2 };
            Assert.AreEqual("BOB", GamingArray.WhoWins(board));
        }

        [TestMethod]
        public void TwoElementsSecondLarger()
        {
            int[] board = { 1, 2 };
            Assert.AreEqual("ANDY", GamingArray.WhoWins(board));
        }

        [TestMethod]
        public void ThreeAscending()
        {
            int[] board = { 1, 2, 3 };
            Assert.AreEqual("BOB", GamingArray.WhoWins(board));
        }

        [TestMethod]
        public void UpDown()
        {
            int[] board = { 1, 3, 2 };
            Assert.AreEqual("ANDY", GamingArray.WhoWins(board));
        }

        [TestMethod]
        public void TestCase_16()
        {
            string filepath = Path.Combine
                (
                    Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName,
                    "RunningMedian",
                    "TestCaseInput",
                    "TestCase_16_Input.txt"
                );
            string[] lines = File.ReadAllLines(filepath);
            int[][] inputs = lines.Skip(1)
                .Where((s, i) => i % 2 == 1)
                .Select((s) => Array.ConvertAll(s.Split(' '), int.Parse))
                .ToArray();
            string[] expectedOutputs =
            {
                "BOB",
                "BOB",
                "BOB",
                "ANDY",
                "BOB",
                "BOB",
                "BOB",
                "BOB",
                "ANDY",
                "BOB"
            };
            for(int i = 0; i < inputs.Length; ++i)
            {
                Assert.AreEqual(expectedOutputs[i], GamingArray.WhoWins(inputs[i]));
            }
        }
    }
}

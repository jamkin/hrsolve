using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace HackerRankSolutions.GamingArray
{
    [TestClass]
    public class GamingArray_Test
    {
        [TestMethod]
        public void SampleInput_0_Line0()
        {
            int[] board = { 5, 2, 6, 3, 4 };
            Assert.AreEqual(GamingArray.PlayerTwo, GamingArray.WhoWins(board));
        }

        [TestMethod]
        public void SampleInput_0_Line1()
        {
            int[] board = { 3, 1 };
            Assert.AreEqual(GamingArray.PlayerOne, GamingArray.WhoWins(board));
        }

        [TestMethod]
        public void EmptyBoard()
        {
            int[] board = { };
            Assert.AreEqual(GamingArray.PlayerTwo, GamingArray.WhoWins(board));
        }

        [TestMethod]
        public void SingleElement()
        {
            int[] board = { 1 };
            Assert.AreEqual(GamingArray.PlayerOne, GamingArray.WhoWins(board));
        }

        [TestMethod]
        public void TwoOfSameElement()
        {
            int[] board = { 2, 2 };
            Assert.AreEqual(GamingArray.PlayerOne, GamingArray.WhoWins(board));
        }

        [TestMethod]
        public void TwoElementsSecondLarger()
        {
            int[] board = { 1, 2 };
            Assert.AreEqual(GamingArray.PlayerTwo, GamingArray.WhoWins(board));
        }

        [TestMethod]
        public void GeneralAscendingOrder()
        {
            for(int i = 0; i < 10; ++i)
            {
                int[] board = Enumerable.Range(0, i).ToArray();
                string expectedWinner = i % 2 == 1 ? GamingArray.PlayerOne : GamingArray.PlayerTwo;
                Assert.AreEqual(expectedWinner, GamingArray.WhoWins(board));
            }
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

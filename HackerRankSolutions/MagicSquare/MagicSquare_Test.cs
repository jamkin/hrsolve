using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace HackerRankSolutions.MagicSquare
{
    [TestClass]
    public class MagicSquareTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidInput_TooSmall_Test()
        {
            int[,] tooSmall = new int[2, 3];
            MagicSquare.ConvertCost(tooSmall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidInput_TooBig_Test()
        {
            int[,] tooBig = new int[3, 4];
            MagicSquare.ConvertCost(tooBig);
        }

        [TestMethod]
        public void SampleInput_Test()
        {
            int[,] mat = StringToMatrix
            (@"
                4 9 2
                3 5 7
                8 1 5
            ");
            Assert.AreEqual(1, MagicSquare.ConvertCost(mat));
        }

        [TestMethod]
        public void AlreadyMagial_Test_0()
        {
            int[,] mat = StringToMatrix
            (@"
                8 1 6
                3 5 7
                4 9 2
            ");
            Assert.AreEqual(0, MagicSquare.ConvertCost(mat));
        }

        [TestMethod]
        public void AlreadyMagial_Test_1()
        {
            int[,] mat = StringToMatrix
            (@"
                6 1 8
                7 5 3
                2 9 4
            ");
            Assert.AreEqual(0, MagicSquare.ConvertCost(mat));
        }

        [TestMethod]
        public void AlreadyMagial_Test_2()
        {
            int[,] mat = StringToMatrix
            (@"
                4 9 2
                3 5 7
                8 1 6
            ");
            Assert.AreEqual(0, MagicSquare.ConvertCost(mat));
        }

        [TestMethod]
        public void AlreadyMagial_Test_3()
        {
            int[,] mat = StringToMatrix
            (@"
                2 9 4
                7 5 3
                6 1 8
            ");
            Assert.AreEqual(0, MagicSquare.ConvertCost(mat));
        }

        [TestMethod]
        public void AlreadyMagial_Test_4()
        {
            int[,] mat = StringToMatrix
            (@"
                8 3 4
                1 5 9
                6 7 2
            ");
            Assert.AreEqual(0, MagicSquare.ConvertCost(mat));
        }

        [TestMethod]
        public void AlreadyMagial_Test_5()
        {
            int[,] mat = StringToMatrix
            (@"
                4 3 8
                9 5 1
                2 7 6
            ");
            Assert.AreEqual(0, MagicSquare.ConvertCost(mat));
        }

        [TestMethod]
        public void AlreadyMagial_Test_6()
        {
            int[,] mat = StringToMatrix
            (@"
                6 7 2
                1 5 9
                8 3 4
            ");
            Assert.AreEqual(0, MagicSquare.ConvertCost(mat));
        }

        [TestMethod]
        public void AlreadyMagial_Test_7()
        {
            int[,] mat = StringToMatrix
            (@"
                2 7 6
                9 5 1
                4 3 8
            ");
            Assert.AreEqual(0, MagicSquare.ConvertCost(mat));
        }

        [TestMethod]
        public void OneOff_Test_0()
        {
            for(int i = 2; i <= 9; ++i)
            {
                int[,] mat = StringToMatrix
                ($@"
                4   9    2
                3   5    7
                8   {i}  6
                ");
                Assert.AreEqual(i - 1, MagicSquare.ConvertCost(mat));
            }
        }

        [TestMethod]
        public void OneOff_Test_1()
        {
            for(int i = 7; i >= 1; --i)
            {
                int[,] mat = StringToMatrix
                ($@"
                4    9   2
                3    5   7
                {i}  1   6
                ");
                Assert.AreEqual(8 - i, MagicSquare.ConvertCost(mat));
            }
        }

        private static int[,] StringToMatrix(string lines)
        {
            int[] nums = lines.Split(new char[0], StringSplitOptions.RemoveEmptyEntries)
                .Select(s => int.Parse(s))
                .ToArray();
            int[,] matrix = new int[3, 3];
            for(int i = 0; i < 3; ++i)
                for(int j = 0; j < 3; ++j)
                    matrix[i, j] = nums[i * 3 + j];
            return matrix;
        }
    }
}

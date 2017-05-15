using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace HackerRankSolutions.CrosswordPuzzle
{
    [TestClass]
    public class CrosswordPuzzle_Test
    {
        [TestMethod]
        public void SingleLetterSingleSpace()
        {
            string lines = @"
++++++++++
++++++++++
++++++++++
+++++++-++
++++++++++
++++++++++
++++++++++
++++++++++
++++++++++
++++++++++
";
            char[,] board = LinesToMatrix(lines);
            string[] words = { "a" };
            CrosswordPuzzle cp = new CrosswordPuzzle(board);
            cp.AddWords(words);
            string boardstr = cp.StringifyBoard();
            string expected = @"
++++++++++
++++++++++
++++++++++
+++++++a++
++++++++++
++++++++++
++++++++++
++++++++++
++++++++++
++++++++++
".Trim();
            Assert.AreEqual(expected, boardstr);
        }

        [TestMethod]
        public void SampleInput()
        {
            string lines = @"
+-++++++++
+-++++++++
+-++++++++
+-----++++
+-+++-++++
+-+++-++++
+++++-++++
++------++
+++++-++++
+++++-++++
";
            char[,] board = LinesToMatrix(lines);
            string[] words = { "LONDON", "DELHI", "ICELAND", "ANKARA" };
            CrosswordPuzzle cp = new CrosswordPuzzle(board);
            cp.AddWords(words);
            string boardstr = cp.StringifyBoard();
            string expected = @"
+L++++++++
+O++++++++
+N++++++++
+DELHI++++
+O+++C++++
+N+++E++++
+++++L++++
++ANKARA++
+++++N++++
+++++D++++
".Trim();
            Assert.AreEqual(expected, boardstr);
        }

        private char[,] LinesToMatrix(string lines)
        {
            string[] separate = lines.Split(new char[0], StringSplitOptions.RemoveEmptyEntries).ToArray();
            int m = separate.Length, n = separate[0]?.Length ?? 0;
            char[,] matrix = new char[m, n];
            for(int i = 0; i < m; ++i)
                for(int j = 0; j < n; ++j)
                    matrix[i, j] = separate[i][j];
            return matrix;
        }
    }
}

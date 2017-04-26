using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.MagicSquare
{
    /// <summary>
    /// Provides a solution to the Magic Square problem
    /// https://www.hackerrank.com/challenges/magic-square-forming
    /// </summary>
    public static class MagicSquare
    {
        /// <summary>
        /// Hard-code the the 8 out of 9! squares of dimensions 3x3
        /// that are magic.
        /// </summary>
        public static readonly int[][,] MagicSquares =
        {
           new int[]
           {
               8, 1, 6,
               3, 5, 7,
               4, 9, 2
           }.ToSquare(),
           new int[]
           {
               6, 1, 8,
               7, 5, 3,
               2, 9, 4
           }.ToSquare(),
           new int[]
           {
               4, 9, 2,
               3, 5, 7,
               8, 1, 6
           }.ToSquare(),
           new int[]
           {
               2, 9, 4,
               7, 5, 3,
               6, 1, 8
           }.ToSquare(),
           new int[]
           {
               8, 3, 4,
               1, 5, 9,
               6, 7, 2
           }.ToSquare(),
           new int[]
           {
               4, 3, 8,
               9, 5, 1,
               2, 7, 6
           }.ToSquare(),
           new int[]
           {
               6, 7, 2,
               1, 5, 9,
               8, 3, 4
           }.ToSquare(),
           new int[]
           {
               2, 7, 6,
               9, 5, 1,
               4, 3, 8
           }.ToSquare(),
        };

        /// <summary>
        /// Brute force, but O(1), solution. The number of operations is capped
        /// at a little over 100 since there is a fixed number of matrices
        /// </summary>
        public static int ConvertCost(int[,] M)
        {
            if(M.GetLength(0) != 3 || M.GetLength(1) != 3)
                throw new ArgumentException();
            return MagicSquares.Min(ms => MatrixDiff(ms, M));
        }

        /// <summary>
        /// Sum of absolute difference between elements of two matrices
        /// </summary>
        private static int MatrixDiff(int[,] A, int[,] B)
        {
            if
            (A.GetLength(0) != B.GetLength(0)
                || A.GetLength(1) != B.GetLength(1)
                || A.GetLength(1) != B.GetLength(0))
            {
                throw new ArgumentException($"{nameof(A)}, {nameof(B)}");
            }
            int diff = 0;
            for(int i = 0, n = A.GetLength(0); i < n; ++i)
                for(int j = 0; j < n; ++j)
                    diff += Math.Abs(A[i, j] - B[i, j]);
            return diff;
        }
    }

    public static class Extensions
    {
        /// <summary>
        /// Helper method for transforming an arry into a square matrix
        /// </summary>
        public static T[,] ToSquare<T>(this T[] flattened)
        {
            double d = Math.Sqrt(flattened.Length);
            if(d % 1 != 0)
                throw new ArgumentException(nameof(flattened));
            int n = (int)d;
            T[,] multi = new T[n, n];
            for(int i = 0; i < n; ++i)
                for(int j = 0; j < n; ++j)
                    multi[i, j] = flattened[n * i + j];
            return multi;
        }
    }
}

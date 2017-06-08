using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.Abbreviation
{
    /// <summary>
    /// Provides a solution to https://www.hackerrank.com/challenges/abbr
    /// </summary>
    public class Abbreviation
    {
        #region LengthyExplanation
        /*
            Explanation of algorithm, by example:
            
            Suppose A = "daBcd", B = "ABC".

            Since A.Length = 5 and B.Length = 3, construct a 6x4 matrix

            M =

            -----------------------------------------
            |    X    |    X    |    X    |    X    |
            -----------------------------------------
            |    X    |    X    |    X    |    X    |
            -----------------------------------------
            |    X    |    X    |    X    |    X    |
            -----------------------------------------
            |    X    |    X    |    X    |    X    |
            -----------------------------------------
            |    X    |    X    |    X    |    X    |
            -----------------------------------------
            |    X    |    X    |    X    |    X    |
            -----------------------------------------

            that will be filled with true or false values. The (i,j)th element will
            be the solution to the problem if using the substring of indices [0, i)
            from A and [0, j) from B.

            How to fill out the 1st column is fairly obvious. M[i, 0] = true for i > 0
            only if A.Substring(0, i) does not contain any upper-case letters, because
            to convert a non-empty string A.Substring(0, i) to the empty string
            B.Substring(0, 0) we would need to delete every single letter and we cannot
            delete capital letters. This gives us

            M =

            -------------------------------------------------------
            |    true    |      X      |      X      |      X     |
            -------------------------------------------------------
            |    true    |      X      |      X      |      X     |
            -------------------------------------------------------
            |    true    |      X      |      X      |      X     |
            -------------------------------------------------------
            |    false   |      X      |      X      |      X     |
            -------------------------------------------------------
            |    false   |      X      |      X      |      X     |
            -------------------------------------------------------
            |    false   |      X      |      X      |      X     |
            -------------------------------------------------------

            Now consider how to fill out M[i, j] given that we know the value of
            M[i - 1, j - 1] and M[i, j - 1]. This will fill out the Xs above.

            If M[i - 1, j - 1] = true, that means the string A.Substring(0, i - 1)
            can be transformed to the string B.Substring(0, j - 1). We know then
            that A.Substring(0, i) = A.Substring(0, i - 1) + A[i - 1] can be transformed
            to B.Substring(0, j) = B.Substring(0, j - 1) + B[j - 1] if A[i - 1] = B[j - 1]
            or A[i - 1].ToUpper() = B[j - 1], because we can use the same transformation 
            A.Substring(0, i - 1) -> B.Substring(0, j - 1) for the first parts of the strings
            and then for the second parts A[i - 1] -> B[j - 1] we do nothing if they're equal
            or capitalize A[i - 1] if it's the lower case of B[j - 1].

            If M[i - 1, j] = true, that means A.Substring(0, i - 1) can be transformed to
            B.Substring(0, j) = B.Substring(0, j - 1) + B[j - 1]. We know then that 
            A.Substring(0, i - 1) + A[i - 1] can be transformed to B.Substring(0, j - 1)
            if A[i - 1] is lowercase because we can delete it.

            The above reasoning showed that M[i, j] = true if

                * M[i - 1, j - 1] = true
                and
                * A[i - 1] = B[j - 1] or A[i - 1].ToUpper() = B[j - 1]
            
            or

                * M[i - 1, j] = true
                and
                * A[i - 1] is lowercase

            The inverse is 

                * M[i - 1, j - 1] = false
               or
                * A[i - 1] = B[j - 1] and A[i - 1].ToUpper() != B[j - 1]
            and
                * M[i - 1, j] = false
               or
                * A[j - 1] is uppercase
            
            and it can be shown that the inverse implies M[i, j] = false. 
        */
        #endregion
        public static bool Solve(string A, string B)
        {
            bool[,] M = new bool[A.Length + 1, B.Length + 1];
            M[0, 0] = true;
            for(int i = 1; i < A.Length && A[i - 1].IsLower(); ++i)
            {
                M[i, 0] = true;
            }
            for(int i = 1; i <= A.Length; ++i)
            {
                for(int j = 1; j <= B.Length; ++j)
                {
                    if(M[i - 1, j] && A[i - 1].IsLower())
                    {
                        M[i, j] = true;
                    }
                    if(M[i - 1, j - 1] && (Char.ToUpper(A[i - 1]) == B[j - 1] || A[i - 1] == B[j - 1]))
                    {
                        M[i, j] = true;
                    }
                }
            }
            return M[A.Length, B.Length];
        }
    }

    public static class CharExtensions
    {
        public static bool IsLower(this char c) => c == Char.ToLower(c);
    }
}

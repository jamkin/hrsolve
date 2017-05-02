using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.RecursiveDigitSum
{
    /// <summary>
    /// Provides a solution to https://www.hackerrank.com/challenges/recursive-digit-sum
    /// </summary>
    public static class RecursiveDigitSum
    {
        /// <summary>
        /// Recursive function that solves problem in O(n) time where
        /// n is the number of digits in val
        /// </summary>
        public static ulong Solve(IEnumerable<byte> digits)
        {
            if(digits.Count() == 1)
                return (ulong)digits.Single();
            ulong sum = digits.Aggregate(0ul, (prev, cur) => prev + cur);
            byte[] nextdigs = sum.GetDigits();
            return Solve(nextdigs);
        }

        /// <summary>
        /// Method for generating the input to the Solve method from the
        /// parameters given in the problem. We have to use a string for sn
        /// since the max value of the number is too big for a primitive 
        /// integral type to hold.
        /// </summary>
        /// <param name="sn"></param>
        /// <param name="k">Number of repeats of sn</param>
        /// <returns>The digits of the number sn repeat k times</returns>
        public static IEnumerable<byte> ConvertInput(string sn, int k)
        {
            // optimization
            for(; k % 10 == 0; k /= 10);

            for(int i = 0; i < k; ++i)
                foreach(char c in sn)
                    yield return Convert.ToByte(c - '0');
        }
    }
}

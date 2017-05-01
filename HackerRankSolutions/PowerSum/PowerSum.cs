using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRankSolutions.PowerSum
{
    /// <summary>
    /// Provides a solution to https://www.hackerrank.com/challenges/the-power-sum/forum
    /// </summary>
    public static class PowerSum
    {
        /// <summary>
        /// Bounds of value X in the problem
        /// </summary>
        public static readonly Tuple<int, int> XRange = Tuple.Create(1, 1000);

        public static int Solve(int X, int N)
        {
            int[] powers = GetPowers(N).ToArray();
            return SubsetSums(powers, X);
        }

        /// <summary>
        /// Ripped from http://stackoverflow.com/questions/18305843/find-all-subsets-that-sum-to-a-particular-value, 
        /// this is an O(n^2) way of finding all subsets of an array that add up to a particular value.
        /// </summary>
        private static int SubsetSums(int[] numbers, int sum)
        {
            int[] dp = new int[sum + 1];
            dp[0] = 1;
            int currentSum = 0;
            for(int i = 0; i < numbers.Length; i++)
            {
                currentSum += numbers[i];
                for(int j = Math.Min(sum, currentSum); j >= numbers[i]; j--)
                    dp[j] += dp[j - numbers[i]];
            }
            return dp[sum];
        }

        /// <summary>
        /// Yields all the natural numbers that when raised to the power of n
        /// fall within the bounds of X
        /// </summary>
        private static IEnumerable<int> GetPowers(int n)
        {
            for(int b = XRange.Item1; ; ++b)
            {
                int p = (int)Math.Pow(b, n);
                if(p >= XRange.Item1 && p <= XRange.Item2)
                    yield return p;
                else
                    yield break;
            }
        }
    }
}

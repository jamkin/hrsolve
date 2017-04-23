using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.Candies
{
    /// <summary>
    /// Provides a solution to the Candies problem (https://www.hackerrank.com/challenges/candies)
    /// </summary>
    public static class Candies
    {
        /// <summary>
        /// O(n) solution for minimizing the number of candies given out
        /// </summary>
        /// <param name="ratings">Ratings of students</param>
        /// <returns>The total number of candies that must be given to students</returns>
        public static ulong ByRating(int[] ratings)
        {
            int[] candies = Enumerable.Repeat(1, ratings.Length).ToArray();

            for(int i = 0; i < ratings.Length; ++i)
            {
                if(IsValley(ratings, i))
                {
                    candies[i] = 1;
                    for(int j = i - 1; j >= 0 && ratings[j] > ratings[j + 1] && candies[j] <= candies[j + 1]; --j)
                    {
                        candies[j] = candies[j + 1] + 1;
                    }
                    for(int j = i + 1; j < ratings.Length && ratings[j] > ratings[j - 1] && candies[j] <= candies[j - 1]; ++j)
                    {
                        candies[j] = candies[j - 1] + 1;
                    }
                }
            }
         
            ulong l = 0;
            foreach(int c in candies)
                l += (ulong)c;
            return l;
        }

        private static bool IsValley(int[] arr, int index) =>
            (index == 0 || arr[index - 1] >= arr[index])
                && ((index + 1) == arr.Length || arr[index + 1] >= arr[index]);
    }
}

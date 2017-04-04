using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.BirthdayCakeCandles
{
    /// <summary>
    /// Solution to https://www.hackerrank.com/challenges/birthday-cake-candles
    /// </summary>
    public static class BirthdayCakeCandles
    {
        /// <summary>
        /// The problem reduces to finding the number of candles with heights
        /// equal to the max height.
        /// 
        /// Time-Complexity: O(n) where n = heights.Length
        /// </summary>
        public static int CandlesToBlow(int[] heights)
        {
            // Note: We could do this with 1 pass through the array by keeping track
            // of the max and grouping the heights. But this looks better.
            if(heights.Length == 0)
                return 0;
            int max = heights.Max();
            return heights.Count(h => h == max);
        }
    }
}

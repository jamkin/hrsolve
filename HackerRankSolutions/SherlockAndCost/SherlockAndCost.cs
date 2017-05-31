using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.SherlockAndCost
{
    /// <summary>
    /// Provides a solution to https://www.hackerrank.com/challenges/sherlock-and-cost
    /// </summary>
    public static class SherlockAndCost
    {
        /// <summary>
        /// Maximizes 
        /// 
        /// |a[0] - a[1]| + |a[1] - a[2]| + ... + |a[n-1] - a[n]|
        /// 
        /// subject to 1 <= a[i] <= b[i]
        /// 
        /// Returns the max value
        /// 
        /// Assumes valid input
        /// </summary>
        public static int Solve(int[] b)
        {
            int low = 0, high = 0;
            for(int i = 1; i < b.Length; ++i)
            {
                int up = b[i] - 1;
                int down = b[i - 1] - 1;
                int prev_low = low;
                low = Math.Max(low, high + down);
                high = Math.Max(high, prev_low + up);
            }
            return Math.Max(high, low);
        }
    }
}

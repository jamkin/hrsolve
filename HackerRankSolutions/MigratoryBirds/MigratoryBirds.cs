using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.MigratoryBirds
{
    /// <summary>
    /// Solution to https://www.hackerrank.com/challenges/migratory-birds?h_r=next-challenge&h_v=zen
    /// </summary>
    public static class MigratoryBirds
    {
        /// <summary>
        /// Returns the most common bird, and if there is more than one, the 
        /// one with the lowest Id.
        /// 
        /// Time-complexity: O(n) provided valid input (range of values of
        /// input array is [1, 5])
        /// </summary>
        public static int MostCommonBird(int[] birds)
        {
            return
                (from b in birds
                 group b by b into g
                 orderby g.Count() descending, g.Key
                 select g.Key).First();                
        }
    }
}

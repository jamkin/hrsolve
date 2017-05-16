using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.WeekOfCode32.FightTheMonsters
{
    /// <summary>
    /// Provides a solution to https://www.hackerrank.com/contests/w32/challenges/fight-the-monsters
    /// </summary>
    public static class FightTheMonsters
    {
        /// <summary>
        /// Solves the problem prompt in O(n*log(n)) time where n is h.Length
        /// </summary>
        /// <param name="h">Monster healths</param>
        /// <param name="hit">Hit value</param>
        /// <param name="t">Time</param>
        public static int KillCount(int[] h, int hit, int t)
        {
            Array.Sort(h);
            Queue<int> q = new Queue<int>(h);
            int kills = 0;
            for (; t > 0 && q.Count > 0;)
            {
                int m = q.Dequeue();
                for(; t > 0 && m > 0; --t, m -= hit) ;
                if (m <= 0)
                {
                    ++kills;
                }
            }
            return kills;
        }
    }
}

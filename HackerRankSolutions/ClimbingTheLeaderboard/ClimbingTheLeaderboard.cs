using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Provides a solution to https://www.hackerrank.com/challenges/climbing-the-leaderboard
/// </summary>
namespace HackerRankSolutions.ClimbingTheLeaderboard
{
    public static class ClimbingTheLeaderboard
    {
        /// <summary>
        /// Calculate's Alice's running rank at each level (see prompt).
        /// Time-complexity is O(m+n) where m is the number of scores on the
        /// leaderboard and n is the number of scores for Alice's levels.
        /// </summary>
        /// <param name="scores">Monotonically decreasing scores of leaderboard</param>
        /// <param name="alice">Alice's scores as she "levels up"</param>
        /// <returns></returns>
        public static IEnumerable<int> HistoricalRanks(int[] scores, int[] alice)
        {
            var dscores = scores.Reverse().Distinct();
            var qscores = new Queue<int>(dscores);
            foreach(int s in alice)
            {
                for(; qscores.Count > 0 && s >= qscores.Peek(); qscores.Dequeue());
                yield return qscores.Count + 1;
            }
        }
    }
}

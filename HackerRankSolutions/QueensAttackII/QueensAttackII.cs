using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.QueensAttackII
{
    /// <summary>
    /// Provides a solution for https://www.hackerrank.com/challenges/queens-attack-2
    /// </summary>
    public class QueensAttackII
    {
        public static int Solve(int n, Tuple<int, int> queen, IEnumerable<Tuple<int, int>> obstacles)
        {
            var obstacleSet = new HashSet<Tuple<int, int>>(obstacles);
            int moves = 0;
            for(int dx = -1; dx <= 1; ++dx)
            {
                for(int dy = -1; dy <= 1; ++dy)
                {
                    if((dx | dy) == 0)
                        continue;
                    for(int x = queen.Item2 + dx, y = queen.Item1 + dy;
                        x >= 1 && x <= n && y >= 1 && y <= n && !obstacleSet.Contains(new Tuple<int, int>(y, x));
                        x += dx, y += dy, ++moves) ;
                }
            }               
            return moves;
        }
    }
}

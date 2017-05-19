using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.WeekOfCode32.GeometricTrick
{
    public static class GeometricTrick
    {
        public static readonly char[] Letters = { 'a', 'b', 'c' };

        public static int Solve(string s)
        {
            var range = Enumerable.Range(1, s.Length);
            Dictionary<ulong, int> squareRoots = range.ToDictionary(i => (ulong)i * (ulong)i, i => i);
            int count = 0;
            foreach(ulong square in squareRoots.Keys)
            {
                var multipliers = Multipliers(square, (ulong)s.Length);
                foreach(Tuple<int, int> pair in multipliers)
                {
                    int i = pair.Item1, k = pair.Item2, j = squareRoots[square];
                    char[] p1 = new char[] { s[i - 1], s[j - 1], s[k - 1] };
                    char[] p2 = new char[] { s[k - 1], s[j - 1], s[i - 1] };
                    if(p1.SequenceEqual(Letters) || p2.SequenceEqual(Letters))
                    {
                        ++count;
                    }
                }
            }
            return count;
        }

        public static IEnumerable<Tuple<int, int>> Multipliers(ulong m, ulong limit)
        {
            ulong i = 1;
            ulong lastVal = limit;
            for(; i <= lastVal; i++)
            {
                if(m % i == 0)
                {
                    lastVal = m / i;
                    if(lastVal <= limit)
                    {
                        yield return Tuple.Create((int)i, (int)lastVal);
                    }
                }
            }
        }
    }
}

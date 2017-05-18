using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.WeekOfCode32.CircularWalk
{
    public static class CircularWalk
    {
        public static long Solve(long n, long s, long t, long R0, long g, long seed, long p)
        {
            long[] R = GetR(n, R0, g, seed, p);
            long d;
            return ((d = ShortestDistance(R, s, t)) < long.MaxValue ? d : -1);
        }


        private static long ShortestDistance(long[] R, long start, long end)
        {
            long[] d = new long[R.Length];
            for(long i = 0; i < (long)d.Length; ++i)
                d[i] = long.MaxValue;
            d[start] = 0;
            Queue<long> q = new Queue<long>();
            q.Enqueue(start);
            HashSet<long> visited = new HashSet<long>();
            while(q.Count > 0)
            {
                long cur = q.Dequeue();
                if(cur == end)
                {
                    return d[cur];
                }
                IEnumerable<long> nexts = GetNexts(R, cur);
                foreach(long child in nexts)
                {
                    long distFromCur = d[cur] + 1;
                    if(distFromCur < d[child])
                    {
                        d[child] = distFromCur;
                    }
                    if(!visited.Contains(child))
                    {
                        q.Enqueue(child);
                    }
                    visited.Add(child);
                }
            }
            return long.MaxValue;
        }

        private static long[] GetR(long n, long R0, long g, long seed, long p)
        {
            long[] R = new long[n];
            R[0] = R0;
            for(long i = 1; i < (long)R.Length; ++i)
            {
                R[i] = (R[i - 1] * g + seed) % p;
            }
            return R;
        }

        private static IEnumerable<long> GetNexts(long[] R, long i)
        {
            for(long j = 1; j <= R[i]; ++j)
            {
                long p1 = (i + j) % (long)R.Length;
                yield return p1;

                long x;
                long p2 = (x = (i - j) % (long)R.Length) >= 0 ? x : (long)R.Length - ((long)R.Length - x) % (long)R.Length;
                yield return p2;
            }
        }
    }
}

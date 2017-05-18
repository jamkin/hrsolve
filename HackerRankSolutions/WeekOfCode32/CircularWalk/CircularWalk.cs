using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.WeekOfCode32.CircularWalk
{
    public static class CircularWalk
    {
        public static int Solve(int n, int s, int t, int R0, int g, int seed, int p)
        {
            int[] R = GetR(n, R0, g, seed, p);
            int d;
            return (d = ShortestDistance(R, s, t)) < int.MaxValue ? d : -1;
        }


        private static int ShortestDistance(int[] R, int start, int end)
        {
            //int[] d = Enumerable.Repeat(int.MaxValue, R.Length).ToArray();
            int[] d = new int[R.Length];
            for(int i = 0; i < d.Length; ++i)
                d[i] = int.MaxValue;
            d[start] = 0;
            Queue<int> q = new Queue<int>();
            q.Enqueue(start);
            HashSet<int> visited = new HashSet<int>();
            while(q.Count > 0)
            {
                int cur = q.Dequeue();
                if(cur == end)
                {
                    return d[cur];
                }
                IEnumerable<int> nexts = GetNexts(R, cur);
                foreach(int child in nexts)
                {
                    int distFromCur = d[cur] + 1;
                    if(distFromCur < d[child])
                    {
                        d[child] = distFromCur;

                    }
                    if(!visited.Contains(child))
                    {
                        q.Enqueue(child);
                    }
                }
                visited.Add(cur);
            }
            return int.MaxValue;
        }

        private static int[] GetR(int n, int R0, int g, int seed, int p)
        {
            int[] R = new int[n];
            R[0] = R0;
            for(int i = 1; i < R.Length; ++i)
            {
                R[i] = (R[i - 1] * g + seed) % p;
            }
            return R;
        }

        private static IEnumerable<int> GetNexts(int[] R, int i)
        {
            for(int j = 1; j <= R[i]; ++j)
            {
                int p1 = (i + j) % R.Length;
                yield return p1;

                int x;
                int p2 = (x = (i - j) % R.Length) >= 0 ? x : R.Length - (R.Length - x) % R.Length;
                yield return p2;
            }
        }
    }
}

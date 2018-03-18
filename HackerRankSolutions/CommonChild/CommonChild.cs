using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.CommonChild
{
    /// <summary>
    /// Provides a solution to the Common Child string problem
    /// https://www.hackerrank.com/challenges/common-child/problem
    /// </summary>
    public static class CommonChild
    {
        public static int Solve(string first, string second)
        {
            int max = 0;
            for (int i = 0; i < first.Length; ++i)
            {
                int current = 0;
                for (int j = i, k = 0; j < first.Length; ++j)
                {
                    int m = k;
                    bool found = false;
                    for (; k < second.Length && !found; ++k)
                    {
                        if (first[j] == second[k])
                        {
                            current += 1;
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        k = m;
                    }
                }
                if (current > max)
                {
                    max = current;
                }
            }
            return max;
        }
    }
}

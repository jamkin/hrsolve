using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.HackerRankInAString
{
    public static class HackerRankInAString
    {
        public const string Target = "hackerrank";

        public static string Solve(string s)
        {
            int j = 0;
            for(int i = 0; i < s.Length && j < Target.Length; ++i)
            {
                if(s[i] == Target[j])
                {
                    ++j;
                }
            }
            return j == Target.Length ? "YES" : "NO";
        }
    }
}

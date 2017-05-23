using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.MarcsCakewalk
{
    public static class MarcsCakewalk
    {
        public static ulong Solve(int[] c)
        {
            int[] r = c.OrderByDescending(i => i).ToArray();
            ulong miles = 0, pow = 1;
            for(int k = 0; k < r.Length; ++k, pow *= 2) 
            {
                miles += (ulong)r[k] * pow;
            }
            return miles;
        }
    }
}

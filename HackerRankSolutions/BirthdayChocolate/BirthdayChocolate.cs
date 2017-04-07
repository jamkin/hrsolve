using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.BirthdayChocolate
{
    /// <summary>
    /// Provides a solution to https://www.hackerrank.com/challenges/the-birthday-bar?h_r=next-challenge&h_v=zen
    /// </summary>
    public static class BirthdayChocolate
    {
        public static int PossibleChocolateBreaks(int m, int d, int[] chocs)
        {
            if (m > chocs.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            Queue<int> section = new Queue<int>(chocs.Take(m));
            int sum = section.Sum();
            int count = sum == d ? 1 : 0;
            for(int i = m; i < chocs.Length; ++i)
            {
                sum -= section.Dequeue();
                sum += chocs[i];
                section.Enqueue(chocs[i]);
                if(sum == d)
                    ++count;
            }
            return count;
        }
    }
}

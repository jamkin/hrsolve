using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRankSolutions.SeparateTheNumbers
{
    /// <summary>
    /// Provides a solution for the "Separate the Numbers" problem on HackerRank
    /// https://www.hackerrank.com/challenges/separate-the-numbers/problem
    /// </summary>
    public static class SeparateTheNumbers
    {
        /// <remarks>
        /// Does not validate input
        /// </remarks>
        public static bool Solve(string input, out string first)
        {
            first = null;

            if (input[0] == '0')
            {
                return false;
            }

            for (int i = 1; i < input.Length / 2 + 1; ++i)
            {       
                if (input[i] == '0')
                {
                    continue;
                }
                string num = input.Substring(0, i);
                bool separated = true;
                for (int j = i; j < input.Length; j += num.Length)
                {
                    num = (ulong.Parse(num) + 1).ToString();
                    if ((j + num.Length) > input.Length || !input.Substring(j, num.Length).Equals(num))
                    {
                        separated = false;
                        break;
                    }
                }
                if (separated)
                {
                    first = input.Substring(0, i);
                    return true;
                }
            }
            return false;
        }
    }
}

using System;

namespace HackerRankSolutions.BreakingTheRecords
{
    /// <summary>
    /// Provides an O(n) solution to https://www.hackerrank.com/challenges/breaking-best-and-worst-records
    /// </summary>
    public static class BreakingTheRecords
    {
        public static void BrokenRecordFrequencies(int[] scores, out int bads, out int goods)
        {
            if(scores.Length == 0)
            {
                throw new ArgumentException(nameof(scores));
            }
            bads = goods = 0;
            for(int i = 1, low = scores[0], high = scores[0]; i < scores.Length; ++i)
            {
                if(scores[i] < low)
                {
                    low = scores[i];
                    ++bads;
                }
                if(scores[i] > high)
                {
                    high = scores[i];
                    ++goods;
                }
            }
        }
    }
}

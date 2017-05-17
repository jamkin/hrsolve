using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.WeightedUniformStrings
{
    /// <summary>
    /// Provides a solution to https://www.hackerrank.com/challenges/weighted-uniform-string
    /// Runtime of the use case is O(n) where is the length of the string
    /// </summary>
    public class WeightedUniformStrings
    {
        private HashSet<int> UniformWeights = new HashSet<int>();

        public WeightedUniformStrings(string s)
        {
            CacheUniformWeights(s);
        }

        private static IEnumerable<string> UniformSubstrings(string s)
        {
            for(int i = 0, j = 0; i < s.Length; i = j)
            {
                for(; j < s.Length && s[j] == s[i]; ++j)
                    yield return s.Substring(i, j - i + 1);
            }
        }

        private void CacheUniformWeights(string s)
        {
            var uniformSubstrings = UniformSubstrings(s);
            foreach(string substring in uniformSubstrings)
            {
                int weight = CalculateWeight(substring);
                UniformWeights.Add(weight);
            }
        }

        /// <summary>
        /// Weight query
        /// </summary>
        public bool HasUniformWeight(int w) => UniformWeights.Contains(w);

        private static int CalculateWeight(string uni) => ((int)(uni[0] - 'a') + 1) * uni.Length;
    }
}

using System;
using System.Collections.Generic;

namespace HackerRankSolutions.RunningMedian
{
    /// <summary>
    /// Contains the methods that solve "Find the Running Median" problem of HackerRank. 
    /// See: https://www.hackerrank.com/challenges/find-the-running-median.
    /// </summary>
    public static class RunningMedian
    {
        /// <summary>
        /// Evaluates the running median of a stream of ints. 
        /// Time-Complexity: O(n*log(n)) where n is input.Length in the Evaluate method below.
        /// </summary>
        /// <param name="input">Array of ints whose current median we calculate by expanding a sub array from the left.</param>
        /// <returns>Median at each point in the array expansion.</returns>
        public static double[] Evaluate(int[] input)
        {
            if(input.Length == 0)
            {
                throw new ArgumentException(nameof(input));
            }
            double[] result = new double[input.Length];
            List<int> slist = new List<int>(capacity: input.Length);
            for(int i = 0; i < input.Length; ++i)
            {
                slist.BinaryInsertion(input[i]);
                int m = slist.Count / 2;
                result[i] = (slist.Count & 1) == 1 
                    ? (double)slist[m] 
                    : (double)(slist[m] + slist[m - 1]) / 2.0;
            }
            return result;
        }
    }

    public static class Extensions
    {
        /// <summary>
        /// Extension method for O(log(n)) insertion of an element into a sorted list.
        /// </summary>
        /// <param name="list">List of ints in ascending order.</param>
        /// <param name="val">Value to insert.</param>
        public static void BinaryInsertion(this List<int> list, int val)
        {
            // Handle edge case
            if(list.Count == 0)
            {
                list.Insert(0, val);
                return;
            }
            // Divide and conquer
            int i = 0, k = list.Count - 1;
            for(int j = list.Count / 2; (i + 1) < k; j = (i + k) / 2)
            {
                if(val < list[j])
                    k = j;
                else
                    i = j;
            }
            list.Insert(val <= list[i] ? i : (val <= list[k] ? k : k + 1), val);
        }
    }
}

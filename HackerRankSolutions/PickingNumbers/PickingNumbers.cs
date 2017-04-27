using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Provides a solution to the Picking Numbers problem
/// https://www.hackerrank.com/challenges/picking-numbers?h_r=next-challenge&h_v=zen
/// </summary>
namespace HackerRankSolutions.PickingNumbers
{
    public static class PickingNumbers
    {
        /// <summary>
        /// O(n) algorithm for finding the largest subarray such that any 2
        /// elements are less than or equal to distance 1 from each other.
        /// Validates input.
        /// </summary>
        public static int Solve(int[] arr)
        {
            if(arr.Length < 2 || arr.Length > 100)
                throw new ArgumentException(nameof(arr));

            // Store the counts of each numbers: 
            // counts[i - 1] is the count of i
            int[] counts = new int[99];
            for(int i = 0; i < arr.Length; ++i)
            {
                if(arr[i] <= 0 || arr[i] >= 100)
                    throw new ArgumentException($"arr[{i}]");
                ++counts[arr[i] - 1];            
            }
            // Find the maximum combined counts of number i and i + 1. 
            // This is easy with our lookup array.
            int max = 0;
            for(int i = 1; i < counts.Length; ++i)
            {
                int sum = counts[i - 1] + counts[i];   
                if(sum > max)
                {
                    max = sum;
                }
            } 
            return max;
        }
    }
}

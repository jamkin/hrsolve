using System;

namespace HackerRankSolutions.MinimumAbsoluteDifference
{
    public static class MinimumAbsoluteDifference
    {
        public static int Solve(int[] arr)
        {
            if(arr.Length < 2)
            {
                throw new ArgumentException("Array must have at least 2 elements");
            }
            Array.Sort(arr);
            int min = int.MaxValue;
            for(int i = 0, j = 1; j < arr.Length; ++i, ++j)
            {
                int diff = Math.Abs(arr[i] - arr[j]);
                if(diff < min)
                {
                    min = diff;
                }
            }
            return min;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.NonDivisibleSubset
{
    public static class NonDivisibleSubset
    {
        #region longExplanation
        /*
            Let arr = { 1, 6, 4, 3, 8, 10, 7, 20, 0, 11, 76, 14, 49 }, k = 7

            By the fact that (a + b) % n = (a % n + b % n) % n, the largest subarray of arr
            such that no pairs are divisible by k=7 is equivalent to the largest subarray of 

            T  = { 1 % 7, 6 % 7, 4 % 7, 3 % 7, 8 % 7, 10 % 7, 7 % 7, 20 % 7, 0 % 7, 11 % 7, 76 % 7, 14 % 7, 49 % 7 }
               = {   1,    6,      4,     3,     1,      3,     0,      6,     0,      4,      6,      0,      7   }

            such that no pairs sum to k or 0.

            In O(N) time we can determine that all such pairs are 

            { {1, 6}, {4, 3}, {1, 6}, {4, 3}, {1, 6}, {3, 4}, {0, 0}, {0, 0} }

            and uniquely are 

            P = { {1, 6}, {4, 3}, {0, 0} }

            The counts of elements in the transformed array T are

            [0] -> 3
            [1] -> 2
            [3] -> 2
            [6] -> 3
            [0] -> 2
            [4] -> 2

            which we can also find in O(N) time.
            
            Recall that what we're trying to do is remove as many elements as we can from T so that
            none of the pairs in P exist in T. Therefore, for each pair in P, we will have to remove
            all occurences of one of the elements, and we want to remove the element that has a lower
            frequency in T.

            For the pair {1, 6}, since the count of 1 is less than the count of 6, we want to remove
            all 1s so we have

            T = { 6, 4, 3, 3, 0, 6, 0, 4, 6, 0 }

            For the pair {4, 3}, since the count of 4 is the same as the count of 3, we can choose
            arbitrarily to remove all the 4s, so we have

            T = { 6, 3, 3, 0, 6, 0, 6, 0 }

            Now we need to deal with the last pair, {0, 0}. For any pair having equal elements (the other
            time this can happen is if k is even and the pair values are each k/2) we need to remove all 
            but one occurence of the number. Since the count of 0 is 3, that means removing 2 of them,
            leaving us with 

            T = { 6, 3, 3, 0, 6, 6 }

            which is of size 6, the answer.

            Note that for the previous steps of "removing elements from T", since all we're interested
            in is the count of remaining elements, we don't have to remove any elements.

            The algorithm is implemented below.
        */
        #endregion
        /// <summary>
        /// Finds the size of the maximum subset having every
        /// pair of numbers' sum not divisible by k.
        /// Time-complexity: O(n)
        /// </summary>
        /// <param name="arr">Assummed to contain unique elements</param>
        public static int GetMaxSize(int[] arr, int k)
        {
            int[] R = new int[k]; // counts of remainders
            for(int i = 0; i < arr.Length; ++i)
                ++R[arr[i] % k];

            var bads = new List<Tuple<int, int>>(); // pairs of remainders that sum to k

            for(int i = 1, j = k - 1; i <= j; ++i, --j)
            {
                if(R[i] > 0 && R[j] > 0)
                {
                    bads.Add(Tuple.Create(i, j));
                }
            }

            // also add zero-valued pairs to the list of bads
            if(R[0] > 1)
                bads.Add(Tuple.Create(0, 0));

            // Count the number of items left after removing pairs that need removed
            int count = arr.Length;
            foreach (var pair in bads)
            {
                if(pair.Item1 == pair.Item2)
                    count -= R[pair.Item1] - 1;
                else if(R[pair.Item1] < R[pair.Item2])
                    count -= R[pair.Item1];
                else
                    count -= R[pair.Item2];
            }
            return count;
        }
    }
}

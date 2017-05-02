using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions
{
    /// <summary>
    /// Utility class to use in solutions and unit testing.
    /// </summary>
    public static class Algorithm
    {
        /// <summary>
        /// Iterative algorithm to yield all combinations of a specified size from a collection source. For example, if
        /// source = { 1, 2, 3, 4 }
        /// and 
        /// size = 2
        /// then the combinations yielded are
        /// { 1, 1 }
        /// { 1, 2 }
        /// { 1, 3 }
        /// { 1, 4 }
        /// { 2, 1 }
        /// { 2, 2 }
        /// { 2, 3 }
        /// { 2, 4 }
        /// { 3, 1 }
        /// { 3, 2 }
        /// { 3, 3 }
        /// { 3, 4 }
        /// { 4, 1 }
        /// { 4, 2 }
        /// { 4, 3 }
        /// { 4, 4 }.
        /// The complexity is O(n^s) where n is the size of the source and s is the size of the combinations.
        /// </summary>
        public static IEnumerable<IEnumerable<T>> CombinationsOfSize<T>(this IEnumerable<T> source, int size)
        {
            if(size < 0)
                throw new ArgumentException(nameof(source));
            if(size == 0)
                yield break;
            IEnumerable<List<T>> ones = source.Select(t => new List<T>() { t });
            var combos = new List<IEnumerable<T>>(ones);
            for(int i = 2; i <= size; ++i)
            {
                var nexts = new List<IEnumerable<T>>();
                foreach(IEnumerable<T> sub in combos)
                {
                    foreach(T element in source)
                    {
                        var addition = sub.Concat(new List<T>() { element });
                        nexts.Add(addition);
                    }
                }
                combos = nexts;
            }
            foreach(var item in combos)
                yield return item;
        }

        /// <summary>
        /// Yields all subcollections of a source collection. In other words, all subsets of a set
        /// if we're considering the source set to not necessarily be unique elements (as the typical
        /// definition of a set would assume). 
        /// For example, if the source is { 1, 2, 3 } then the results yielded are
        /// {  },
        /// { 1 }, 
        /// { 2 }, 
        /// { 3 },
        /// { 1, 2 },
        /// { 2, 3 },
        /// { 1, 3 },
        /// { 1, 2, 3 }
        /// The time-complexity is O(2^n) where n is the size of the source.
        /// </summary
        public static IEnumerable<IEnumerable<T>> AllSubcollections<T>(this IEnumerable<T> source)
        {
            // The empty set is always a subcollection
            yield return new List<T>() { };
                     
            T[] arr = source.ToArray();
            IEnumerable<int> indices = Enumerable.Range(0, arr.Length);
            var last = new List<HashSet<int>>(new List<HashSet<int>>() { new HashSet<int>() });
            for(int k = 1; k < arr.Length; ++k)
            {
                var next = new List<HashSet<int>>(new List<HashSet<int>>());
                foreach(HashSet<int> hs in last)
                {
                    foreach(int index in indices)
                    {
                        if(!hs.Contains(index))
                        {
                            var addition = hs.Concat(new List<int> { index });
                            yield return addition.Select(i => arr[i]);
                            next.Add(new HashSet<int>(addition));
                        }
                    }
                }
            }
        }

        public static byte[] GetDigits(this ulong n)
        {
            List<byte> digits = new List<byte>();
            for(; n != 0; n /= 10)
            {
                ulong r = n % 10;
                byte b = Convert.ToByte(r);
                digits.Add(b);
            }
            byte[] arr = digits.ToArray();
            Array.Reverse(arr);
            return arr;
        }
    }
}

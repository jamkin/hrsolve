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
        /// Yields all contiguous subarrays of a given array. 
        /// Ex. { 1, 5, 2 } -> { {1}, {5}, {2}, {1, 5}, {5, 2}, {1, 5, 2} }
        /// </summary>
        public static IEnumerable<T[]> ContiguousSubarrays<T>(this T[] source)
        {
            for(int len = 1; len <= source.Length; ++len)
            {
                for(int i = 0, j = source.Length - len + 1; i < j; ++i)
                {
                    T[] result = new T[len];
                    for(int k = 0; k < len; ++k)
                    {
                        result[k] = source[k + i];
                    }
                    yield return result;
                }
            }
        }

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
            T[] arr = source.ToArray();
            if(arr.Length == 0)
            {
                yield return new List<T>() { };
                yield break;
            }
            IEnumerable<IEnumerable<bool>> flagSets = new bool[] { false, true }.CombinationsOfSize(arr.Length);
            foreach(IEnumerable<bool> fs in flagSets)
            {
                yield return fs.Select((flag, index) => new { flag, index })
                    .Where(x => x.flag)
                    .Select(x => arr[x.index]);
            }
        }

        /// <summary>
        /// Yields in linear time all pairs of numbers that sum to n. 
        /// </summary>
        public static IEnumerable<Tuple<int, int>> PairsSumToN(this IEnumerable<int> source, int n)
        {
            var counts = new Dictionary<int, int>();
            foreach(int i in source)
            {
                int j = n - i;
                if(counts.ContainsKey(j))
                {
                    for(int count = 0; count < counts[j]; ++count)
                        yield return Tuple.Create(i, j);
                }
                counts[i] = counts.ContainsKey(i) ? counts[i] + 1 : 1;
            }
        }

        /// <summary>
        /// Gets all digits of a positive whole number.
        /// Time-complexity: O(n) 
        /// </summary>
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

        /// <summary>
        /// Given a collection of collections, yields every collection that uses 1 element from each source collection.
        /// Example: 
        /// 
        /// { { 1, 2 }, { 3 }, { 4, 5, 6 } }
        /// -----> 
        /// {
        ///     { 1, 3, 4 },
        ///     { 1, 3, 5 },
        ///     { 1, 3, 6 },
        ///     { 2, 3, 4 },
        ///     { 2, 3, 5 },
        ///     { 2, 3, 6 }
        /// }
        /// 
        /// Time-complexity: O(N_0***N_m) where N_k is the number of elements in collection k
        /// </summary>
        public static IEnumerable<IEnumerable<T>> OneFromEach<T>(this IEnumerable<IEnumerable<T>> vals)
        {
            var arr = vals.ToArray();
            if(arr.Length == 0)
                yield break;
            var accum = new Queue<IEnumerable<T>>();
            foreach(T item in vals.First())
                accum.Enqueue(new List<T>() { item });
            for(int i = 1; i < arr.Length; ++i)
            {
                IEnumerable<T> inner = arr[i];
                if(inner.Count() == 0)
                {
                    continue;
                }
                for(int j = 0, n = accum.Count(); j < n; ++j)
                {
                    IEnumerable<T> cur = accum.Dequeue();
                    foreach(T item in inner)
                    {
                        accum.Enqueue(cur.Concat(new List<T> { item }));
                    }
                }
            }
            foreach(IEnumerable<T> collection in accum)
                yield return collection;
        }
    }
}

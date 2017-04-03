using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace HackerRankSolutions.RunningMedian
{
    [TestClass]
    public class RunningMedian_Test
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyInput()
        {
            RunningMedian.Evaluate(new int[] { });
        }

        [TestMethod]
        public void SampleInput()
        {
            int[] input = { 12, 4, 5, 3, 8, 7 };
            double[] expectedOutput = { 12.0, 8.0, 5.0, 4.5, 5.0, 6.0 };
            double[] actualOutput = RunningMedian.Evaluate(input);
            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void SingleElement()
        {
            int[] input = { 3 };
            double[] expectedOutput = { 3.0 };
            double[] actualOutput = RunningMedian.Evaluate(input);
            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TwoElements()
        {
            int[] input = { 1, 2 };
            double[] expectedOutput = { 1.0, 1.5 };
            double[] actualOutput = RunningMedian.Evaluate(input);
            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void SameResultsAsBruteForce()
        {
            var rand = new Random();
            for(int t = 0; t < 1000; ++t)
            {
                int len = rand.Next() % 100 + 1;
                int[] input = new int[len];
                for(int i = 0; i < len; ++i)
                {
                    input[i] = rand.Next();
                }
                double[] brute = BruteForce(input).ToArray();
                double[] actual = RunningMedian.Evaluate(input);
                CollectionAssert.AreEqual(brute, actual);
            }
        }

        private static IEnumerable<double> BruteForce(int[] input)
        {
            List<int> slist = new List<int>();
            foreach(int i in input)
            {
                slist.InsertInOrder(i);
                int med = slist.Count / 2; ;
                yield return slist.Count % 2 == 1
                    ? (double)slist[med]
                    : (double)(slist[med] + slist[med - 1]) / 2.0;
            }
        }
    }

    static class RunningMedian_Test_Extensions
    {
        public static void InsertInOrder(this List<int> list, int val)
        {
            int i = 0;
            for(; i < list.Count && list[i] <= val; ++i);
            list.Insert(i, val);
        }
    }
}

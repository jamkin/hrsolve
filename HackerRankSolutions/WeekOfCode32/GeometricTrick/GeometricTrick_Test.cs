using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace HackerRankSolutions.WeekOfCode32.GeometricTrick
{
    [TestClass]
    public class GeometricTrick_Test
    {
        [TestMethod]
        public void EmptyInput()
        {
            Assert.AreEqual(0, GeometricTrick.Solve(string.Empty));
        }

        [TestMethod]
        public void SampleInput()
        {
            Assert.AreEqual(2, GeometricTrick.Solve("ccaccbbbaccccca"));
        }

        [TestMethod]
        public void NotEmptyButTooSmal()
        {
            Assert.AreEqual(0, GeometricTrick.Solve("ac"));
        }

        [TestMethod]
        public void AllThreeLettersNoMore()
        {
            Assert.AreEqual(0, GeometricTrick.Solve("abc"));
        }

        [TestMethod]
        public void MiscTest_2()
        {
            Assert.AreEqual(35, GeometricTrick.Solve("aaaaaaaaaabbbbbbbbbbccccccccccaaaaaaaaaabbbbbbbbbbccccccccccaaaaaaaaaabbbbbbbbbbccccccccccaaaaaaaaaabbbbbbbbbbccccccccccaaaaaaaaaabbbbbbbbbbccccccccccaaaaaaaaaabbbbbbbbbbccccccccccaaaaaaaaaabbbbbbbbbbccccccccccaaaaaaaaaabbbbbbbbbbccccccccccaaaaaaaaaabbbbbbbbbbccccccccccaaaaaaaaaabbbbbbbbbbccccccccccaaaaaaaaaabbbbbbbbbbccccccccccaaaaaaaaaabbbbbbbbbbcccccccccc"));
        }

        [TestMethod]
        public void OneOccurrenceWithinLargeString()
        {
            char[] ch = Enumerable.Repeat('c', 100).ToArray();
            ch[1] = 'a';
            ch[17] = 'b';
            string s = new string(ch);
            Assert.AreEqual(1, GeometricTrick.Solve(s));
        }

        [TestMethod]
        [Ignore]
        public void MiscLargestStringPossibleTest()
        {
            string s = new string(Enumerable.Repeat('a', (int)5e5 + 1).ToArray());
            GeometricTrick.Solve(s);
        }

        [TestMethod]
        [Ignore]
        public void RandomValidStringsDoesntErrorOut()
        {
            for(int t = 0; t < 100; ++t)
            {
                string s = GenerateString();
                GeometricTrick.Solve(s);
            }
        }

        [TestMethod]
        public void CompareAgainstBruteForce()
        {
            for(int t = 0; t < 1000; ++t)
            {
                string s = GenerateString(100);
                int brute = Brute(s);
                int algo = GeometricTrick.Solve(s);
                Assert.AreEqual(brute, algo);
            }
        }

        private static int Brute(string s)
        {
            var charIndexPairs = s.Select((c, i) => new { C = c, J = i + 1 });
            return (
                from x in charIndexPairs
                from y in charIndexPairs
                from z in charIndexPairs
                where (x.J * y.J == z.J * z.J)
                    && new char[] { x.C, z.C, y.C }.SequenceEqual("abc")
                select 1
            ).Count();
        }

        private static char[] StringCharacters = { 'a', 'b', 'c' };

        private static string GenerateString(int maxSize = (int)5e5 + 1)
        {
            Random r = new Random();
            int n = r.Next(1, maxSize);
            char[] ch = new char[n];
            for(int i = 0; i < n; ++i)
                ch[i] = StringCharacters[r.Next(0, StringCharacters.Length)];
            return new string(ch);
        }
    }
}

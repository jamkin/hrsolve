using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace HackerRankSolutions.WeekOfCode32.Duplication
{
    [TestClass]
    public class Duplication_Test
    {
        [TestMethod]
        public void SizeCheck()
        {
            Assert.AreEqual(Duplication.Size, Duplication.Bits.Length);
        }

        [TestMethod]
        public void SimpleElementCheck()
        {
            // 0110100110010110...
            Assert.AreEqual(0, Duplication.Bits[0]);
            Assert.AreEqual(1, Duplication.Bits[1]);
            Assert.AreEqual(1, Duplication.Bits[2]);
            Assert.AreEqual(0, Duplication.Bits[3]);
            Assert.AreEqual(1, Duplication.Bits[4]);
            Assert.AreEqual(0, Duplication.Bits[5]);
            Assert.AreEqual(0, Duplication.Bits[6]);
            Assert.AreEqual(1, Duplication.Bits[7]);
        }

        [TestMethod]
        public void CompareToAlt()
        {
            byte[] alt = BuildAlternatively();
            CollectionAssert.AreEqual(alt, Duplication.Bits);
        }

        private static byte[] BuildAlternatively()
        {
            byte[] accum = { 0 };
            while(accum.Length <= 1000)
            {
                IEnumerable<byte> next = accum.Select(b => (byte)(1 - b));
                accum = accum.Concat(next).ToArray();
            }
            return accum;
        }
    }
}

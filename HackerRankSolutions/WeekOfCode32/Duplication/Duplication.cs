using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.WeekOfCode32.Duplication
{
    /// <summary>
    // Provides a solution to https://www.hackerrank.com/contests/w32/challenges/duplication
    /// </summary>
    public static class Duplication
    {
        public const int Size = 1024;

        private static byte[] _bits;

        public static byte[] Bits
        {
            get
            {
                if(_bits == null)
                    SetBits();
                return _bits;
            }
            private set
            {
                _bits = value;
            }
        }

        /// <summary>
        /// Generates the byte array 0110100110010110... described in the prompt.
        /// </summary>
        private static void SetBits()
        {
            _bits = new byte[Size];
            _bits[0] = 0;
            for(int i = 1, j = 2; j <= _bits.Length; i <<= 1, j <<= 1)
            {
                for(int k = i; k < j; ++k)
                {
                    _bits[k] = (byte)(1 - _bits[k - i]);
                }
            }
        }
    }
}

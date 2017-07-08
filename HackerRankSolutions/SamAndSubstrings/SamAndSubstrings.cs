using System;

namespace HackerRankSolutions.SamAndSubstrings
{
    public static class SamAndSubstrings
    {
        private const ulong divisor = 1000000007ul;

        /*
            Algorithm explanation: 

            Let s = "2394", as an example. 
    
            Define B[i] = s.Substring(i,1) + s.Substring(i - 1, 2) + ... +  s.Substring(0, i + 1)

            That is, 

            B[0] = 2
            B[1] = 3 + 23
            B[2] = 9 + 39 + 239
            B[3] = 4 + 94 + 394 + 2394

            We can also write B in terms of itself, like

            B[i] = B[i - 1] * 10 + (i + 1) * s[i]

            Define T[i] = the solution over s.Substring(0, i)

            That is, 

            T[0] = 2
            T[1] = 23 + 2 + 3
            T[2] = 239 + 23 + 39 + 3 + 9 + 2
            T[3] = 2394 + 239 + 394 + 23 + 39 + 94 + 2 + 3 + 9 + 4

            We can also write T in terms of itself and B, like

            T[0] = B[0],
            T[i] = T[i - 1] + B[i]

            Therefore we can find the solution T[s.Length - 1] iteratively.

            (Note that we also have to deal with modding the result)
        */
        public static ulong Solve(string s)
        {
            if(s.Length == 0)
            {
                throw new ArgumentException(s);
            }
            ulong T = GetDigit(s[0]);
            ulong B = T;
            for(int i = 1; i < s.Length; ++i)
            {
                B = B * 10ul + (ulong)(i + 1) * GetDigit(s[i]);
                B %= divisor;
                T += B;
            }
            return T % divisor;
        }

        private static ulong GetDigit(char c) => (ulong)(c - '0');
    }
}

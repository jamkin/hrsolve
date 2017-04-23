using System;

namespace HackerRankSolutions.CatsAndMouse
{
    /// <summary>
    /// Provides a solution to the "Cat and a Mouse" problem https://www.hackerrank.com/contests/hourrank-15/challenges/cats-and-a-mouse
    /// </summary>
    public static class CatsAndMouse
    {
        public static string Catcher(int x, int y, int z)
        {
            int d1 = Math.Abs(x - z),
                d2 = Math.Abs(y - z);
            return d1 < d2
                ? "Cat A"
                :
                (
                    d1 == d2
                    ? "Mouse C"
                    : "Cat B"
                );
        }
    }
}

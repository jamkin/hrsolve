using System;

namespace HackerRankSolutions.CatsAndMouse
{
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

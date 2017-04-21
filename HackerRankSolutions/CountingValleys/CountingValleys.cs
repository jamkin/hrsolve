namespace HackerRankSolutions.CountingValleys
{
    /// <summary>
    /// Provides a solution to https://www.hackerrank.com/challenges/counting-valleys
    /// </summary>
    public static class CountingValleys
    {
        /// <summary>
        /// O(n) algorithm for generating the output of the problem. Assumes valid input.
        /// </summary>
        /// <param name="steps">Character array of 'U' and 'V'</param>
        /// <returns>Number of "valleys" as defined in prompt</returns>
        public static int Solve(char[] steps)
        {
            int count = 0, net = 0;
            for(int i = 0; i < steps.Length; ++i)
            {
                int last = net;
                net += steps[i] == 'U' ? 1 : -1;
                if(net == 0 && last < 0)
                {
                    ++count;
                }
            }
            return count;
        }
    }
}

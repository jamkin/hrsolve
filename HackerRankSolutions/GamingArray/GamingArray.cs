using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.GamingArray
{
    /// <summary>
    /// Provides solution to Gamer Array problem on HackerRank.
    /// See https://www.hackerrank.com/challenges/an-interesting-game-1.
    /// </summary>
    public static class GamingArray
    {
        public const string PlayerOne = "BOB";

        public const string PlayerTwo = "ANDY";

        public static string WhoWins(int[] board) => CurrentPlayerWins(board) ? PlayerOne : PlayerTwo;

        /// <summary>
        /// O(n^2) solution
        /// </summary>
        /// <param name="board">Board setup on current player's turn</param>
        /// <returns>Whether the current player wins</returns>
        private static bool CurrentPlayerWins(int[] board)
        {
            if(board.Length == 0)
                return false;
            int maxIndex = Array.IndexOf(board, board.Max());
            board = board.Take(maxIndex).ToArray();
            return !CurrentPlayerWins(board);
        }
    }
}

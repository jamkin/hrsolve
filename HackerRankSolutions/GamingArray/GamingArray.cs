using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.GamingArray
{
    public enum Player { BOB, ANDY };

    /// <summary>
    /// Provides solution to Gamer Array problem on HackerRank.
    /// See https://www.hackerrank.com/challenges/an-interesting-game-1.
    /// </summary>
    public static class GamingArray
    {
        /// <summary>
        /// Prints name of winner based on starting board
        /// </summary>
        public static string WhoWins(int[] board) => FindWinner(board).ToString();

        /// <summary>
        /// Gets the winner based on starting board.
        /// 
        /// Algorithm:
        /// 
        /// Set pointer at the end of the array and keep jumping it leftwards to
        /// the index of the max element between the beginning and the pointer
        /// inclusive. We determine the winner based on the number of jumps we did.
        /// 
        /// Time-complexity: O(n) where n = board.Length.
        /// </summary>
        private static Player FindWinner(int[] board)
        {
            int[] maxes = RunningMaxIndices(board);
            int switches = 0;
            for(int j = board.Length - 1; 0 <= j; j = maxes[j] - 1, switches += 1) ;
            return (switches & 1) == 1 ? Player.BOB : Player.ANDY;
        }

        /// <summary>
        /// Helper method for toggling players
        /// </summary>
        private static Player OppositePlayer(Player p) => p == Player.BOB ? Player.ANDY : Player.BOB;

        /// <summary>
        /// Constructs and array of the same length as the 
        /// inputted array, such that that each index i represents
        /// the index of the max value in the range [0, i].
        /// 
        /// Example:
        /// 
        ///     { 1, 5, 3, -1, 6, 9, 3, 1 }
        /// --> { 0, 1, 1,  1, 4, 5, 5, 5 }
        /// 
        /// </summary>
        private static int[] RunningMaxIndices(int[] board)
        {
            int[] maxIndices = new int[board.Length];
            if(board.Length == 0)
            {
                return maxIndices;
            }
            int maxi = maxIndices[0] = 0;
            for(int i = 1; i < board.Length; ++i)
            {
                if(board[i] > board[maxi])
                {
                    maxi = i;
                }
                maxIndices[i] = maxi;
            }
            return maxIndices;
        }
    }
}

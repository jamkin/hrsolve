using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.CrosswordPuzzle
{
    public class CrosswordPuzzle
    {
        private const char Block = '+';
        private const char Space = '-';
        private const int M = 10;
        private const int N = 10;
        private char[,] board = new char[M, N];

        public CrosswordPuzzle(char[,] initial)
        {
            InitializeBoard(initial);
        }

        public void Print()
        {
            Console.WriteLine(StringifyBoard());
        }

        /// <summary>
        /// Provides string representation of current board
        /// </summary>
        public string StringifyBoard()
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < M; ++i)
            {
                char[] line = new char[N];
                for(int j = 0; j < N; ++j)
                {
                    line[j] = board[i, j];
                }
                if((i + 1) == M)
                {
                    sb.Append(line);
                }
                else
                {
                    sb.AppendLine(new string(line));
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Initializes the board with spaces and blocks given in a 2d array.
        /// </summary>
        /// <param name="initial"></param>
        private void InitializeBoard(char[, ] initial)
        {
            int iM = initial.GetLength(0), iN = initial.GetLength(1);

            if(iM != M || iN != N)
            {
                throw new ArgumentException($"Board must have dimensions {M}x{N}");
            }

            for(int i = 0; i < M; ++i)
            {
                for(int j = 0; j < N; ++j)
                {
                    if(initial[i, j] != Block && initial[i, j] != Space)
                    {
                        throw new ArgumentException($"Board must consist of characters {Block}, {Space}. Found a {initial[i, j]}");
                    }
                    board[i, j] = initial[i, j];
                }
            }
        }

        /// <summary>
        /// Tries to add all the given words to the board. Uses brute force.
        /// </summary>
        /// <param name="words">Assumed to be strings of capital english letters.</param>
        public void AddWords(IEnumerable<string> words)
        {
            // Gets all possible combinations of pairs between words and spaces
            // on the board where they fit.
            // Sloppy code!
            var spacesByLength = GetSpaces()
                .GroupBy(space => space.Length)
                .ToDictionary(g => g.Key, g => g.ToArray());
            string[] wordsArray = words.ToArray();
            var wordSpaceCombos = wordsArray.Select(w => Enumerable.Range(0, spacesByLength[w.Length].Length))
                .OneFromEach()
                .Select(arr => arr.Select((i, j) => Tuple.Create(wordsArray[j], spacesByLength[wordsArray[j].Length][i])));

            // Try each placement combination
            foreach(IEnumerable<Tuple<string, CrosswordSpace>> placements in wordSpaceCombos)
            {
                if(TryPlacements(placements))
                {
                    return;
                }
            }
            // If made it here, none of the placement combinations worked
            throw new ApplicationException("No placements possilbe");
        }

        /// <summary>
        /// Tries to place words into designated spaces on the board.
        /// </summary>
        /// <param name="placements">
        /// Pairs of words to the places they 
        /// </param>
        /// <returns>True or false depending on whether placements worked.</returns>
        private bool TryPlacements(IEnumerable<Tuple<string, CrosswordSpace>> placements)
        {
            // We consider the placements an atomic operation. Work with a copy of the board so that we can undo
            // the placements as soon as one doesn't work.
            char[,] copy = CopyBoard();

            foreach(Tuple<string, CrosswordSpace> placement in placements)
            {
                if(!TryPlaceWord(placement.Item1, placement.Item2))
                {
                    board = copy; // revert board
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Tries to place a given word on a given space of the board.
        /// </summary>
        /// <returns>True or false depending on whether the word can possibly fit in the space</returns>
        private bool TryPlaceWord(string word, CrosswordSpace space)
        {
            if(word.Length != space.Length)
            {
                return false;
            }
            if(space.Direction == Direction.RIGHT)
            {
                for(int x = space.X, n = space.X + word.Length; x < n; ++x)
                {
                    if(!TryPlaceLetter(x, space.Y, word[x - space.X]))
                    {
                        return false;
                    }
                }
            }
            else if(space.Direction == Direction.DOWN)
            {
                for(int y = space.Y, m = space.Y + word.Length; y < m; ++y)
                {
                    if(!TryPlaceLetter(space.X, y, word[y - space.Y]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Tries to place a given letter on a given coordinate of the board
        /// </summary>
        /// <returns>True or false depending on whether the placement is possible</returns>
        private bool TryPlaceLetter(int x, int y, char c)
        {
            if(board[y, x] != Space && board[y, x] != c)
                return false;
            board[y, x] = c;
            return true;
        }

        /// <summary>
        /// Creates deep copy of board
        /// </summary>
        private char[,] CopyBoard()
        {
            char[,] copy = new char[M, N];
            for(int i = 0; i < M; ++i)
                for(int j = 0; j < N; ++j)
                    copy[i, j] = board[i, j];
            return copy;
        }

        /// <summary>
        /// Finds all the the spaces that words can fit in on an empty board.
        /// Spaces are defined as any left-to-right or up-to-down sequence of
        /// space characters, that is not a subsequence of any other such
        /// subequence.
        /// </summary>
        private IEnumerable<CrosswordSpace> GetSpaces()
        {
            for(int i = 0; i < M; ++i)
            {
                for(int j = 0; j < N; ++j)
                {
                    if(board[i, j] == Space)
                    {
                        if(i == 0 || board[i - 1, j] == Block)
                        {
                            int len = 1;
                            for(int ii = i + 1; ii < M && board[ii, j] == Space; ++ii, ++len);
                            yield return new CrosswordSpace()
                            {
                                X = j,
                                Y = i,
                                Length = len,
                                Direction = Direction.DOWN
                            };
                        }
                        if(j == 0 || board[i, j - 1] == Block)
                        {
                            int len = 1;
                            for(int jj = j + 1; jj < N && board[i, jj] == Space; ++jj, ++len);
                            yield return new CrosswordSpace()
                            {
                                X = j,
                                Y = i,
                                Length = len,
                                Direction = Direction.RIGHT
                            };
                        }
                    }
                }
            }
        }
    }

    public enum Direction { RIGHT, DOWN };

    public struct CrosswordSpace
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Length { get; set; }
        public Direction Direction { get; set; }
    }
}

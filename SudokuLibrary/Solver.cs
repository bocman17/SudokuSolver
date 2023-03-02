namespace SudokuLibrary
{
    public class Solver
    {
        public static char[,] Input()
        {
            char[,] unsolvedSudoku = new char[9, 9];
            bool Invalid = true;
            while (Invalid)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Console.Write($"Enter number in range of 1-9 on this position: {i + 1}-{j + 1}. If the position is empty enter '.' ");

                        char c = Console.ReadKey().KeyChar;
                        if (c != '0' && (char.IsNumber(c) || c == '.'))
                        {
                            unsolvedSudoku[i, j] = c;
                            Console.WriteLine();
                        }
                        else
                        {
                            j--;
                            Console.WriteLine();
                            Console.WriteLine("Char is not in range 1-9 or '.'! Try again!");
                            continue;
                        }
                    }
                    Console.WriteLine();
                }
                if (!IsValid(unsolvedSudoku))
                {
                    Console.WriteLine("The input is not valid sudoku, start again");
                    Invalid = true;
                }
                else
                {
                    Invalid = false;
                }
            }
            return unsolvedSudoku;
        }

        public static void PrintSudoku(char[,] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void SolveSudoku(char[,] board)
        {
            FillSudoku(board, 0, 0);
            PrintSudoku(board);
        }

        public static bool FillSudoku(char[,] board, int row, int col)
        {
            for (int i = row; i < 9; i++, col = 0)
            {
                for (int j = col; j < 9; j++)
                {
                    if ('.' != board[i, j]) continue;
                    for (char c = '1'; c <= '9'; c++)
                    {
                        if (IsValid(board, i, j, c))
                        {
                            board[i, j] = c;
                            bool foundSolution = FillSudoku(board, i, j + 1);
                            if (foundSolution)
                            {
                                return true;
                            }
                            board[i, j] = '.';
                        }
                    }
                    return false;
                }
            }
            return true;
        }

        public static bool IsValid(char[,] board)
        {
            HashSet<char>[] rowHash = new HashSet<char>[9];
            HashSet<char>[] colsHash = new HashSet<char>[9];

            for (int i = 0; i < rowHash.Length; i++)
            {
                rowHash[i] = new HashSet<char>();
                colsHash[i] = new HashSet<char>();
            }

            HashSet<char>[,] squareHash = new HashSet<char>[3, 3];

            for (int row = 0; row < squareHash.GetLength(0); row++)
            {
                for (int col = 0; col < squareHash.GetLength(1); col++)
                {
                    squareHash[row, col] = new HashSet<char>();
                }
            }

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (board[row, col] == '.')
                    {
                        continue;
                    }

                    if (rowHash[row].Contains(board[row, col]))
                    {
                        return false;
                    }
                    rowHash[row].Add(board[row, col]);

                    if (colsHash[col].Contains(board[row, col]))
                    {
                        return false;
                    }
                    colsHash[col].Add(board[row, col]);

                    if (squareHash[row / 3, col / 3].Contains(board[row, col]))
                    {
                        return false;
                    }
                    squareHash[row / 3, col / 3].Add(board[row, col]);
                }
            }
            return true;
        }
        public static bool IsValid(char[,] board, int row, int col, char val)
        {
            // check row
            for (int i = 0; i < 9; i++)
            {
                if (val.CompareTo(board[row, i]) == 0)
                {
                    return false;
                }
            }
            // check col
            for (int i = 0; i < 9; i++)
            {
                if (val.CompareTo(board[i, col]) == 0)
                {
                    return false;
                }
            }
            // check subsquare
            for (int i = row / 3 * 3; i < row / 3 * 3 + 3; i++)
            {
                for (int j = col / 3 * 3; j < col / 3 * 3 + 3; j++)
                {
                    if (val.CompareTo(board[i, j]) == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
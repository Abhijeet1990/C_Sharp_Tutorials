using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class Question36
    {
        public bool IsValidSudoku(char[,] board)
        {
            int i, j, k, l, m, n;
            bool[] isValid = new bool[9];
            int blockCount = 0;
            bool BlockValid=true;
            bool RowColumnValid=true;
            //check if inside each block there is no redundancy
            for (i = 0; i < board.GetLength(0); i=i+3)
            {
                for (j = 0; j < board.GetLength(1);j= j+3)
                {
                    char[,] subBoard = new char[3, 3];
                    for (k = i, m = 0; k < i + 3; k++, m++)
                    {
                        for (l = j, n = 0; l < j + 3; l++,n++)
                        {
                            subBoard[m,n] = board[k,l];
                        }
                    }
                    isValid[blockCount] = IsEachBlockValid(subBoard);
                    blockCount++;
                }
            }
            for (i = 0; i < 9; i++)
            {
                BlockValid =BlockValid & isValid[i];
            }

            //check inside each row if there is no redundancy

            RowColumnValid = IsEachRowColumnValid(board);
            //check if all the numbers range from 1-9
            return RowColumnValid & BlockValid;

        }

        public bool IsEachBlockValid(char[,] subBoard)
        {
            List<char> container = new List<char>();
            for (int i = 0; i < subBoard.GetLength(0); i++)
            {
                for (int j = 0; j < subBoard.GetLength(1); j++)
                {
                    if (subBoard[i,j] != '.' && container.Contains(subBoard[i,j]))
                    {
                        return false;

                    }
                    container.Add(subBoard[i,j]);

                }
            }
            return true;

        }

        public bool IsEachRowColumnValid(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                List<char> container = new List<char>();
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (container.Contains(board[i,j]) && board[i,j] != '.')
                    {
                        return false;

                    }
                    container.Add(board[i,j]);
                }
                container.Clear();

            }

            for (int i = 0; i < board.GetLength(0); i++)
            {
                List<char> container = new List<char>();
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (container.Contains(board[j,i]) && board[j,i] != '.')
                    {
                        return false;

                    }
                    container.Add(board[j,i]);
                }
                container.Clear();

            }

            return true;

        }

        //static void Main(string[] args)
        //{
        //    Question36 p = new Question36();
        //    char[,] board = new char[9, 9] { {'5','3','.','.','7','.', '.', '.', '.' }, 
        //                                     { '6','.','.','1','9','5','.','.','.'},
        //                                     {'.','9','8','.','.','.','.','6','.' },
        //                                     {'8','.','.','.','6','.','.','.','3' },
        //                                     {'4','.','.','8','.','3','.','.','1' },
        //                                     { '7','.','.','.','2','.','.','.','6'}, 
        //                                     {'.','6','.','.','.','.','2','8','.' },
        //                                     {'.','.','.','4','1','9','.','.','5' }, 
        //                                     {'.','.','.','.','8','.','.','7','9'} };
        //    bool isValidSudoku = p.IsValidSudoku(board);
            
        //    Console.WriteLine(isValidSudoku.ToString());
        //    Console.ReadLine();
        //}
    }
}

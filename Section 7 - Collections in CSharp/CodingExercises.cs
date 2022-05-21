using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section7Namespace
{
    internal class CodingExercises
    {
        public class Exercise7
        {
            public static void GetOdd(int[] Array)
            {
                for (int i = 0; i < Array.Length; i++)
                {
                    int elem = Array[i];
                    if ((elem % 2) == 1)
                    {
                        Console.WriteLine(elem);
                    }
                }
            }

            public static void GetEven(int[] Array)
            {
                for (int i = 0; i < Array.Length; i++)
                {
                    int elem = Array[i];
                    if ((elem % 2) == 0)
                    {
                        Console.WriteLine(elem);
                    }
                }
            }

            public static void Run()
            {
                int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                GetOdd(array);
                GetEven(array);

            }
        }

        public class Exercise8
        {
            public static bool Checker(string[,] board)
            {
                bool isHorizontalWin = CheckHorizontals(board);

                if (isHorizontalWin) return true;

                bool isVerticalWin = CheckVerticals(board);

                if (isVerticalWin) return true;

                bool isDiagonalWin = CheckDiagonals(board);

                if (isDiagonalWin) return true;

                return false;
            }

            public static bool CheckHorizontals(string[,] board)
            {
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    bool doesPlayerXWin = true;
                    bool doesPlayerOWin = true;

                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        if (board[i, j] == "X")
                        {
                            doesPlayerOWin = false;
                        }
                        else if (board[i, j] == "O")
                        {
                            doesPlayerXWin = false;
                        }
                        else
                        {
                            doesPlayerOWin = false;
                            doesPlayerXWin = false;
                        }
                    }
                    if (doesPlayerXWin || doesPlayerOWin)
                    {
                        return true;
                    }
                }
                return false;
            }

            public static bool CheckVerticals(string[,] board)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    bool doesPlayerXWin = true;
                    bool doesPlayerOWin = true;

                    for (int i = 0; i < board.GetLength(0); i++)
                    {
                        if (board[i, j] == "X")
                        {
                            doesPlayerOWin = false;
                        }
                        else if (board[i, j] == "O")
                        {
                            doesPlayerXWin = false;
                        }
                        else
                        {
                            doesPlayerOWin = false;
                            doesPlayerXWin = false;
                        }
                    }
                    if (doesPlayerXWin || doesPlayerOWin)
                    {
                        return true;
                    }
                }
                return false;
            }

            public static bool CheckDiagonals(string[,] board)
            {
                bool doesPlayerXWinLeftDiag = true;
                bool doesPlayerOWinLeftDiag = true;

                bool doesPlayerXWinRightDiag = true;
                bool doesPlayerOWinRightDiag = true;

                int boardLength = board.GetLength(0);

                for (int i = 0; i < boardLength; i++)
                {    
                    if (board[i, i] == "X")
                    {
                        doesPlayerOWinLeftDiag = false;
                    }
                    else if (board[i, i] == "O")
                    {
                        doesPlayerXWinLeftDiag = false;
                    }
                    else
                    {
                        doesPlayerOWinLeftDiag = false;
                        doesPlayerXWinLeftDiag = false;
                    }

                    int otherSide = (boardLength - i - 1);

                    if (board[i, otherSide] == "X")
                    {
                        doesPlayerOWinRightDiag = false;
                    }
                    else if (board[i, otherSide] == "O")
                    {
                        doesPlayerXWinRightDiag = false;
                    }
                    else
                    {
                        doesPlayerOWinRightDiag = false;
                        doesPlayerXWinRightDiag = false;
                    }
                }
                    if (doesPlayerXWinLeftDiag || doesPlayerOWinLeftDiag || doesPlayerXWinRightDiag || doesPlayerOWinRightDiag)
                    {
                        return true;
                    }
                return false;
            }
        }

        public class Exercise10
        {
            public static string Convert(int i)
            {
                Dictionary<int, string> numbers = new Dictionary<int, string>();
                numbers.Add(0, "zero");
                numbers.Add(1, "one");
                numbers.Add(2, "two");
                numbers.Add(3, "three");
                numbers.Add(4, "four");
                numbers.Add(5, "five");

                string numberString;

                bool numberExisted = numbers.TryGetValue(i, out numberString);

                if (!numberExisted) return "nope";

                return numberString;
            }
        }
    }
}

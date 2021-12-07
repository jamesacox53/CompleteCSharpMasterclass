using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section7Namespace
{
    internal class TicTacToe
    {

        private int gridSize;
        private int[,] ticTacToeGrid;

        public TicTacToe()
        {
            this.gridSize = 3;
            this.ticTacToeGrid = new int[this.gridSize, this.gridSize];
        }

        public void PlayTicTacToe()
        {

            bool gameOver = false;
            int playerTurn = 1;

            PrintTicTacToeGrid();

            while (!gameOver)
            {

                Console.WriteLine($"It is player {playerTurn}'s turn.");

                string playerChoiceString = Console.ReadLine();

                int playerChoice;

                bool correctlyParsed = int.TryParse(playerChoiceString, out playerChoice);

                if (!correctlyParsed)
                {
                    Console.WriteLine("Please input a valid number");

                }
                else
                {
                    playerChoice--;
                    int x = playerChoice / this.gridSize;
                    int y = playerChoice % this.gridSize;

                    if (x < 0 || x >= this.gridSize || y < 0 || y >= this.gridSize)
                    {
                        Console.WriteLine("Please input a valid square");
                    }
                    else if (this.ticTacToeGrid[x, y] != 0)
                    {
                        Console.WriteLine("Please input a square which hasn't previously been used");

                    }
                    else
                    {
                        this.ticTacToeGrid[x, y] = playerTurn;
                        PrintTicTacToeGrid();

                        if (checkIfWon(x, y, playerTurn))
                        {
                            Console.WriteLine($"Congratulations player {playerTurn}, you win!");
                            return;
                        }
                        else if (checkIfDraw())
                        {
                            Console.WriteLine("Unlucky, the match ends in a draw. Nobody wins.");
                            return;
                        }


                        playerTurn = (playerTurn % 2) + 1;
                    }
                }

            }
        }

        private void PrintTicTacToeGrid()
        {

            string[] ticTacToeStringGrid = new string[this.gridSize];

            for (int i = 0; i < this.ticTacToeGrid.GetLength(0); i++)
            {
                string[] rows = new string[this.gridSize];

                rows[0] = getBlankRow();

                string[] rowArray = getTicTacToeRowFromGrid(i);
                rows[1] = "   " + string.Join("   |   ", rowArray) + "   ";

                rows[2] = getBlankRow();

                ticTacToeStringGrid[i] = string.Join("\n", rows);
            }

            Console.WriteLine(string.Join("\n" + getSeparatorRow() + "\n", ticTacToeStringGrid));

        }

        private string getTicTacToeGridElement(int ticTacToeElement, int row, int col)
        {
            switch (ticTacToeElement)
            {
                case 1: return "O";
                case 2: return "X";
                default: return ((row * 3) + col + 1).ToString();
            }
        }

        private string[] getTicTacToeRowFromGrid(int row)
        {
            string[] retArray = new string[this.ticTacToeGrid.GetLength(1)];

            for (int j = 0; j < this.ticTacToeGrid.GetLength(1); j++)
            {
                retArray[j] = getTicTacToeGridElement(this.ticTacToeGrid[row, j], row, j);
            }

            return retArray;
        }

        private string getBlankRow()
        {
            return "       |       |       ";
        }

        private string getSeparatorRow()
        {
            return "-------|-------|-------";
        }

        private bool checkIfWon(int x, int y, int playerTurn)
        {
            bool isRow = true;

            for (int i = 0; i < this.gridSize; i++)
            {
                isRow = isRow && (this.ticTacToeGrid[i, y] == playerTurn);
            }

            if (isRow) return true;

            bool isCol = true;

            for (int j = 0; j < this.gridSize; j++)
            {
                isCol = isCol && (this.ticTacToeGrid[x, j] == playerTurn);
            }

            if (isCol) return true;

            bool isRightDiagonal = true;

            for (int i = 0; i < this.gridSize; i++)
            {
                isRightDiagonal = isRightDiagonal && (this.ticTacToeGrid[i, i] == playerTurn);
            }

            if (isRightDiagonal) return true;

            bool isLeftDiagonal = true;

            for (int i = 0; i < this.gridSize; i++)
            {
                isLeftDiagonal = isLeftDiagonal && (this.ticTacToeGrid[i, (this.gridSize - 1) - i] == playerTurn);
            }

            if (isLeftDiagonal) return true;

            return false;
        }

        private bool checkIfDraw()
        {
            foreach (int val in this.ticTacToeGrid)
            {
                if (val == 0) return false;
            }

            return true;
        }

    }

}

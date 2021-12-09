using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section7Namespace
{
    internal class TicTacToe
    {
        private int defaultGridSize = 3;
        private int gridSize;
        private string[,] ticTacToeGrid;
        private int numPlayers = 2;
        private char[] playerSymbols = { 'O', 'X' };
        private int playerTurn = 1;

        public TicTacToe()
        {
            setUp(this.defaultGridSize);
        }

        public TicTacToe(int gridSize)
        {
            setUpWithGridSize(gridSize);
        }

        public TicTacToe(int gridSize, int numPlayers, char[] playerSymbols)
        {
            setUpWithNumPlayers(gridSize, numPlayers, playerSymbols);
        }

        private void setUp(int gridSize)
        {
            this.gridSize = gridSize;
            this.ticTacToeGrid = new string[this.gridSize, this.gridSize];
            initializeGrid();
        }

        private void setUpWithGridSize(int gridSize)
        {
            if (gridSize >= 1 && gridSize <= 10)
            {
                setUp(gridSize);
            }
            else
            {
                Console.WriteLine("Invalid gridSize selection, using default grid Size of 3.");
                setUp(this.defaultGridSize);
            }
        }

        private void setUpWithNumPlayers(int gridSize, int numPlayers, char[] playerSymbols)
        {
            setUpWithGridSize(gridSize);

            if (numPlayers >= 2 && numPlayers <= 10 && arePlayerSymbolsValid(numPlayers, playerSymbols))
            {
                this.numPlayers = numPlayers;
                this.playerSymbols = playerSymbols;
            }
            else
            {
                Console.WriteLine("Invalid number of players selected or number of player symbols so using the default of 2 players with the symbols O and X.");
            }
        }

        public void PlayTicTacToe()
        {
            bool gameOver = false;

            PrintTicTacToeGridAndMessages();

            while (!gameOver)
            {
                Console.WriteLine($"It is player {this.playerTurn}'s turn.");

                string playerChoiceString = Console.ReadLine();

                if (playerChoiceString == "q")
                {
                    quitGame();
                    return;
                }
                
                int playerChoice;

                bool correctlyParsed = int.TryParse(playerChoiceString, out playerChoice);

                if (!correctlyParsed)
                {
                    Console.WriteLine("Please input a valid number.");
                }
                else
                {
                    playerChoice--;
                    int x = playerChoice / this.gridSize;
                    int y = playerChoice % this.gridSize;

                    if (x < 0 || x >= this.gridSize || y < 0 || y >= this.gridSize)
                    {
                        Console.WriteLine("Please input a valid square.");
                    }
                    else if (hasSquareAlreadyBeenPlayed(x, y))
                    {
                        Console.WriteLine("Please input a square which hasn't previously been played.");
                    }
                    else
                    {
                        // Set the grid position to be the players symbol
                        this.ticTacToeGrid[x, y] = this.playerSymbols[this.playerTurn - 1].ToString();

                        Console.Clear();
                        PrintTicTacToeGrid();

                        if (checkIfWon(x, y))
                        {
                            gameOver = !gameFinished($"Congratulations player {playerTurn}, you win!");
                        }
                        else if (checkIfDraw())
                        {
                            gameOver = !gameFinished("Unlucky, the match ends in a draw. Nobody wins.");
                        }
                        else
                        {
                            printQuitMessage();
                            switchPlayer();
                        }
                    }
                }
            }
        }

        private void PrintTicTacToeGrid()
        {
            // ticTacToeStringGrid will hold the rows as strings.
            string[] ticTacToeStringGrid = new string[this.gridSize];

            for (int i = 0; i < this.ticTacToeGrid.GetLength(0); i++)
            {
                // Each grid row will be printed as 3 lines to the console. So gridRow will
                //  hold those 3 lines: the top line, the middle line and the bottom line.
                string[] gridRow = new string[3];

                // The top line parts
                string[] squaresTopParts = new string[this.gridSize];

                // The middle line parts
                string[] squaresMiddleParts = new string[this.gridSize];

                // the bottom line parts
                string[] squaresBottomParts = new string[this.gridSize];


                for (int j = 0; j < this.ticTacToeGrid.GetLength(1); j++) 
                {   
                    string[] squareStringParts = getSquareStringParts(this.ticTacToeGrid[i, j]);

                    squaresTopParts[j] = squareStringParts[0];
                    squaresMiddleParts[j] = squareStringParts[1];
                    squaresBottomParts[j] = squareStringParts[2];
                }

                gridRow[0] = string.Join("|", squaresTopParts);
                gridRow[1] = string.Join("|", squaresMiddleParts);
                gridRow[2] = string.Join("|", squaresBottomParts);

                string gridRowString = string.Join("\n", gridRow);

                ticTacToeStringGrid[i] = gridRowString;
            }

            string ticTacToeGridAsString = string.Join("\n" + getSeparatorRow() + "\n", ticTacToeStringGrid);

            Console.WriteLine(ticTacToeGridAsString);
        }

        private string getSeparatorRow()
        {
            string[] separatorRow = new string[this.gridSize];

            for (int i = 0; i < separatorRow.Length; i++)
            {
                // Each tictactoe grid square is 7 characters wide when
                // printed to the screen.
                separatorRow[i] = "".PadRight(7, '-');
            }

            string separator = String.Join('+', separatorRow);

            return separator;
        }

        private bool checkIfWon(int x, int y)
        {
            string playerSymbol = this.playerSymbols[this.playerTurn - 1].ToString();

            bool isRow = true;
            
            for (int i = 0; i < this.gridSize; i++)
            {
                if (this.ticTacToeGrid[i, y] != playerSymbol)
                {
                    isRow = false;
                    break;
                }
            }
            if (isRow) return true;

            bool isCol = true;

            for (int j = 0; j < this.gridSize; j++)
            {
                if (this.ticTacToeGrid[x, j] != playerSymbol)
                {
                    isCol = false;
                    break;
                }
            }
            if (isCol) return true;

            if (x == y)
            {
                bool isRightDiagonal = true;

                for (int i = 0; i < this.gridSize; i++)
                {
                    if (this.ticTacToeGrid[i, i] != playerSymbol)
                    {
                        isRightDiagonal = false;
                        break;
                    }
                }
                if (isRightDiagonal) return true;
            }
            // if the grid position is on the left diagonal
            if ((x == (this.gridSize - 1) - y) || (y == (this.gridSize - 1) - x))
            {
                bool isLeftDiagonal = true;

                for (int i = 0; i < this.gridSize; i++)
                {
                    if (this.ticTacToeGrid[i, (this.gridSize - 1) - i] != playerSymbol)
                    {
                        isLeftDiagonal = false;
                        break;
                    }
                }
                if (isLeftDiagonal) return true;
            }

            return false;
        }

        private bool checkIfDraw()
        {
            foreach (string value in this.ticTacToeGrid)
            {
                bool wasSymbol = false;

                foreach (char symbol in this.playerSymbols)
                {
                    if (symbol.ToString() == value)
                    {
                        wasSymbol = true;
                        break;
                    }
                }
                if (!wasSymbol) return false;
            }

            return true;
        }

        private string[] getSquareStringParts (string element)
        {
            
            // each grid square has 3 rows.
            string[] retArray = new string[3];

            // each grid square is 7 characters wide when printed to the screen.
           
            retArray[0] = "".PadRight(7, ' ');

            string elementPaddedRight = element.PadRight(4, ' ');
            retArray[1] = elementPaddedRight.PadLeft(7, ' ');

            retArray[2] = "".PadRight(7, ' ');

            return retArray;
        }

        private void initializeGrid()
        {
            for(int i = 0; i < this.ticTacToeGrid.GetLength(0); i++)
            {
                for (int j = 0; j < this.ticTacToeGrid.GetLength(1); j++)
                {
                    int gridNum = (i * this.gridSize) + j + 1;

                    this.ticTacToeGrid[i, j] = gridNum.ToString();
                }
            }
        }

        private void switchPlayer()
        {
            this.playerTurn = (this.playerTurn % this.numPlayers) + 1;
        }

        private bool hasSquareAlreadyBeenPlayed(int row, int column)
        {
            string ticTacToeGridElement = this.ticTacToeGrid[row, column];

            for (int i = 0; i < this.playerSymbols.Length; i++)
            {
                if (this.playerSymbols[i].ToString() == ticTacToeGridElement)
                {
                    return true;
                }
            }

            return false;
        }

        private bool arePlayerSymbolsValid(int numPlayers, char[] playerSymbols)
        {
            if (playerSymbols.Length < numPlayers)
            {
                return false;
            }

            foreach (char playerSymbol in playerSymbols)
            {
                if (char.IsNumber(playerSymbol)) {
                    return false;
                }
            }
            return true;
        }

        private bool decideIfWantToPlayAgain()
        {
            Console.WriteLine("Press q if you want to quit or press any other key if you want to play again.");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.KeyChar == 'q')
            {
                quitGame();
                return false;
            }
            else 
            {
                Console.Clear();
                initializeGrid();
                this.playerTurn = 1;
                PrintTicTacToeGridAndMessages();
                return true;
            }
        }
        private bool gameFinished(string message)
        {
            Console.WriteLine(message);
            return decideIfWantToPlayAgain();
        }

        private void quitGame()
        {
            Console.WriteLine();
            Console.WriteLine("Thank you for playing! Goodbye :).");
        }

        private void PrintTicTacToeGridAndMessages()
        {
            PrintTicTacToeGrid();
            printQuitMessage();
        }

        private void printQuitMessage()
        {
            Console.WriteLine($"Type q to quit the game.");
        }
    }
}

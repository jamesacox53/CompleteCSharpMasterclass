using System;

namespace Section7Namespace
{
    class Section7
    {
        static void Main(string[] args)
        {
            // ChallengeForeachLoop();

            // understandingNestedLoops();

            // TicTacToe ticTacToeGame = new TicTacToe();
            // TicTacToe ticTacToeGame = new TicTacToe(10);


            // TicTacToe ticTacToeGame = new TicTacToe(16, 8, new char [] {'A', 'B', 'C', 'D', 'E', 'F', 'H', 'I'});

            TicTacToe ticTacToeGame = new TicTacToe(4);

            ticTacToeGame.PlayTicTacToe();
        }

        public static void ChallengeForeachLoop()
        {
            Console.WriteLine("Please enter an input value");
            string argument1 = Console.ReadLine();

            if (argument1.Length <= 0)
            {
                Console.WriteLine("The argument wasn't valid. Please restart the program and enter a valid argument type.");
                return;
            }

            Console.WriteLine("Please enter the data type of the input value");
            Console.WriteLine("Press 1 for String");
            Console.WriteLine("Press 2 for integer");
            Console.WriteLine("Press 3 for Boolean");

            string argument2 = Console.ReadLine();

            int argument2Int;
            bool wasValidInt = Int32.TryParse(argument2, out argument2Int);

            if (!wasValidInt || argument2Int < 1 || argument2Int > 3)
            {
                Console.WriteLine("The argument type wasn't valid. Please restart the program and enter a valid argument type.");
                return;
            }

            switch(argument2Int)
            {
                case 1:
                    {
                        writeToScreen(argument1, "String", checkStringValid(argument1));
                        break;
                    }
                case 2:
                    {
                        int parsedInteger;
                        bool isValidInteger = Int32.TryParse(argument1, out parsedInteger);
                        writeToScreen(argument1, "Integer", isValidInteger);
                        break;
                    }
                case 3:
                    {
                        bool parsedBool;
                        bool isValidBoolean = Boolean.TryParse(argument1, out parsedBool);
                        writeToScreen(argument1, "Boolean", isValidBoolean);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Not able to detect an output type.");
                        break;
                    }
            }

        }

        public static bool checkStringValid(string argument1)
        {
            
            for (int i = 0; i < argument1.Length; i++)
            {
                int tempVar;
                bool isNumber = Int32.TryParse(argument1[i].ToString(), out tempVar);
                
                if(isNumber)
                {
                    return false;
                }
            }

            return true;
        }

        public static void writeToScreen(string val, string dataType, bool isValid) 
        {
            Console.WriteLine($"You have entered a value: {val}");
            if (isValid)
            {
                Console.WriteLine($"It is a valid: {dataType}");
            } else
            {
                Console.WriteLine($"Is is an invalid: {dataType}");
            }
        }

        public static void understandingNestedLoops()
        {
            int[,] matrix =
            {
                {1, 2, 3 },
                {4, 5, 6 },
                {7, 8, 9 },
            };

            for (int i = 0; i < matrix.GetLength(0); i++)
            {

                Console.WriteLine("Row: " + i);

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.WriteLine("Column: " + j);
                    Console.WriteLine("Element: " + matrix[i, j]);
                }
            }
        }
    }
}
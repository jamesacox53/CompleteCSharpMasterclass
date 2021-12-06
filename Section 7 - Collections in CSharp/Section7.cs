using System;

namespace Section7Namespace
{
    class Section7
    {
        static void Main(string[] args)
        {
            ChallengeForeachLoop();

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
    }
}
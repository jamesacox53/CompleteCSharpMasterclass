using System;

namespace Section2Namespace
{
    class Section2
    {

        static void Main(string[] args)
        {
            // Section2.ExerciseStrings1();
            Section2.ExerciseStrings2();
        }

        public static void ExerciseStrings1()
        {
            string value;

            Console.WriteLine("Please enter your name and press enter");

            string returnedValue = Console.ReadLine();

            value = returnedValue;
            Console.WriteLine($"Upper Case                :{value.ToUpper()}");
            Console.WriteLine($"Lower Case                :{value.ToLower()}");
            Console.WriteLine($"Trimmed Value             :{value.Trim()}");
            Console.WriteLine($"Substring from position 3 :{value.Substring(3)}");

        }

        public static void ExerciseStrings2()
        {
            Console.WriteLine("Enter a string here:");
            string inputString = Console.ReadLine();
            Console.WriteLine("Enter the character to search:");
            char inputCharacter = Console.ReadLine()[0];
            Console.WriteLine($"Index of first occurrence: {inputString.IndexOf(inputCharacter)}");

            Console.WriteLine("Please Input your first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Please Input your surname:");
            string surname = Console.ReadLine();
            string fullName = string.Concat(firstName, " ", surname);
            Console.WriteLine($"Your full name is: {fullName}");

        }
    
    }

}

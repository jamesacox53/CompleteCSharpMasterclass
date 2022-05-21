using System;

namespace Section2Namespace
{
    class Section2
    {

        static void Main(string[] args)
        {
            // Section2.ExerciseStrings1();
            // Section2.ExerciseStrings2();
            // ChallengeDatatypesAndVariables();
            Assignment1();
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

        public static void ChallengeDatatypesAndVariables()
        {

            byte myByte = 250;
            sbyte mySByte = -120;
            Console.WriteLine(myByte);
            Console.WriteLine(mySByte);

            short myShort = -32700;
            ushort myUShort = 65500;
            Console.WriteLine(myShort);
            Console.WriteLine(myUShort);

            int myInt = -2147483000;
            uint myUInt = 4294967000;
            Console.WriteLine(myInt);
            Console.WriteLine(myUInt);

            long myLong = -9223372036854775000;
            ulong myUlong = 18446744073709551000;
            Console.WriteLine(myLong);
            Console.WriteLine(myUlong);

            float myFloat = -340.123f;
            Console.WriteLine(myFloat);

            double myDouble = -179769.1234;
            Console.WriteLine(myDouble);

            decimal myDecimal = new Decimal(-12345.12345);
            Console.WriteLine(myDecimal);

            char myChar = 'j';
            Console.WriteLine(myChar);

            bool myBool = false;
            Console.WriteLine(myBool);

            string myString = "Hello";
            Console.WriteLine(myString);

            string value1 = "I control text";
            Console.WriteLine(value1);

            string value2 = "30";

            int num2 = Int32.Parse(value2);
            Console.WriteLine(num2);
        }
    
        public static void Assignment1()
        {
            string stringForFloat = "0.85"; // datatype should be float
            string stringForInt = "12345"; // datatype should be int

            float myFloat = float.Parse(stringForFloat);
            int myInt = Int32.Parse(stringForInt);

            Console.WriteLine(myFloat);
            Console.WriteLine(myInt);
        }
    }
}

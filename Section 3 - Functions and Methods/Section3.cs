using System;

namespace Section3Namespace
{
    class Section3
    {
        static void Main(string[] args)
        {
            // string friend1 = "Billy";
            // string friend2 = "Joseph";
            // string friend3 = "Ben";

            // GreetFriend(friend1);
            // GreetFriend(friend2);
            // GreetFriend(friend3);

            CodingExercise1("hey there !");
        }

        public static void GreetFriend(string friendName)
        {
            Console.WriteLine($"Hi {friendName}, my friend!");
        }

        public static void CodingExercise1(string input)
        {
            string lowerUpper = LowUpper(input);
            Console.WriteLine(lowerUpper);

            string count = Count(lowerUpper);
            Console.WriteLine(count);
        }

        public static string LowUpper(string input)
        {
            string lowercaseInputString = input.ToLower();
            string uppercaseInputString = input.ToUpper();

            return (lowercaseInputString + uppercaseInputString);
        }

        public static string Count(string input)
        {
            return ($"The amount of letters is {input.Length}.");
        }

    }

}
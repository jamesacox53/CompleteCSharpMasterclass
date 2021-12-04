using System;

namespace Section3Namespace
{
    class Section3
    {
        static void Main(string[] args)
        {
            string friend1 = "Billy";
            string friend2 = "Joseph";
            string friend3 = "Ben";

            GreetFriend(friend1);
            GreetFriend(friend2);
            GreetFriend(friend3);
        }

        public static void GreetFriend(string friendName)
        {
            Console.WriteLine($"Hi {friendName}, my friend!");
        }

    }

}
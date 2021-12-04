using System;

namespace Section4Namespace
{
    class Section4
    {
        static string username;
        static string password;

        static void Main(string[] args)
        {
            ChallengeIfStatements();
        }

        public static void ChallengeIfStatements()
        {
            Register();
            Login();
        }

        public static void Register()
        {
            Console.WriteLine("Please enter your username:");
            username = Console.ReadLine();

            Console.WriteLine("Please enter your password:");
            password = Console.ReadLine();

            Console.WriteLine("Registration completed");
            Console.WriteLine();

        }

        public static void Login()
        {
            Console.WriteLine("Please enter your username:");
            string inputUsername = Console.ReadLine();
            if (username.Equals(inputUsername))
            {
                
                Console.WriteLine("Please enter your password:");
                string inputPassword = Console.ReadLine();
                if (password.Equals(inputPassword))
                {
                    Console.Write("Login successful!");
                } else
                {
                    Console.WriteLine("Login unsuccessful.");
                }
            } else
            {
                Console.WriteLine("Login unsuccessful.");
            }
        }
    }
}
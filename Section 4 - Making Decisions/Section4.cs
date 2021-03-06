using System;

namespace Section4Namespace
{
    class Section4
    {
        static string username;
        static string password;

        static int highscore = 300;
        static string highscorePlayer = "James";

        static void Main(string[] args)
        {
            // ChallengeIfStatements();
            // ChallengeIfStatements2();
            // ChallengeTernaryOperator();
            // CodingExercise2(16);
            // CodingExercise3(3);
            // CodingExercise3(28);
            // CodingExercise3(1);
            // CodingExercise3(2);
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

        public static void ChallengeIfStatements2()
        {
            CheckHighscore(100, "Kyle");
            CheckHighscore(600, "Stan");
        }

        public static void CheckHighscore(int score, string playerName)
        {
            if(score > highscore)
            {
                highscore = score;
                highscorePlayer = playerName;

                Console.WriteLine($"New highscore: {highscore} which is held by {highscorePlayer}. All hail {highscorePlayer}.");

            } else
            {
                Console.WriteLine($"The old highscore: {highscore} held by {highscorePlayer} couldn't be broken. All hail {highscorePlayer}.");
            }
        }

        public static void ChallengeTernaryOperator()
        {
            Console.WriteLine("Please input temperature as an integer:");
            string inputTemperatureString = Console.ReadLine();
            int inputTemperature;

            try
            {

                inputTemperature = Int32.Parse(inputTemperatureString);

            } catch (Exception)
            {
                Console.WriteLine("Not a valid temperature");
                return;
            }

            Console.WriteLine(inputTemperature <= 15 ? "It is too cold here" : (inputTemperature > 28 ? "It is hot here" : "it is ok"));

        }

        public static void CodingExercise2(int number)
        {
            if ((number % 2) == 0)
            {
                Console.WriteLine("Even");
            } 
            else
            {
                Console.WriteLine("Odd");
            }
        }

        public static void CodingExercise3(int number)
        {
            if ((number % 3) == 0)
            {
                Console.WriteLine("Divisible by 3.");
            }
            else if ((number % 7) == 0)
            {
                Console.WriteLine("Divisible by 7.");
            }
            else if ((number % 2) == 1)
            {
                Console.WriteLine("Odd number.");
            }
            else
            {
                Console.WriteLine("Even number.");
            }
        }

    }
}
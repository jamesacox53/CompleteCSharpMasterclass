using System;

namespace Section5Namespace
{
    class Section5
    {
        static void Main(string[] args)
        {

            // ChallengeLoops1();
            // CodingExercise4ForLoop();
            // CodingExercise4WhileLoop();
            CodingExercise5();
        }

        static void ChallengeLoops1()
        {
            Console.WriteLine();

            double sum = 0;
            int numStudents = 0;
            bool finished = false;

            do
            {
                Console.WriteLine("Please enter a test score of a student:");
                string score = Console.ReadLine();

                int studentScore;

                bool isScore = Int32.TryParse(score, out studentScore);

                if (isScore && studentScore >= -1 && studentScore <= 20)
                {

                    if (studentScore == -1)
                    {
                        finished = true;

                    } else
                    {
                        sum += studentScore;
                        numStudents++;

                    }

                } else
                {
                    Console.WriteLine("That test score was incorrectly formatted. Please enter one correctly formatted.");
                }

            } while (!finished);

            if (numStudents > 0) {
                Console.WriteLine($"The average test score was {sum / numStudents}");
            }
        }

        public static void CodingExercise4ForLoop()
        {
            for (int i = -3; i <= 3; i++)
            {
                Console.WriteLine(i);
            }
        }

        public static void CodingExercise4WhileLoop()
        {
            int i = 3;
            while (i >= -3)
            {
                Console.WriteLine(i);
                i--;
            }
        }

        public static void CodingExercise5()
        {
            int i = -10;

            while (true)
            {
                if (i == 10)
                {
                    break;
                }

                if ((i % 3) == 0)
                {
                    i++;
                    continue;
                }

                Console.WriteLine(i++);
            }
        }
    }
}
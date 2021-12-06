using System;

namespace Section5Namespace
{
    class Section5
    {
        static void Main(string[] args)
        {
            
            ChallengeLoops1();
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
    }
}
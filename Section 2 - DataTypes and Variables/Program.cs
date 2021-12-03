using System;

namespace StringChallenge1
{
    class Program
    {

        static void Main(string[] args)
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

    }

}

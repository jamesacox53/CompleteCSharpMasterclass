using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Section11Namespace
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Assignment3Part2();

            }
            catch (Exception)
            {
                Console.WriteLine("There was an error");
            }

            Console.ReadKey();
        }

        public static void Assignment3Part2()
        {
            string directoryPath = "Directory Path goes here";

            string inputFilePath = directoryPath + "input2.txt";

            foreach (string line in System.IO.File.ReadLines(inputFilePath))
            {
                var matches = Regex.Matches(line, @"\d{2,3}");
                foreach (Match match in matches)
                {
                    string val = match.Value;

                    try
                    {
                        int intVal = Int32.Parse(val);

                        char charVal = (char) intVal;

                        Console.Write(charVal);
                    } 
                    catch(Exception)
                    {
                    }
                }
            }
        }
    }
}

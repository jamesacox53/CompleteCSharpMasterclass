using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section10Namespace
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Assignment2Part1();

            } catch (Exception) {
                return;
            }

        }

        public static void Assignment2Part1()
        {
            string directoryPath = "Path to the directory goes here";

            string inputFilePath = directoryPath + "input.txt";

            string outputFilePath = directoryPath + "output.txt";

            string outputString = "";
            
            foreach (string line in System.IO.File.ReadLines(inputFilePath))
            {
                if (!line.Contains("split")) continue;

                string[] splitLine = line.Split();

                outputString += (splitLine[4] + " ");
            }
            
            outputString = outputString.Trim();

            string[] output = new string[1];
            output[0] = outputString;

            File.WriteAllLines(outputFilePath, output);
        }
    }
}

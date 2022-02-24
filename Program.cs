using System;
using System.IO;

namespace Google_Hashcode2022
{
    class Program
    {
        static void Main(string[] args)
        {
            bool firstLine = true;
            fileParser(firstLine);
            Console.WriteLine("Hello World!");
        }
        ///Build Models and start prioritizing Data
        private static void fileParser(bool firstLine)
        {
            foreach (var item in File.ReadLines("./InputFiles/a_an_example.in.txt"))
            {
                if (firstLine)
                {
                    firstLine = false;
                    // DurataSimulazione = int.Parse(line.Split(" ")[0]);
                    // n_Intersezioni = int.Parse(line.Split(" ")[1]);
                    // n_streets = int.Parse(line.Split(" ")[2]);
                    // n_macchine = int.Parse(line.Split(" ")[3]);
                    // score = int.Parse(line.Split(" ")[4]);
                }
                else
                {

                }
            }
        }
        private static void scoreSystem()
        {

        }
    }
}
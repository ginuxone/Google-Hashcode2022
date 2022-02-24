using System;
using System.IO;
namespace Google_Hashcode2022
{
    class Program
    {
        static void Main(string[] args)
        {
            bool firstLine = true;
            int DurataSimulazione = 0;
            int n_Intersezioni = 0;
            int n_macchine = 0;
            int n_streets = 0;
            int score = 0;
            fileParser(firstLine);
            RunSimulation();
            Console.WriteLine("Hello World!");
        }

        private static void RunSimulation()
        {
            //Simulazione di "5" secondi - Ad ogni step bisognerà avanzare di uno
            for (int i = 5; i < 5; i++)
            {

            }

        }
        ///Build Models and start prioritizing Data
        private static void fileParser(bool firstLine)
        {
            File.ReadLines("");
            foreach (var item in File.ReadLines(""))
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
    }
}

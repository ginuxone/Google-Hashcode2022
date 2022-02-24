using System;
using System.IO;

namespace Google_Hashcode2022
{
    class Program
    {
        static void Main(string[] args)
        {
            bool firstLine = true;
            int n_projects = 0;
            int n_contributors = 0;
            fileParser(firstLine, n_contributors, n_projects);
            Console.WriteLine("Hello World!");
        }
        ///Build Models and start prioritizing Data
        private static void fileParser(bool firstLine, int n_contributors, int n_projects)
        {
            foreach (var item in File.ReadLines("./InputFiles/a_an_example.in.txt"))
            {
                if (firstLine)
                {
                    firstLine = false;
                    n_contributors = int.Parse(line.Split(" ")[0]);
                    n_projects = int.Parse(line.Split(" ")[1]);
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
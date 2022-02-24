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
            List<Contributor> contributors = new List<Contributor>();
            List<Project> projects = new List<Project>();
            fileParser(firstLine, n_contributors, n_projects);
        }
        ///Build Models and start prioritizing Data
        private static void fileParser(bool firstLine, int n_contributors, int n_projects, List<Contributor> contributors, List<Projects> projects)
        {
            int tmp_c = n_contributors;
            int tmp_p = n_projects;
            Contributor c;
            Project p;
            foreach (var line in File.ReadLines("./InputFiles/a_an_example.in.txt"))
            {
                
                if (firstLine)
                {
                    firstLine = false;
                    n_contributors = int.Parse(line.Split(" ")[0]);
                    n_projects = int.Parse(line.Split(" ")[1]);
                }
                else
                {
                    if (tmp_c > 0)
                    {
                        if (int == 0)
                        {
                            c = new Contributor();
                            c.name = line.Split(" ")[0];
                            c.n_skills = int.Parse(line.Split(" ")[1]);
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        if (int == 0)
                        {

                        }
                        else
                        {

                        }

                    }
                }
            }
        }
        private static void scoreSystem()
        {

        }
    }
}
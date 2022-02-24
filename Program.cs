using System;
using System.IO;

namespace Google_Hashcode2022
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool firstLine = true;
            int n_projects = 0;
            int n_contributors = 0;
            List<Contributor> contributors = new List<Contributor>();
            List<Project> projects = new List<Project>();
            fileParser(firstLine, n_contributors, n_projects, contributors, projects);
            foreach (Project p in projects)
            {
                Console.Write(p.name + " ");
            }
            List<Project> endedProjects = scoreSystem(projects, contributors);
            fileWrite(endedProjects);
        }
        ///Build Models and start prioritizing Data
        private static void fileParser(bool firstLine, int n_contributors, int n_projects, List<Contributor> contributors, List<Project> projects)
        {
            int tmp_c = n_contributors;
            int tmp_p = n_projects;
            Contributor c = new Contributor("");
            Project p = new Project("");
            int n_skill_req = 0;
            int n_skills = 0;
            foreach (var line in File.ReadLines("./InputFiles/a_an_example.in.txt"))
            {
                if (firstLine)
                {
                    firstLine = false;
                    n_contributors = int.Parse(line.Split(" ")[0]);
                    n_projects = int.Parse(line.Split(" ")[1]);
                }
                else if (n_contributors > 0 || n_skills > 0)
                {

                    //Contributors
                    if (n_skills == 0) //first line contributor
                    {
                        c = new Contributor(line.Split(" ")[0]);
                        n_skills = int.Parse(line.Split(" ")[1]);
                        --n_contributors;
                    }
                    else // insert skill in c contributor
                    {
                        int lv = Int32.Parse(line.Split(" ")[1]);
                        c.lista_skill.Add(new Skill(line.Split(" ")[0], lv));
                        --n_skills;
                    }
                    if (n_skills == 0)
                    {
                        contributors.Add(c);
                    }
                }
                //Projects
                else if (n_projects > 0 || n_skill_req > 0)
                {

                    if (n_skill_req == 0)
                    { // new project
                        string name = line.Split(" ")[0];
                        int duration = Int32.Parse(line.Split(" ")[1]);
                        int score = Int32.Parse(line.Split(" ")[2]);
                        int day = Int32.Parse(line.Split(" ")[3]);
                        n_skill_req = Int32.Parse(line.Split(" ")[4]);
                        p = new Project(name, score, day, n_skill_req, duration);
                        --n_projects;
                    }
                    else
                    { // add skill to project
                        int lv = Int32.Parse(line.Split(" ")[1]);
                        p.skill_list_required.Add(new Skill(line.Split(" ")[0], lv));
                        --n_skill_req;
                    }
                    if (n_skill_req == 0)
                    {
                        projects.Add(p);
                    }
                }
                else
                { //end
                    Console.WriteLine("----------------- ERROR IN READING INPUT FILE ----------------------");
                }

            }
        }
        private static List<Project> scoreSystem(List<Project> inputProjects, List<Contributor> inputContributors)
        {
            //passo i parsati
            List<Project> projects = inputProjects;
            List<Contributor> contributors = inputContributors;

            List<List<Project>> calendar = new List<List<Project>>();
            List<Project> assingedProjects = new List<Project>();
            List<Project> endProjects = new List<Project>();
            List<Contributor> freeContributors = new List<Contributor>();
            freeContributors = contributors;
            projects.Sort();

            //maxScadenza = punteggio del progetto + bestbefore del progetto. Ossia
            //i giorni disponibili tali per cui quel progetto ci darà punti.
            int maxScadenza = projects.Last().day_to_terminate + projects.Last().score;

            int score = 0;

            for (int day = 0; day < maxScadenza; day++)
            {
                Console.WriteLine(day);

                //assegnare i progetti
                foreach (Project project in projects)
                {
                    List<Skill> soddisfatte = new List<Skill>();
                    if (!assingedProjects.Contains(project))
                    {
                        Console.WriteLine(project.name);
                        foreach (Skill reqSkill in project.skill_list_required)
                        {
                            Contributor tmp = null;
                            bool found = false;
                            foreach (Contributor contributor in freeContributors)
                            {
                                if (found) break;
                                foreach (Skill contSkill in contributor.lista_skill)
                                {
                                    if (contSkill.name == reqSkill.name && contSkill.level >= reqSkill.level)
                                    {
                                        tmp = contributor;
                                        project.number_contributor--;
                                        project.list_contributor.Add(contributor);
                                        soddisfatte.Add(reqSkill);
                                        found = true;
                                        break;
                                    }
                                }
                            }
                            if (tmp != null)
                                freeContributors.Remove(tmp);
                        }
                        if (project.number_contributor == 0)
                        {
                            assingedProjects.Add(project);
                        }

                        calendar.Add(assingedProjects);
                    }
                }

                //aggiornare e controllare se un progetto è finito
                foreach (Project project in projects)
                {
                    if (assingedProjects.Contains(project))
                        project.duration--;
                    if (project.duration == 0)
                    {
                        endProjects.Add(project);
                        assingedProjects.Remove(project);
                        int delay = day - project.day_to_terminate;
                        if (delay < 0) delay = 0;
                        score += project.score - delay;


                        //migliorare le skills


                        foreach (Contributor contributor in project.list_contributor)
                        {
                            freeContributors.Add(contributor);
                        }
                    }
                }
            }
            return endProjects;
        }
        private static void fileWrite(List<Project> completedProjects)
        {
            string path = "./OutputFiles/results.txt";
            string text = completedProjects.Count + "\n"; //PRIMA RIGA E' NUMERO PROGETTI

            foreach (Project item in completedProjects)
            {
                text += item.name + "\n"; //add project name
                foreach (Contributor person in item.list_contributor)
                { //importante, lista di contributor in ordine già!
                    text += person.name + " "; //add people
                }
            }
            File.WriteAllText(path, text);
        }
    }
}
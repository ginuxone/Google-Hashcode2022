using System;
using System.Collections.Generic;
namespace Google_Hashcode2022
{
    public class Project : IComparable<Project>
    {
        public string name;

        public int score;

        public int day_to_terminate;

        public int number_contributor;
        public int duration;
        public List<Skill> skill_list_required;
        public List<Contributor> list_contributor;
        public Project(string name, int score, int day_to_terminate, int number_contributor, int duration, List<Skill> skill_list_required)
        {
            this.name = name;
            this.score = score;
            this.number_contributor = number_contributor;
            this.duration = duration;
            this.day_to_terminate = day_to_terminate;
            this.skill_list_required = skill_list_required;
            this.list_contributor = new List<Contributor>();
        }

        public Project(string name, int score, int day_to_terminate, int number_contributor, int duration)
        {
            this.name = name;
            this.score = score;
            this.number_contributor = number_contributor;
            this.duration = duration;
            this.day_to_terminate = day_to_terminate;
            this.skill_list_required = new List<Skill>();
            this.list_contributor = new List<Contributor>();
        }

        public Project(string name, int score, int day_to_terminate, int number_contributor, int duration, List<Skill> skill_list_required, List<Contributor> list_contributor)
        {
            this.name = name;
            this.score = score;
            this.number_contributor = number_contributor;
            this.duration = duration;
            this.day_to_terminate = day_to_terminate;
            this.skill_list_required = skill_list_required;
            this.list_contributor = list_contributor;
        }

        public Project(string name)
        {
            this.name = name;
            this.score = -1;
            this.number_contributor = -1;
            this.duration = -1;
            this.day_to_terminate = -1;
            this.skill_list_required = new List<Skill>();
            this.list_contributor = new List<Contributor>();
        }

        public int CompareTo(Project x)
        {
            return this.duration - x.duration;
        }

        public int compareTo_duration(Project p)
        {
            return this.duration - p.duration;
        }

        public int compareTo_end(Project p)
        {
            return this.day_to_terminate - p.day_to_terminate;
        }

        public float compareTo_rap_score_duration(Project p) {
            return this.score/this.duration - p.score/p.duration;
        }


            }*/
        }
        public List<Contributor> end_project(List<Contributor> lista) { //toDO --> aumentare livello dei contributor

            List<Skill> max_lv = new List<Skill>();

            for (int k= 0; k< this.skill_list_required.Count; k++ ) {
                Skill s = this.skill_list_required[k];
                bool edit = false;
                foreach(Contributor c in this.list_contributor) {
                    for(int i =0; i< c.lista_skill.Count; i++) {
                        Skill ss = c.lista_skill[i];
                        if(ss.conmpareTo_name(s)== 0) {
                            if (!edit ){
                            edit = true;
                            max_lv[k] = ss;
                            }
                            else if(max_lv[k].level < ss.level)
                                max_lv[k]= ss;
                        }
                    }
                }       
            }

            foreach(Skill s in max_lv) {
                foreach(Contributor c in this.list_contributor) {
                    foreach(Contributor cc in lista) {
                        if(cc.name == c.name) {
                            foreach(Skill ss in cc.lista_skill) {
                                if (ss.name == s.name && s.level> ss.level) {
                                   ++ ss.level;
                                }
                            }
                        }
                    }
                }
            }

        return lista;
        }
    }
}
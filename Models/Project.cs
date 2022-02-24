using System;
using System.Collections.Generic;
namespace Google_Hashcode2022
{
    class Project  {
        string name;

        int score;

        int day_to_terminate;

        int number_contributor;
        int duration;
        Dictionary<String, int> skill_list_required;

        List<Contributor> list_contributor;
        public Project(string name, int score, int day_to_terminate, int number_contributor, int duration,  Dictionary<String, int> skill_list_required) {
            this.name = name;
            this.score= score;
            this.number_contributor= number_contributor;
            this.duration= duration;
            this.day_to_terminate= day_to_terminate;
            this.skill_list_required= skill_list_required;
            this.list_contributor= new List<Contributor>();
        }

        public Project(string name, int score, int day_to_terminate, int number_contributor, int duration,  Dictionary<String, int> skill_list_required, List<Contributor> list_contributor) {
            this.name = name;
            this.score= score;
            this.number_contributor= number_contributor;
            this.duration= duration;
            this.day_to_terminate= day_to_terminate;
            this.skill_list_required= skill_list_required;
            this.list_contributor= list_contributor;
        }
    }
}
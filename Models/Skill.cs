namespace Google_Hashcode2022{
    public class Skill {
        public string name = "";
        public int level;

        public Skill(string name, int level)
        {
            this.name = name;
            this.level = level;
        }

        public int conmpareTo_name(Skill s){
            return this.name.CompareTo(s.name);
        }
        public int compareTo_level(Skill s) {
            return this.level - s.level;
        }

       
    }
}

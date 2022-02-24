using System.Collections.Generic;

namespace Google_Hashcode2022
{
   public class Contributor{
       public String name;
        public List<Skill> lista_skill;

        public Contributor(string name, List<Skill> lista)
        {
            this.name = name;
            this.lista_skill = lista;
        }

        public Contributor(string n)
        {
            this.name = n;
            this.lista_skill = new List<Skill>();
        }
    }
}
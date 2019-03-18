using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Odev1._0
{
     public class Takım
    {
        private string name;
        private List<Asker> team;

        public Takım()
        {
            this.team = new List<Asker>();
        }
        public List<Asker> createTeam(int teamNumber)
        {
            // takım belirleme
            if (teamNumber == 1)
                this.name = "First Team";
            else if (teamNumber == 2)
                this.name = "Second Team";
            else this.name = null;
            byte countOfTeam = 0;

            Random random = new Random();
            int x = random.Next(0, 2); // yüzbaşı ekliyorum 1 yada 0
            if (x == 1)
            {
                this.team.Add(new Yuzbasi());
                countOfTeam++;
                
            }

            x = random.Next(1, 3); // 1 veya 2 tane
            for (int i = 0; i < x; i++)
            {
                this.team.Add(new Tegmen());
                countOfTeam++;
            }
            for (int i = 0; i < 7 - countOfTeam; i++)
                this.team.Add(new Er());

            return this.team;
        }
        public string getName()
        { return this.name; }


    }
}

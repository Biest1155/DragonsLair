using System.Collections.Generic;

namespace DragonsLair_1
{
    public class Team
    {
        public string Name { get; set; }
        public int Wins { get; set; }

        public Team(string teamName)
        {
            Name = teamName;
            Wins = 0;
        }
    }
}

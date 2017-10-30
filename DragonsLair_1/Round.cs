using System.Collections.Generic;

namespace DragonsLair_1
{
    public class Round
    {
        private List<Match> matches = new List<Match>();
        private Team FreeRider;
        public List<Match> GetMatches()
        {
            return matches;
        }
        
        public void AddMatch(Match m)
        {
            matches.Add(m);
        }

        public Match GetMatch(string teamName1, string teamName2)
        {
            Match match = new Match();
            foreach(Match m in matches)
            {
                if(teamName1 == m.FirstOpponent.Name && teamName2 == m.SecondOpponent.Name)
                {
                    match = m;
                }                
            }
            return match;
        }

        public bool IsMatchesFinished()
        {
            bool finished = false;
            foreach(Match m in matches)
            {
                if (m.Winner != null)
                {
                    finished = true;
                }
                else
                {
                   finished = false;
                }
            }
            return finished;            
        }

        public List<Team> GetWinningTeams()
        {
            List<Team> WinningTeams = new List<Team>();

            foreach (Match m in matches)
            {
                    WinningTeams.Add(m.Winner);                
            }
            return WinningTeams;
        }

        public List<Team> GetLosingTeams()
        {
            List<Team> LosingTeams = new List<Team>();

            foreach (Match m in matches)
            {
                if (m.FirstOpponent == m.Winner)
                {
                    LosingTeams.Add(m.SecondOpponent);
                }
                else
                {
                    LosingTeams.Add(m.FirstOpponent);
                }
            }
            return LosingTeams;
        }
        public Team GetFreeRider()
        {
            return FreeRider;
        }
        public void AddFreeRider(Team FreeRider)
        {
            this.FreeRider = FreeRider;
        }
    }
}

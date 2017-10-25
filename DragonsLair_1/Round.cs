using System.Collections.Generic;

namespace DragonsLair_1
{
    public class Round
    {
        private List<Match> matches = new List<Match>();       
        
        public void AddMatch(Match m)
        {
            matches.Add(m);
        }

        public Match GetMatch(string teamName1, string teamName2)
        {
            // TODO: Implement this method
            return null;
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
                if (m.FirstOpponent == m.Winner)
                {
                    WinningTeams.Add(m.FirstOpponent);
                }
                else
                {
                    WinningTeams.Add(m.SecondOpponent);
                }
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
    }
}

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
            // TODO: Implement this method
            return false;
        }

        public List<Team> GetWinningTeams()
        {
            //foreach (Match m in matches)
            //{
            //    if (m.FirstOpponent == m.Winner)
            //    {
            //        GetWinningTeams().Add(m.FirstOpponent);
            //    }
            //    else
            //    {
            //        GetWinningTeams().Add(m.SecondOpponent);
            //    }
            //}
            return GetWinningTeams();
        }

        public List<Team> GetLosingTeams()
        {
            //foreach(Match m in matches)
            //{
            //    if (m.FirstOpponent == m.Winner) {
            //        GetLosingTeams().Add(m.SecondOpponent);
            //    }
            //    else
            //    {
            //        GetLosingTeams().Add(m.FirstOpponent);
            //    }
            //}
            return GetLosingTeams();
        }
    }
}

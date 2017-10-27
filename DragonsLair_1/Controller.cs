using System;
using System.Collections.Generic;

namespace DragonsLair_1
{
    public class Controller
    {
        private TournamentRepo tournamentRepository = new TournamentRepo();

        public void ShowScore(string tournamentName)
        {
            /*
             * TODO: Calculate for each team how many times they have won
             * Sort based on number of matches won (descending)
             */
            List<Team> Winners = new List<Team>();
            Tournament CurrentTournament = tournamentRepository.GetTournament(Console.ReadLine());

            for (int i = 0; i > CurrentTournament.GetNumberOfRounds(); i++) {
                Round CurrentRound = CurrentTournament.GetRound(i);
                foreach(Team t in CurrentRound.GetWinningTeams())
                {
                    Winners.Add(t);
                }             
                    }
            Console.WriteLine("Implement this method!");
        }

        public void ScheduleNewRound(string tournamentName, bool printNewMatches = true)
        {
            // Do not implement this method
        }

        public void SaveMatch(string tournamentName, int roundNumber, string team1, string team2, string winningTeam)
        {
            // Do not implement this method
        }
    }
}

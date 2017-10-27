using System;
using System.Collections.Generic;
using System.Linq;

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

            Tournament CurrentTournament = tournamentRepository.GetTournament(tournamentName);
            List<Team> teams = CurrentTournament.GetTeams();
            List<Team> Tsorted = new List<Team>();

            int[] score = new int[teams.Count];
            int[] Ssorted = new int[teams.Count];

            //creation of score array
            for (int i = 0; i < CurrentTournament.GetNumberOfRounds(); i++)
            {
                Round CurrentRound = CurrentTournament.GetRound(i);
                for (int y = 0; y < teams.Count; y++)
                {
                    foreach (Team t in CurrentRound.GetWinningTeams())
                    {
                        if (teams[y].Name == t.Name)
                        {
                            score[y]++;
                        }
                    }
                }
            }

            //sorting
            for (int i = 0; i < teams.Count; i++)
            {
                int index = Array.IndexOf(score, score.Max());
                Tsorted.Add(teams[index]);
                Ssorted[i] = score[index];
                score[index]=-1;
            }

            //print
            for (int i = 0; i < teams.Count; i++)
            {
                Console.WriteLine("Name: " + Tsorted[i].Name + " Score: " + Ssorted[i] + "\n");
            }
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

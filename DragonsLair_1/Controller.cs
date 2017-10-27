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

            int[] score = new int[teams.Count];

            for (int i = 0; i < CurrentTournament.GetNumberOfRounds(); i++)
            {
                Round CurrentRound = CurrentTournament.GetRound(i);
                for (int y = 0; y < CurrentRound.GetWinningTeams().Count; y++)
                {
                    foreach (Team t in teams)
                    {
                        if (t.Name == CurrentRound.GetWinningTeams()[y].Name)
                        {
                            score[y]++;
                        }
                    }
                }
            }
            for (int i = 0; i < teams.Count; i++)
            {
                int x = i;
                while (x < score.Length - 1 && score[x] < score[x + 1])
                {
                    int y = score[x];
                    Team Temp = teams[x];
                    score[x] = score[x + 1];
                    teams[x] = teams[x + 1];
                    score[x + 1] = y;
                    teams[x + 1] = Temp;

                    x++;
                    i++;
                }
            }
            for (int i = 0; i < teams.Count; i++)
            {
                Console.WriteLine("Name: " + teams[i].Name + " Score: " + score[i] + "\n");
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

﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DragonsLair_1
{
    public class Controller
    {
        private TournamentRepo tournamentRepository = new TournamentRepo();

        public void ShowScore(string tournamentName)
        {
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
                        if (t != null)
                        {
                            if (teams[y].Name == t.Name)
                            {
                                score[y]++;
                            }
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
            Tournament CurrentTournament = tournamentRepository.GetTournament(tournamentName);
            int NoR = CurrentTournament.GetNumberOfRounds();
            bool isRoundFinished;
            List<Team> teams = new List<Team>();
            Round LastRound = new Round();

            if (NoR == 0)
            {
                teams = CurrentTournament.GetTeams();


                if (teams.Count > 1)
                {
                    //shuffle
                    int n = teams.Count;
                    while (n > 1)
                    {
                        Random rng = new Random();
                        n--;
                        int k = rng.Next(n + 1);
                        Team team = teams[k];
                        teams[k] = teams[n];
                        teams[n] = team;
                    }
                    //end of shuffle
                    Round NewRound = new Round();
                    if (teams.Count % 2 == 1)
                    {

                        Team newFreeRider = new Team("newFreeRider");
                        newFreeRider = teams[teams.Count - 1];
                        teams.Remove(newFreeRider);
                        NewRound.AddFreeRider(newFreeRider);
                    }

                    while (teams.Count > 0)
                    {
                        Match match = new Match();
                        Team first = teams[0];
                        teams.Remove(teams[0]);
                        Team second = teams[0];
                        teams.Remove(teams[0]);

                        match.FirstOpponent = first;
                        match.SecondOpponent = second;
                        NewRound.AddMatch(match);
                    }
                    CurrentTournament.AddRound(NewRound);
                    Console.WriteLine("New round: " + (NoR + 1) + " was added to " + CurrentTournament.Name + "\n" + "with the following matches");
                    foreach (Match match in NewRound.GetMatches())
                    {
                        Console.WriteLine(match.FirstOpponent.Name + " VS " + match.SecondOpponent.Name);
                    }
                }
            }
            else
            {
                LastRound = CurrentTournament.GetRound(NoR - 1);
                isRoundFinished = LastRound.IsMatchesFinished();
                if (isRoundFinished)
                {
                    teams = LastRound.GetWinningTeams();
                    if (teams.Count > 1)
                    {
                        //shuffle
                        int n = teams.Count;
                        while (n > 1)
                        {
                            Random rng = new Random();
                            n--;
                            int k = rng.Next(n + 1);
                            Team team = teams[k];
                            teams[k] = teams[n];
                            teams[n] = team;
                        }
                        //end of shuffle

                        Round NewRound = new Round();

                        if (teams.Count % 2 == 1)
                        {
                            Team oldFreeRider = LastRound.GetFreeRider();
                            Team newFreeRider = new Team("newFreeRider");
                            for (int x = 0; oldFreeRider != newFreeRider; x++)
                            {
                                newFreeRider = teams[x];
                            }
                            teams.Remove(newFreeRider);
                            teams.Add(oldFreeRider);
                            NewRound.AddFreeRider(newFreeRider);
                        }

                        for (int i = 0; i < teams.Count / 2; i++)
                        {
                            Match match = new Match();
                            Team first = teams[0];
                            teams.Remove(teams[0]);
                            Team second = teams[0];
                            teams.Remove(teams[0]);

                            match.FirstOpponent = first;
                            match.SecondOpponent = second;
                            NewRound.AddMatch(match);
                        }
                        CurrentTournament.AddRound(NewRound);
                        Console.WriteLine("New round: " + (NoR + 1) + " was added to " + CurrentTournament.Name + "\n" + "with the following matches");
                        foreach (Match match in NewRound.GetMatches())
                        {
                            Console.WriteLine(match.FirstOpponent.Name + " VS " + match.SecondOpponent.Name);
                        }
                    }
                    else
                    {
                        CurrentTournament.SetStatus("Finished");
                    }
                }
                else
                {
                    Console.WriteLine("Error round not finished");
                }
            }
        }        
        

        public void SaveMatch(string tournamentName, int roundNumber, string team1, string team2, string winningTeam)
        {
            Tournament currenttournament = tournamentRepository.GetTournament(tournamentName);

            Round Currentround = currenttournament.GetRound(roundNumber-1);

            Match currentmatch = Currentround.GetMatch(team1, team2);

            if (currentmatch != null)
            {
                if (winningTeam==team1||winningTeam==team2) {
                    currentmatch.Winner = currenttournament.GetTeam(winningTeam);
                    Console.WriteLine("Winner has been set");
                }
                else
                {
                    Console.WriteLine("The chosen winner is neither team 1 or 2");
                }
            }
            else
            {
                Console.WriteLine("Match not found");
            }
        }
    }
}

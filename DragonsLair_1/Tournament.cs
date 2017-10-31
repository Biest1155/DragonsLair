using System;
using System.Collections.Generic;

namespace DragonsLair_1
{
    public class Tournament
    {
        public string Name { get; set; }
        private string Status;
        public Tournament(string tournamentName)
        {
            Name = tournamentName;
        }

        public List<Team> Teams = new List<Team>();
        private List<Round> rounds = new List<Round>();

        public List<Team> GetTeams()
        {
            return new List<Team>(new Team[] {
                new Team("The Valyrians"),
                new Team("The Spartans"),
                new Team("The Cretans"),
                new Team("The Thereans"),
                new Team("The Coans"),
                new Team("The Cnideans"),
                new Team("The Megareans"),
                new Team("The Corinthians")
            });            
        }

        public int GetNumberOfRounds()
        {
            return rounds.Count;
        }
        
        public Round GetRound(int idx)
        {
            return rounds[idx];
        }

        internal void AddRound(Round newRound)
        {
            rounds.Add(newRound);
        }

        public void SetStatus(string Status)
        {
            this.Status = Status;
        }
    }
}

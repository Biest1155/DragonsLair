using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DragonsLair_1
{
    [TestClass]
    public class DragonsLairTests
    {
        Tournament currentTournament;
        Controller controller;

        [TestInitialize]
        public void SetupForTest()
        {
            currentTournament = new Tournament("Vinter Turnering");
        }

        [TestMethod]
        public void TournamentHasEvenNumberOfTeams()
        {
            int numberOfTeams = currentTournament.GetTeams().Count;
            Assert.AreEqual(0, numberOfTeams % 2);
        }

        [TestMethod]
        public void EqualNumberOfWinnersAndLosersPerRound()
        {
            int numberOfRounds = currentTournament.GetNumberOfRounds();
            for (int round = 0; round < numberOfRounds -1; round++)
            {
                Round currentRound = currentTournament.GetRound(round);
                int numberOfWinningTeams = currentRound.GetWinningTeams().Count;
                int numberOfLosingTeams = currentRound.GetLosingTeams().Count;
                Assert.AreEqual(numberOfWinningTeams, numberOfLosingTeams);
            }
        }

        [TestMethod]
        public void OneWinnerInLastRound()
        {
            // Verifies there is exactly one winner in last round
            int numberOfRounds = currentTournament.GetNumberOfRounds();
            Round currentRound = currentTournament.GetRound(numberOfRounds - 1);
            int numberOfWinningTeams = currentRound.GetWinningTeams().Count;
            Assert.AreEqual(1, numberOfWinningTeams);
        }

        [TestMethod]
        public void AllMatchesInPreviousRoundsFinished()
        {
            bool matchesFinished = true;
            int numberOfRounds = currentTournament.GetNumberOfRounds();
            for (int round = 0; round < numberOfRounds - 1; round++)
            {
                Round currentRound = currentTournament.GetRound(round);
                if (currentRound.IsMatchesFinished() == false)
                    matchesFinished = false;
            }
            Assert.AreEqual(true, matchesFinished);
        }
        [TestMethod]

        public void CheckWinsforeachplayer()
        {
            List<Team> Teams;
            foreach(Team t in Teams)
            {
                int expected;
                switch (t.Name)
                {
                    case "The Valyrians":
                        expected = 2;
                        break;                                   
                    case "The Thereans":
                        expected = 1;
                        break;
                    case "The Coans":
                        expected = 3;
                        break;                                      
                    case "The Corinthians":
                        expected = 1;
                        break;
                    default:
                        expected = 0;
                        break;
                }                
                Assert.AreEqual(expected,t.Wins);
            }
        }
    }
}
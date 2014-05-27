using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp.net.mvc.charlal1.MelbourneCupOfficeSweepstakes.Models
{
    public class DatabaseManager
    {
        private MelbourneCupDbContext db = new MelbourneCupDbContext();

        public DatabaseManager()
        {
        }

        public Player CreateNewPlayer(DbView signUpFormData)
        {
            // Get the new player fromt he sign up form data
            Player newPlayer = signUpFormData.SignUpPlayer;

            // Assign random horses to the new player            
            newPlayer.Horses = AssignHorses(newPlayer.NoHorses);

            return newPlayer;
        }

        private List<Horse> AssignHorses(int pickedNoHorses)
        {
            // Create list for assigned horses
            List<Horse> assignedHorses = new List<Horse>();

            // Make a random instance for the horse allocation
            Random rGen = new Random();

            // Get the latest available horse
            List<Horse> availableHorses = GetAvailableHorses();

            // For each horse that player has chosen
            for (int i = 0; i < pickedNoHorses; i++)
            {
                // Pick random horse
                int pick = rGen.Next(availableHorses.Count);

                // Gen new pick if horse is already in the list
                while (assignedHorses.Contains(availableHorses[pick]))
                {
                    pick = rGen.Next(availableHorses.Count);
                }

                // Add the picked horse to the new players horse list
                assignedHorses.Add(availableHorses[pick]);
            }

            return assignedHorses;
        }

        public bool[] AddPlayer(Player newPlayer, bool modelStateIsValid)
        {
            // Get all players from db
            List<Player> dbPlayers = db.Players.ToList();

            // Set the player exists flag to false
            bool nameExists = false;
            bool emailExists = false;

            // Test is player name or email exists in db
            foreach (Player p in dbPlayers)
            {
                if (p.Name.Equals(newPlayer.Name))
                    nameExists = true;
                // If the email matchs set the flag to true
                if (p.Email.Equals(newPlayer.Email))
                    emailExists = true;

            }

            // If there is no player in the db AND all inputs are valid
            if (nameExists == false && emailExists == false && modelStateIsValid)
            {
                // add new person to the Dbset
                db.Players.Add(newPlayer);

                // Save changes to db
                db.SaveChanges();
            }

            return new bool[] { nameExists, emailExists };
        }

        public List<Horse> GetAvailableHorses()
        {
            // Get latest db information
            // This seems to be needed for the relationships between the player table and horses table
            List<Horse> dbHorses = db.Horses.ToList();
            List<Player> dbPlayers = db.Players.ToList();

            // Make a new list for all available horses
            List<Horse> availableHorses = new List<Horse>();

            // Find all the horses from the db that have a player assigned to them
            foreach (Horse h in dbHorses)
            {
                // If the horse has no player add it to the available horses list
                if (h.player == null)
                    availableHorses.Add(h);
            }

            return availableHorses;
        }

        public Status GetSweepstakeStatus()
        {
            // Create sweepstakes information for the webpage
            Status sweepstakeStatus = new Status();
            sweepstakeStatus.BettingPlayers = new List<Player>();
            sweepstakeStatus.BettingPlayers = db.Players.ToList();
            sweepstakeStatus.BettingPool = 0;

            // Loops through all betting players and add the bets to the pool
            foreach (var bettingPlayers in sweepstakeStatus.BettingPlayers)
            {
                // Each bet is worth $10 * amount of horses the player has bet on
                sweepstakeStatus.BettingPool += (10 * bettingPlayers.Horses.Count);
            }

            return sweepstakeStatus;
        }
    }
}
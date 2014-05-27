using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp.net.mvc.charlal1.MelbourneCupOfficeSweepstakes.Models;

namespace asp.net.mvc.charlal1.MelbourneCupOfficeSweepstakes.Controllers
{
    public class RaceController : Controller
    {
        private MelbourneCupDbContext db = new MelbourneCupDbContext();

        private DatabaseManager dbm = new DatabaseManager();

        //
        // GET: /RunRace/

        public ActionResult RunRace()
        {
            // Get all horses and players from db
            List<Horse> dbHorses = db.Horses.ToList();
            List<Player> dbPlayers = db.Players.ToList();

            // Get all available horses
            List<Horse> availableHorses = dbm.GetAvailableHorses();

            // Get the latest sweepstake status
            Status sweepstakeStatus = dbm.GetSweepstakeStatus();

            // Create list of horses being bet on
            List<Horse> horsesBetOn = new List<Horse>();

            // Loop through the sweepstake betting players and add thier horses to the list
            foreach (var player in sweepstakeStatus.BettingPlayers)
                horsesBetOn.AddRange(player.Horses);

            // Create a new list ordered by the finishing place
            List<Horse> winningHorses = horsesBetOn.OrderBy(h => h.FinishingPlace).ToList();

            // Allocate winnings
            winningHorses[0].player.Winnings += (int)(sweepstakeStatus.BettingPool * 0.5);                      // 50% of pool 
            winningHorses[1].player.Winnings += (int)(sweepstakeStatus.BettingPool * 0.25);                     // 25% of pool
            winningHorses[2].player.Winnings += (int)(sweepstakeStatus.BettingPool * 0.15);                     // 15% of pool
            winningHorses[winningHorses.Count - 1].player.Winnings += (int)(sweepstakeStatus.BettingPool * 0.10); // 10% of pool

            // Get new dbview ready
            DbView dbView = new DbView { AllHorses = availableHorses, AllPlayers = dbPlayers, SweepstakeStatus = sweepstakeStatus, WinningHorses = winningHorses };

            // Add view to tempData for when page redirects
            TempData["raceResults"] = dbView;

            return RedirectToAction("RaceResult", "Home");
        }
    }
}

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

        //
        // GET: /Results/

        public ActionResult RunRace()
        {
            

            List<Horse> dbHorses = db.Horses.ToList();
            List<Player> dbPlayers = db.Players.ToList();

            List<Horse> availableHorses = new List<Horse>();

            foreach (Horse h in dbHorses)
            {
                if (h.player == null)
                    availableHorses.Add(h);

            }

            Status sweepstakeStatus = new Status();
            sweepstakeStatus.BettingPlayers = new List<Player>();
            sweepstakeStatus.BettingPlayers = db.Players.ToList();
            sweepstakeStatus.BettingPool = 0;

            foreach (var bettingPlayers in sweepstakeStatus.BettingPlayers)
            {
                sweepstakeStatus.BettingPool += (10 * bettingPlayers.Horses.Count);
            }

            List<Horse> horsesBetOn = new List<Horse>();

            foreach (var player in sweepstakeStatus.BettingPlayers)
            {
                horsesBetOn.AddRange(player.Horses);
            }

            List<Horse> winningHorses = horsesBetOn.OrderBy(h => h.FinishingPlace).ToList();



            foreach (var bettingPlayer in sweepstakeStatus.BettingPlayers)
            {
                foreach (var horse in bettingPlayer.Horses)
                {
                    if (horse == horsesBetOn[0])
                        bettingPlayer.Winnings += (int)(sweepstakeStatus.BettingPool * 0.5);

                    if (horse == horsesBetOn[1])
                        bettingPlayer.Winnings += (int)(sweepstakeStatus.BettingPool * 0.25);

                    if (horse == horsesBetOn[2])
                        bettingPlayer.Winnings += (int)(sweepstakeStatus.BettingPool * 0.15);

                    if (horse == horsesBetOn[horsesBetOn.Count - 1])
                        bettingPlayer.Winnings += (int)(sweepstakeStatus.BettingPool * 0.10);
                    
                }
            }



            

            DbView dbView = new DbView { AllHorses = availableHorses, AllPlayers = dbPlayers, SweepstakeStatus = sweepstakeStatus, WinningHorses=horsesBetOn };

            TempData["raceResults"] = dbView;
            //return View(dbView);
            return RedirectToAction("RaceResult", "Home");
        }

    }
}

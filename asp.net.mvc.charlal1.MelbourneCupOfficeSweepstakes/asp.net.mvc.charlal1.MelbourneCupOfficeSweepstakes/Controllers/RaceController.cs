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

            Status sweepstakeStatus = new Status();
            sweepstakeStatus.BettingPlayers = new List<Player>();
            sweepstakeStatus.BettingPlayers = db.Players.ToList();
            sweepstakeStatus.BettingPool = sweepstakeStatus.BettingPlayers.Count * 10;

            List<Horse> horses = db.Horses.ToList();

            foreach (var bettingPlayer in sweepstakeStatus.BettingPlayers)
            {
                foreach (var horse in bettingPlayer.Horses)
                {
                    if (horse.FinishingPlace == 1)
                        bettingPlayer.Winnings += (int)(sweepstakeStatus.BettingPool * 0.5);

                    if (horse.FinishingPlace == 2)
                        bettingPlayer.Winnings += (int)(sweepstakeStatus.BettingPool * 0.25);

                    if (horse.FinishingPlace == 3)
                        bettingPlayer.Winnings += (int)(sweepstakeStatus.BettingPool * 0.15);

                    if (horse.FinishingPlace == 12)
                        bettingPlayer.Winnings += (int)(sweepstakeStatus.BettingPool * 0.10);
                    
                }
            }

            // Get list of horses for race

            // 
            //Race newRace = new Race();
            //newRace.MoneyPool = sweepstakeStatus.BettingPool;
            //newRace.Winners =

            return View(sweepstakeStatus);
        }

    }
}

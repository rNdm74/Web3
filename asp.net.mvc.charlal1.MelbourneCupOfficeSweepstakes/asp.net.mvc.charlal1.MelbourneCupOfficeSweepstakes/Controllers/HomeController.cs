using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp.net.mvc.charlal1.MelbourneCupOfficeSweepstakes.Models;

namespace asp.net.mvc.charlal1.MelbourneCupOfficeSweepstakes.Controllers
{
    public class HomeController : Controller
    {
        private MelbourneCupDbContext db = new MelbourneCupDbContext();


        public ActionResult NewRace()
        {
            //List<Player> dbPlayers = db.Players.ToList();

            //foreach (Player p in dbPlayers)
            //{
                
            //}

            db.Database.Initialize(true);

            return RedirectToAction("SignupForm", "Home"); 
        }

        //
        // GET: /Signup Form/

        public ActionResult RaceResult()
        {
            if (TempData["raceResults"] != null)
            {
                DbView raceResultDbView = (DbView) TempData["raceResults"];

                return View("SignupForm", raceResultDbView);
            }

            return RedirectToAction("SignupForm", "Home");
        }

        //
        // POST: /RaceResult/
        [HttpPost]
        public ActionResult RaceResult(DbView signUpFormData)
        {
            DbView dbView = ProcessHttpPost(signUpFormData);

            return View("SignupForm", dbView);
        }

        public ActionResult SignupForm() 
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

            
            DbView dbView = new DbView { AllHorses = availableHorses, AllPlayers = dbPlayers, SweepstakeStatus=sweepstakeStatus };

            

            return View(dbView);
        }

        //
        // POST: /Signup Form/
        [HttpPost]
        public ActionResult SignupForm(DbView signUpFormData) 
        {
            DbView dbView = ProcessHttpPost(signUpFormData);

            ModelState.Clear();

            return View("SignupForm", dbView);            
        }

        private DbView ProcessHttpPost(DbView signUpFormData) 
        {
            Player newPlayer = signUpFormData.SignUpPlayer;

            Random rGen = new Random();

            // Get latest db information
            List<Horse> dbHorses = db.Horses.ToList();
            List<Player> dbPlayers = db.Players.ToList();

            // Find available horses
            List<Horse> availableHorses = new List<Horse>();

            foreach (Horse h in dbHorses)
            {
                if (h.player == null)
                    availableHorses.Add(h);
            }

            // Init player horses list
            newPlayer.Horses = new List<Horse>();

            // For each horse that player has chosen
            for (int i = 0; i < newPlayer.NoHorses; i++)
            {
                // Pick random horse
                int pick = rGen.Next(availableHorses.Count);

                while (newPlayer.Horses.Contains(availableHorses[pick]))
                {
                    pick = rGen.Next(availableHorses.Count);
                }

                newPlayer.Horses.Add(availableHorses[pick]);
            }


            bool playerExists = false;

            // Test is player exists in db
            foreach (Player p in dbPlayers)
            {
                if (p.Name.Equals(newPlayer.Name))
                    playerExists = true;
            }

            // Add to database
            if (!playerExists && ModelState.IsValid)
            {
                // add new person to the Dbset
                db.Players.Add(newPlayer);
                // Save changes
                db.SaveChanges();
                // hand off to next view
                //return View("SignupResult", newPlayer);
            }

            // Get latest db information
            dbHorses = db.Horses.ToList();
            dbPlayers = db.Players.ToList();

            // Find available horses
            availableHorses = new List<Horse>();

            foreach (Horse h in dbHorses)
            {
                if (h.player == null)
                    availableHorses.Add(h);
            }

            // Create sweepstakes information
            Status sweepstakeStatus = new Status();
            sweepstakeStatus.BettingPlayers = new List<Player>();
            sweepstakeStatus.BettingPlayers = db.Players.ToList();
            sweepstakeStatus.BettingPool = 0;

            foreach (var bettingPlayers in sweepstakeStatus.BettingPlayers)
            {
                sweepstakeStatus.BettingPool += (10 * bettingPlayers.Horses.Count);
            }

            // Update dbView
            return new DbView { AllHorses = availableHorses, AllPlayers = dbPlayers, SweepstakeStatus = sweepstakeStatus, PlayerExists = playerExists, SignUpPlayer=new Player() };
        }
    }
}

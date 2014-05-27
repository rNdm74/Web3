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

        private DatabaseManager dbm = new DatabaseManager();
        //
        // GET: /SignupForm/
        //
        // This is loads initial database info for the user

        public ActionResult SignupForm()
        {
            List<Player> dbPlayers = db.Players.ToList();
            List<Horse> dbHorses = db.Horses.ToList();
            List<Horse> availableHorses = dbm.GetAvailableHorses();
            Status sweepstakeStatus = dbm.GetSweepstakeStatus();

            DbView dbView = new DbView { AllHorses = availableHorses, AllPlayers = dbPlayers, SweepstakeStatus = sweepstakeStatus };

            return View(dbView);
        }

        //
        // POST: /SignupForm/
        //
        // When a player signs up this processes the form data

        [HttpPost]
        public ActionResult SignupForm(DbView signUpFormData)
        {
            DbView dbView = CreateDbViewFrom(signUpFormData);

            return View("SignupForm", dbView);
        }

        //
        // GET: /RaceResult/
        //
        // Run from the RaceController after the race has been process it is redirected here

        public ActionResult RaceResult()
        {
            // If there is something in tempdata
            if (TempData["raceResults"] != null)
            {
                // Get the dbView from RaceController
                DbView raceResultDbView = (DbView)TempData["raceResults"];
                                
                return View("SignupForm", raceResultDbView);
            }

            return RedirectToAction("SignupForm", "Home");
        }

        //
        // POST: /RaceResult/
        [HttpPost]
        public ActionResult RaceResult(DbView signUpFormData)
        {
            DbView dbView = CreateDbViewFrom(signUpFormData);

            // Clears previous form data inputs for next signup
            ModelState.Clear();

            return View("SignupForm", dbView);
        }

        //
        // GET: /NewRace/
        //
        // Redirects to the main form run when the run race button is clicked

        public ActionResult NewRace()
        {
            // Resets the database to it initial state for new sign ups
            db.Database.Initialize(true);

            return RedirectToAction("SignupForm", "Home"); 
        }

        //
        // ProcessHttpPost
        //
        // Used for SignupForm POST and RaceResult POST
        //
        // This processes the post data from the form and returns a DbView for the view

        private DbView CreateDbViewFrom(DbView signUpFormData)
        {
            // Get the new player fromt he sign up form data
            Player newPlayer = dbm.CreateNewPlayer(signUpFormData);

            // Clears previous form data inputs for next signup
            ModelState.Clear();
            
            // When creating the view the order is IMPORTANT
            DbView dbView = new DbView();
                                 
            // 1. Can add new player to the database
            dbView.PlayerExists = dbm.AddPlayer(newPlayer, ModelState.IsValid);

            // 2. Get available horses
            dbView.AllHorses = dbm.GetAvailableHorses();   

            // 3. Create sweepstakes information for the webpage
            dbView.SweepstakeStatus = dbm.GetSweepstakeStatus();

            // 4. Get latest list of all players in the db
            dbView.AllPlayers = db.Players.ToList();

            // 5. Clears the signup player field in the DbView
            dbView.SignUpPlayer = new Player();
            
            // Returns a new DbView
            return dbView;
        }        
    }
}

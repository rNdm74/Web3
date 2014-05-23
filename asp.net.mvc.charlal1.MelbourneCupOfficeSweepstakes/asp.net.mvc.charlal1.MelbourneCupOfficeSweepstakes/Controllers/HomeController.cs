﻿using System;
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

        //
        // GET: /Signup Form/

        public ActionResult SignupForm() 
        {
            List<Horse> dbHorses = db.Horses.ToList();
            List<Player> dbPlayers = db.Players.ToList();

            DbView dbView = new DbView { AllHorses=dbHorses, AllPlayers=dbPlayers };
            //SeedDatabase();

            return View(dbView);
        }

        //
        // POST: /Signup Form/
        [HttpPost]
        public ActionResult SignupForm(DbView signUpFormData) 
        {
            Player newPlayer = signUpFormData.SignUpPlayer;

            Random rGen = new Random();

            // Randomly select horses
            List<Horse> horses = db.Horses.ToList();

            // Init player horses list
            newPlayer.Horses = new List<Horse>();

            // For each horse that player has chosen
            for (int i = 0; i < newPlayer.NoHorses; i++)
			{
                // Pick random horse
                int pick = rGen.Next(horses.Count);

                // Create horse to modify
                Horse pickedHorse = db.Horses.Find(horses[pick].HorseID);

                // Add the player to the horse
                pickedHorse.player = newPlayer;

                // Modify horse in db
                db.Entry(pickedHorse).State = EntityState.Modified;
                
                // Check if horse is free to allocate
                //if(horses[pick].player.PlayerID != player.PlayerID)
                newPlayer.Horses.Add(horses[pick]);
			}

            if (ModelState.IsValid)
            {
                // add new person to the Dbset
                db.Players.Add(newPlayer);
                // Save changes
                db.SaveChanges();
                // hand off to next view
                return View("SignupResult", newPlayer);  
            }

            // next view will list horses
            return View(newPlayer);
        }

        public ActionResult SweepstakeStatus(Player currentPlayer) 
        {

            Status sweepstakeStatus = new Status();
            sweepstakeStatus.BettingPlayers = new List<Player>();
            sweepstakeStatus.BettingPlayers = db.Players.ToList();
            sweepstakeStatus.BettingPool = 0;

            foreach (var bettingPlayers in sweepstakeStatus.BettingPlayers)
            {
                sweepstakeStatus.BettingPool += 10;
            }

            return View(sweepstakeStatus);
        }

        private void SeedDatabase() 
        {
            var Horses = new List<Horse> 
            {
                new Horse{Form="13X66X10X1", Name="GLASS HARMONIUM",    FinishingPlace=4},
                new Horse{Form="12X3X12X91", Name="DUNADEN",            FinishingPlace=1},
                new Horse{Form="X446X13137", Name="DRUNKEN SAILOR",     FinishingPlace=12},
                new Horse{Form="2573X34844", Name="MANIGHAR",           FinishingPlace=5},
                new Horse{Form="3621X5X406", Name="UNUSUAL SUSPECT",    FinishingPlace=9},
                new Horse{Form="2164112461", Name="FOX HUNT",           FinishingPlace=7},
                new Horse{Form="111X4215X5", Name="LUCAS CRANACH",      FinishingPlace=3},
                new Horse{Form="X025X67009", Name="PRECEDENCE",         FinishingPlace=11},
                new Horse{Form="9X20141053", Name="RED CADEAUX",        FinishingPlace=2},
                new Horse{Form="189X223274", Name="LOST IN THE MOMENT", FinishingPlace=6},
                new Horse{Form="23245X0622", Name="AT FIRST SIGHT",     FinishingPlace=10},
                new Horse{Form="0121X07201", Name="NIWOT",              FinishingPlace=8},
            };

            foreach (Horse h in Horses)
            {
                db.Horses.Add(h);
            }

            db.SaveChanges();
        }
    }
}

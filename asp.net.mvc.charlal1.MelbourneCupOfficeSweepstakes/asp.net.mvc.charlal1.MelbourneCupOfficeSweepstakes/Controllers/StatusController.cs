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
    public class StatusController : Controller
    {
        private MelbourneCupDbContext db = new MelbourneCupDbContext();

        //
        // GET: /Status/

        public ViewResult Index()
        {
            List<Bet> bets = db.Bets.ToList();
            List<Horse> horses = db.Horses.ToList();
            
            List<Player> bettingPlayers = new List<Player>();

            foreach (var bet in bets)
            {
                bet.Player.Horses = GetHorsesList(bet.NoHorses);
                bettingPlayers.Add(bet.Player);
                
                foreach (var horse in bet.Player.Horses)
	            {
                    horses.RemoveAt(horse.HorseID);                    		 
	            }                
            }

            Status currentStatus = new Status { BettingPlayers = bettingPlayers, AvailableHorses = horses };
            db.SweepstakeStatus.Add(currentStatus);
            db.SaveChanges();
            
            return View(db.SweepstakeStatus.ToList());
        }

        private List<Horse> GetHorsesList(int NoHorses)
        {
            Random rGen = new Random();

            List<Horse> pickedHorses = new List<Horse>();

            List<Horse> horseList = db.Horses.ToList();

            for (int i = 0; i < NoHorses; i++)
            {
                int randomNumber = rGen.Next(horseList.Count);

                Horse pickedHorse = horseList[randomNumber];

                horseList.RemoveAt(randomNumber);
                // Check that horse is not in list

                pickedHorses.Add(pickedHorse);
            }

            return pickedHorses;
        }

        //
        // GET: /Status/Details/5

        public ViewResult Details(int id)
        {
            Status status = db.SweepstakeStatus.Find(id);
            return View(status);
        }

        //
        // GET: /Status/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Status/Create

        [HttpPost]
        public ActionResult Create(Status status)
        {
            if (ModelState.IsValid)
            {
                db.SweepstakeStatus.Add(status);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(status);
        }
        
        //
        // GET: /Status/Edit/5
 
        public ActionResult Edit(int id)
        {
            Status status = db.SweepstakeStatus.Find(id);
            return View(status);
        }

        //
        // POST: /Status/Edit/5

        [HttpPost]
        public ActionResult Edit(Status status)
        {
            if (ModelState.IsValid)
            {
                db.Entry(status).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(status);
        }

        //
        // GET: /Status/Delete/5
 
        public ActionResult Delete(int id)
        {
            Status status = db.SweepstakeStatus.Find(id);
            return View(status);
        }

        //
        // POST: /Status/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Status status = db.SweepstakeStatus.Find(id);
            db.SweepstakeStatus.Remove(status);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
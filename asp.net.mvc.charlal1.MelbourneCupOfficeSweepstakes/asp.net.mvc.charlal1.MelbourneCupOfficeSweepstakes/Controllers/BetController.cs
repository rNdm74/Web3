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
    public class BetController : Controller
    {
        private MelbourneCupDbContext db = new MelbourneCupDbContext();

        //
        // GET: /Bet/

        public ViewResult Index()
        {
            return View(db.Bets.ToList());
        }

        //
        // GET: /Bet/Details/5

        public ViewResult Details(int id)
        {
            Bet bet = db.Bets.Find(id);
            return View(bet);
        }

        //
        // GET: /Bet/Create

        public ActionResult Create(Player player)
        {
            Bet bet = new Bet();
            bet.Player = player;
            return View(bet);
        } 

        //
        // POST: /Bet/Create

        [HttpPost]
        public ActionResult Create(Bet bet, Player player)
        {


            if (ModelState.IsValid)
            {
                db.Bets.Add(bet);
                db.SaveChanges();
                return RedirectToAction("Index","Home", bet);  
            }

            return View(bet);
        }
        
        //
        // GET: /Bet/Edit/5
 
        public ActionResult Edit(int id)
        {
            Bet bet = db.Bets.Find(id);
            return View(bet);
        }

        //
        // POST: /Bet/Edit/5

        [HttpPost]
        public ActionResult Edit(Bet bet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bet);
        }

        //
        // GET: /Bet/Delete/5
 
        public ActionResult Delete(int id)
        {
            Bet bet = db.Bets.Find(id);
            return View(bet);
        }

        //
        // POST: /Bet/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Bet bet = db.Bets.Find(id);
            db.Bets.Remove(bet);
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
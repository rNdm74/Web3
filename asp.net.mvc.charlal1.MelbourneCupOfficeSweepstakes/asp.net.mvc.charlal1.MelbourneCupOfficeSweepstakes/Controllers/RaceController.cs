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
    public class RaceController : Controller
    {
        private MelbourneCupDbContext db = new MelbourneCupDbContext();

        //
        // GET: /Race/

        public ViewResult Index()
        {
            return View(db.Races.ToList());
        }

        //
        // GET: /Race/Details/5

        public ViewResult Details(int id)
        {
            Race race = db.Races.Find(id);
            return View(race);
        }

        //
        // GET: /Race/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Race/Create

        [HttpPost]
        public ActionResult Create(Race race)
        {
            if (ModelState.IsValid)
            {
                db.Races.Add(race);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(race);
        }
        
        //
        // GET: /Race/Edit/5
 
        public ActionResult Edit(int id)
        {
            Race race = db.Races.Find(id);
            return View(race);
        }

        //
        // POST: /Race/Edit/5

        [HttpPost]
        public ActionResult Edit(Race race)
        {
            if (ModelState.IsValid)
            {
                db.Entry(race).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(race);
        }

        //
        // GET: /Race/Delete/5
 
        public ActionResult Delete(int id)
        {
            Race race = db.Races.Find(id);
            return View(race);
        }

        //
        // POST: /Race/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Race race = db.Races.Find(id);
            db.Races.Remove(race);
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
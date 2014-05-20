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

        public ActionResult Create()
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
                //db.Horses.Add(h);
            }
                

            //db.SaveChanges();

            return View();
        } 

        //
        // POST: /Bet/Create

        [HttpPost]
        public ActionResult Create(Bet bet)
        {
            if (ModelState.IsValid)
            {
                db.Bets.Add(bet);
                db.SaveChanges();
                return RedirectToAction("Index");  
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
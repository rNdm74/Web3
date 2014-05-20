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
    public class PlayerController : Controller
    {
        private MelbourneCupDbContext db = new MelbourneCupDbContext();

        //
        // GET: /Player/

        public ViewResult Index()
        {
            return View(db.Players.ToList());
        }

        //
        // GET: /Player/Details/5

        public ViewResult Details(int id)
        {
            Player player = db.Players.Find(id);
            return View(player);
        }

        //
        // GET: /Player/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Player/Create

        [HttpPost]
        public ActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                db.Players.Add(player);
                db.SaveChanges();
                return RedirectToAction("Create","Bet", player);  
            }

            return View(player);
        }
        
        //
        // GET: /Player/Edit/5
 
        public ActionResult Edit(int id)
        {
            Player player = db.Players.Find(id);
            return View(player);
        }

        //
        // POST: /Player/Edit/5

        [HttpPost]
        public ActionResult Edit(Player player)
        {
            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(player);
        }

        //
        // GET: /Player/Delete/5
 
        public ActionResult Delete(int id)
        {
            Player player = db.Players.Find(id);
            return View(player);
        }

        //
        // POST: /Player/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Player player = db.Players.Find(id);
            db.Players.Remove(player);
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
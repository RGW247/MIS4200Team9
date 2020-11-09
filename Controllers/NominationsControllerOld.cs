﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MIS4200Team9.DAL;
using MIS4200Team9.Models;

namespace MIS4200Team9.Controllers
{
    public class NominationsControllerOld : Controller
    {
        private MIS4200Team9Context db = new MIS4200Team9Context();

        // GET: Nominations
        public ActionResult Index()
        {
            return View(db.Nominations.ToList());
        }

        // GET: Nominations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nominations nominations = db.Nominations.Find(id);
            if (nominations == null)
            {
                return HttpNotFound();
            }
            return View(nominations);
        }

        // GET: Nominations/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.nomineeID = new SelectList(db.UserDetails, "ID", "fullName");
      
            
            return View();
        }

        // POST: Nominations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nominationID,award,recognizor,recognized,recognizationDate")] Nominations nominations)
        {
            if (ModelState.IsValid)
            {
                Guid memberID;
                Guid.TryParse(User.Identity.GetUserId(), out memberID);
                nominations.recognizor = memberID;
                nominations.recognizationDate = DateTime.Now;
                db.Nominations.Add(nominations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.nomineeID = new SelectList(db.UserDetails, "ID", "fullName");

            return View(nominations);
        }

        // GET: Nominations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nominations nominations = db.Nominations.Find(id);
            if (nominations == null)
            {
                return HttpNotFound();
            }
            return View(nominations);
        }

        // POST: Nominations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nominationID,award,recognizor,recognized,recognizationDate")] Nominations nominations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nominations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nominations);
        }

        // GET: Nominations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nominations nominations = db.Nominations.Find(id);
            if (nominations == null)
            {
                return HttpNotFound();
            }
            return View(nominations);
        }

        // POST: Nominations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nominations nominations = db.Nominations.Find(id);
            db.Nominations.Remove(nominations);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
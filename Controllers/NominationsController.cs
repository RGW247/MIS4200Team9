using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MIS4200Team9.DAL;
using MIS4200Team9.Models;

namespace MIS4200Team9.Controllers
{
    public class NominationsController : Controller
    {
        private MIS4200Team9Context db = new MIS4200Team9Context();

        // GET: Nominations
        public ActionResult Index()
        {
            var nominations = db.Nominations.Include(n => n.UserDetails);
            return View(nominations.ToList());
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
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.UserDetails, "ID", "email");
            return View();
        }

        // POST: Nominations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "coreValueID,coreValue,ID")] Nominations nominations)
        {
            if (ModelState.IsValid)
            {
                db.Nominations.Add(nominations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.UserDetails, "ID", "email", nominations.ID);
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
            ViewBag.ID = new SelectList(db.UserDetails, "ID", "email", nominations.ID);
            return View(nominations);
        }

        // POST: Nominations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "coreValueID,coreValue,ID")] Nominations nominations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nominations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.UserDetails, "ID", "email", nominations.ID);
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

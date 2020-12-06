using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MIS4200Team9.DAL;
using MIS4200Team9.Models;

namespace MIS4200Team9.Controllers
{
    public class UserDetailsController : Controller
    {
        private MIS4200Team9Context db = new MIS4200Team9Context();

        // GET: UserDetails
        public ActionResult Index(string searchString)
        {
            var testusers = from u in db.UserDetails select u;


            if (!String.IsNullOrEmpty(searchString))
            {
                testusers = testusers.Where(u =>
                u.lastName.Contains(searchString)
                   || u.firstName.Contains(searchString));
                return View(testusers.ToList());
            }

            // sort listed of employees ordered by last name
            var employees = db.UserDetails.OrderBy(u => u.lastName);

            return View(employees.ToList());
        }





        // GET: UserDetails/Details/5
        [Authorize]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetails userDetails = db.UserDetails.Find(id);
            if (userDetails == null)
            {
                return HttpNotFound();
            }

            // Leaderboard creation
            var nom = db.Nominations.Where(r => r.nomineeID == id);
            var overall = db.Nominations.Count();
            var nomList = nom.ToList();
            var totalNoms = nomList.Count(); 
            
            
            
            ViewBag.nomCount = totalNoms;

            // Count each award
            //var stewardshipCount = nomList.Where(r => r.award.Equals("Stewardship");
            //var cultureCount = nomList.Where(r => r.award.Equals("Culture"));
            //var excellenceCount = nomList.Where(r => r.award.Equals("Excellence"));
            //var innovationCount = nomList.Where(r => r.award.Equals("Innovation"));
            //var greaterGoodCount = nomList.Where(r => r.award.Equals("GreaterGood"));
            //var balanceCount = nomList.Where(r => r.award.Equals("Balance"));
            //var integrityCount = nomList.Where(r => r.award.Equals("IntegrityAndOpenness");

            //ViewBag.overall = overall;
            ViewBag.totalNoms = totalNoms;
            //ViewBag.stewardshipCount = stewardshipCount;
            //ViewBag.cultureCount = cultureCount;
            //ViewBag.excellenceCount = excellenceCount;
            //ViewBag.innovationCount = innovationCount;
            //ViewBag.greaterGoodCount = greaterGoodCount;
            //ViewBag.balanceCount = balanceCount;
            //ViewBag.integrityCount = integrityCount;




            return View(userDetails);
        }

        // GET: UserDetails/Create

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,email,firstName,lastName,jobTitle,hireDate,photo")] UserDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                Guid memberID;
                Guid.TryParse(User.Identity.GetUserId(), out memberID);
                userDetails.ID = memberID;
                db.UserDetails.Add(userDetails);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(userDetails);
        }

        // GET: UserDetails/Edit/5
        [Authorize]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetails UserDetails = db.UserDetails.Find(id);
            if (UserDetails == null)
            {
                return HttpNotFound();
            }
            Guid memberID;
            Guid.TryParse(User.Identity.GetUserId(), out memberID);
            if (id == memberID)
            {
                return View(UserDetails);
            }
            else
            {
                return View("NotAuthorized");
            }

        }

        // POST: UserDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,email,firstName,lastName,jobTitle,hireDate,photo")] UserDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userDetails);
        }

        // GET: UserDetails/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetails userDetails = db.UserDetails.Find(id);
            if (userDetails == null)
            {
                return HttpNotFound();
            }
            return View(userDetails);
        }

        // POST: UserDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            UserDetails userDetails = db.UserDetails.Find(id);
            db.UserDetails.Remove(userDetails);
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
    


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using MIS4200Team9.DAL;
using MIS4200Team9.Models;

namespace MIS4200Team9.Controllers
{
    public class NominationsController : Controller
    {
        private MIS4200Team9Context db = new MIS4200Team9Context();

        // GET: Nominations
        public ActionResult Index(String SortOrder)
        {

            var nominations = db.Nominations.Include(n => n.nominator).Include(n => n.nominee).OrderByDescending(n => n.recognitionDate);
 

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
        [Authorize]
        public ActionResult Create()
        {
            //ViewBag.recognizer = new SelectList(db.UserDetails, "ID", "email");
            
            string userID = User.Identity.GetUserId();
            SelectList employees = new SelectList(db.UserDetails, "ID", "fullName");
            employees = new SelectList(employees.Where(x => x.Value != userID).ToList(), "Value", "Text");
            ViewBag.nomineeID = employees;
            return View();
        }

        // POST: Nominations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "nominationID,award,recognizor,nomineeID,recognitionDate,description")] Nominations nominations)
        {
            if (ModelState.IsValid)
            {
                Guid memberID;
                Guid.TryParse(User.Identity.GetUserId(), out memberID);
                nominations.recognizor = memberID;
                nominations.recognitionDate = DateTime.Now;
                db.Nominations.Add(nominations);
                db.SaveChanges();
                var recognizorObject = db.UserDetails.Find(nominations.recognizor);
                var recipientObject = db.UserDetails.Find(nominations.nomineeID);
                var recognizorFirstName = recognizorObject.firstName;
                var recognizorLastName = recognizorObject.lastName;
                var recipientFirstName = recipientObject.firstName;
                var recipientLastName = recipientObject.lastName;
                var recepientEmail = recipientObject.email;
                var valueName = nominations.award;
                var valueDescription = nominations.description;

                var message = "Hello" + recipientFirstName + " " + recipientLastName + ", \n\nCongradulations! ";
                message += "You have been recognized by " + recognizorFirstName + " " + recognizorLastName + " for exemplifying one of Centric's core values.";
                message += recognizorFirstName + "\nrecognized you for demonstrating " + valueName + " in the workplace.";
                message += "\n\nOn behaf of Centric,\nthank you for all your hard work!";

                MailMessage myMessage = new MailMessage();
                MailAddress from = new MailAddress("centricvalues@gmail.com", "Centric Values System");
                myMessage.From = from;
                myMessage.To.Add(recepientEmail);
                myMessage.Subject = "Centric Core Values Recognition";
                myMessage.Body = message;
                try
                {
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("centricvalues", "Values2020!");
                    smtp.EnableSsl = true;
                    //smtp.Send(myMessage);
                    TempData["mailError"] = message;
                    return View("mailError");
                }
                catch (Exception ex)
                {
                    TempData["mailError"] = ex.Message;
                    return View("mailError");
                }

            }

            string userID = User.Identity.GetUserId();
            SelectList employees = new SelectList(db.UserDetails, "ID", "fullName");
            employees = new SelectList(employees.Where(x => x.Value != userID).ToList(), "Value", "Text");
            ViewBag.nomineeID = employees;

                //ViewBag.nomineeID = new SelectList(db.UserDetails, "ID", "fullName");

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
            ViewBag.recognizor = new SelectList(db.UserDetails, "ID", "email", nominations.recognizor);
            ViewBag.nomineeID = new SelectList(db.UserDetails, "ID", "email", nominations.nomineeID);
            return View(nominations);
        }

        // POST: Nominations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nominationID,award,recognizor,nomineeID,recognitionDate")] Nominations nominations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nominations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.recognizor = new SelectList(db.UserDetails, "ID", "email", nominations.recognizor);
            ViewBag.nomineeID = new SelectList(db.UserDetails, "ID", "email", nominations.nomineeID);
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

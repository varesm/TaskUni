using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskUni;

namespace TaskUni.Controllers
{
    public class conference_attendersController : Controller
    {
        private UniTaskEntities db = new UniTaskEntities();

        // GET: conference_attenders
        public ActionResult Index()
        {
            var conference_attenders = db.conference_attenders.Include(c => c.Attender).Include(c => c.conference);
            return View(conference_attenders.ToList());
        }

        // GET: conference_attenders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            conference_attenders conference_attenders = db.conference_attenders.Find(id);
            if (conference_attenders == null)
            {
                return HttpNotFound();
            }
            return View(conference_attenders);
        }

        // GET: conference_attenders/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.Attenders, "id", "firstname");
            ViewBag.conference_id = new SelectList(db.conferences, "id", "Title");
            return View();
        }

        // POST: conference_attenders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,conference_id,user_id,isAccepted")] conference_attenders conference_attenders)
        {
            if (ModelState.IsValid)
            {
                db.conference_attenders.Add(conference_attenders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.Attenders, "id", "firstname", conference_attenders.user_id);
            ViewBag.conference_id = new SelectList(db.conferences, "id", "Title", conference_attenders.conference_id);
            return View(conference_attenders);
        }

        // GET: conference_attenders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            conference_attenders conference_attenders = db.conference_attenders.Find(id);
            if (conference_attenders == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.Attenders, "id", "firstname", conference_attenders.user_id);
            ViewBag.conference_id = new SelectList(db.conferences, "id", "Title", conference_attenders.conference_id);
            return View(conference_attenders);
        }

        // POST: conference_attenders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,conference_id,user_id,isAccepted")] conference_attenders conference_attenders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conference_attenders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.Attenders, "id", "firstname", conference_attenders.user_id);
            ViewBag.conference_id = new SelectList(db.conferences, "id", "Title", conference_attenders.conference_id);
            return View(conference_attenders);
        }

        // GET: conference_attenders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            conference_attenders conference_attenders = db.conference_attenders.Find(id);
            if (conference_attenders == null)
            {
                return HttpNotFound();
            }
            return View(conference_attenders);
        }

        // POST: conference_attenders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            conference_attenders conference_attenders = db.conference_attenders.Find(id);
            db.conference_attenders.Remove(conference_attenders);
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

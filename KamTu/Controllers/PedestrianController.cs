using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KamTu.Models;

namespace KamTu.Controllers
{
    public class PedestrianController : Controller
    {
        private KamTuDB db = new KamTuDB();

        //
        // GET: /Pedestrian/

        public ActionResult Index()
        {
            var pedestrians = db.Pedestrians.Include(p => p.Community);
            return View(pedestrians.ToList());
        }

        //
        // GET: /Pedestrian/Details/5

        public ActionResult Details(int id = 0)
        {
            Pedestrian pedestrian = db.Pedestrians.Find(id);
            if (pedestrian == null)
            {
                return HttpNotFound();
            }
            return View(pedestrian);
        }

        //
        // GET: /Pedestrian/Create

        public ActionResult Create()
        {
            ViewBag.CommunityId = new SelectList(db.Communitys, "CommunityId", "Name");
            return View();
        }

        //
        // POST: /Pedestrian/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pedestrian pedestrian)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(pedestrian);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CommunityId = new SelectList(db.Communitys, "CommunityId", "Name", pedestrian.CommunityId);
            return View(pedestrian);
        }

        //
        // GET: /Pedestrian/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Pedestrian pedestrian = db.Pedestrians.Find(id);
            if (pedestrian == null)
            {
                return HttpNotFound();
            }
            ViewBag.CommunityId = new SelectList(db.Communitys, "CommunityId", "Name", pedestrian.CommunityId);
            return View(pedestrian);
        }

        //
        // POST: /Pedestrian/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pedestrian pedestrian)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedestrian).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CommunityId = new SelectList(db.Communitys, "CommunityId", "Name", pedestrian.CommunityId);
            return View(pedestrian);
        }

        //
        // GET: /Pedestrian/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Pedestrian pedestrian = db.Pedestrians.Find(id);
            if (pedestrian == null)
            {
                return HttpNotFound();
            }
            return View(pedestrian);
        }

        //
        // POST: /Pedestrian/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedestrian pedestrian = db.Pedestrians.Find(id);
            db.Persons.Remove(pedestrian);
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
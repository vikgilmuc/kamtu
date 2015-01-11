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
    public class DriverController : Controller
    {
        private KamTuDB db = new KamTuDB();

        //
        // GET: /Driver/

        public ActionResult Index()
        {
            var drivers = db.Drivers.Include(d => d.Community);
            return View(drivers.ToList());
        }

        //
        // GET: /Driver/Details/5

        public ActionResult Details(int id = 0)
        {
            Driver driver = db.Drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        //
        // GET: /Driver/Create

        public ActionResult Create()
        {
            ViewBag.CommunityId = new SelectList(db.Communitys, "CommunityId", "Name");
            return View();
        }

        //
        // POST: /Driver/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Driver driver)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(driver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CommunityId = new SelectList(db.Communitys, "CommunityId", "Name", driver.CommunityId);
            return View(driver);
        }

        //
        // GET: /Driver/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Driver driver = db.Drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            ViewBag.CommunityId = new SelectList(db.Communitys, "CommunityId", "Name", driver.CommunityId);
            return View(driver);
        }

        //
        // POST: /Driver/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Driver driver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(driver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CommunityId = new SelectList(db.Communitys, "CommunityId", "Name", driver.CommunityId);
            return View(driver);
        }

        //
        // GET: /Driver/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Driver driver = db.Drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        //
        // POST: /Driver/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Driver driver = db.Drivers.Find(id);
            db.Persons.Remove(driver);
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
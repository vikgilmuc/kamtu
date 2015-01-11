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
    public class CommunityController : Controller
    {
        private KamTuDB db = new KamTuDB();

        //
        // GET: /Community/

        public ActionResult Index()
        {
            return View(db.Communitys.ToList());
        }

        //
        // GET: /Community/Details/5

        public ActionResult Details(int id = 0)
        {
            Community community = db.Communitys.Find(id);
            if (community == null)
            {
                return HttpNotFound();
            }
            return View(community);
        }

        //
        // GET: /Community/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Community/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Community community)
        {
            if (ModelState.IsValid)
            {
                db.Communitys.Add(community);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(community);
        }

        //
        // GET: /Community/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Community community = db.Communitys.Find(id);
            if (community == null)
            {
                return HttpNotFound();
            }
            return View(community);
        }

        //
        // POST: /Community/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Community community)
        {
            if (ModelState.IsValid)
            {
                db.Entry(community).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(community);
        }

        //
        // GET: /Community/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Community community = db.Communitys.Find(id);
            if (community == null)
            {
                return HttpNotFound();
            }
            return View(community);
        }

        //
        // POST: /Community/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Community community = db.Communitys.Find(id);
            db.Communitys.Remove(community);
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
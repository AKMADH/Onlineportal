using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineEXAM.Models;

namespace OnlineEXAM.Controllers.Admin
{
    public class MaincateogryController : Controller
    {
        private onlineTestEntities1 db = new onlineTestEntities1();

        // GET: Maincateogry
        public ActionResult Index()
        {
            return View(db.maincateogries.ToList());
        }

        // GET: Maincateogry/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            maincateogry maincateogry = db.maincateogries.Find(id);
            if (maincateogry == null)
            {
                return HttpNotFound();
            }
            return View(maincateogry);
        }

        // GET: Maincateogry/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Maincateogry/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MainCateogryID,MainCateogryName,CreatedDate")] maincateogry maincateogry)
        {
            if (ModelState.IsValid)
            {
                db.maincateogries.Add(maincateogry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(maincateogry);
        }

        // GET: Maincateogry/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            maincateogry maincateogry = db.maincateogries.Find(id);
            if (maincateogry == null)
            {
                return HttpNotFound();
            }
            return View(maincateogry);
        }

        // POST: Maincateogry/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MainCateogryID,MainCateogryName,CreatedDate")] maincateogry maincateogry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maincateogry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(maincateogry);
        }

        // GET: Maincateogry/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            maincateogry maincateogry = db.maincateogries.Find(id);
            if (maincateogry == null)
            {
                return HttpNotFound();
            }
            return View(maincateogry);
        }

        // POST: Maincateogry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            maincateogry maincateogry = db.maincateogries.Find(id);
            db.maincateogries.Remove(maincateogry);
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

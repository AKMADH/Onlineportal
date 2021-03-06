﻿using System;
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
    public class TopicsController : Controller
    {
        private onlineTestEntities1 db = new onlineTestEntities1();

        // GET: Topics
        public ActionResult Index()
        {
            var topics = db.Topics.Include(t => t.maincateogry).Include(t => t.Subject);
            return View(topics.ToList());
        }

        // GET: Topics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = db.Topics.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        // GET: Topics/Create
        public ActionResult Create()
        {
            ViewBag.MainCateogryID = new SelectList(db.maincateogries, "MainCateogryID", "MainCateogryName");
            ViewBag.Subject_id = new SelectList(db.Subjects, "Subject_id", "SubjectName");
            return View();
        }

        // POST: Topics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Topic_id,TopicName,MainCateogryID,Subject_id")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Topics.Add(topic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MainCateogryID = new SelectList(db.maincateogries, "MainCateogryID", "MainCateogryName", topic.MainCateogryID);
            ViewBag.Subject_id = new SelectList(db.Subjects, "Subject_id", "SubjectName", topic.Subject_id);
            return View(topic);
        }

        // GET: Topics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = db.Topics.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            ViewBag.MainCateogryID = new SelectList(db.maincateogries, "MainCateogryID", "MainCateogryName", topic.MainCateogryID);
            ViewBag.Subject_id = new SelectList(db.Subjects, "Subject_id", "SubjectName", topic.Subject_id);
            return View(topic);
        }

        // POST: Topics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Topic_id,TopicName,MainCateogryID,Subject_id")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MainCateogryID = new SelectList(db.maincateogries, "MainCateogryID", "MainCateogryName", topic.MainCateogryID);
            ViewBag.Subject_id = new SelectList(db.Subjects, "Subject_id", "SubjectName", topic.Subject_id);
            return View(topic);
        }

        // GET: Topics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = db.Topics.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        // POST: Topics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Topic topic = db.Topics.Find(id);
            db.Topics.Remove(topic);
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

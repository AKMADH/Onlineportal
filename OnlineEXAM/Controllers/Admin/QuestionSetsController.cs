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
    public class QuestionSetsController : Controller
    {
        private onlineTestEntities1 db = new onlineTestEntities1();

        // GET: QuestionSets
        public ActionResult Index()
        {
            var questionSets = db.QuestionSets.Include(q => q.maincateogry).Include(q => q.Subject).Include(q => q.Topic);
            return View(questionSets.ToList());
        }

        // GET: QuestionSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionSet questionSet = db.QuestionSets.Find(id);
            if (questionSet == null)
            {
                return HttpNotFound();
            }
            return View(questionSet);
        }

        // GET: QuestionSets/Create
        public ActionResult Create()
        {
            ViewBag.MainCateogryID = new SelectList(db.maincateogries, "MainCateogryID", "MainCateogryName");
            ViewBag.Subject_id = new SelectList(db.Subjects, "Subject_id", "SubjectName");
            ViewBag.Topic_id = new SelectList(db.Topics, "Topic_id", "TopicName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Question_ID,Question,Option1,Option2,Option3,Option4,correctOption,MainCateogryID,Subject_id,Topic_id")] QuestionSet questionSet)
        {
            if (ModelState.IsValid)
            {
                db.QuestionSets.Add(questionSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MainCateogryID = new SelectList(db.maincateogries, "MainCateogryID", "MainCateogryName", questionSet.MainCateogryID);
            ViewBag.Subject_id = new SelectList(db.Subjects, "Subject_id", "SubjectName", questionSet.Subject_id);
            ViewBag.Topic_id = new SelectList(db.Topics, "Topic_id", "TopicName", questionSet.Topic_id);
            return View(questionSet);
        }

        // GET: QuestionSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionSet questionSet = db.QuestionSets.Find(id);
            if (questionSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.MainCateogryID = new SelectList(db.maincateogries, "MainCateogryID", "MainCateogryName", questionSet.MainCateogryID);
            ViewBag.Subject_id = new SelectList(db.Subjects, "Subject_id", "SubjectName", questionSet.Subject_id);
            ViewBag.Topic_id = new SelectList(db.Topics, "Topic_id", "TopicName", questionSet.Topic_id);
            return View(questionSet);
        }

        // POST: QuestionSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Question_ID,Question,Option1,Option2,Option3,Option4,correctOption,MainCateogryID,Subject_id,Topic_id")] QuestionSet questionSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MainCateogryID = new SelectList(db.maincateogries, "MainCateogryID", "MainCateogryName", questionSet.MainCateogryID);
            ViewBag.Subject_id = new SelectList(db.Subjects, "Subject_id", "SubjectName", questionSet.Subject_id);
            ViewBag.Topic_id = new SelectList(db.Topics, "Topic_id", "TopicName", questionSet.Topic_id);
            return View(questionSet);
        }

        // GET: QuestionSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionSet questionSet = db.QuestionSets.Find(id);
            if (questionSet == null)
            {
                return HttpNotFound();
            }
            return View(questionSet);
        }

        // POST: QuestionSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestionSet questionSet = db.QuestionSets.Find(id);
            db.QuestionSets.Remove(questionSet);
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

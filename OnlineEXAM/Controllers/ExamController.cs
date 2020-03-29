using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineEXAM.Models;

namespace OnlineEXAM.Controllers
{
    public class ExamController : Controller
    {
        private onlineTestEntities1 db = new onlineTestEntities1();

        // GET: Exam
        public ActionResult Index()
        {
            var questionSets = db.QuestionSets.Include(q => q.maincateogry).Include(q => q.Subject).Include(q => q.Topic);
            return View(questionSets.ToList());
        }

        // GET: Exam/Details/5
        
        // GET: Exam/Edit/5
       
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

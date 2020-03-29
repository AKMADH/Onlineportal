using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using OnlineEXAM.Models;

namespace OnlineEXAM.Controllers
{
    public class UsersController : Controller
    {
        private onlineTestEntities db = new onlineTestEntities();

        // GET: Users
       

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,FullName,ProfilImage,Email,Password,Mobile")] User user, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var count = db.Users.Where(x => x.Email.Equals(user.Email)).Count();
                if (count >= 1)
                {
                    ViewBag.errormsg = "Email ID already Exist";
                    return View();
                }
                

                if (file != null)
                {
                    string filename = Path.GetFileName(file.FileName);
                    user.ProfilImage = filename;
                    string filepath = Path.Combine(Server.MapPath("~/profilepic/user/"), filename);
                    file.SaveAs(filepath);
                }
                db.Users.Add(user);
                int i=db.SaveChanges();
                //if (i > 0)
                //{
                //    SendVerificationLinkEmail(objReg.EmailId, objReg.ActivateionCode.ToString(), objReg.scheme, objReg.host, objReg.port);
                //   // return "Registration has been done,And Account activation link" + "has been sent your eamil id:" + objReg.EmailId;
                //}
                //else
                //{
                //    //return "Registration has been Faild";

                //}

                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,FullName,ProfilImage,Email,Password,Mobile")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            var response = db.Users.Where(x => x.Email.Equals(user.Email) && x.Password.Equals(user.Password)).FirstOrDefault();
            if (response != null)
            {
                Session["UserID"] = response.UserID;
                Session["UserName"] = response.FullName;
                Session["profilename"] = response.ProfilImage;
                return RedirectToAction("UserDashBoard", new RouteValueDictionary(
                       new { controller = "Users", action = "UserDashBoard", userId = Session["UserID"].ToString() }));
            }
            else
            {
                ViewBag.LoginError = "Invalid Username Or password";
                return View();
            }
           
        }
        
        public ActionResult UserDashBoard(string userId)
        {
            if (Session["UserID"] != null)
            {
                int userid = Convert.ToInt32(userId);
                var response = db.Users.Where(x => x.UserID== userid).FirstOrDefault();
                return View(response);
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
        public ActionResult Logout( )
        {
            if (Session["UserID"] != null)
            {
                Session.Clear();
            }
            return View("Login");
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

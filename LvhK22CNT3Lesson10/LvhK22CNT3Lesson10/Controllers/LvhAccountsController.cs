using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LvhK22CNT3Lesson10.Models;

namespace LvhK22CNT3Lesson10.Controllers
{
    public class LvhAccountsController : Controller
    {
        private LvhK22CNT3Lesson10Entities db = new LvhK22CNT3Lesson10Entities();

        // GET: LvhAccounts
        public ActionResult Index()
        {
            return View(db.LvhAccounts.ToList());
        }

        // GET: LvhAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LvhAccount lvhAccount = db.LvhAccounts.Find(id);
            if (lvhAccount == null)
            {
                return HttpNotFound();
            }
            return View(lvhAccount);
        }

        // GET: LvhAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LvhAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LvhId,LvhUserName,LvhPassword,LvhFullName,LvhEmail,LvhPhone,LvhActive")] LvhAccount lvhAccount)
        {
            if (ModelState.IsValid)
            {
                db.LvhAccounts.Add(lvhAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lvhAccount);
        }

        // GET: LvhAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LvhAccount lvhAccount = db.LvhAccounts.Find(id);
            if (lvhAccount == null)
            {
                return HttpNotFound();
            }
            return View(lvhAccount);
        }

        // POST: LvhAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LvhId,LvhUserName,LvhPassword,LvhFullName,LvhEmail,LvhPhone,LvhActive")] LvhAccount lvhAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lvhAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lvhAccount);
        }

        // GET: LvhAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LvhAccount lvhAccount = db.LvhAccounts.Find(id);
            if (lvhAccount == null)
            {
                return HttpNotFound();
            }
            return View(lvhAccount);
        }

        // POST: LvhAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LvhAccount lvhAccount = db.LvhAccounts.Find(id);
            db.LvhAccounts.Remove(lvhAccount);
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
        public ActionResult LvhLogin()
        {
            var lvhModel = new LvhAccount();
            return View(lvhModel);
        }
        [HttpPost]
        public ActionResult LvhLogin(LvhAccount lvhAccount)
        {
            var lvhCheck = db.LvhAccounts.Where(x=>x.LvhUserName.Equals(lvhAccount.LvhUserName)&& x.LvhPassword.Equals(lvhAccount.LvhPassword)).FirstOrDefault();
            if(lvhCheck !=null)
            {
                //Lưu Session
                Session["LvhAccount"] = lvhCheck;
                return Redirect("/");
            }
            return View(lvhAccount);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LvhK22CNT3Lesson11_2210900024.Models;

namespace LvhK22CNT3Lesson11_2210900024.Controllers
{
    public class LvhCategoriesController : Controller
    {
        private LvhK22CNT3Lesson11DbEntities db = new LvhK22CNT3Lesson11DbEntities();

        // GET: LvhCategories
        public ActionResult LvhIndex()
        {
            return View(db.LvhCategories.ToList());
        }

        // GET: LvhCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LvhCategory lvhCategory = db.LvhCategories.Find(id);
            if (lvhCategory == null)
            {
                return HttpNotFound();
            }
            return View(lvhCategory);
        }

        // GET: LvhCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LvhCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LvhID,LvhCateName,LvhStatus")] LvhCategory lvhCategory)
        {
            if (ModelState.IsValid)
            {
                db.LvhCategories.Add(lvhCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lvhCategory);
        }

        // GET: LvhCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LvhCategory lvhCategory = db.LvhCategories.Find(id);
            if (lvhCategory == null)
            {
                return HttpNotFound();
            }
            return View(lvhCategory);
        }

        // POST: LvhCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LvhID,LvhCateName,LvhStatus")] LvhCategory lvhCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lvhCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lvhCategory);
        }

        // GET: LvhCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LvhCategory lvhCategory = db.LvhCategories.Find(id);
            if (lvhCategory == null)
            {
                return HttpNotFound();
            }
            return View(lvhCategory);
        }

        // POST: LvhCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LvhCategory lvhCategory = db.LvhCategories.Find(id);
            db.LvhCategories.Remove(lvhCategory);
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

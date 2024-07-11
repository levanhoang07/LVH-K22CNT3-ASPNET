using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LeVanHoang2210900024_Demo_OnTap.Models;

namespace LeVanHoang2210900024_Demo_OnTap.Controllers
{
    public class LVH_TACGIAController : Controller
    {
        private LeVanHoang2210900024_Demo_OnTapEntities db = new LeVanHoang2210900024_Demo_OnTapEntities();

        // GET: LVH_TACGIA
        public ActionResult LvhIndex()
        {
            return View(db.LVH_TACGIA.ToList());
        }

        // GET: LVH_TACGIA/Details/5
        public ActionResult LvhDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LVH_TACGIA lVH_TACGIA = db.LVH_TACGIA.Find(id);
            if (lVH_TACGIA == null)
            {
                return HttpNotFound();
            }
            return View(lVH_TACGIA);
        }

        // GET: LVH_TACGIA/Create
        public ActionResult LvhCreate()
        {
            return View();
        }

        // POST: LVH_TACGIA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LvhCreate([Bind(Include = "Lvh_MaTG,Lvh_TenTacGia")] LVH_TACGIA lVH_TACGIA)
        {
            if (ModelState.IsValid)
            {
                db.LVH_TACGIA.Add(lVH_TACGIA);
                db.SaveChanges();
                return RedirectToAction("LvhIndex");
            }

            return View(lVH_TACGIA);
        }

        // GET: LVH_TACGIA/Edit/5
        public ActionResult LvhEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LVH_TACGIA lVH_TACGIA = db.LVH_TACGIA.Find(id);
            if (lVH_TACGIA == null)
            {
                return HttpNotFound();
            }
            return View(lVH_TACGIA);
        }

        // POST: LVH_TACGIA/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LvhEdit([Bind(Include = "Lvh_MaTG,Lvh_TenTacGia")] LVH_TACGIA lVH_TACGIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lVH_TACGIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("LvhIndex");
            }
            return View(lVH_TACGIA);
        }

        // GET: LVH_TACGIA/Delete/5
        public ActionResult LvhDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LVH_TACGIA lVH_TACGIA = db.LVH_TACGIA.Find(id);
            if (lVH_TACGIA == null)
            {
                return HttpNotFound();
            }
            return View(lVH_TACGIA);
        }

        // POST: LVH_TACGIA/Delete/5
        [HttpPost, ActionName("LvhDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LVH_TACGIA lVH_TACGIA = db.LVH_TACGIA.Find(id);
            db.LVH_TACGIA.Remove(lVH_TACGIA);
            db.SaveChanges();
            return RedirectToAction("LvhIndex");
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

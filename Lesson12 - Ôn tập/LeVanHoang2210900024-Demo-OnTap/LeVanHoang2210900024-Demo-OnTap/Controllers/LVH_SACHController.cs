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
    public class LVH_SACHController : Controller
    {
        private LeVanHoang2210900024_Demo_OnTapEntities db = new LeVanHoang2210900024_Demo_OnTapEntities();

        // GET: LVH_SACH
        public ActionResult LvhIndex()
        {
            var lVH_SACH = db.LVH_SACH.Include(l => l.LVH_TACGIA);
            return View(lVH_SACH.ToList());
        }

        // GET: LVH_SACH/Details/5
        public ActionResult LvhDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LVH_SACH lVH_SACH = db.LVH_SACH.Find(id);
            if (lVH_SACH == null)
            {
                return HttpNotFound();
            }
            return View(lVH_SACH);
        }

        // GET: LVH_SACH/Create
        public ActionResult LvhCreate()
        {
            ViewBag.Lvh_MaTG = new SelectList(db.LVH_TACGIA, "Lvh_MaTG", "Lvh_TenTacGia");
            return View();
        }

        // POST: LVH_SACH/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LvhCreate([Bind(Include = "Lvh_MaSach,Lvh_TenSach,Lvh_SoTrang,Lvh_NamXB,Lvh_MaTG,Lvh_TrangThai")] LVH_SACH lVH_SACH)
        {
            if (ModelState.IsValid)
            {
                db.LVH_SACH.Add(lVH_SACH);
                db.SaveChanges();
                return RedirectToAction("LvhIndex");
            }

            ViewBag.Lvh_MaTG = new SelectList(db.LVH_TACGIA, "Lvh_MaTG", "Lvh_TenTacGia", lVH_SACH.Lvh_MaTG);
            return View(lVH_SACH);
        }

        // GET: LVH_SACH/Edit/5
        public ActionResult LvhEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LVH_SACH lVH_SACH = db.LVH_SACH.Find(id);
            if (lVH_SACH == null)
            {
                return HttpNotFound();
            }
            ViewBag.Lvh_MaTG = new SelectList(db.LVH_TACGIA, "Lvh_MaTG", "Lvh_TenTacGia", lVH_SACH.Lvh_MaTG);
            return View(lVH_SACH);
        }

        // POST: LVH_SACH/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LvhEdit([Bind(Include = "Lvh_MaSach,Lvh_TenSach,Lvh_SoTrang,Lvh_NamXB,Lvh_MaTG,Lvh_TrangThai")] LVH_SACH lVH_SACH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lVH_SACH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("LvhIndex");
            }
            ViewBag.Lvh_MaTG = new SelectList(db.LVH_TACGIA, "Lvh_MaTG", "Lvh_TenTacGia", lVH_SACH.Lvh_MaTG);
            return View(lVH_SACH);
        }

        // GET: LVH_SACH/Delete/5
        public ActionResult LvhDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LVH_SACH lVH_SACH = db.LVH_SACH.Find(id);
            if (lVH_SACH == null)
            {
                return HttpNotFound();
            }
            return View(lVH_SACH);
        }

        // POST: LVH_SACH/Delete/5
        [HttpPost, ActionName("LvhDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LVH_SACH lVH_SACH = db.LVH_SACH.Find(id);
            db.LVH_SACH.Remove(lVH_SACH);
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

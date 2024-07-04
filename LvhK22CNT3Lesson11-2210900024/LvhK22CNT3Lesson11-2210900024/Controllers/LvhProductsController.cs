using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LvhK22CNT3Lesson11_2210900024.Models;

namespace LvhK22CNT3Lesson11_2210900024.Controllers
{
    public class LvhProductsController : Controller
    {
        private LvhK22CNT3Lesson11DbEntities db = new LvhK22CNT3Lesson11DbEntities();

        // GET: LvhProducts
        public async Task<ActionResult> LvhIndex()
        {
            var lvhProducts = db.LvhProducts.Include(l => l.LvhCategory);
            return View(await lvhProducts.ToListAsync());
        }

        // GET: LvhProducts/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LvhProduct lvhProduct = await db.LvhProducts.FindAsync(id);

            if (lvhProduct == null)
            {
                return HttpNotFound();
            }

            return View(lvhProduct);
        }

        // GET: LvhProducts/Create
        public ActionResult Create()
        {
            ViewBag.LvhCateId = new SelectList(db.LvhCategories, "LvhID", "LvhCateName");
            return View();
        }

        // POST: LvhProducts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "LvhId2210900024,LvhProName,LvhQty,LvhPrice,LvhCateId,LvhActive")] LvhProduct lvhProduct)
        {
            if (ModelState.IsValid)
            {
                db.LvhProducts.Add(lvhProduct);
                await db.SaveChangesAsync();
                return RedirectToAction("LvhIndex");
            }

            ViewBag.LvhCateId = new SelectList(db.LvhCategories, "LvhID", "LvhCateName", lvhProduct.LvhCateId);
            return View(lvhProduct);
        }

        // GET: LvhProducts/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LvhProduct lvhProduct = await db.LvhProducts.FindAsync(id);

            if (lvhProduct == null)
            {
                return HttpNotFound();
            }

            ViewBag.LvhCateId = new SelectList(db.LvhCategories, "LvhID", "LvhCateName", lvhProduct.LvhCateId);
            return View(lvhProduct);
        }

        // POST: LvhProducts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "LvhId2210900024,LvhProName,LvhQty,LvhPrice,LvhCateId,LvhActive")] LvhProduct lvhProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lvhProduct).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("LvhIndex");
            }

            ViewBag.LvhCateId = new SelectList(db.LvhCategories, "LvhID", "LvhCateName", lvhProduct.LvhCateId);
            return View(lvhProduct);
        }

        // GET: LvhProducts/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LvhProduct lvhProduct = await db.LvhProducts.FindAsync(id);

            if (lvhProduct == null)
            {
                return HttpNotFound();
            }

            return View(lvhProduct);
        }

        // POST: LvhProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            LvhProduct lvhProduct = await db.LvhProducts.FindAsync(id);
            db.LvhProducts.Remove(lvhProduct);
            await db.SaveChangesAsync();
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

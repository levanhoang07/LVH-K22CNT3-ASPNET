using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lession02.LVH.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            ViewBag.name = "Lê Văn Hoàng - 2210900024";
            return View();
        }

        public ActionResult Details(int? id)
        {
            ViewBag.id = id;
            return View();
        }
        public string GetName()
        {
            return "Lê Văn Hoàng - 2210900024 ";
        }
        public JsonResult Listname()
        {
            string[]names= { "Hoàng", "Hương", "Sang ", "Trọng" };
            return Json(names, JsonRequestBehavior.AllowGet);
        }
    }
}
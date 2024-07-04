using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LvhK22CNT3Lesson11_2210900024.Controllers
{
    public class LvhHomeController : Controller
    {
        public ActionResult LvhIndex()
        {
            return View();
        }

        public ActionResult LvhAbout()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult LvhContact()
        {
            ViewBag.msv = "2210900024";
            ViewBag.fullname = "Lê Văn Hoàng";

            return View();
        }
    }
}
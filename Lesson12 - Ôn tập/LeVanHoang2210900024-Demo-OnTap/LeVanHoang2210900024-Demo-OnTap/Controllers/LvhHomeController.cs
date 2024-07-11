using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeVanHoang2210900024_Demo_OnTap.Controllers
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
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
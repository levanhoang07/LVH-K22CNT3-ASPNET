using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LvhK22CNT3Lesson10.Models;

namespace LvhK22CNT3Lesson10.Controllers
{
    public class LvhHomeController : Controller
    {
        public ActionResult LvhIndex()
        {
            if (Session["LvhAccount"] != null) {
                var lvhAccount = Session["LvhAccount"] as LvhAccount;
                ViewBag.FullName = lvhAccount.LvhFullName;
                    }
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
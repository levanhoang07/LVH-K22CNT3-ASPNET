using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lession04.LVH.Controllers
{
    /// <summary>
    /// author:Lê Văn Hoàng
    /// class:K22CNT3
    /// 
    /// </summary>
    public class LVHStudentController : Controller
    {
        // GET: LVHStudent
        public ActionResult Index()
        {
            //truyền dữ liệu từ controllner ->> view
            ViewBag.fullName = "Lê Văn Hoàng";
            ViewData["birtday"] = "07/04/2004";
            TempData["phone"] = "0982121680";

            return View();
        }
        public ActionResult Details()
        {
            string lvhStr = "";
            lvhStr += "<h3>Họ và tên :Lê Văn Hoàng<h3/> ";
            lvhStr += "<p>Mã số:2210900024";
            lvhStr += "<p>Địa chỉ mail: levanhoang742004@gmail.com";
            ViewBag.Details = lvhStr;
            return View("chiTiet");
        }
        public ActionResult NgonNguRazor()
        {
            string[] names = { "Lê Văn Hoàng", "Trần Văn A", "Nguyễn Thị B" };
            ViewBag.names = names;
            return View("");
        }
        //HTML Helper
        //GET :LVHStudent/AddNewStudent
        public ActionResult AddNewStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewStudent(FormCollection form)  
        {
            //lấy dữ liệu trên form
            string fullName = form["fullName"];
            string Masv = form["Masv"];
            string Taikhoan = form["Taikhoan"];
            string Matkhau = form["Matkhau"];

            string lvhStr = "<h3>" + fullName + "</h3>";
             lvhStr += "<p>" + Masv;
             lvhStr += "<p>" + Taikhoan;
             lvhStr += "<p>" + Matkhau;

            ViewBag.info = lvhStr;
            return View("Ketqua");
        }
    }
}
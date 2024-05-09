using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lession03.LVH.Controllers
{
    public class LVHStudentController : Controller
    {
        // GET: LVHStudent
        public ActionResult Index()
        {
            //dữ liệu từ viewdata
            ViewData["msg"] = "View Data - LÊ VĂN HOÀNG";
            ViewData["time"] = DateTime.Now.ToString("hh:mm:ss dd/MM/yyyy tt");
            return View();
        }
        public ActionResult StudentList()
        {
            //sử dụng viewBag
            //lưu trữ giá trị đơn
            ViewBag.titleName = "Danh sách học viên - Lê Văn Hoàng";

            //giá trị la 1 tập hợp
            string[] names = { "Trần Tiến", "Thu Hương", "Văn Hoàng" };
            ViewBag.ListName = names;

            //giá trị là một đối tượng
            var obj = new 
            {
                ID=100,
                Name="Lê Văn Hoàng 123",
                Age= 20
            };
            ViewBag.Student = obj;
            return View();
        }
        public ActionResult Insert()
        {
            return View("AddStudent");
        }
    }
}
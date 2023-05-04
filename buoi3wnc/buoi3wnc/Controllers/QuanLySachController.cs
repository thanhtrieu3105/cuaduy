using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace buoi3wnc.Controllers
{
    public class QuanLySachController : Controller
    {
        // GET: QuanLySach
        public ActionResult ThemSanPham()
        {
            return View();
        }
        public ActionResult DanhSach()
        {
            return View();
        }
        public ActionResult SuaThongTinSanPham()
        {
            return View();
        }
    }
}
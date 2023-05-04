using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace buoi3wnc.Controllers
{
    public class QuanLyCuaHangController : Controller
    {
        // GET: QuanLyCuaHang
        public ActionResult ThemDienThoai()
        {
            return View();
        }
        public ActionResult DanhSach()
        {
            return View();
        }
        public ActionResult SuaThongTinDienThoai()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace buoi3wnc.Controllers
{
    public class CuaHangDienThoaiController : Controller
    {
        // GET: CuaHangDienThoai
        public ActionResult DanhSachSanPham()
        {
            return View();
        }
        public ActionResult DienThoai()
        {
            return View();
        }
    }
}
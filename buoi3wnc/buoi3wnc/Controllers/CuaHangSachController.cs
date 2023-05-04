using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace buoi3wnc.Controllers
{
    public class CuaHangSachController : Controller
    {
        // GET: CuaHangSach
        public ActionResult DanhsachSanPham()
        {
            return View();
        }
        public ActionResult ChiTietSach()
        {
            return View();
        }
        
    }
}
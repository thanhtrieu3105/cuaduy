using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace buoi3wnc.Controllers
{
    public class LienHeController : Controller
    {
        // GET: LienHe
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Post( string tieude,string noidung,string ten,string email,string sdt)
        {
            ViewBag.Tonghop = "Tieu de" + tieude + ", Noi dung " + noidung + ", Ten " + ten + ", Email " + email + ", sdt " + sdt;

            return View();
        }
    }
}
<<<<<<< Updated upstream
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_dienthoai.Models;

namespace Web_dienthoai.Controllers
{
    public class NguoiDungController : Controller
    {
         QLDienThoaiEntities db = new QLDienThoaiEntities();
        public string TaoMa(string bien)
        {
            int ma = 10;
            if (bien == "kh")
            {

                string makh = "KH" + ma.ToString();
                //kiem tra ton tai ma don hang
                while (db.KhachHangs.FirstOrDefault(s => s.MaKH == makh) != null)
                {
                    ma++;
                    makh = "KH" + ma.ToString();
                }
                return makh;
            }
          
            else return null;

        }

        // GET: NguoiDung
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }


        [HttpPost]
        public ActionResult DangKy(KhachHang kh)
        {
            if(ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(kh.TenKH))
                    ModelState.AddModelError(string.Empty, "Họ tên không được để trống");
                if (string.IsNullOrEmpty(kh.MK))
                    ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (string.IsNullOrEmpty(kh.Email))
                    ModelState.AddModelError(string.Empty, "Email không được để trống");
                if (string.IsNullOrEmpty(kh.DiaChi))
                    ModelState.AddModelError(string.Empty, "Dịa chỉ không được để trống");
                if (string.IsNullOrEmpty(kh.SDT))
                    ModelState.AddModelError(string.Empty, "Điện thoại không được để trống");

                //Kiểm tra đã có ai đk tài khoản này hay chưa
                var khachhang = db.KhachHangs.FirstOrDefault(id => id.SDT == kh.SDT);
                if(khachhang != null)
                    ModelState.AddModelError(string.Empty, "Tên đăng nhập đã được sử dụng, hãy chọn tên khác");

                if (ModelState.IsValid)
                {
                    try
                    {
                        kh.MaKH = TaoMa("kh");
                        db.KhachHangs.Add(kh);
                        db.SaveChanges();
                    }
                    catch
                    {
                        return Content("LỖI TẠO MỚI TÀI KHOẢN!");
                    }
                }
                else
                {
                    return View();
                }
            }
            return RedirectToAction("DangNhap");
        }


        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }


        [HttpPost]
        public ActionResult DangNhap(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(kh.SDT))
                    ModelState.AddModelError(string.Empty, "Vui lòng điền tên đăng nhập");
                if (string.IsNullOrEmpty(kh.MK))
                    ModelState.AddModelError(string.Empty, "Vui lòng điền mật khẩu");

                if (ModelState.IsValid)
                {
                    //Tìm KH hợp lệ có trong CSDL
                    var khachhang = db.KhachHangs.FirstOrDefault(id => id.SDT == kh.SDT && id.MK == kh.MK);
                    if (khachhang != null)
                    {
                        ViewBag.ThongBao = "Đăng nhập thành công!";
                        //Lưu > session
                        Session["KhachHang"] = khachhang;
                        return RedirectToAction("Index", "PhoneStore");
                    }
                    else
                        ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không hợp lệ!";
                }
            }
            return View();
        }
        public ActionResult UserPartial()

        {
            var kh = Session["KhachHang"] as KhachHang;
            if (kh != null) ViewBag.name = kh.TenKH.ToString();
            else ViewBag.name = "";


            return PartialView();
        }
        public ActionResult TrangThongTinTK()
        {
            var kh = Session["KhachHang"] as KhachHang;
            if(kh==null)
            {
                return RedirectToAction("DangNhap");
            }
            return View(kh);
        }
        public ActionResult DangXuat()
        {
            Session["KhachHang"] = null;

            return RedirectToAction("Index", "PhoneStore");
        }
        public ActionResult TrangTK()
        {
            var kh = Session["KhachHang"] as KhachHang;
            if (kh == null)
            {
                return RedirectToAction("DangNhap");
            }
            return View(kh);
        }

        public ActionResult DonHang(string id)
        {
            var list = new List<ChiTietDonHangView>();

            var donhang = db.DonHangs.FirstOrDefault(s => s.MaDH == id);

            var chitietdonhang = db.ChiTietDHs.Where(s => s.MaDH == donhang.MaDH).ToList();
            //List CTSPV
            var ListCTSP = new List<CTSPView>();

            foreach (var item in chitietdonhang)
            {
                var MaCTSP = item.MaCTSP;
                var ctspv = new CTSPView(MaCTSP);
                ListCTSP.Add(ctspv);
            }

            var ChiTietDonHangView = new ChiTietDonHangView(ListCTSP,donhang);
            return View(ChiTietDonHangView);
        }
    }
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_dienthoai.Models;

namespace Web_dienthoai.Controllers
{
    public class NguoiDungController : Controller
    {
         QLDienThoaiEntities db = new QLDienThoaiEntities();
        public string TaoMa(string bien)
        {
            int ma = 10;
            if (bien == "kh")
            {

                string makh = "KH" + ma.ToString();
                //kiem tra ton tai ma don hang
                while (db.KhachHangs.FirstOrDefault(s => s.MaKH == makh) != null)
                {
                    ma++;
                    makh = "KH" + ma.ToString();
                }
                return makh;
            }
          
            else return null;

        }

        // GET: NguoiDung
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }


        [HttpPost]
        public ActionResult DangKy(KhachHang kh)
        {
            if(ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(kh.TenKH))
                    ModelState.AddModelError(string.Empty, "Họ tên không được để trống");
                if (string.IsNullOrEmpty(kh.MK))
                    ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (string.IsNullOrEmpty(kh.Email))
                    ModelState.AddModelError(string.Empty, "Email không được để trống");
                if (string.IsNullOrEmpty(kh.DiaChi))
                    ModelState.AddModelError(string.Empty, "Dịa chỉ không được để trống");
                if (string.IsNullOrEmpty(kh.SDT))
                    ModelState.AddModelError(string.Empty, "Điện thoại không được để trống");

                //Kiểm tra đã có ai đk tài khoản này hay chưa
                var khachhang = db.KhachHangs.FirstOrDefault(id => id.SDT == kh.SDT);
                if(khachhang != null)
                    ModelState.AddModelError(string.Empty, "Tên đăng nhập đã được sử dụng, hãy chọn tên khác");

                if (ModelState.IsValid)
                {
                    try
                    {
                        kh.MaKH = TaoMa("kh");
                        db.KhachHangs.Add(kh);
                        db.SaveChanges();
                    }
                    catch
                    {
                        return Content("LỖI TẠO MỚI TÀI KHOẢN!");
                    }
                }
                else
                {
                    return View();
                }
            }
            return RedirectToAction("DangNhap");
        }


        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }


        [HttpPost]
        public ActionResult DangNhap(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(kh.SDT))
                    ModelState.AddModelError(string.Empty, "Vui lòng điền tên đăng nhập");
                if (string.IsNullOrEmpty(kh.MK))
                    ModelState.AddModelError(string.Empty, "Vui lòng điền mật khẩu");

                if (ModelState.IsValid)
                {
                    //Tìm KH hợp lệ có trong CSDL
                    var khachhang = db.KhachHangs.FirstOrDefault(id => id.SDT == kh.SDT && id.MK == kh.MK);
                    if (khachhang != null)
                    {
                        ViewBag.ThongBao = "Đăng nhập thành công!";
                        //Lưu > session
                        Session["KhachHang"] = khachhang;
                        return RedirectToAction("Index", "PhoneStore");
                    }
                    else
                        ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không hợp lệ!";
                }
            }
            return View();
        }
        public ActionResult UserPartial()

        {
            var kh = Session["KhachHang"] as KhachHang;
            if (kh != null) ViewBag.name = kh.TenKH.ToString();
            else ViewBag.name = "";


            return PartialView();
        }
        public ActionResult TrangThongTinTK()
        {
            var kh = Session["KhachHang"] as KhachHang;
            if(kh==null)
            {
                return RedirectToAction("DangNhap");
            }
            return View(kh);
        }
        public ActionResult DangXuat()
        {
            Session["KhachHang"] = null;

            return RedirectToAction("Index", "PhoneStore");
        }
        public ActionResult TrangTK()
        {
            var kh = Session["KhachHang"] as KhachHang;
            if (kh == null)
            {
                return RedirectToAction("DangNhap");
            }
            return View(kh);
        }

        public ActionResult DonHang(string id)
        {
            var list = new List<ChiTietDonHangView>();

            var donhang = db.DonHangs.FirstOrDefault(s => s.MaDH == id);

            var chitietdonhang = db.ChiTietDHs.Where(s => s.MaDH == donhang.MaDH).ToList();
            //List CTSPV
            var ListCTSP = new List<CTSPView>();

            foreach (var item in chitietdonhang)
            {
                var MaCTSP = item.MaCTSP;
                var ctspv = new CTSPView(MaCTSP);
                ListCTSP.Add(ctspv);
            }

            var ChiTietDonHangView = new ChiTietDonHangView(ListCTSP,donhang);
            return View(ChiTietDonHangView);
        }
    }
>>>>>>> Stashed changes
}
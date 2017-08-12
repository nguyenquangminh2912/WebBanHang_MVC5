using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Models;

namespace WebsiteBanHang.Controllers
{
    public class KhachHangController : Controller
    {
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        // GET: KhachHang
        public ActionResult Index()
        {
            //var lstKhachHang = from kh in db.KhachHangs
            //                   select kh;

            var lstKhachHang = db.KhachHangs.ToList();
            return View(lstKhachHang);
        }
        public ActionResult GroupThanhVien()
        {
            List<ThanhVien> lstThanhVien = db.ThanhViens.ToList();
            return View(lstThanhVien);

        }

        public ActionResult GroupSanPham()
        {
            List<SanPham> lstSanPham = (from sp in db.SanPhams
                                        where sp.MaLoaiSP != null
                                        select sp).ToList();
            return View(lstSanPham);                               
        }

    }
}
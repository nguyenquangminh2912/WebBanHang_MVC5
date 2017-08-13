using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Models;

namespace WebsiteBanHang.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        public ActionResult Index()
        {
            //Lấy List DienThoai
            var lstDienThoai = db.SanPhams.Where(n => n.MaLoaiSP == 1 && n.DaXoa == false);
            ViewBag.listDienThoai = lstDienThoai;

            //Lấy Máy Tính Bảng.
            var lstMayTinhBang = db.SanPhams.Where(n => n.MaLoaiSP == 2 && n.DaXoa == false);
            ViewBag.listMayTinhBang = lstMayTinhBang;

            //Lấy LapTop.
            var lstLapTop = db.SanPhams.Where(n => n.MaLoaiSP == 3 && n.DaXoa == false);
            ViewBag.listLapTop = lstLapTop;

            return View();
        }
    }
}
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Models;

namespace WebsiteBanHang.Controllers
{
    public class QuanLySanPhamController : Controller
    {
        // GET: QuanLySanPham
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        public ActionResult Index()
        {
            return View(db.SanPhams.Where(n=>n.DaXoa==false));
        }

        [HttpGet]
        public ActionResult TaoMoi()
        {
            //Xư lý dropdownlist
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps.OrderBy(n =>n.TenNCC), "MaNCC", "TenNCC");
            ViewBag.MaLoaiSP = new SelectList(db.LoaiSanPhams.OrderBy(n => n.TenLoai), "MaLoaiSP", "TenLoai");
            ViewBag.MaNSX = new SelectList(db.NhaSanXuats.OrderBy(n => n.TenNSX), "MaNSX", "TenNSX");
            return View();
        }

        [HttpPost]
        public ActionResult TaoMoi(HttpPostedFileBase HinhAnh)
        {
            return View();
        }
    }
}
using System.IO;
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
            return View(db.SanPhams.Where(n=>n.DaXoa==false).OrderByDescending(n=>n.MaSP));
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

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult TaoMoi(SanPham sp, HttpPostedFileBase HinhAnh)
        {
            //Xử lý Dropdownlist
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps.OrderBy(n => n.TenNCC), "MaNCC", "TenNCC");
            ViewBag.MaLoaiSP = new SelectList(db.LoaiSanPhams.OrderBy(n => n.TenLoai), "MaLoaiSP", "TenLoai");
            ViewBag.MaNSX = new SelectList(db.NhaSanXuats.OrderBy(n => n.TenNSX), "MaNSX", "TenNSX");

            //Xử ly hình ảnh
            if (HinhAnh.ContentLength > 0)
            {
                var FileName_    = Path.GetFileName(HinhAnh.FileName);
                var Path_ = Path.Combine(Server.MapPath("~/Content/HinhAnhSP"), FileName_);
                if (System.IO.File.Exists(Path_))
                {
                    ViewBag.Upload = "Hình ảnh đã tồn tại";
                }
                else
                {
                    HinhAnh.SaveAs(Path_);
                    //Session["ssTenHinh"] = HinhAnh.FileName;
                    //ViewBag.ssTenHinh= "";
                }
                sp.HinhAnh = FileName_;
            }
            db.SanPhams.Add(sp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
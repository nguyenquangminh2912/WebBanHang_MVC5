using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Models;

namespace WebsiteBanHang.Controllers
{
    public class DemoAjaxController : Controller
    {
        // GET: DemoAjax

        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        public ActionResult DemoAjax()
        {
            return View();
        
            
        }

        //Xu ly Ajax ActionLink
        public ActionResult LoadAjaxOption()
        {
            return Content("Hello Ajax");
        }


        //Xu ly Ajax BeginForm

        public ActionResult LoadAjaxBeginForm(FormCollection f)
        {
            var KQ = f["txtTest"].ToString();
            return Content(KQ);

        }

        //Su dung Ajax.actionlink load du lieu tu Database
        public ActionResult LoadSanPhamAjax()
        {
            var LstSanPham = db.SanPhams.Where(n => n.MaLoaiSP == 2 && n.Moi == 1);
            return PartialView("LoadSanPhamAjax",LstSanPham);
        }
    }
}
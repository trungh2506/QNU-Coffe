using coffeeMVV04.Model;
using coffeeMVV04.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace coffeeMVC05.Areas.Admin.Controllers
{

    public class HomeAdminController : Controller
    {
        Model1 db = new Model1();
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            CountTotalOrder();
            CountTotalMoney();
            CountTotalMoneyAllDay();
            return View(db.HoaDons.ToList());
        }
        //Thống kê số tiền tất cả
        public void CountTotalMoneyAllDay()
        {
            if (ModelState.IsValid)
            {
                var TotalMoney = db.HoaDons.Sum(d => d.TongCong);
                ViewBag.TotalMoneyAllDay = TotalMoney.ToString();
            }
        }

        //Thống kê số tiền trong ngày
        public void CountTotalMoney()
        {
            var today = DateTime.Today;
            if (ModelState.IsValid)
            {
                var TotalMoney = db.HoaDons.Where(d => d.Date == today).Sum(d => d.TongCong);
                ViewBag.TotalMoney = TotalMoney.ToString();
            }
        }

        //Thống kê số ly bán được trong ngày
        public void CountTotalOrder()
        {
            var today = DateTime.Today;
            var record = (from a in db.ChiTietHoaDons
                          join b in db.HoaDons
                          on a.IDHoaDon equals b.ID
                          where b.Date == today
                          select a);

            var TotalOrder = record.Select(c => c.SoLuong).Sum();

            ViewBag.TotalOrder = TotalOrder.ToString();

        }
        //Xem chi tiết đơn hàng
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(db.ChiTietHoaDons.Where(a => a.IDHoaDon == id).ToList());
        }
    }
}
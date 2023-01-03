using System.Net;
using System.Data.Entity;
using coffeeMVV04.Model;
using coffeeMVV04.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using coffeeMVV04.Areas.Sales.model;

namespace coffeeMVV04.Areas.Sales.Controllers
{
    public class OrderController : Controller
    {
        Model1 db = new Model1();
        // GET: Sales/Order
        public ActionResult Index()
        {
            CountTotalOrder();
            CountTotalMoney();
            CountTotalMoneyAllDay();
            return View(db.HoaDons.ToList());
        }
        

        //Checkout
     /*   [HttpGet]
        public ActionResult CheckOut()
        {
            return View();
        }*/
        [HttpPost]
        public ActionResult CheckOut(FormCollection form)
        {
            //kiểm tra Session["UserID"]
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
            else
            {
                //lấy số bàn từ form
                string strTB = form["NumTB"].ToString();
                //Thêm vào bảng Hóa Đơn
                Carts cart = new Carts();
                //lưu session vào cart
                cart = Session[strTB] as Carts;

                //lưu order vào session chi tiết hóa đơn để chuyển đi trang checkout
                Session["cthd"] = cart;
                //lưu số bàn vào session
                Session["numTB"] = strTB;

                //
                HoaDon hoaDon = new HoaDon();
                hoaDon.Date = DateTime.Now;
                hoaDon.TrangThai = true;
                hoaDon.TongCong = Double.Parse(cart.Total().ToString());
                hoaDon.IDUser = Int32.Parse(Session["UserID"].ToString());
                db.HoaDons.Add(hoaDon);

                //luư thông tin hóa đơn vào session 
                Session["hoaDon"] = hoaDon;

                //Thêm vào bảng CTHD
                foreach (var item in cart.product)
                {
                    ChiTietHoaDon cthd = new ChiTietHoaDon()
                    {
                        IDHoaDon = hoaDon.ID,
                        IDSanPham = item.ID,
                        SoLuong = item.SoLuong
                    };
                    db.ChiTietHoaDons.Add(cthd);
                }
                db.SaveChanges();
                 return View("CheckOut");
            }
        }

        //nút Checkout Clear các order và hóa đơn đã thanh toán
        public ActionResult ClearSession(string numTB)
        {
            Session.Remove(numTB);
            Session.Remove("hoaDon");
            Session.Remove("cthd");
            return RedirectToAction("Index", "HomeSale");
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
                return RedirectToAction("Index");
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(db.ChiTietHoaDons.Where(a => a.IDHoaDon == id).ToList());
        }

        //Xóa chi tiết hóa đơn và hóa đơn
        public ActionResult Delete(int? id)
        {
            //Nếu không thấy id cần xóa
            if (id == null)
            {
                //trả về badrequest
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHoaDon cthd = db.ChiTietHoaDons.Find(id);
            
            if (cthd == null)
            {
                return HttpNotFound();
            }
            db.ChiTietHoaDons.Remove(cthd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //In hóa đơn PDF
        public ActionResult CreatePDF()
        {
            return new Rotativa.ViewAsPdf("CheckOut")
            {
                PageSize = Rotativa.Options.Size.A5,
                FileName = "Hóa-đơn.pdf",
                CustomSwitches = "--print-media-type"
            };
        }
       

    }
}
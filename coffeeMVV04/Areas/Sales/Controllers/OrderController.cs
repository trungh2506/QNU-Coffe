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
            return View(db.HoaDons.ToList());
        }


        //Checkout
        [HttpGet]
        public ActionResult CheckOut()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CheckOut(FormCollection form)
        {
            //kiểm tra Session["UserID"]
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
            else {
                //lấy số bàn
                string strTB = form["NumTB"].ToString();
                //Thêm vào bảng Hóa Đơn
                Carts cart = new Carts();
                cart = Session[strTB] as Carts;

                //lưu order vào session để chuyển đi trang checkout
                Session["cthd"] = cart;

                //
                HoaDon hoaDon = new HoaDon();
                hoaDon.Date = DateTime.Now;
                hoaDon.TrangThai = true;
                hoaDon.TongCong = Double.Parse(cart.Total().ToString());
                hoaDon.IDUser = Int32.Parse(Session["UserID"].ToString());
                db.HoaDons.Add(hoaDon);

                //luư thông tin hóa đơn vào sesion 
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
                return View();
            }
        }

        //nút Checkout Clear các order và hóa đơn đã thanh toán
        public ActionResult ClearSession(string numTB)
        {
            Session.Remove(numTB);
            Session.Remove("hoaDon");
            Session.Remove("cthd");
            return RedirectToAction("Index","HomeSale");
        }


    }
}
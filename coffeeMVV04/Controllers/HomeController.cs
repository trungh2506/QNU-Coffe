using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using coffeeMVV04.Models;

namespace coffeeMVV04.Controllers
{
    public class HomeController : Controller
    {
        QNU_CoffeeEntities QNU_CoffeeEntities = new QNU_CoffeeEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string sdt, string password)
        {
            if (ModelState.IsValid)
            {
                var data = QNU_CoffeeEntities.NguoiDungs.Where(s => s.SDT.Equals(sdt) && s.Password == password).ToList();
                if (data.Count() > 0)
                {
                    Session["HoTen"] = data.FirstOrDefault().HoTen;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["UserID"] = data.FirstOrDefault().ID;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Đăng nhập thất bại";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
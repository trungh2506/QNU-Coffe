﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using coffeeMVV04.Model.EF;
using System.IO;
using System.Data.Entity;

namespace coffeeMVV04.Controllers
{
    public class HomeController : Controller
    {
        private Model1 Model1 = new Model1();
        /*QNU_CoffeeEntities QNU_CoffeeEntities = new QNU_CoffeeEntities();*/
        public ActionResult Index()
        {
            return View(Model1.SanPhams.ToList());
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
            ViewBag.error = "";
            if (ModelState.IsValid)
            {
                var data = Model1.NguoiDungs.Where(s => s.SDT.Equals(sdt) && s.Password == password).ToList();
                if (data.Count() > 0)
                {
                    Session["HoTen"] = data.FirstOrDefault().HoTen;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["UserID"] = data.FirstOrDefault().ID;
                    Session["Admin"] = data.FirstOrDefault().Admin;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Sai số điện thoại hoặc mật khẩu!";
                    return View();
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
using System.Net;
using System.Data.Entity;
using coffeeMVV04.Model;
using coffeeMVV04.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Checkout(FormCollection form)
        {
            try
            {

            }
            return View(form);
        }
       

    }
}
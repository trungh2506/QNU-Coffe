using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coffeeMVV04.Areas.Sales.Controllers
{
    public class HomeController : Controller
    {
        // GET: Sales/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
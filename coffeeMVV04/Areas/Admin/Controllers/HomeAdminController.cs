using coffeeMVV04.Model;
using coffeeMVV04.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coffeeMVC05.Areas.Admin.Controllers
{

    public class HomeAdminController : Controller
    {
        Model1 db = new Model1();
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            return View(db.HoaDons.ToList());
        }
    }
}
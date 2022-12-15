using coffeeMVV04.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coffeeMVC05.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private Model1 db = new Model1();
        // GET: Admin/Product
        public ActionResult Index()
        {
            CountProduct();
            return View(db.SanPhams.ToList());

        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Category()
        {
            CountCategory();
            return View(db.DanhMucs.ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "TenDanhMuc")] DanhMuc danhMuc)
        {
            if (ModelState.IsValid)
            {
                db.DanhMucs.Add(danhMuc);
                db.SaveChanges();
                return RedirectToAction("Category");
            }

            return View(danhMuc);
        }
        public void CountCategory()
        {
            if (ModelState.IsValid)
            {
                int count = db.DanhMucs.Count();
                ViewBag.Count = count;
            }
        }
        public void CountProduct()
        {
            if (ModelState.IsValid)
            {
                int count = db.SanPhams.Count();
                ViewBag.Count = count;
            }
        }
    }
}
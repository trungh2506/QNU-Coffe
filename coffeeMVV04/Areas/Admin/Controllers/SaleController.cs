using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.Mvc;
using coffeeMVV04.Model;
using coffeeMVV04.Model.EF;
using System.Net;
using System.Data.Entity;

namespace coffeeMVC05.Areas.Admin.Controllers
{
    public class SaleController : Controller
    {
        private Model1 db = new Model1();
        // GET: Admin/Sale
        public ActionResult Index()
        {
            var NguoiDungs = db.NguoiDung;
            var items = db.NguoiDung;
            return View(NguoiDungs.ToList());
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoiDung = db.NguoiDung.Find(id);
            if (nguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(nguoiDung);
        }

        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoiDung = db.NguoiDung.Find(id);
            if (nguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(nguoiDung);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Add([Bind(Include ="ID,HoTen,SDT,Email,Password,DiaChi,Admin")]NguoiDung model)
        { 
            if (ModelState.IsValid)
            {
               db.NguoiDung.Add(model);
               db.SaveChanges();
               return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NguoiDung nguoiDung = db.NguoiDung.Find(id);
            db.NguoiDung.Remove(nguoiDung);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,HoTen,SDT,Email,Password,DiaChi,Admin")] NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nguoiDung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nguoiDung);
        }

    }
}